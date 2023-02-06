using System;
using Server;
using Server.Items;
using Server.Network;
using Server.Mobiles;
using Server.ContextMenus;
using System.Collections.Generic;
using System.Data;


// Robert the walking fortune cookie
// created by Nick Lancaster
// August 31, 2019
// hello@nickjlancaster.com

        
namespace Server.Mobiles
{
    

public class Robert : BaseCreature
    {
	
       // public override bool CanTeach { get { return true; } }
	public int Clothcol;
        private static bool m_Talked;

        string[] kfcsay = new string[]
        {

"A beautiful, smart, and loving person will be coming into your life.", 
"A dubious friend may be an enemy in camouflage.", 
"A faithful friend is a strong defense.", 
"A feather in the hand is better than a bird in the air. ", 
"A fresh start will put you on your way.", 
"A friend asks only for your time not your money.", 
"A friend is a present you give yourself.", 
"A gambler not only will lose what he has, but also will lose what he doesn’t have.", 
"A golden egg of opportunity falls into your lap this month.", 
"A good friendship is often more important than a passionate romance.", 
"A good time to finish up old tasks. ", 
"A hunch is creativity trying to tell you something.", 
"A lifetime friend shall soon be made.", 
"A lifetime of happiness lies ahead of you.", 
"A light heart carries you through all the hard times.", 
"A new perspective will come with the new year. ", 
"A person is never too old to learn. ", 
"A person of words and not deeds is like a garden full of weeds.", 
"A pleasant surprise is waiting for you.", 
"A short pencil is usually better than a long memory any day.", 
"A small donation is call for. It’s the right thing to do.", 
"A smile is your personal welcome mat.", 
"A smooth long journey! Great expectations.", 
"A soft voice may be awfully persuasive.", 
"A truly rich life contains love and art in abundance.", 
"Accept something that you cannot change, and you will feel better.", 
"Adventure can be real happiness.", 
"Advice is like kissing. It costs nothing and is a pleasant thing to do. ", 
"Advice, when most needed, is least heeded.", 
"All the effort you are making will ultimately pay off.", 
"All the troubles you have will pass away very quickly.", 
"All will go well with your new project.", 
"All your hard work will soon pay off.", 
"Allow compassion to guide your decisions.", 
"An acquaintance of the past will affect you in the near future.", 
"An agreeable romance might begin to take on the appearance.", 
"An important person will offer you support.", 
"An inch of time is an inch of gold.", 
"Any decision you have to make tomorrow is a good decision.", 
"At the touch of love, everyone becomes a poet.", 
"Be careful or you could fall for some tricks today.", 
"Beauty in its various forms appeals to you. (2)", 
"Because you demand more from yourself, others respect you deeply.", 
"Believe in yourself and others will too.", 
"Believe it can be done.", 
"Better ask twice than lose yourself once.", 
"Bide your time, for success is near.", 
"Carve your name on your heart and not on marble.", 
"Change is happening in your life, so go with the flow!", 
"Competence like yours is underrated.", 
"Congratulations! You are on your way.", 
"Could I get some directions to your heart? ", 
"Courtesy begins in the home.", 
"Courtesy is contagious.", 
"Curiosity kills boredom. Nothing can kill curiosity.", 
"Dedicate yourself with a calm mind to the task at hand.", 
"Depart not from the path which fate has you assigned.", 
"Determination is what you need now.", 
"Diligence and modesty can raise your social status.", 
"Disbelief destroys the magic.", 
"Distance yourself from the vain.", 
"Do not be intimidated by the eloquence of others.", 
"Do not demand for someone’s soul if you already got his heart.", 
"Do not let ambitions overshadow small success.", 
"Do not make extra work for yourself.", 
"Do not underestimate yourself. Human beings have unlimited potentials.", 
"Do you know that the busiest person has the largest amount of time?", 
"Don’t be discouraged, because every wrong attempt discarded is another step forward.", 
"Don’t confuse recklessness with confidence. ", 
"Don’t just spend time. Invest it.", 
"Don’t just think, act!", 
"Don’t let friends impose on you, work calmly and silently.", 
"Don’t let the past and useless detail choke your existence.", 
"Don’t let your limitations overshadow your talents.", 
"Don’t worry; prosperity will knock on your door soon.", 
"Each day, compel yourself to do something you would rather not do.", 
"Education is the ability to meet life’s situations.", 
"Embrace this love relationship you have!", 
"Emulate what you admire in your parents. ", 
"Emulate what you respect in your friends.", 
"Every flower blooms in its own sweet time.", 
"Every wise man started out by asking many questions.", 
"Everyday in your life is a special occasion.", 
"Everywhere you choose to go, friendly faces will greet you.", 
"Failure is the chance to do better next time.", 
"Failure is the path of lease persistence.", 
"Fear and desire – two sides of the same coin.", 
"Fearless courage is the foundation of victory.", 
"Feeding a cow with roses does not get extra appreciation.", 
"First think of what you want to do; then do what you have to do.", 
"For hate is never conquered by hate. Hate is conquered by love.", 
"For the things we have to learn before we can do them, we learn by doing them.", 
"Fortune Not Found: Abort, Retry, Ignore?", 
"From listening comes wisdom and from speaking repentance.", 
"From now on your kindness will lead you to success.", 
"Get your mind set – confidence will lead you on.", 
"Get your mind set…confidence will lead you on.", 
"Go for the gold today! You’ll be the champion of whatever.", 
"Go take a rest; you deserve it.", 
"Good news will be brought to you by mail.", 
"Good news will come to you by mail.", 
"Good to begin well, better to end well.", 
"Happiness begins with facing life with a smile and a wink.", 
"Happiness will bring you good luck.", 
"Happy life is just in front of you.", 
"Hard words break no bones, fine words butter no parsnips.", 
"Have a beautiful day.", 
"He who expects no gratitude shall never be disappointed. ", 
"He who knows he has enough is rich.", 
"Help! I’m being held prisoner in a chinese bakery!", 
"How many of you believe in psycho-kinesis? Raise my hand.", 
"How you look depends on where you go.", 
"I learn by going where I have to go.", 
"If a true sense of value is to be yours it must come through service.", 
"If certainty were truth, we would never be wrong.", 
"If you continually give, you will continually have.", 
"If you look in the right places, you can find some good offerings.", 
"If you think you can do a thing or think you can’t do a thing, you’re right.", 
"If you wish to see the best in others, show the best of yourself.", 
"If your desires are not extravagant, they will be granted.", 
"If your desires are not to extravagant they will be granted. ", 
"If you’re feeling down, try throwing yourself into your work.", 
"Imagination rules the world.", 
"In order to take, one must first give.", 
"In the end all things will be known.", 
"In this world of contradiction, it's better to be merry than wise.", 
"It could be better, but it's good enough.", 
"It is better to be an optimist and proven a fool than to be a pessimist and be proven right.", 
"It is better to deal with problems before they arise.", 
"It is honorable to stand up for what is right, however unpopular it seems.", 
"It is worth reviewing some old lessons.", 
"It takes courage to admit fault.", 
"It’s not the amount of time you devote, but what you devote to the time that counts.", 
"It’s time to get moving. Your spirits will lift accordingly.", 
"Keep your face to the sunshine and you will never see shadows.", 
"Let the world be filled with tranquility and goodwill.", 
"Like the river flow into the sea. Something are just meant to be.", 
"Listen not to vain words of empty tongue.", 
"Listen to everyone. Ideas come from everywhere.", 
"Living with a commitment to excellence shall take you far.", 
"Long life is in store for you.", 
"Love is a warm fire to keep the soul warm.", 
"Love is like sweet medicine, good to the last drop.", 
"Love lights up the world.", 
"Love truth, but pardon error. ", 
"Man is born to live and not prepared to live.", 
"Man’s mind, once stretched by a new idea, never regains it’s original dimensions.", 
"Many will travel to hear you speak.", 
"Meditation with an old enemy is advised.", 
"Miles are covered one step at a time.", 
"Nature, time and patience are the three great physicians.", 
"Never fear! The end of something marks the start of something new.", 
"New ideas could be profitable.", 
"New people will bring you new realizations, especially about big issues. ", 
"No one can walk backwards into the future.", 
"Nothing is more difficult, and therefore more precious, than to be able to decide.", 
"Now is a good time to buy stock.", 
"Now is the time to go ahead and pursue that love interest!", 
"Now is the time to try something new", 
"Now is the time to try something new.", 
"Observe all men, but most of all yourself.", 
"One can never fill another’s shoes, rather he must outgrow the old shoes.", 
"One of the first things you should look for in a problem is its positive side.", 
"Others can help you now.", 
"Pennies from heaven find their way to your doorstep this year!", 
"People are attracted by your Delicate[sic] features.", 
"People find it difficult to resist your persuasive manner.", 
"Perhaps you’ve been focusing too much on saving.", 
"Physical activity will dramatically improve your outlook today.", 
"Pick battles big enough to matter, small enough to win.", 
"Place special emphasis on old friendship.", 
"Please visit us at www.wontonfood.com", 
"Po Says: Pandas like eating bamboo, but I prefer mine dipped in chocolate.", 
"Practice makes perfect.", 
"Protective measures will prevent costly disasters.", 
"Put your mind into planning today. Look into the future.", 
"Remember the birthday but never the age.", 
"Remember to share good fortune as well as bad with your friends.", 
"Rest has a peaceful effect on your physical and emotional health.", 
"Resting well is as important as working hard.", 
"Romance moves you in a new direction.", 
"Savor your freedom – it is precious.", 
"Say hello to others. You will have a happier day.", 
"Self-knowledge is a life long process.", 
"Share your joys and sorrows with your family.", 
"Sift through your past to get a better idea of the present.", 
"Sloth makes all things difficult; industry all easy.", 
"Small confidences mark the onset of a friendship.", 
"Society prepares the crime; the criminal commits it.", 
"Someone you care about seeks reconciliation.", 
"Soon life will become more interesting.", 
"Stand tall. Don’t look down upon yourself. ", 
"Staying close to home is going to be best for your morale today", 
"Stop searching forever, happiness is just next to you.", 
"Strong reasons make strong actions.", 
"Success is a journey, not a destination.", 
"Success is failure turned inside out.", 
"Success is going from failure to failure without loss of enthusiasm.", 
"Swimming is easy. Stay floating is hard.", 
"Take care and sensitivity you show towards others will return to you.", 
"Take the high road.", 
"Technology is the art of arranging the world so we do not notice it.", 
"The austerity you see around you covers the richness of life like a veil.", 
"The best prediction of future is the past.", 
"The change you started already have far-reaching effects. Be ready.", 
"The change you started already have far-reaching effects. Be ready.", 
"The first man gets the oyster, the second man gets the shell.", 
"The greatest achievement in life is to stand up again after falling.", 
"The harder you work, the luckier you get.", 
"The night life is for you.", 
"The one that recognizes the illusion does not act as if it is real.", 
"The only people who never fail are those who never try.", 
"The person who will not stand for something will fall for anything.", 
"The philosophy of one century is the common sense of the next.", 
"The saints are the sinners who keep on trying.", 
"The secret to good friends is no secret to you. ", 
"The small courtesies sweeten life, the greater ennoble it.", 
"The smart thing to do is to begin trusting your intuitions.", 
"The strong person understands how to withstand substantial loss.", 
"The sure way to predict the future is to invent it.", 
"The truly generous share, even with the undeserving.", 
"The value lies not within any particular thing, but in the desire placed on that thing.", 
"The weather is wonderful. (2)", 
"There is no mistake so great as that of being always right.", 
"There is no wisdom greater than kindness. ", 
"There is no greater pleasure than seeing your loved  ones prosper.", 
"There’s no such thing as an ordinary cat.", 
"Things don’t just happen; they happen just.", 
"Those who care will make the effort.", 
"Time and patience are called for many surprises await you!", 
"Time is precious, but truth is more precious than time", 
"To know oneself, one should assert oneself.", 
"To the world you may be one person, but to one person you may be the world.", 
"Today is the conserve yourself, as things just won’t budge.", 
"Today, your mouth might be moving but no one is listening.", 
"Tonight you will be blinded by passion.", 
"Use your eloquence where it will do the most good.", 
"We first make our habits, and then our habits make us.", 
"Welcome change.", 
"", 
"Well done is better than well said.", 
"What’s hidden in an empty box?", 
"What’s yours in mine, and what’s mine is mine.", 
"When more become too much. It’s same as being not enough.", 
"When your heart is pure, your mind is clear.", 
"Wish you happiness.", 
"With age comes wisdom.", 
"You always bring others happiness.", 
"You are a person of another time.", 
"You are a talented storyteller. ", 
"You are admired by everyone for your talent and ability.", 
"You are almost there.", 
"You are busy, but you are happy.", 
"You are generous to an extreme and always think of the other fellow.", 
"You are going to have some new clothes. ", 
"You are in good hands this evening.", 
"You are interested in higher education, whether material or spiritual.", 
"You are modest and courteous.", 
"You are never selfish with your advice or your help.", 
"You are next in line for promotion in your firm.", 
"You are offered the dream of a lifetime. Say yes!", 
"You are open-minded and quick to make new friends. ", 
"You are solid and dependable.", 
"You are soon going to change your present line of work.", 
"You are talented in many ways.", 
"You are the master of every situation. ", 
"You are very expressive and positive in words, act and feeling.", 
"You are working hard.", 
"You begin to appreciate how important it is to share your personal beliefs.", 
"You can keep a secret.", 
"You can see a lot just by looking.", 
"You can’t steal second base and keep your foot on first.", 
"You desire recognition and you will find it.", 
"You have a deep appreciation of the arts and music.", 
"You have a deep interest in all that is artistic.", 
"You have a friendly heart and are well admired. ", 
"You have a shrewd knack for spotting insincerity.", 
"You have a yearning for perfection. ", 
"You have an active mind and a keen imagination.", 
"You have an ambitious nature and may make a name for yourself.", 
"You have an unusual equipment for success, use it properly.", 
"You have exceeded what was expected.", 
"You have had a good start. Work harder!", 
"You have the power to write your own fortune.", 
"You have yearning for perfection.", 
"You know where you are going and how to get there.", 
"You look pretty.", 
"You love challenge.", 
"You love chinese food.", 
"You make people realize that there exist other beauties in the world.", 
"You never hesitate to tackle the most difficult problems. ", 
"You never know who you touch.", 
"You only treasure what you lost.", 
"You seek to shield those you love and like the role of provider. ", 
"You should be able to make money and hold on to it.", 
"You should be able to undertake and complete anything.", 
"You should pay for this check. Be generous.", 
"You understand how to have fun with others and to enjoy your solitude.", 
"You will always be surrounded by true friends.", 
"You will always get what you want through your charm and personality.", 
"You will always have good luck in your personal affairs.", 
"You will be a great success both in the business world and society. ", 
"You will be blessed with longevity.", 
"You will be pleasantly surprised tonight.", 
"You will be sharing great news with all the people you love.", 
"You will be successful in your work.", 
"You will be traveling and coming into a fortune.", 
"You will be unusually successful in business.", 
"You will become a great philanthropist in your later years.", 
"You will become more and more wealthy.", 
"You will enjoy good health.", 
"You will enjoy good health; you will be surrounded by luxury.", 
"You will find great contentment in the daily, routine activities.", 
"You will have a fine capacity for the enjoyment of life.", 
"You will have gold pieces by the bushel.", 
"You will inherit a large sum of money.", 
"You will make change for the better.", 
"You will soon be surrounded by good friends and laughter.", 
"You will take a chance in something in near future.", 
"You will travel far and wide, both pleasure and business.", 
"You will travel far and wide,both pleasure and business.", 
"Your abilities are unparalleled.", 
"Your ability is appreciated.", 
"Your ability to juggle many tasks will take you far.", 
"Your biggest virtue is your modesty.", 
"Your character can be described as natural and unrestrained.", 
"Your difficulties will strengthen you.", 
"Your dreams are never silly; depend on them to guide you.", 
"Your dreams are worth your best efforts to achieve them.", 
"Your energy returns and you get things done.", 
"Your family is young, gifted and attractive.", 
"Your first love has never forgotten you.", 
"Your goal will be reached very soon.", 
"Your happiness is before you, not behind you! Cherish it.", 
"Your hard work will payoff today.", 
"Your heart will always make itself known through your words.", 
"Your home is the center of great love.", 
"Your ideals are well within your reach.", 
"Your infinite capacity for patience will be rewarded sooner or later.", 
"Your leadership qualities will be tested and proven.", 
"Your life will be happy and peaceful.", 
"Your life will get more and more exciting.", 
"Your love life will be happy and harmonious.", 
"Your love of music will be an important part of your life.", 
"Your loyalty is a virtue, but not when it’s wedded with blind stubbornness.", 
"Your mentality is alert, practical, and analytical.", 
"Your mind is creative, original and alert.", 
"Your mind is your greatest asset.", 
"Your moods signal a period of change.", 
"Your quick wits will get you out of a tough situation.", 
"Your reputation is your wealth.", 
"Your success will astonish everyone. ", 
"Your talents will be recognized and suitably rewarded.", 
"Your work interests can capture the highest status or prestige.",
"There is a true and sincere friendship between you and your friends.",
"You find beauty in ordinary things, do not lose this ability.",
"Ideas are like children; there are none so wonderful as your own.",
"It takes more than good memory to have good memories.",
"A thrilling time is in your immediate future.",
"Your blessing is no more than being safe and sound for the whole lifetime.",
"Plan for many pleasures ahead.",
"The joyfulness of a man prolongeth his days.",
"Your everlasting patience will be rewarded sooner or later.",
"Make two grins grow where there was only a grouch before.",
"Something you lost will soon turn up.",
"Your heart is pure, and your mind clear, and your soul devout.",
"Excitement and intrigue follow you closely wherever you go!",
"A pleasant surprise is in store for you.",
"May life throw you a pleasant curve.",
"As the purse is emptied the heart is filled.",
"Be mischievous and you will not be lonesome.",
"You have a deep appreciation of the arts and music.",
"Your flair for the creative takes an important place in your life.",
"Your artistic talents win the approval and applause of others.",
"Pray for what you want, but work for the things you need.",
"Your many hidden talents will become obvious to those around you.",
"Don't forget, you are always on our minds.",
"Your greatest fortune is the large number of friends you have.",
"A firm friendship will prove the foundation on your success in life.",
"Don't ask, don't say. Everything lies in silence.",
"Look for new outlets for your own creative abilities.",
"Be prepared to accept a wondrous opportunity in the days ahead!",
"Fame, riches and romance are yours for the asking.",
"Good luck is the result of good planning.",
"Good things are being said about you.",
"Smiling often can make you look and feel younger.",
"Someone is speaking well of you.",
"The time is right to make new friends.",
"You will inherit some money or a small piece of land.",
"Your life will be happy and peaceful.",
"A friend is a present you give yourself.",
"A member of your family will soon do something that will make you proud.",
"A quiet evening with friends is the best tonic for a long day.",
"A single kind word will keep one warm for years.",
"Anger begins with folly, and ends with regret.",
"Generosity and perfection are your everlasting goals.",
"Happy news is on its way to you.",
"He who laughs at himself never runs out of things to laugh at.",
"If your desires are not extravagant they will be granted.",
"Let there be magic in your smile and firmness in your handshake.",
"If you want the rainbow, you must to put up with the rain.",
"Nature, time and patience are the three best physicians.",
"Strong and bitter words indicate a weak cause.",
"The beginning of wisdom is to desire it.",
"You will have a very pleasant experience.",
"You will inherit some money or a small piece of land.",
"You will live a long, happy life.",
"You will spend old age in comfort and material wealth.",
"You will step on the soil of many countries.",
"You will take a chance in something in the near future.",
"You will witness a special ceremony.",
"Your everlasting patience will be rewarded sooner or later.",
"Your great attention to detail is both a blessing and a curse.",
"Your heart is a place to draw true happiness.",
"Your ability to juggle many tasks will take you far.",
"A friend asks only for your time, not your money.",
"You will be invited to an exciting event.",
"A Rolling Stone Spoils The Broth",
"Too Many Cooks Gather No Moss",
"A Puritan is someone who is deathly afraid that someone somewhere is having fun.",
"A bad compromise is better than a good battle.",
"A bird in hand is worth two in the bush.",
"A bright cook may be little more than a flash in the pan.",
"A clash of doctrine is not a disaster - it is an opportunity.",
"A conclusion is where you got tired of thinking.",
"Always tell the truth, but leave as soon as you do.",
"A fanatic is one who can't change his mind and won't change the subject.",
"A good man always knows his limitations.",
"A handful of friends is worth more than a wagon of gold.",
"A hermit is a deserter from the army of humanity.",
"About the only thing on a farm that has an easy time is the dog.",
"A soft drink turneth away company.",
"A thing not worth doing is worth not doing well.",
"Are you a turtle?",
"Courage is grace under pressure.",
"Depression is merely anger without the enthusiasm.",
"Even a hawk is an eagle among crows.",
"Even the smallest candle burns brighter in the dark.",
"Excuse me, but is this thing private?",
"Far duller than a serpent's tooth it is to spend a quiet youth.",
"Friends: People who borrow my books and set wet glasses on them.",
"Great spirits have always encountered violent opposition from mediocre minds.",
"I am not a crook.",
"I will never lie to you.",
"If at first you don't succeed, quit; don't be a nut about success.",
"If you ask how much it is, you can't afford it.",
"It's a poor workman who blames his tools.",
"Learn good things, the bad ones will teach you by themselves.",
"Mistakes are oft the stepping stones to failure.",
"Long life is in store for you.",
"Never insult an alligator until you have crossed the river.",
"Nothing in life is to be feared.  It is only to be understood.",
"Only those who attempt the absurd achieve the impossible.",
"Simplicity does not precede complexity, but follows it.",
"Have you checked all the chests in Brit bank?",
"Time is nature's way of making sure that everything doesn't happen at once.",
"To laugh at men of sense is the privilege of fools.",
"What do you call a gorilla with a heavy crossbow? Sir.",
"When you live close to the graveyard, you can't weep for every funeral",
"You don't have to rehearse to be yourself.",
"A great empire, like a great cake, is most easily diminished at the edges."
        };
      
  
        [Constructable]
        public Robert()
            : base(AIType.AI_Melee, FightMode.None, 10, 1, 0.8, 3.0)
        {
Random rnd = new Random();
int RndCol  = rnd.Next(400, 600);  // creates a number between 1 and 12



		Clothcol = RndCol;
		
		//512;
            {

		this.Body = 400;
		FaceHue = 33770;
		
		
		
        
		this.Name = NameList.RandomName("male");
		this.Title = "the seer";
                SpeechHue = 56;
                // Hue = 128;
				Hue = Utility.RandomSkinHue();
                Item hair = new Item(Utility.RandomList(0x2FC2, 0x2FC2));
                hair.Hue = 55;
                hair.Layer = Layer.Hair;
                hair.Movable = false;
                AddItem(hair);
            }
            {
                SetStr(100);
                SetDex(100);
                SetInt(100);

                Fame = 50;
                Karma = 50;

              
                SetSkill(SkillName.Discordance, 60.0, 70.0);
            }
            {

                Container pack = new Backpack();
                pack.DropItem(new Gold(0, 50));
                pack.Movable = false;
                AddItem(pack);
            }
            {
                Item AnniversaryRobe = new AnniversaryRobe();
                AnniversaryRobe.Hue = Clothcol;
                AnniversaryRobe.Movable = false;
                AddItem(AnniversaryRobe);
            }
            
	    {
                Item Boots = new Boots();
                //Boots.Hue = Clothcol;
                Boots.Movable = false;
                AddItem(Boots);
            }
            
		



        }
 
        
        public Robert(Serial serial)
            : base(serial)
        {
        }

        public override void OnMovement(Mobile m, Point3D oldLocation)
        {
            if (m_Talked == false)
            {
                if (m.InRange(this, 1))
                {
                    m_Talked = true;
                    SayRandom(kfcsay, this);
                    this.Move(GetDirectionTo(m.Location));
                    SpamTimer t = new SpamTimer();
                    t.Start();
                }
            }
        }

        private class SpamTimer : Timer
        {
            public SpamTimer()
                : base(TimeSpan.FromSeconds(10))
            {
                Priority = TimerPriority.OneSecond;
            }

            protected override void OnTick()
            {
                m_Talked = false;
            }
        }

        private static void SayRandom(string[] say, Mobile m)
        {
            m.Say(say[Utility.Random(say.Length)]);
        }

        

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}