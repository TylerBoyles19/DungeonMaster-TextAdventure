using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Monster : Character
    {
        private int _minDamage;
        public int MaxDamage { get; set; }
        public string Description { get; set; }
        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                _minDamage = value > 0 && value <= MaxDamage ? value : 1;
            }//end set
        }//end MinDamage

        public Monster(string name, int life, int maxLife, int hitChance, int block, int xp, int minDamage, int maxDamage,
            string description)
            : base(name, life, maxLife, hitChance, block, xp)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Description = description;
        }//end FQCTOR

        public override string ToString()
        {
            string condition = "";

            if (Life >= MaxLife)
            {
                condition = "Uninjured";
            }//end if
            else if (Life <= MaxLife * .75)
            {
                condition = "injured";
            }//end else if 

            else if (Life <= MaxLife * .5)
            {
                condition = "Badly injured";
            }//end else if

            else
            {
                condition = "Near death";
            }//end else

            return string.Format("Description: {0}\nLife: {1},{2}\n\nCondition: {3}",
                Description,
                Life,
                MaxLife,
                condition
                );
        }//end ToString()

        public override int CalcDamage()
        {
            return new Random().Next(MinDamage, MaxDamage + 1);
        }//end CalcDamage
    }
}
