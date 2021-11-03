using rpg.CallOfCthulhu.Models;
using rpg.System.Interfaces;
using rpg.System.Models;

namespace rpg.CallOfCthulhu.Services
{
    public class CallOfCthulhu : ISystem
    {
        public ICharacterService CharacterService { get; set; }
        public ICharacteristicService CharacteristicService { get; set; }
        public ISkillService SkillService { get; set; }

        public CallOfCthulhu()
        {
            CharacterService = new CharacterService();
            CharacteristicService = new CharacteristicService();
            SkillService = new SkillService();
        }

        public Character CreateCharacter()
        {
            var character = new Character
            {
                Race = Races.All.Find(_ => _.Name == Config.Races.Human)
            };
            character.Characteristics = CharacteristicService.GenerateCharacteristics(character.Race!.Name);
            character.Skills = SkillService.GenerateSkills(character.Race.Name, character.Characteristics);
            return character;
        }
    }
}
