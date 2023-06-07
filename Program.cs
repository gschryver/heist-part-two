using System;
using System.Collections.Generic;



namespace Heist {
    class Program {
        public static void Main (string[] args) {
        Console.WriteLine();
        Console.WriteLine ("-----------------");
        Console.WriteLine ("Plan Your Heist!");
        Console.WriteLine ("-----------------");
        

           List<IRobber> rolodex = new List<IRobber>();
            rolodex.Add(new Hacker() {
                Name = "Coolmans5000",
                SkillLevel = 50,
                PercentageCut = 10
            });

            rolodex.Add(new Muscle() {
                Name = "The Schwarzenegger",
                SkillLevel = 50,
                PercentageCut = 10
            });

            rolodex.Add(new LockSpecialist() {
                Name = "Scooter",
                SkillLevel = 50,
                PercentageCut = 10
            });

            rolodex.Add(new Hacker() {
                Name = "edgelord420",
                SkillLevel = 50,
                PercentageCut = 10
            });

            rolodex.Add(new Muscle() {
                Name = "John Cena",
                SkillLevel = 50,
                PercentageCut = 10
            });

            // Print current number of operatives in rolodex
            Console.WriteLine($"There are currently {rolodex.Count} operatives in the rolodex.");

            Console.WriteLine($"Enter a new operative's name:");
            string? newOperativeName = Console.ReadLine();

            Console.WriteLine($"Choose from the following specialties:");
            Console.WriteLine($"1. Hacker (Disables alarms)");
            Console.WriteLine($"2. Muscle (Disarms guards)");
            Console.WriteLine($"3. Lock Specialist (Cracks vault)");
            Console.WriteLine($"Enter a new operative's specialty:");
            string? newOperativeSpecialty = Console.ReadLine();

            Console.WriteLine($"Enter a new operative's skill level (1-100):");
            int newOperativeSkillLevel;

            while (true)
{
                string? newOperativeSkillLevelString = Console.ReadLine();
                if (!int.TryParse(newOperativeSkillLevelString, out newOperativeSkillLevel))
                {
                    Console.WriteLine("Invalid skill level. Please enter a number between 1 and 100.");
                    continue;
                }

                if (newOperativeSkillLevel < 1 || newOperativeSkillLevel > 100)
                {
                    Console.WriteLine("Invalid skill level. Please enter a number between 1 and 100.");
                    continue;
                }

                break;
            }
            
            Console.WriteLine($"Enter a new operative's cut of the loot (1-100):");
            int newOperativePercentageCut;

            while (true) {
                string? newOperativePercentageCutString = Console.ReadLine();
                if (!int.TryParse(newOperativePercentageCutString, out newOperativePercentageCut)) {
                    Console.WriteLine("Invalid percentage cut. Please enter a number between 1 and 100.");
                    continue;
                }
                if (newOperativePercentageCut < 1 || newOperativePercentageCut > 100) {
                    Console.WriteLine("Invalid percentage cut. Please enter a number between 1 and 100.");
                    continue;
                }
                break;
            }

            IRobber newOperative;
            string? specialtyName; 

            if (newOperativeSpecialty == "1") {
                specialtyName = "Hacker";
                newOperative = new Hacker() {
                    Name = newOperativeName,
                    SkillLevel = newOperativeSkillLevel,
                    PercentageCut = newOperativePercentageCut
                };
            } else if (newOperativeSpecialty == "2") {
                specialtyName = "Muscle";
                newOperative = new Muscle() {
                    Name = newOperativeName,
                    SkillLevel = newOperativeSkillLevel,
                    PercentageCut = newOperativePercentageCut
                };
            } else {
                specialtyName = "Lock Specialist";
                newOperative = new LockSpecialist() {
                    Name = newOperativeName,
                    SkillLevel = newOperativeSkillLevel,
                    PercentageCut = newOperativePercentageCut
                };
            }

            rolodex.Add(newOperative);
            Console.WriteLine($"The new operative is {newOperative.Name}. They are a {specialtyName} with a skill level of {newOperativeSkillLevel} and a cut of {newOperativePercentageCut}%.");
            Console.WriteLine($"There are now {rolodex.Count} operatives in the rolodex.");
        }
    }
}

