namespace STMDomain.Domain
{
    public class FamilyData : Entity
    {
        public float FamilyRevenue { get; set; }
        public int ResidenceQuantity { get; set; }
        public int ChildrenQuantity { get; set; }
        public bool IsSoloParent { get; set; }
    }
}