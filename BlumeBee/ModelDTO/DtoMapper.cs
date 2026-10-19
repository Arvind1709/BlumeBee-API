using System;
using System.Reflection;

namespace BlumeBee.ModelDTO
{
    /// <summary>
    /// Copies matching public properties from an API request DTO to a domain model.
    /// Keep mapping explicit in a dedicated mapper if the model and DTO later diverge.
    /// </summary>
    public static class DtoMapper
    {
        public static TModel ToModel<TModel>(this object source)
            where TModel : new()
        {
            ArgumentNullException.ThrowIfNull(source);

            var target = new TModel();
            var sourceProperties = source.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
            var targetProperties = typeof(TModel).GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (var sourceProperty in sourceProperties)
            {
                if (!sourceProperty.CanRead)
                    continue;

                var targetProperty = Array.Find(
                    targetProperties,
                    property => property.Name == sourceProperty.Name &&
                                property.CanWrite &&
                                property.PropertyType == sourceProperty.PropertyType);

                if (targetProperty == null)
                    continue;

                targetProperty.SetValue(target, sourceProperty.GetValue(source));
            }

            return target;
        }
    }
}
