using System.Reflection;
using CodeSamples.PropertyPermissionSystem.Attributes;

namespace CodeSamples.PropertyPermissionSystem;


/// <summary>
/// It's Example :)
/// </summary>
public class ModelDefaulter
{
    public void MakeThatDefault<T>(T model)
    {
        if (model is null)
        {
            return;
        }

        if (model.GetType()
                 .GetCustomAttributes<NullIgnoreAttribute>()
                 .FirstOrDefault() is not null)
        {
            return;
        }

        foreach (var property in model.GetType().GetProperties())
        {
            NullIgnoreAttribute? nullAttribute = property.GetCustomAttributes<NullIgnoreAttribute>().FirstOrDefault();

            if (nullAttribute is not null)
            {
                continue;
            }
            Type propertyType = property.PropertyType;

            if (Nullable.GetUnderlyingType(propertyType) != null)
            {
                propertyType = Nullable.GetUnderlyingType(propertyType) ?? property.PropertyType;
            }

            if (propertyType == typeof(int))
            {
                property.SetValue(model, -1);
            }
            else if (propertyType == typeof(decimal))
            {
                property.SetValue(model, -1.0m);
            }
            else if (propertyType == typeof(DateTimeOffset))
            {
                property.SetValue(model, DateTimeOffset.MinValue);
            }
            else if (propertyType == typeof(string))
            {
                property.SetValue(model, "");
            }
            else
            {
                property.SetValue(model, default);
            }
        }
    }
}