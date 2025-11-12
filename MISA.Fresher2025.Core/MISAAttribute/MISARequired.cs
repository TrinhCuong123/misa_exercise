namespace MISA.Fresher2025.Core.MISAAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class MISARequired : Attribute
    {
        public MISARequired(string error)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISACheckDuplicate : Attribute
    {
        public MISACheckDuplicate(string error)
        {

        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class MISAColumName : Attribute
    {
        string columName;
        public MISAColumName(string name)
        {
            columName = name;
        }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class MISATableName : Attribute
    {
        string tableName;
        public MISATableName(string name)
        {
            tableName = name;
        }
    }
}
