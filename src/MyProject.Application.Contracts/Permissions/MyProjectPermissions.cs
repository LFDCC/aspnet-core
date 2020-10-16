namespace MyProject.Permissions
{
    public static class MyProjectPermissions
    {
        public const string GroupName = "MyProject";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class User
        {
            public const string Default = GroupName + ".User";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class Role
        {
            public const string Default = GroupName + ".Role";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }

        public class UserRole
        {
            public const string Default = GroupName + ".UserRole";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}
