using System; 

namespace Heist {
    public class LockSpecialist : IRobber {
        public string? Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank) {
            bank.AlarmScore -= SkillLevel;
            Console.WriteLine($"{Name} is picking the lock. Decreased security {SkillLevel} points.");
            if (bank.AlarmScore <= 0) {
                Console.WriteLine($"{Name} has picked the lock!");
            }
        }
    }
}