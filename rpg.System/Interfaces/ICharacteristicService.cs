using rpg.System.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rpg.System.Interfaces
{
    public interface ICharacteristicService
    {
        /// <summary>
        /// 
        /// </summary>
        public List<Characteristic> GenerateCharacteristics(string raceName);

        public Characteristic GetCharacteristic(string raceName, string characteristicName);
    }

    public static class Extensions
    {
        public static Characteristic FindByName(this List<Characteristic> list, string name)
        {
            return list.Find(_ => _.Name == name);
        }
    }
}
