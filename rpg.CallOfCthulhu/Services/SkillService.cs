using rpg.CallOfCthulhu.Models;
using rpg.System.Interfaces;
using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static rpg.CallOfCthulhu.Services.CharacteristicService;

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
            Shotgun, SleightOfhand, Spear, SpotHidden, Stealth, SubmachineGun, Survival, Sword, Swim,
            Throw, Track,
            Whip,
            Zoology
        }
        public List<Skill> GenerateSkills(string raceName)
        {
            Races races = new Races();
            Race race = races.GetRace(raceName);
            List<Skill> result = race.Skills;
            return result;
        }

        public List<Skill> GenerateSkills(string raceName, List<Characteristic> characteristics)
        {
            var result = GenerateSkills(raceName);
            result.Add(new Skill(characteristics.FindByName(Chars.Dexterity.ToString()).Value / 2) 
            { Name = Skills.Dodge.ToString() });
            result.Add(new Skill(characteristics.FindByName(Chars.Education.ToString()).Value)
            { Name = Skills.LanguageOwn.ToString() });
            return result;
        }
    }
}
