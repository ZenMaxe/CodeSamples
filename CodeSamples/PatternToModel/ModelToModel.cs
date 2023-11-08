using CodeSamples.PatternToModel.Entities;

namespace CodeSamples.PatternToModel;

public class ModelToModel
{
    public static void SetValuesFromRawToFilled(RawDebitDescription raw,
    DebitDescriptionCreateViewModel filled)
{
    foreach (var property in typeof(RawDebitDescription).GetProperties())
    {
        // Check if the boolean value is true
        if (property.PropertyType != typeof(bool))
            continue;

        var filledProperty = typeof(DebitDescriptionCreateViewModel).GetProperty(property.Name)!;
        Type propertyType = filledProperty.PropertyType;

        if (Nullable.GetUnderlyingType(propertyType) != null)
        {
            propertyType = Nullable.GetUnderlyingType(propertyType) ?? filledProperty.PropertyType;
        }
        if (!(bool)property.GetValue(raw))
        {
            if (propertyType == typeof(int))
            {
                filledProperty.SetValue(filled, -1);
            }
            else if (propertyType == typeof(decimal))
            {
                filledProperty.SetValue(filled, -1.0m);
            }
            else if (propertyType == typeof(DateTimeOffset))
            {
                filledProperty.SetValue(filled, DateTimeOffset.MinValue);
            }
            else if (propertyType == typeof(string))
            {
                filledProperty.SetValue(filled, "");
            }
            else if (propertyType == typeof(bool))
            {
                filledProperty.SetValue(filled, false);
            }
            else
            {
                filledProperty.SetValue(filled, default);
            }
        }
        else
        {
            if (propertyType == typeof(int))
            {
                filledProperty.SetValue(filled, 0);
            }
            else if (propertyType == typeof(decimal))
            {
                filledProperty.SetValue(filled, 0.0m);
            }
            else if (propertyType == typeof(DateTimeOffset))
            {
                filledProperty.SetValue(filled, DateTimeOffset.UtcNow);
            }
            else if (propertyType == typeof(string))
            {
                filledProperty.SetValue(filled, "پیشفرض");
            }
            else if (propertyType == typeof(bool))
            {
                filledProperty.SetValue(filled, true);
            }
            else
            {
                filledProperty.SetValue(filled, default);
            }
        }
    }
}
}