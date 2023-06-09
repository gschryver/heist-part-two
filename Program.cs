using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("-----------------");
            Console.WriteLine("Plan Your Heist!");
            Console.WriteLine("-----------------");

            List<IRobber> rolodex = new List<IRobber>();
            rolodex.Add(
                new Hacker()
                {
                    Name = "Coolmans5000",
                    Specialty = "Hacker",
                    SkillLevel = 50,
                    PercentageCut = 10
                }
            );

            rolodex.Add(
                new Muscle()
                {
                    Name = "The Schwarzenegger",
                    Specialty = "Muscle",
                    SkillLevel = 50,
                    PercentageCut = 10
                }
            );

            rolodex.Add(
                new LockSpecialist()
                {
                    Name = "Scooter",
                    Specialty = "Lock Specialist",
                    SkillLevel = 50,
                    PercentageCut = 10
                }
            );

            rolodex.Add(
                new Hacker()
                {
                    Name = "edgelord420",
                    Specialty = "Hacker",
                    SkillLevel = 50,
                    PercentageCut = 10
                }
            );

            rolodex.Add(
                new Muscle()
                {
                    Name = "John Cena",
                    Specialty = "Muscle",
                    SkillLevel = 50,
                    PercentageCut = 10
                }
            );

            // Print current number of operatives in rolodex
            Console.WriteLine($"There are currently {rolodex.Count} operatives in the rolodex.");

            while (true)
            {
                Console.WriteLine($"Enter a new operative's name:");
                string? newOperativeName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newOperativeName))
                {
                    break;
                }

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
                        Console.WriteLine(
                            "Invalid skill level. Please enter a number between 1 and 100."
                        );
                        continue;
                    }

                    if (newOperativeSkillLevel < 1 || newOperativeSkillLevel > 100)
                    {
                        Console.WriteLine(
                            "Invalid skill level. Please enter a number between 1 and 100."
                        );
                        continue;
                    }

                    break;
                }

                Console.WriteLine($"Enter a new operative's cut of the loot (1-100):");
                int newOperativePercentageCut;

                while (true)
                {
                    string? newOperativePercentageCutString = Console.ReadLine();
                    if (
                        !int.TryParse(
                            newOperativePercentageCutString,
                            out newOperativePercentageCut
                        )
                    )
                    {
                        Console.WriteLine(
                            "Invalid percentage cut. Please enter a number between 1 and 100."
                        );
                        continue;
                    }
                    if (newOperativePercentageCut < 1 || newOperativePercentageCut > 100)
                    {
                        Console.WriteLine(
                            "Invalid percentage cut. Please enter a number between 1 and 100."
                        );
                        continue;
                    }
                    break;
                }

                IRobber newOperative;
                string? specialtyName;

                if (newOperativeSpecialty == "1")
                {
                    specialtyName = "Hacker";
                    newOperative = new Hacker()
                    {
                        Name = newOperativeName,
                        Specialty = specialtyName,
                        SkillLevel = newOperativeSkillLevel,
                        PercentageCut = newOperativePercentageCut
                    };
                }
                else if (newOperativeSpecialty == "2")
                {
                    specialtyName = "Muscle";
                    newOperative = new Muscle()
                    {
                        Name = newOperativeName,
                        Specialty = specialtyName,
                        SkillLevel = newOperativeSkillLevel,
                        PercentageCut = newOperativePercentageCut
                    };
                }
                else
                {
                    specialtyName = "Lock Specialist";
                    newOperative = new LockSpecialist()
                    {
                        Name = newOperativeName,
                        Specialty = specialtyName,
                        SkillLevel = newOperativeSkillLevel,
                        PercentageCut = newOperativePercentageCut
                    };
                }

                rolodex.Add(newOperative);
                Console.WriteLine(
                    $"The new operative is {newOperative.Name}. They are a {specialtyName} with a skill level of {newOperativeSkillLevel} and a cut of {newOperativePercentageCut}%."
                );
                Console.WriteLine($"There are now {rolodex.Count} operatives in the rolodex.");
            }

            Bank bank = new Bank()
            {
                AlarmScore = new Random().Next(0, 101),
                VaultScore = new Random().Next(0, 101),
                SecurityGuardScore = new Random().Next(0, 101),
                CashOnHand = new Random().Next(50000, 1000001)
            };

            string mostSecureSystem;
            string leastSecureSystem;

            if (bank.AlarmScore >= bank.VaultScore && bank.AlarmScore >= bank.SecurityGuardScore)
            {
                mostSecureSystem = "Alarm";
            }
            else if (
                bank.VaultScore >= bank.AlarmScore && bank.VaultScore >= bank.SecurityGuardScore
            )
            {
                mostSecureSystem = "Vault";
            }
            else
            {
                mostSecureSystem = "Security Guards";
            }

            if (bank.AlarmScore <= bank.VaultScore && bank.AlarmScore <= bank.SecurityGuardScore)
            {
                leastSecureSystem = "Alarm";
            }
            else if (
                bank.VaultScore <= bank.AlarmScore && bank.VaultScore <= bank.SecurityGuardScore
            )
            {
                leastSecureSystem = "Vault";
            }
            else
            {
                leastSecureSystem = "Security Guards";
            }

            // Recon Report
            Console.WriteLine();
            Console.WriteLine("Recon Report");
            Console.WriteLine("------------");
            Console.WriteLine($"Most Secure System: {mostSecureSystem}");
            Console.WriteLine($"Least Secure System: {leastSecureSystem}");

            // Rolodex Report
            Console.WriteLine();
            Console.WriteLine("Rolodex Report");
            Console.WriteLine("--------------");

            for (int i = 0; i < rolodex.Count; i++)
            {
                Console.WriteLine(
                    $"{i + 1}. {rolodex[i].Name} is a {rolodex[i].Specialty} with a skill level of {rolodex[i].SkillLevel} and a cut of {rolodex[i].PercentageCut}%."
                );
            }

            List<IRobber> crew = new List<IRobber>();

            if (rolodex.Count > 0)
            {
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine(
                        $"Select an operative to include in the heist (1-{rolodex.Count}) or enter '0' to quit:"
                    );
                    string selectedOperativeString = Console.ReadLine();

                    if (selectedOperativeString == "0")
                    {
                        break;
                    }

                    if (
                        !int.TryParse(selectedOperativeString, out int selectedOperativeIndex)
                        || selectedOperativeIndex <= 0
                        || selectedOperativeIndex > rolodex.Count
                    )
                    {
                        Console.WriteLine(
                            $"Invalid selection. Please enter a number between 1 and {rolodex.Count}."
                        );
                        continue;
                    }

                    IRobber selectedOperative = rolodex[selectedOperativeIndex - 1];

                    if (crew.Contains(selectedOperative))
                    {
                        Console.WriteLine(
                            $"{selectedOperative.Name} has already been added to the crew."
                        );
                        continue;
                    }

                    if (selectedOperative.PercentageCut > bank.CashOnHand)
                    {
                        Console.WriteLine(
                            $"{selectedOperative.Name} requires a percentage cut of {selectedOperative.PercentageCut}%, which cannot be offered."
                        );
                        continue;
                    }

                    crew.Add(selectedOperative);
                    rolodex.RemoveAt(selectedOperativeIndex - 1);

                    Console.WriteLine($"{selectedOperative.Name} has been added to the crew.");

                    // Print the updated Rolodex report
                    Console.WriteLine();
                    Console.WriteLine("Updated Rolodex Report");
                    Console.WriteLine("-----------------------");

                    for (int i = 0; i < rolodex.Count; i++)
                    {
                        Console.WriteLine(
                            $"[{i + 1}] {rolodex[i].Name} ({rolodex[i].Specialty}): Skill Level {rolodex[i].SkillLevel}, Cut {rolodex[i].PercentageCut}%"
                        );
                    }
                }

                // Perform the heist
                Console.WriteLine();
                Console.WriteLine("Performing the heist...");
                Console.WriteLine("-----------------------");

                foreach (var crewMember in crew)
                {
                    crewMember.PerformSkill(bank);
                }

                if (bank.isSecure)
                {
                    Console.WriteLine("The heist was a failure.");
                }
                else
                {
                    Console.WriteLine("The heist was a success!");
                    Console.WriteLine($"The crew made off with ${bank.CashOnHand}!");

                    int totalPercentage = 0;
                    foreach (var crewMember in crew)
                    {
                        totalPercentage += crewMember.PercentageCut;
                    }
                    int remainingCash = bank.CashOnHand;

                    Console.WriteLine();
                    Console.WriteLine("Crew Report");
                    Console.WriteLine("-----------");
                    foreach (IRobber operative in crew)
                    {
                        int operativeCut = (int)(bank.CashOnHand * operative.PercentageCut / 100.0);
                        remainingCash -= operativeCut;
                        Console.WriteLine(
                            $"{operative.Name} ({operative.Specialty}): Skill Level {operative.SkillLevel}, Cut {operative.PercentageCut}%, Take: ${operativeCut}"
                        );
                    }
                    Console.WriteLine();
                    Console.WriteLine("Organizer's Report");
                    Console.WriteLine("------------------");
                    Console.WriteLine($"Your take: ${remainingCash}");
                }
            }
        }
    }
}
