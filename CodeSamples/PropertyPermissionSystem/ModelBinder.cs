using System.Reflection;
using CodeSamples.PropertyPermissionSystem.Attributes;

namespace CodeSamples.PropertyPermissionSystem;

public class ModelBinder
{
        public async Task<T> ApplyPermissionsAndPopulateProperties<T, X>(X model, string userId) where T : class
    {
        var modelType = typeof(X);

        foreach (var property in modelType.GetProperties())
        {
            var readPermission = property.GetCustomAttributes<RequiresPermissionAttribute>()
                .FirstOrDefault(attr => attr.Type == PermissionType.Read);

            var editPermission = property.GetCustomAttributes<RequiresPermissionAttribute>()
                .FirstOrDefault(attr => attr.Type == PermissionType.Edit);
            

            if (readPermission != null)
            {
                var hasReadPermission = false;//await _roleService.UserHasPermission(userId, readPermission.PermissionName);
                if (!hasReadPermission)
                {
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

            if (editPermission != null)
            {
                var hasEditPermission = false;//await _roleService.UserHasPermission(userId, editPermission.PermissionName);

                if (!hasEditPermission)
                {
                    var editableStatusProperty = modelType.GetProperty($"{property.Name}Editable");
                    if (editableStatusProperty != null)
                    {
                        editableStatusProperty.SetValue(model, false);
                    }

                    //property.SetValue(model, null);
                }
                else
                {
                    var editableStatusProperty = modelType.GetProperty($"{property.Name}Editable");
                    if (editableStatusProperty != null)
                    {
                        editableStatusProperty.SetValue(model, true);
                    }
                }
            }
        }
        var mappedModel = _mapper.Map<T>(model);
        return mappedModel;
    }
    public async Task<T> ApplyPermissionsAndPopulateProperties<T>(T model, string userId) where T : class
    {
        var modelType = typeof(T);

        foreach (var property in modelType.GetProperties())
        {
            var readPermission = property.GetCustomAttributes<RequiresPermissionAttribute>()
                .FirstOrDefault(attr => attr.Type == PermissionType.Read);

            var editPermission = property.GetCustomAttributes<RequiresPermissionAttribute>()
                .FirstOrDefault(attr => attr.Type == PermissionType.Edit);

            if (readPermission != null)
            {
                var hasReadPermission =  false // Need Role Service
                if (!hasReadPermission)
                {
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

            if (editPermission != null)
            {
                var hasEditPermission = false; // Need Role Service

                if (!hasEditPermission)
                {
                    var editableStatusProperty = modelType.GetProperty($"{property.Name}Editable");
                    if (editableStatusProperty != null)
                    {
                        editableStatusProperty.SetValue(model, false);
                    }

                }
                else
                {
                    var editableStatusProperty = modelType.GetProperty($"{property.Name}Editable");
                    if (editableStatusProperty != null)
                    {
                        editableStatusProperty.SetValue(model, true);
                    }
                }
            }
        }
        return model;
    }
}