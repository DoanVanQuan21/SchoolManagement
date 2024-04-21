namespace SchoolManagement.GlobalShared.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
    public class IsIDAttribute : Attribute
    {
        public bool IsID { get; set; } = false;

        public IsIDAttribute(bool isID)
        {
            IsID = isID;
        }
    }
}