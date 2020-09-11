using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;

namespace MonsterLibrary
{
    public class Vampire : Monster
    {
        public Vampire(string name, int life, int maxLife, int hitChance, int block, int xp, int minDamage, int maxDamage,
         string description)
          : base(name, life, maxLife, hitChance, block, xp, minDamage, maxDamage, description)
        {
            if (DateTime.Now.Hour > 20 || DateTime.Now.Hour < 6)
            {
                MaxLife += 10;
                Life += 10;
                HitChance += 5;
                MaxDamage += 2;
                XP += 10;
                Description += "\nIt appears especially strong due to the late hour...";
            }

        }
    }
}