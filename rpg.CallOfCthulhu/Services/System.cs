using rpg.CallOfCthulhu.Models;
using rpg.CallOfCthulhu.Services;
using rpg.System.Interfaces;
using rpg.System.Models;
using System;

namespace rpg.CallOfCthulhu
{
    public class CallOfCthulhu : ISystem
    {
        public ICharacterService CharacterService { get; set; }
        public ICharacteristicService CharacteristicService { get; set; }
        public ISkillService SkillService { get; set; }
        private Races races;

        public CallOfCthulhu()
        {
            CharacterService = new CharacterService();
            CharacteristicService = new CharacteristicService();
            SkillService = new SkillService();
            races = new Races();
        }

        public Character CreateCharacter()
        {
            Character character = new Character();
            character.Race = races.GetRace("Human");
            character.Characteristics = CharacteristicService.GenerateCharacteristics(character.Race.Name);
            character.Skills = SkillService.GenerateSkills(character.Race.Name, character.Characteristics);
            return character;
        }
    }
}
