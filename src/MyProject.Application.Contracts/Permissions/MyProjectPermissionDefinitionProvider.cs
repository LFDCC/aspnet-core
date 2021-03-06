using MyProject.Localization;

using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MyProject.Permissions
{
    public class MyProjectPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(MyProjectPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(MyProjectPermissions.MyPermission1, L("Permission:MyPermission1"));

            var userPermission = myGroup.AddPermission(MyProjectPermissions.User.Default, L("Permission:User"));
            userPermission.AddChild(MyProjectPermissions.User.Create, L("Permission:Create"));
            userPermission.AddChild(MyProjectPermissions.User.Update, L("Permission:Update"));
            userPermission.AddChild(MyProjectPermissions.User.Delete, L("Permission:Delete"));
            userPermission.AddChild(MyProjectPermissions.User.ManagePermissions, L("Permission:ChangePermissions"));

            var rolePermission = myGroup.AddPermission(MyProjectPermissions.Role.Default, L("Permission:Role"));
            rolePermission.AddChild(MyProjectPermissions.Role.Create, L("Permission:Create"));
            rolePermission.AddChild(MyProjectPermissions.Role.Update, L("Permission:Update"));
            rolePermission.AddChild(MyProjectPermissions.Role.Delete, L("Permission:Delete"));
            rolePermission.AddChild(MyProjectPermissions.Role.ManagePermissions, L("Permission:ChangePermissions"));


            var userRolePermission = myGroup.AddPermission(MyProjectPermissions.UserRole.Default, L("Permission:UserRole"));
            userRolePermission.AddChild(MyProjectPermissions.UserRole.Create, L("Permission:Create"));
            userRolePermission.AddChild(MyProjectPermissions.UserRole.Update, L("Permission:Update"));
            userRolePermission.AddChild(MyProjectPermissions.UserRole.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MyProjectResource>(name);
        }
    }
}
