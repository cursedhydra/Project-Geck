﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace Geck
{
    public class Player
    {

        //Special/Skills/Perks

        public String FileName = String.Empty;
        int SpecialPoints = 5;

        static int Str = 5;
        static int Per = 5;
        static int End = 5;
        static int Cha = 5;
        static int Int = 5;
        static int Agi = 5;
        static int Luc = 5;

        int Barter = 0;
        int Energy_Weapons = 0;
        int Explosives = 0;
        int Guns = 0;
        int Lockpick = 0;
        int Medicine = 0;
        int Melee_Weapons = 0;
        int Repair = 0;
        int Science = 0;
        int Sneak = 0;
        int Speech = 0;
        int Survival = 0;
        int Unarmed = 0;

        List<Perk> perklist = new List<Perk>(new Perk[] {
            new Perk("error","error"),
            new Perk("Lady Killer","In combat you do increased damage on people of the opposite sex. You also have an easier time convincing them during speech checks."), //Must be male
            new Perk("Black Widow","In combat you do increased damage on people of the opposite sex. You also have an easier time convincing them during speech checks."), //Must be female
            new Perk("Cherchez La Femme","In combat you do increased damage on people of the same sex. You also have an easier time convincing them during speech checks."), //Must be female
            new Perk("Confirmed Bachelor","In combat you do increased damage on people of the same sex. You also have an easier time convincing them during speech checks."), //Must be male
            new Perk("Friend of the Night","Increased accuracy at night with all ranged weapons."),
            new Perk("Theif", 5,5, "Sneak", "Lockpick" ,"You gain plus 5 to both Sneak and Lockpick."),
            new Perk("Hunter","In combat you do 25% more damage against animals and mutated animals."),
            new Perk("Intensive Training", 1, "SpecialPoints", "You can put a single point into any of your special attributes."),
            new Perk("Rapid Reload","All of your weapons reloads require one less AP point."), //Code this
            new Perk("Retention","Skill magazines now last longer."), //idk
            new Perk("Swift Learner","You gain an additional 10% XP whenever XP is earned."), //maybe code idk
            new Perk("Gun Nut", 5, 5, "Guns", "Repair", "You gain plus 5 to Guns and Repair."),
            new Perk("Cannibal","The player can eat the corpses of members of their same race in order to regain HP, at the cost of Karma."), //ask how much karma
            new Perk("Child At Heart","You have an easier time connecting with and convincing children."),
            new Perk("Educated", "You gain +1 skill points every time you other time you advance in level."), //Make sure you code for this shit
            new Perk("Entomologist","You do an additional 25% damage every time you attack a mutated insect."),
            new Perk("Scoundrel","You gain plus 5 to both Speech and Barter, at the cost of Karma."), //Ask how much karma
            new Perk("Travel Light","While wearing Light Armor, or no armor, you get an extra point of AP."), //Code this
            new Perk("Bloody Mess","You gain plus 5 to damage overall. In addition, those killed by the player will die horribly at the cost of Karma."), //Ughhhhhh
            new Perk("Demolitions Expert","You gain plus 20% damage with explosives."), //Code this
            new Perk("Lead Belly","You take 50% less radiation from drinking unpurified water."),
            new Perk("Toughness","Permanent 10% increase to Damage Resistance."), //Code this
            new Perk("The Professional","All Sneak Attack Criticals with revolvers, pistols, and submachine guns inflict an additional 20% damage."), //Code this (Sneak crit% variable?)
            new Perk("Shotgun Surgeon","When using shotguns, regardless of ammunition used, you ignore an additional 10 points of the target’s Damage Resistance."),
            new Perk("Commando","You gain plus 25% accuracy when using two handed weapons."),
            new Perk("Cowboy","You deal plus 25% damage when using dynamite, hatchets, knives, revolvers, and lever-action guns."),
            new Perk("Living Anatomy","You deal plus 5% damage on all humans and non-feral ghouls."),
            new Perk("Rad Resistance","You gain a 25% radiation resistance permanently."), //Code this
            new Perk("Stonewall","You gain plus 5 DR/DT against all melee and unarmed attacks. In addition, you can not be knocked down in combat."),
            new Perk("Strong Back", 50, "Carry_Weight", "Strong Back: You can carry an additional 50 pounds of equipment."),
            new Perk("Super Slam!"," Your chances increase to knock down an enemy when using all melee and unarmed weapons. 15% for Unarmed, 20% for One Handed Melee, and 25% for Two Handed Melee."),
            new Perk("Terrifying Presence","You have a stronger chance of succeeding any sort of threatening speech check."),
            new Perk("Here and Now!", 1, "Level", "You instantly gain one level."),
            new Perk("Animal Friend","On the first rank of this perk, hostile animals will become friendly. The second rank animals will come to your aid in combat, as long as you are not fighting other animals."),
            new Perk("And Stay Back!","Any shotgun shot has a 10% chance to knock an enemy off his feet."),
            new Perk("Finesse", 5 , "Crit_Chance", "You gain plus 5% crit chance."),
            new Perk("Math Wrath","You reduce all AP cost by 20%."), //code this
            new Perk("Mister Sandman","You can instantly kill a sleeping character without any checks. You also gain bonus XP."),
            new Perk("Mysterious Stranger"," Every few combat sessions the DM will roll dice. If the majority of the dice land on 5 or 6, the Mysterious Stranger will kill an enemy combatant of the player’s choosing."),
            new Perk("Nerd Rage!","Your DR is increased by 15 and your Strength is increased to 10 when your health is 20% or lower."),
            new Perk("Night Person","Your INT and PER is increased by 2 between 6pm and 6am."),
            new Perk("Plasma Spaz","The AP cost for using plasma weapons is reduced by 20%."),
            new Perk("Ghastly Scavenger","The player can now eat the corpses of other player races. This comes at an additional cost of Karma."), //karma
            new Perk("Hit the Deck","You gain 25 DR against all explosive damage."),
            new Perk("Life Giver", 30, "HP", "You gain 30 HP."),
            new Perk("Piercing Strike","All of your unarmed and melee attacks negate 15 of your enemy’s DR."),
            new Perk("Pyromaniac","You do 50% more damage with fire-based weapons."),
            new Perk("Robotics Expert","You do 25% more damage to robots. You can also sneak up behind them and disable them."),
            new Perk("Sniper","You are 25% more likely to hit a target's head."),
            new Perk("Fast Metabolism","Stimpaks now restore an additional 20% of your hit points."),
            new Perk("Adamantium Skeleton", -50, "Limb_Damage", "Limb damage reduced by 50%."),
            new Perk("Center of Mass","You do an additional 15% damage when aiming at the torso."),
            new Perk("Chemist","Chems last twice as long."),
            new Perk("Light Step","Floor Traps and Mines will not be set off."),
            new Perk("Purifier","You do an additional 50% damage  with melee and unarmed weapons against abominations."),
            new Perk("Action Boy", 15, "AP", "Gain 15 Action Points."),
            new Perk("Action Girl", 15, "AP", "Gain 15 Action Points."),
            new Perk("Better Criticals", 50, "Crit_Damage", "Do 50% more damage with critical hits."),
            new Perk("Chem Resistant","You are half as likely to get addicted."), //code?
            new Perk("Meltdown","Targets killed by Energy Weapons release a harmful corona of energy upon death."),
            new Perk("Tag!","Select a fourth tag skill."), //codeeeee
            new Perk("Weapon Handling","Weapon Requirements are now 2 points lower than normal for you."), //code
            new Perk("Computer Whiz","You receive an additional chance to hack a terminal if you get locked out."),
            new Perk("Concentrated Fire","You gain additional accuracy every time you select a certain body part to be hit. Increase by 5 every shot."),
            new Perk("Infiltrator","You receive an additional chance to pick a lock if it breaks."),
            new Perk("Paralyzing Palm","You can paralyze an enemy for a turn with an unarmed attack.  Player must say they are going to use the combat move."),
            new Perk("Master Trader","All items cost 25% less."),
            new Perk("Grim Reaper's Sprint","A kill restores 10 AP immediately."),
            new Perk("Ninja","You deal an additional 25 percent damage with Melee/Unarmed Sneak Criticals."),
            new Perk("Solar Powered","Plus 2 Strength and Endurance between 6am and 6pm."),
            new Perk("Laser Commander","You do an extra 15% damage with Energy Weapons and you have a 10% extra chance to get a critical hit when using any laser weapon."),
            new Perk("Spray n' Pray"," Your attacks do 75% less damage to other party members."),
            new Perk("Slayer","All Melee and Unarmed attacks cost 3 less AP."),
            new Perk("Heavyweight","All weapons with a weight more than 10 have their weight value cut in half."),
            new Perk("Rad Absorption","You lose 1 rad every 20 seconds."),
            new Perk("Burden to Bear", 50 , "Carry_Weight", "Plus 50 carry weight."),
            new Perk("Walker Instinct","Plus 1 AGI and PER while outside"),
            new Perk("Party Boy", "Immune to alcohol addiction."),
            new Perk("Party Girl","Immune to alcohol addiction."),
            new Perk("Balance","All SPECIAL stats are increased by 1"), //codeeeeeee
            new Perk("Ghoulified","Healed by light rads, and immune to the effects of radiation up to 600 Rads."),
            new Perk("One of Us","Increased Speech, Charisma, and Barter among ghouls. Feral ghouls are non-hostile."),
            new Perk("\"Zombie!\"", "Decreased Speech, Charisma, and Barter among humans."),
            new Perk("Freak of Nature","Immune to the effects of radiation up to 800 rads."),
            new Perk("Vault Educated", 10, 10 , 10, "Science", "Medicine", "Repair", "Gain 10 points in Science, Medicine, and Repair."),
            new Perk("Stigmatized","Lose 15 Speech when talking with a human."),
            new Perk("Brawler", 10, 10, "Melee", "Unarmed", "Gain 10 points in Melee and Unarmed."),
            new Perk("Brutish", -15, -15 ,"Speech", "Barter", "Lose 15 points in Speech and Barter"),
            new Perk("Schizophrenia","Due to an excess use of Stealth Boys, you have developed schizophrenia. In addition to auditory hallucinations, your Speech and Barter are capped at 50, and your CHA is capped at 5."),
            new Perk("Super Soldier","Your Sneak and Guns start at 30."), 
            new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"),
            new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"),
            new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"),
            new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"),
            new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"), new Perk("a","a"),
            });


        //The list of the player's taken perks
        List<Perk> playerperks = new List<Perk>();



        String Name = String.Empty;
        String Gender = String.Empty;
        String Race = String.Empty;
        String CurrencyName = String.Empty;
        int Karma = 0;
        int Currency = 0;
        int Level = 1;
        int Experience = 0;

        int AP = 5 + (int)(Math.Floor((double)(5 / 2)));
        int Carry_Weight = 0; //fill ask dam
        int Crit_Chance = 0; //fill
        int Crit_Damage_Percent = 100;
        int DR = 0; //fill
        int HP = 0; //fill
        int Skill_Points = 0;
        int Skill_Points_On_Level = 0;
        int Limb_Damage_Percent = 100;
        bool Addicted = false;

        public bool BarterTagged = false;
        public bool EWTagged = false;
        public bool ExplosivesTagged = false;
        public bool GunsTagged = false;
        public bool LockpickTagged = false;
        public bool MedicineTagged = false;
        public bool MWTagged = false;
        public bool RepairTagged = false;
        public bool ScienceTagged = false;
        public bool SneakTagged = false;
        public bool SpeechTagged = false;
        public bool SurvivalTagged = false;
        public bool UnarmedTagged = false;

        public Player()
        {

        }

        ArrayList Traits = new ArrayList();

        public void SetAttribute(String id, int val)
        {
            if (id.Equals("Str"))
                Str = val;

            if (id.Equals("Per"))
                Per = val;

            if (id.Equals("End"))
                End = val;

            if (id.Equals("Cha"))
                Cha = val;

            if (id.Equals("Int"))
                Int = val;

            if (id.Equals("Agi"))
                Agi = val;

            if (id.Equals("Luc"))
                Luc = val;

            if (id.Equals("Barter"))
                Barter = val;

            if (id.Equals("EW"))
                Energy_Weapons = val;

            if (id.Equals("Explosives"))
                Explosives = val;

            if (id.Equals("Guns"))
                Guns = val;

            if (id.Equals("Lockpick"))
                Lockpick = val;

            if (id.Equals("Medicine"))
                Medicine = val;

            if (id.Equals("MW"))
                Melee_Weapons = val;

            if (id.Equals("Repair"))
                Repair = val;

            if (id.Equals("Science"))
                Science = val;

            if (id.Equals("Sneak"))
                Sneak = val;

            if (id.Equals("Speech"))
                Speech = val;

            if (id.Equals("Survival"))
                Survival = val;

            if (id.Equals("Unarmed"))
                Unarmed = val;

            if (id.Equals("Karma"))
                Karma = val;

            if (id.Equals("Limb_Damage"))
                Limb_Damage_Percent = val;

            if (id.Equals("SpecialPoints"))
                SpecialPoints = val;

            if (id.Equals("Skill_points_on_level"))
                Skill_Points_On_Level = val;

            if (id.Equals("DR"))
                DR = val;

            if (id.Equals("Carry_Weight"))
                Carry_Weight = val;

            if (id.Equals("Level"))
                Level = val;

            if (id.Equals("Crit_Chance"))
                Crit_Chance = val;

            if (id.Equals("HP"))
                HP = val;

            if (id.Equals("AP"))
                AP = val;

            if (id.Equals("Crit_Damage"))
                Crit_Damage_Percent = val;

            if (id.Equals("Experience"))
                Experience = val;


        }

        public int GetAttribute(String id)
        {
            if (id.Equals("Str"))
                return Str;

            if (id.Equals("Per"))
                return Per;

            if (id.Equals("End"))
                return End;

            if (id.Equals("Cha"))
                return Cha;

            if (id.Equals("Int"))
                return Int;

            if (id.Equals("Agi"))
                return Agi;

            if (id.Equals("Luc"))
                return Luc;

            if (id.Equals("Barter"))
                return Barter;

            if (id.Equals("EW"))
                return Energy_Weapons;

            if (id.Equals("Explosives"))
                return Explosives;

            if (id.Equals("Guns"))
                return Guns;

            if (id.Equals("Lockpick"))
                return Lockpick;

            if (id.Equals("Medicine"))
                return Medicine;

            if (id.Equals("MW"))
                return Melee_Weapons;

            if (id.Equals("Repair"))
                return Repair;

            if (id.Equals("Science"))
                return Science;

            if (id.Equals("Sneak"))
                return Sneak;

            if (id.Equals("Speech"))
                return Speech;

            if (id.Equals("Survival"))
                return Survival;

            if (id.Equals("Unarmed"))
                return Unarmed;

            if (id.Equals("Karma"))
                return Karma;

            if (id.Equals("Limb_Damage"))
                return Limb_Damage_Percent;

            if (id.Equals("SpecialPoints"))
                return SpecialPoints;

            if (id.Equals("Skill_points_on_level"))
                return Skill_Points_On_Level;

            if (id.Equals("DR"))
                return DR;

            if (id.Equals("Carry_Weight"))
                return Carry_Weight;

            if (id.Equals("Level"))
                return Level;

            if (id.Equals("Crit_Chance"))
                return Crit_Chance;

            if (id.Equals("HP"))
                return HP;

            if (id.Equals("AP"))
                return AP;

            if (id.Equals("Crit_Damage"))
                return Crit_Damage_Percent;

            if (id.Equals("Experience"))
                return Experience;

            else
                return -1;

        }

        public List<String> GetSkillReport()
        {
            List<String> report = new List<String>();
            report.Add(Barter.ToString());
            report.Add(Energy_Weapons.ToString());
            report.Add(Explosives.ToString());
            report.Add(Guns.ToString());
            report.Add(Lockpick.ToString());
            report.Add(Medicine.ToString());
            report.Add(Melee_Weapons.ToString());
            report.Add(Repair.ToString());
            report.Add(Science.ToString());
            report.Add(Sneak.ToString());
            report.Add(Speech.ToString());
            report.Add(Survival.ToString());
            report.Add(Unarmed.ToString());

            return report;
        }

        public void SetSpecialPoints(int val)
        {
            SpecialPoints = val;
        }

        public int GetSpecialPoints()
        {
            return SpecialPoints;
        }

        public void ApplyPerks()
        {

            foreach (Perk i in playerperks)
            {
                if(!i.applied)

                {

                    if (i.GetPerkType() == 2)
                    {
                        this.SetAttribute(i.GetId(), GetAttribute(i.GetId()) + i.GetValue());
                        i.applied = true;
                    }

                    if (i.GetPerkType() == 3)
                    {
                        this.SetAttribute(i.GetId(), GetAttribute(i.GetId()) + i.GetValue());
                        this.SetAttribute(i.GetSecondaryId(), GetAttribute(i.GetSecondaryId()) + i.GetSecondaryValue());
                        i.applied = true;
                    }

                    if (i.GetPerkType() == 4)
                    {
                        this.SetAttribute(i.GetId(), GetAttribute(i.GetId()) + i.GetValue());
                        this.SetAttribute(i.GetSecondaryId(), GetAttribute(i.GetSecondaryId()) + i.GetSecondaryValue());
                        this.SetAttribute(i.GetTertiaryId(), GetAttribute(i.GetTertiaryId()) + i.GetTertiaryValue());
                        i.applied = true;
                    }
                    //Code the rest here laddie (make sure to mark as applied)

                }

            }
        }

        /// <summary>
        /// Adds a perk from the "perklist" array. "Id" corresponds to the array index + 1.
        /// </summary>
        /// <param name="id"></param>
        public void AddPerk(int id)
        {
            playerperks.Add(perklist[id]);
        }

        public void AddPerk(String perkname)
        {
            foreach(Perk i in perklist)
            {
                if (i.GetName().Equals(perkname))
                    playerperks.Add(i);
            }
        }

        /// <summary>
        /// Searches the player's perks for one that matches PerkName and returns it. Returns null if it cannot be found.
        /// </summary>
        /// <param name="PerkName"></param>
        /// <returns></returns>
        public Perk GetPerk(String PerkName)
        {
            foreach (Perk i in playerperks)
            {
                if (i.GetName().Equals(PerkName))
                    return i;
            }
            MessageBox.Show("Perk not found");
            return null;
        }

        public void SetName(String name)
        {
            Name = name;
        }

        public void SetGender(String gender)
        {
            Gender = gender;
        }

        public void SetRace(String race)
        {
            Race = race;
        }

        public String GetName()
        {
            return Name;
        }

        public String GetGender()
        {
            return Gender;
        }

        public String GetRace()
        {
            return Race;
        }

        public List<Perk> GetAllPerks()
        {
            return playerperks;
        }

        public void Save()
        {
            FileStream objStream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            XmlTextWriter objWriter = new XmlTextWriter(objStream, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                Indentation = 1,
                IndentChar = '\t'
            };

            objWriter.WriteStartDocument();

            objWriter.WriteStartElement("Player");

            //Write Player Info
            objWriter.WriteElementString("Name", Name);
            objWriter.WriteElementString("Gender", Gender);
            objWriter.WriteElementString("Race", Race);
            objWriter.WriteElementString("Karma", Karma.ToString());
            objWriter.WriteElementString("CurrencyType", CurrencyName);
            objWriter.WriteElementString("Currency", Currency.ToString());
            

            //Write Special
            objWriter.WriteElementString("Str", Str.ToString());
            objWriter.WriteElementString("Per", Per.ToString());
            objWriter.WriteElementString("End", End.ToString());
            objWriter.WriteElementString("Cha", Cha.ToString());
            objWriter.WriteElementString("Int", Int.ToString());
            objWriter.WriteElementString("Agi", Agi.ToString());
            objWriter.WriteElementString("Luc", Luc.ToString());

            //Write Skills
            objWriter.WriteElementString("Barter", Barter.ToString());
            objWriter.WriteElementString("EnergyWeapons", Energy_Weapons.ToString());
            objWriter.WriteElementString("Explosives", Explosives.ToString());
            objWriter.WriteElementString("Guns", Guns.ToString());
            objWriter.WriteElementString("Lockpick", Lockpick.ToString());
            objWriter.WriteElementString("Medicine", Medicine.ToString());
            objWriter.WriteElementString("MeleeWeapons", Melee_Weapons.ToString());
            objWriter.WriteElementString("Repair", Repair.ToString());
            objWriter.WriteElementString("Science", Science.ToString());
            objWriter.WriteElementString("Sneak", Sneak.ToString());
            objWriter.WriteElementString("Speech", Speech.ToString());
            objWriter.WriteElementString("Survival", Survival.ToString());
            objWriter.WriteElementString("Unarmed", Unarmed.ToString());


            objWriter.WriteStartElement("Perks");

            //Wrtie Perks
            foreach (Perk i in playerperks)
                objWriter.WriteElementString("Perk", i.GetName());

            objWriter.WriteEndElement();


            //End Doc
            objWriter.WriteEndElement();
            objWriter.WriteEndDocument();
            objWriter.Close();
            objStream.Close();

        }

        public void Load()
        {
            int counter = 0;

            //Uses the chummergen dev's XmlExtensions class. It makes life so much easier.

            XmlDocument objXmlDocument = new XmlDocument();
            objXmlDocument.Load(FileName);
            XmlNode objXmlCharacter = objXmlDocument.SelectSingleNode("/Player");
            
            //Load Player Info
            objXmlCharacter.TryGetStringFieldQuickly("Name", ref Name);
            objXmlCharacter.TryGetStringFieldQuickly("Gender", ref Gender);
            objXmlCharacter.TryGetStringFieldQuickly("Race", ref Race);
            objXmlCharacter.TryGetInt32FieldQuickly("Karma", ref Karma);
            objXmlCharacter.TryGetStringFieldQuickly("CurrencyType", ref CurrencyName);
            objXmlCharacter.TryGetInt32FieldQuickly("Currency", ref Currency);

            //Load Special
            objXmlCharacter.TryGetInt32FieldQuickly("Str", ref Str);
            objXmlCharacter.TryGetInt32FieldQuickly("Per", ref Per);
            objXmlCharacter.TryGetInt32FieldQuickly("End", ref End);
            objXmlCharacter.TryGetInt32FieldQuickly("Cha", ref Cha);
            objXmlCharacter.TryGetInt32FieldQuickly("Int", ref Int);
            objXmlCharacter.TryGetInt32FieldQuickly("Agi", ref Agi);
            objXmlCharacter.TryGetInt32FieldQuickly("Luc", ref Luc);

            //Load Skills
            objXmlCharacter.TryGetInt32FieldQuickly("Barter", ref Barter);
            objXmlCharacter.TryGetInt32FieldQuickly("EnergyWeapons",ref Energy_Weapons);
            objXmlCharacter.TryGetInt32FieldQuickly("Explosives", ref Explosives);
            objXmlCharacter.TryGetInt32FieldQuickly("Guns", ref Guns);
            objXmlCharacter.TryGetInt32FieldQuickly("Lockpick", ref Lockpick);
            objXmlCharacter.TryGetInt32FieldQuickly("Medicine", ref Medicine);
            objXmlCharacter.TryGetInt32FieldQuickly("MeleeWeapons", ref Melee_Weapons);
            objXmlCharacter.TryGetInt32FieldQuickly("Repair", ref Repair);
            objXmlCharacter.TryGetInt32FieldQuickly("Science", ref Science);
            objXmlCharacter.TryGetInt32FieldQuickly("Sneak", ref Sneak);
            objXmlCharacter.TryGetInt32FieldQuickly("Speech", ref Speech);
            objXmlCharacter.TryGetInt32FieldQuickly("Survival", ref Survival);
            objXmlCharacter.TryGetInt32FieldQuickly("Unarmed", ref Unarmed);

            foreach (XmlElement i in objXmlCharacter.SelectSingleNode("Perks"))
            {
                counter = 0;
                foreach (Perk j in perklist)
                {
                    if (j.GetName().Equals(i.InnerText))
                        AddPerk(counter);

                    counter++;
                }

            }

        
        }

    }


    }
