namespace NovinCommerce.Permissions;

public static class NovinCommercePermissions
{
    public const string GroupName = "NovinCommerce";
    public const string GroupCompanyManagementName = "CompanyManagement";

    //Add your own permission names. Example:
    //public const string MyPermission1 = GroupName + ".MyPermission1";

    public static class Companies
    {
        public const string Default = GroupCompanyManagementName + ".Companies";
        public const string Create = Default + ".Create";
        public const string Edit = Default + ".Edit";
        public const string Delete = Default + ".Delete";
    }
}