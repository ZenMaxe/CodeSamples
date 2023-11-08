namespace CodeSamples.PropertyPermissionSystem.Attributes;

[AttributeUsage(
    AttributeTargets.Class | AttributeTargets.Property,
    AllowMultiple = false,
    Inherited = true)]
public class NullIgnoreAttribute : Attribute { }