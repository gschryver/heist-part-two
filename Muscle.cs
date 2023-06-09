using System; 

namespace Heist {
    public class Muscle : IRobber {
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank) {
            bank.SecurityGuardScore -= SkillLevel;
            Console.WriteLine($"{Name} is using their muscles to disable the Security Guard. Decreased security {SkillLevel} points.");
            if (bank.SecurityGuardScore <= 0) {
                Console.WriteLine($"{Name} has unleashed a can of whoop arse on the Security Guard!");
            }
        }
    }
}