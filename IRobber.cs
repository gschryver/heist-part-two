namespace Heist {
    public interface IRobber {
        public string? Name { get; set; }
        
        public string? Specialty { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank);
    }
}