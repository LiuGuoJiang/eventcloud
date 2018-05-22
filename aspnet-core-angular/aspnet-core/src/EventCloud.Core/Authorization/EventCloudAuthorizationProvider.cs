using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace EventCloud.Authorization
{
    public class EventCloudAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            context.CreatePermission(PermissionNames.Pages_Events, L("Events"),multiTenancySides:MultiTenancySides.Tenant);

            var BlogPermission = context.CreatePermission(PermissionNames.Pages_Blogs, L("Blogs"));
            var NotePermission = BlogPermission.CreateChildPermission(PermissionNames.Pages_Blogs_Notes, L("Notes"));
            NotePermission.CreateChildPermission(PermissionNames.Blogs_Notes_Edit, L("EditNotes"));
            NotePermission.CreateChildPermission(PermissionNames.Blogs_Notes_Delete, L("DeleteNotes"));
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, EventCloudConsts.LocalizationSourceName);
        }
    }
}
