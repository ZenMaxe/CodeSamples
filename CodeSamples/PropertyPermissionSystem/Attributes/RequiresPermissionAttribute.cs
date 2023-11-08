namespace CodeSamples.PropertyPermissionSystem.Attributes;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
public class RequiresPermissionAttribute : Attribute
{
    public string PermissionName { get; set; }
    public PermissionType Type { get; set; }


    public RequiresPermissionAttribute(string permissionName,
                                       PermissionType type)
    {
        PermissionName = permissionName;
        Type = type;
    }
}

public enum PermissionType
{
    Read,
    Edit
}