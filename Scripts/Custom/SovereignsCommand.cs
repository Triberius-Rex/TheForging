using Server.Accounting;
using Server.Mobiles;
using System;

namespace Server.Commands.Generic.Custom
{
    public class SovereignsCommand : BaseCommand
    {
        public SovereignsCommand()
        {
            AccessLevel = AccessLevel.GameMaster;
            Supports = CommandSupport.AllMobiles;
            Commands = new[] { "AddSovereigns" };
            ObjectTypes = ObjectTypes.Mobiles;
            Usage = "AddSovereigns <Value>";
            Description = "Deposits or withdraws Sovereigns from the Players Account";
        }

        public override void Execute(CommandEventArgs e, object obj)
        {
            if (e.Length == 1)
            {
                if (obj is PlayerMobile pm && pm.Account is Account acc)
                {
                    int amount = e.GetInt32(0);
                    int startSovereigns = acc.Sovereigns;
                    if (amount > 0)
                    {
                        acc.DepositSovereigns(amount);
                        LogTransaction(e, obj, acc, true, startSovereigns, amount, acc.Sovereigns);
                    }
                    else if (amount < 0)
                    {
                        amount *= -1;
                        int temp = acc.Sovereigns - amount;
                        if (temp < 0)
                            amount += temp;

                        acc.WithdrawSovereigns(amount);
                        LogTransaction(e, obj, acc, false, startSovereigns, amount, acc.Sovereigns);
                    }
                    else if (amount == 0)
                    {
                        AddResponse($"Didn't do anything ...");
                    }
                }
                else
                {
                    LogFailure("No Players found to award Sovereigns to!");
                }
            }
            else
            {
                LogFailure("Format: AddSovereigns <value>");
                CommandLogging.WriteLine(e.Mobile, "{0} {1} used command '{2} {3}' on: {4}", e.Mobile == null ? "System" : e.Mobile.AccessLevel.ToString(), CommandLogging.Format(e.Mobile), e.Command, e.ArgString, obj);
            }
        }

        private void LogTransaction(CommandEventArgs e, object targ, Account acc, bool deposit, int initialAmount, int amount, int currentCount)
        {
            Mobile from = e.Mobile;
            CommandLogging.WriteLine(from, $"{from.AccessLevel} {CommandLogging.Format(from)} used command '{e.Command} {e.ArgString}' on: {targ} | had befor: {initialAmount}, took: {amount}, has after: {currentCount}");

            AddResponse($"{(deposit ? "Deposited" : "Withdrew")} {amount} Sovereigns {(deposit ? "to" : "from")} {targ}, current amount = {acc.Sovereigns}");
        }

        public static void Initialize()
        {
            TargetCommands.Register(new SovereignsCommand());
        }
    }
}
