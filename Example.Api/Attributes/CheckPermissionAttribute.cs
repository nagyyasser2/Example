using Example.Core.Enums;

namespace Example.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CheckPermissionAttribute(Permission permission) : Attribute
    {
        public Permission Permission { get; } = permission;
    }
}
