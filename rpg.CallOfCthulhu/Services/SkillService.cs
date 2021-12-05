using rpg.System.Interfaces;
using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using rpg.CallOfCthulhu.Config;
using Races = rpg.CallOfCthulhu.Models.Races;

namespace rpg.CallOfCthulhu.Services
{
    public class SkillService : ISkillService
    {
        public enum Skills
        {
            Accounting, Acting, AnimalHandling, Anthropology, Appraise, Archeology, ArtAndCraft, Artillery,
            Astronomy,
            Axe,
            Biology, Botany, Bow, Brawl,
            Chainsaw, Charm, Chemistry, Climb, CreditRating, Cryptography, CthulhuMythos,
            Demolitions, Disguise, Diving, Dodge, DriveAuto,
            ElectricalRepair, Electronics,
            FastTalk, FineArt, FirstAid, Flail, Flamethrower, Forensics, Forgery,
            Garrote, Geology,
            Handgun, HeavyWeapons, History, Hypnosis,
            Intimidate,
            Jump,
            Language, LanguageOwn, Law, LibraryUse, Listen, Locksmith,
            MachineGun, Mathematics, MechanicalRepair, Medicine, Meteorology,
            NaturalWorld, Navigate,
            Occult,
            OperateHeavyMachinery,
            Persuade, Pharmacy, Photography, Physics, Pilot, Psychoanalysis, Psychology,
            ReadLips, Ride, Rifle,
            Shotgun, SleightOfHand, Spear, SpotHidden, Stealth, SubmachineGun, Survival, Sword, Swim,
            Throw, Track,
            Whip,
            Zoology
        }
        public List<Skill> GenerateSkills(string raceName)
        {
            var race = Races.All.Where(_ => _.Name == raceName).FirstOrDefault();
            List<Skill> result = race.Skills.ToList();
            return result;
        }

        public List<Skill> GenerateSkills(string raceName, List<Characteristic> characteristics)
        {
            var result = GenerateSkills(raceName);
            result.Add(new Skill(characteristics.FindByName(Characteristics.Dexterity).Value / 2) 
            { Name = Skills.Dodge.ToString() });
            result.Add(new Skill(characteristics.FindByName(Characteristics.Education).Value)
            { Name = Skills.LanguageOwn.ToString() });
            return result;
        }
    }
}
