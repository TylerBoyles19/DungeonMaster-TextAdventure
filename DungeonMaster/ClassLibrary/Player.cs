using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        public Race PlayerRace { get; set; }
        public Weapon EquippedWeapon { get; set; }

        public Player(string name, int life, int maxLife, int hitChance, int block, int xp, Race playerRace, Weapon equippedWeapon)
            : base(name, life, maxLife, hitChance, block, xp)
        {
            PlayerRace = playerRace;
            EquippedWeapon = equippedWeapon;

            switch (PlayerRace)
            {
                case Race.Human:
                    Block += 5;
                    break;
                case Race.Dwarf:
                    MaxLife += 5;
                    Life += 5;
                    break;
                case Race.Elf:
                    HitChance += 10;
                    Block -= 5;
                    break;
            }
        }//end FQCTOR

        public override string ToString()
        {
            return string.Format("Name: {0}\n{1} of {2} life\nRace: {3}\nHit Chance: {4}%\nBlock Chance: {5}%\n" +
                "Equipped Weapon: {6}",
                Name,
                Life,
                MaxLife,
                PlayerRace,
                CalcHitChance(),
                Block,
                EquippedWeapon
                );
        }//end ToString()

        public override int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }//end CalcHitChance()

        public override int CalcDamage()
        {
            Random rand = new Random();
            int damage = rand.Next(EquippedWeapon.MinDamage, EquippedWeapon.MaxDamage + 1);
            return damage;
        }//end CalcDamage()
    }//end class
}//end namespace       

