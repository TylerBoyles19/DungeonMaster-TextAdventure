using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;
namespace PersonalDungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dungeon Quest");
            Console.Title = "Dungeon Quest";

            Console.WriteLine("Greetings Traveler! Welcome to the mystical dungeon of Rathnar. " +
                "Please tell me more about you.\nName: ");
            string userName = Console.ReadLine();
            Race characterRace = Race.Human;
            Weapon characterWeapon = new Weapon("Rusty Long sword", 1, 6, 5, false);

            Console.WriteLine("\nNow choose a race:\n" +
                "H)uman\n" +
                "D)warf\n" +
                "E)lf"
                );
            ConsoleKey userRace = Console.ReadKey(true).Key;
            switch (userRace)
            {
                case ConsoleKey.H:
                    characterRace = Race.Human;
                    characterWeapon = new Weapon("Rusty Long sword", 1, 6, 5, false);
                    break;

                case ConsoleKey.D:
                    characterRace = Race.Dwarf;
                    characterWeapon = new Weapon("Trusty Battle Axe", 1, 10, -6, true);
                    break;

                case ConsoleKey.E:
                    characterRace = Race.Elf;
                    characterWeapon = new Weapon("Elvish sword", 1, 10, 6, false);
                    break;



                default:
                    Console.WriteLine("That was not a vaild choice. Your punishment is a human");
                    break;
            }
            Console.Clear();


            Console.WriteLine("Interesting... I hope you are prepared for what lies ahead traveler." +
                "You will find a weapon in the first room. From there you will traverse the dungeon " +
                "in search of awesome loot and to maybe defeat the dungeon keeper himself! Good " +
                "luck... you'll need it. *You enter the dungeon, excited but terrifed by what the old " +
                "man said.*\n");

            Player player = new Player(userName, 50, 50, 65, 5, 0, characterRace, characterWeapon);

            bool exit = false;
            int score = 0;
            do
            {


                //Console.WriteLine(GetRoom() + "\n");
                Skeleton s1 = new Skeleton("Skeleton", 10, 10, 50, 5, 10, 1, 5, "The skeleton stands before you with a dead stare" +
                    "looking into your soul. It readys it's weapon to fight.");
                Monster m1 = new Monster("Zombie", 15, 15, 55, 4, 15, 1, 7, "The old rotting body of a previous adventurer approches you," +
                    "it seems hungry...");
                Monster m2 = new Monster("Necromancer", 20, 20, 65, 6, 20, 3, 10, "The necromacer challenges you for killing their " +
                    "minions.");
                Monster m3 = new Monster("Wraith", 13, 13, 50, 6, 20, 1, 7, "The pale shadowy figure sits there floating as you aproach.");
                Vampire v1 = new Vampire("Vampire Lord", 20, 20, 60, 7, 25, 3, 10, "A pale figure stands before you with blood dripping" +
                    "from it's fangs...");
                Monster m4 = new Monster("Rathnar", 100, 100, 55, 10, 1000000, 5, 10, "The ancient " +
                    "dragon stands before you!");
                Monster[] monsters =
                {
                    s1, s1, m1, m1, m3, m2, v1
                 };
                //Console.WriteLine("Standing before you is a " + monster.Name + ".\n");  
                Monster monster = monsters[new Random().Next(monsters.Length)];
                Console.Title = "Gold:" + score;
                Monster finalMonster = m4;
                if (score >= 1000)
                {
                    monster = m4;
                    Console.WriteLine("You approch a large set of doors. It says, 'those who brave the " +
                        "dungeon and aquire a large sum of gold will be able to enter'. You have bested" +
                        "many monsters to reach this room, the doors open and you see mounds of gold " +
                       "as you enter the mounds starts to fall and a large creature emerges...\n");
                    Console.WriteLine(m4.Name + " " + m4.Description);
                    Console.WriteLine("\n");

                } //end if

                else
                {
                    Console.WriteLine(GetRoom() + "\n");
                    Console.WriteLine("Standing before you is a " + monster.Name + ".\n");
                }



                bool reload = false;

                //ToDo add potions make a seperate method and put the funtionality for it there
                //as well to buy more potentially

                do
                {
                    Console.WriteLine("Choose and action\n" +
                   "A)ttack\n" +
                   "F)lee\n" +
                   "P)layer Stats\n" +
                   "M)onster Stats\n" +
                   "R)estore Health");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();

                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Combat.DoBattle(player, monster);
                            if (monster.Life < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("You Killed the {0}", monster.Name);
                                Console.ResetColor();
                                score += monster.XP;
                                player.XP += monster.XP;
                                reload = true;
                            }//end if 
                            if (m4.Life < 1)
                            {
                                Console.WriteLine("Rathnar lays at your feet... as you admire the wealth you gained, " +
                                    "a dark force surrounds you. You hear the old mans voice saying 'you are now the master of this dungeon..." +
                                    "bound forever until you meet your end to the new master of the dungeon'. " +
                                    "*You try and leave but some force holds you back...*");
                                exit = true;
                            }
                            break;

                        case ConsoleKey.F:
                            Console.WriteLine("RUN AWAY!!!");
                            Console.WriteLine("{0} attacks you as you flee!", monster.Name);
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;

                        case ConsoleKey.P:
                            Console.WriteLine(player);
                            break;

                        case ConsoleKey.M:
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.R:
                            Potions.UsePotion(player);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("{0} attacks you as you heal!", monster.Name);
                            Console.ResetColor();
                            Combat.DoAttack(monster, player);
                            break;

                        case ConsoleKey.Escape:
                            Console.WriteLine("Farwell traveler! Try again soon.");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid action. Try again.");
                            break;
                    }//end switch
                    if (player.Life < 1)
                    {
                        Console.WriteLine("You have been slain by the {0}!", monster.Name);
                        exit = true;
                    }//end if player dies

                } while (!reload && !exit);
            } while (!exit);
            Console.WriteLine("GAME OVER" +
                "");
        }//end Main()

        private static string GetRoom()
        {
            string[] rooms =
            {
                "This room smells strange, no doubt due to the weird sheets of black slime that drip from cracks in the ceiling and spread across the floor. The slime seeps from the shattered stone of the ceiling at a snails crawl, forming a mess of dangling walls of gook. As you watch, a bit of the stuff separates from a sheet and drops to the ground with a wet plop.",
                "This room is shattered. A huge crevasse shears the chamber in half, and the ground and ceilings are tilted away from it. It's as though the room was gripped in two enormous hands and broken like a loaf of bread. Someone has torn a tall stone door from its hinges somewhere else in the dungeon and used it to bridge the 15-foot gap of the chasm between the two sides of the room. Whatever did that must have possessed tremendous strength because the door is huge, and the enormous hinges look bent and mangled.",
                " You push open the stone door to this room and note that the only other exit is a door made of wood. It and the table shoved against it are warped and swollen. Indeed, the table only barely deserves that description. Its surface is rippled into waves and one leg doesn't even touch the floor. The door shows signs of someone trying to chop through from the other side, but it looks like they gave up.",
                "A flurry of bats suddenly flaps through the doorway, their screeching barely audible as they careen past your heads. They flap past you into the rooms and halls beyond. The room from which they came seems barren at first glance.",
                " A pungent, earthy odor greets you as you pull open the door and peer into this room. Mushrooms grow in clusters of hundreds all over the floor. Looking into the room is like looking down on a forest. Tall tangles of fungus resemble forested hills, the barren floor looks like a plain between the woods, and even a trickle of water and a puddle of water that pools in a low spot bears a resemblance to a river and lake, respectively.",
                " Rats inside the room shriek when they hear the door open, then they run in all directions from a putrid corpse lying in the center of the floor. As these creatures crowd around the edges of the room, seeking to crawl through a hole in one corner, they fight one another. The stinking corpse in the middle of the room looks human, but the damage both time and the rats have wrought are enough to make determining its race by appearance an extremely difficult task at best.",
            };
            Random rand = new Random();
            int indexNbr = rand.Next(rooms.Length);
            string room = rooms[indexNbr];
            return room;
        }//end GetRoom()      
    }//end Class
}//end namespace
