using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
namespace MonsterLibrary
{
    public class Skeleton : Monster
    {
        public bool IsArmored { get; set; }

        public Skeleton(string name, int life, int maxLife, int hitChance, int block, int xp, int minDamage, int maxDamage,
            string description)
            : base(name, life, maxLife, hitChance, block, xp, minDamage, maxDamage, description)
        {
            int randomizer = new Random().Next(1, 11);
            IsArmored = randomizer >= 8 ? true : false;
            Description += IsArmored ? "\nIt's wearing rusty, decrepit armor" : "";
        }//end FQCTOR

        public override int CalcBlock()
        {
            return IsArmored ? Block + Block / 2 : Block;
        }
    }
}
