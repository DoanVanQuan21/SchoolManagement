namespace SchoolManagement.GlobalShared.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = false)]
    public class IsHeaderExcelAttribute : Attribute
    {
        public bool IsHeaderExcel { get; set; } = true;

        public IsHeaderExcelAttribute(bool isHeaderExcel)
        {
            IsHeaderExcel = isHeaderExcel;
        }
    }
}