/****************************************
 * Author: ImaNewb                       *
 * Script Name: ImaNewbsChatSystem.cs    *
 * For use with ServUO                   *
 * Date: July 09, 2024                   *
 ****************************************/

using System;
using System.Collections.Generic;
using Server.Gumps;
using Server.Network;
using Server.Commands;


namespace Server.ChatSystem
{
    public class ChatChannel
    {
        public string Name { get; }
        public bool IsPrivate { get; }
        public bool IsDynamic { get; }
        public int SpeechColor { get; }
        private Mobile _owner;
        private List<Mobile> _members;
        private List<string> _messages;
        private List<Mobile> _invited;

        public ChatChannel(string name, Mobile owner, int speechColor, bool isPrivate = false, bool isDynamic = false)
        {
            Name = name;
            _owner = owner;
            IsPrivate = isPrivate;
            IsDynamic = isDynamic;
            SpeechColor = speechColor;
            _members = new List<Mobile>();
            _messages = new List<string>();
            _invited = new List<Mobile>();

            if (owner != null)
            {
                Join(owner);
            }
        }

        public void Join(Mobile m)
        {
            if (IsPrivate && !_invited.Contains(m) && m != _owner)
            {
                m.SendMessage(0x35, $"You are not invited to the {Name} channel.");
                return;
            }

            if (!_members.Contains(m))
            {
                _members.Add(m);
                m.SendMessage(0x35, $"You have joined the {Name} channel.");
            }
        }

        public void Leave(Mobile m)
        {
            if (_members.Contains(m))
            {
                _members.Remove(m);
                m.SendMessage(0x35, $"You have left the {Name} channel.");

                // If the channel is dynamic and the last member leaves, delete the channel
                if (IsDynamic && _members.Count == 0)
                {
                    ImaNewbsChatSystem.DeleteChannel(this);
                }
            }
        }

        public void Invite(Mobile m)
        {
            if (!_invited.Contains(m))
            {
                _invited.Add(m);
                m.SendMessage(0x35, $"You have been invited to the {Name} channel. Type [AcceptInvite {Name} to join.");
            }
        }

        public void SendMessage(Mobile sender, string message)
        {
            string formattedMessage = $"{sender.Name}: {message}";
            _messages.Add(formattedMessage);

            if (_messages.Count > 50)
                _messages.RemoveAt(0);

            foreach (var member in _members)
            {
                member.SendMessage(SpeechColor, formattedMessage);
            }

            // Send message to all staff members with HearAll flag set
            foreach (var mobile in World.Mobiles.Values)
            {
                if (mobile.AccessLevel >= AccessLevel.GameMaster && HearAllSystem.IsHearAllEnabled(mobile) && !_members.Contains(mobile))
                {
                    mobile.SendMessage(SpeechColor, $"[{Name}] {formattedMessage}");
                }
            }
        }

        public string GetMessagesHtml()
        {
            return string.Join("<br>", _messages);
        }

        public List<Mobile> Members => _members;
        public List<Mobile> Invited => _invited;
    }

    public static class ImaNewbsChatSystem
    {
        private static bool _enabled = true;
        public static Dictionary<string, ChatChannel> _channels = new Dictionary<string, ChatChannel>();
        private static Dictionary<Mobile, ChatChannel> _currentChannels = new Dictionary<Mobile, ChatChannel>();

        static ImaNewbsChatSystem()
        {
            Initialize();
        }

        public static void Initialize()
        {
            if (_enabled)
            {
                CommandSystem.Register("Chat", AccessLevel.Player, OpenChatWindow_OnCommand);
                CommandSystem.Register("c", AccessLevel.Player, SendChatMessage_OnCommand);
                CommandSystem.Register("CreateChannel", AccessLevel.Player, CreateChannel_OnCommand);
                CommandSystem.Register("Invite", AccessLevel.Player, Invite_OnCommand);
                CommandSystem.Register("AcceptInvite", AccessLevel.Player, AcceptInvite_OnCommand);

                // Register the HearAll command for staff
                CommandSystem.Register("HearAll", AccessLevel.GameMaster, HearAll_OnCommand);

                InitializeChannels();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Chat System: Loading...");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("done ");
                Console.WriteLine("( ***Chat System Activated*** )");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Chat System: Loading...");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("done ");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("( ***Turned Off*** )");
                Console.ResetColor();
            }
        }

        private static void InitializeChannels()
        {
            _channels["Global Chat"] = new ChatChannel("Global Chat", null, 0x22);           // Red
            _channels["General"] = new ChatChannel("General", null, 0x35);                   // Yellow
            _channels["Trade"] = new ChatChannel("Trade", null, 0x3E);                       // Green
            _channels["LFGuild"] = new ChatChannel("LFGuild", null, 0x4F); // Light Blue
            _channels["LFGroup"] = new ChatChannel("LFGroup", null, 0x2B); // Orange
            _channels["Help"] = new ChatChannel("Help", null, 0x5E);                         // Cyan
        }

        public static void DeleteChannel(ChatChannel channel)
        {
            if (_channels.ContainsKey(channel.Name))
            {
                _channels.Remove(channel.Name);
                Console.WriteLine($"Dynamic channel '{channel.Name}' has been deleted.");
            }
        }

        private static void OpenChatWindow_OnCommand(CommandEventArgs e)
        {
            // Close any existing chat gumps
            e.Mobile.CloseGump(typeof(ChatGump));
            e.Mobile.SendGump(new ChatGump(e.Mobile));
        }

        private static void SendChatMessage_OnCommand(CommandEventArgs e)
        {
            if (_currentChannels.TryGetValue(e.Mobile, out var channel))
            {
                if (e.Length >= 1)
                {
                    string message = e.ArgString.Trim();
                    channel.SendMessage(e.Mobile, message);
                }
                else
                {
                    e.Mobile.SendMessage(0x35, "Usage: c <message>");
                }
            }
            else
            {
                e.Mobile.SendMessage(0x35, "You are not in any channel. Use [chat to open the chat window.");
            }

            // Refresh the chat gump
            e.Mobile.CloseGump(typeof(ChatGump));
            e.Mobile.SendGump(new ChatGump(e.Mobile));
        }

        private static void CreateChannel_OnCommand(CommandEventArgs e)
        {
            if (e.Length >= 1)
            {
                string channelName = e.GetString(0);
                if (channelName.Length > 13)
                {
                    e.Mobile.SendMessage(0x35, "Channel name cannot exceed 13 characters.");
                    return;
                }

                if (!_channels.ContainsKey(channelName))
                {
                    var channel = new ChatChannel(channelName, e.Mobile, 0x35, true, true); // All dynamic channels are private by default
                    _channels[channelName] = channel;
                    JoinChannel(e.Mobile, channelName);
                    e.Mobile.SendMessage(0x35, $"Private channel '{channelName}' has been created.");

                    // Refresh the gump
                    e.Mobile.CloseGump(typeof(ChatGump));
                    e.Mobile.SendGump(new ChatGump(e.Mobile));
                }
                else
                {
                    e.Mobile.SendMessage(0x35, $"Channel '{channelName}' already exists.");
                }
            }
            else
            {
                e.Mobile.SendMessage(0x35, "Usage: CreateChannel <channelName>");
            }
        }

        private static void Invite_OnCommand(CommandEventArgs e)
        {
            if (e.Length >= 1)
            {
                string targetName = e.GetString(0);
                Mobile target = GetMobileByName(targetName);
                if (target != null)
                {
                    if (_currentChannels.TryGetValue(e.Mobile, out var channel))
                    {
                        channel.Invite(target);
                        e.Mobile.SendMessage(0x35, $"You have invited {targetName} to the {channel.Name} channel.");
                    }
                    else
                    {
                        e.Mobile.SendMessage(0x35, "You are not in any channel to invite players.");
                    }
                }
                else
                {
                    e.Mobile.SendMessage(0x35, $"Player '{targetName}' not found.");
                }
            }
            else
            {
                e.Mobile.SendMessage(0x35, "Usage: Invite <playerName>");
            }
        }

        private static void AcceptInvite_OnCommand(CommandEventArgs e)
        {
            if (e.Length >= 1)
            {
                string channelName = e.GetString(0);
                if (_channels.TryGetValue(channelName, out var channel))
                {
                    if (channel.Invited.Contains(e.Mobile))
                    {
                        JoinChannel(e.Mobile, channelName);
                        e.Mobile.SendMessage(0x35, $"You have joined the '{channelName}' channel.");

                        // Refresh the gump
                        e.Mobile.CloseGump(typeof(ChatGump));
                        e.Mobile.SendGump(new ChatGump(e.Mobile));
                    }
                    else
                    {
                        e.Mobile.SendMessage(0x35, $"You do not have an invite to the '{channelName}' channel.");
                    }
                }
                else
                {
                    e.Mobile.SendMessage(0x35, $"Channel '{channelName}' does not exist.");
                }
            }
            else
            {
                e.Mobile.SendMessage(0x35, "Usage: AcceptInvite <channelName>");
            }
        }

        private static Mobile GetMobileByName(string name)
        {
            foreach (Mobile mobile in World.Mobiles.Values)
            {
                if (mobile.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return mobile;
                }
            }
            return null;
        }

        public static void JoinChannel(Mobile mobile, string channelName)
        {
            if (_channels.TryGetValue(channelName, out var channel))
            {
                // Check if the channel is private and if the mobile is invited
                if (channel.IsPrivate && !channel.Members.Contains(mobile) && !channel.Invited.Contains(mobile))
                {
                    mobile.SendMessage(0x35, "You are not invited to this channel.");
                    return;
                }

                // Leave current channel if already in one
                if (_currentChannels.TryGetValue(mobile, out var currentChannel))
                {
                    currentChannel.Leave(mobile);
                    _currentChannels.Remove(mobile);
                }

                // Join new channel
                channel.Join(mobile);
                _currentChannels[mobile] = channel;

                // Refresh the chat gump
                mobile.CloseGump(typeof(ChatGump));
                mobile.SendGump(new ChatGump(mobile));
            }
        }

        public static void LeaveCurrentChannel(Mobile mobile)
        {
            if (_currentChannels.TryGetValue(mobile, out var channel))
            {
                channel.Leave(mobile);
                _currentChannels.Remove(mobile);

                // Refresh the chat gump
                mobile.CloseGump(typeof(ChatGump));
                mobile.SendGump(new ChatGump(mobile));
            }
            else
            {
                mobile.SendMessage(0x35, "You are not in any channel.");
            }
        }

        public static string GetCurrentChannelName(Mobile mobile)
        {
            if (_currentChannels.TryGetValue(mobile, out var channel))
            {
                return $"{channel.Name} ({channel.Members.Count})";
            }
            return "None";
        }

        private static void HearAll_OnCommand(CommandEventArgs e)
        {
            HearAllSystem.ToggleHearAll(e.Mobile);
        }
    }

    public class ChatGump : Gump
    {
        private Mobile _mobile;

        public ChatGump(Mobile mobile) : base(50, 50)
        {
            _mobile = mobile;

            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;

            AddPage(0);

            // Background must be added first
            AddBackground(0, 0, 200, 270, 9270);
            AddAlphaRegion(10, 10, 180, 250); // Transparent background

            AddLabel(20, 20, 1350, "Available Channels");

            string currentChannelName = ImaNewbsChatSystem.GetCurrentChannelName(mobile);
            AddLabel(20, 40, 1350, $"Connected: {currentChannelName}");

            int y = 70;
            foreach (var channel in ImaNewbsChatSystem._channels.Values)
            {
                if (!channel.IsPrivate)
                {
                    int memberCount = channel.Members.Count;
                    AddButton(20, y, 4005, 4007, channel.Name.GetHashCode(), GumpButtonType.Reply, 0);
                    AddLabel(55, y, channel.SpeechColor, $"{channel.Name} ({memberCount})"); // Match label color with speech color and add member count
                    y += 25;
                }
            }

            AddButton(20, y, 4005, 4007, 1, GumpButtonType.Reply, 0);
            AddLabel(55, y, 1153, "Leave Chat");
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            int buttonId = info.ButtonID;
            if (buttonId != 0)
            {
                if (buttonId == 1)
                {
                    // Leave current channel
                    ImaNewbsChatSystem.LeaveCurrentChannel(_mobile);

                    // Update Gump to show disconnected state
                    _mobile.CloseGump(typeof(ChatGump));
                    _mobile.SendGump(new ChatGump(_mobile));
                }
                else
                {
                    // Join a channel
                    string channelName = null;
                    foreach (var channel in ImaNewbsChatSystem._channels.Values)
                    {
                        if (channel.Name.GetHashCode() == buttonId)
                        {
                            channelName = channel.Name;
                            break;
                        }
                    }

                    if (channelName != null)
                    {
                        ImaNewbsChatSystem.JoinChannel(_mobile, channelName);

                        // Refresh the gump
                        _mobile.CloseGump(typeof(ChatGump));
                        _mobile.SendGump(new ChatGump(_mobile));
                    }
                }
            }
        }
    }

    public static class HearAllSystem
    {
        private static readonly Dictionary<Mobile, bool> _hearAllFlags = new Dictionary<Mobile, bool>();

        public static bool IsHearAllEnabled(Mobile mobile)
        {
            return _hearAllFlags.TryGetValue(mobile, out bool isEnabled) && isEnabled;
        }

        public static void ToggleHearAll(Mobile mobile)
        {
            if (_hearAllFlags.TryGetValue(mobile, out bool isEnabled))
            {
                _hearAllFlags[mobile] = !isEnabled;
            }
            else
            {
                _hearAllFlags[mobile] = true;
            }

            mobile.SendMessage(0x35, $"Hear all channels is now {(IsHearAllEnabled(mobile) ? "enabled" : "disabled")}.");
        }
    }
}
