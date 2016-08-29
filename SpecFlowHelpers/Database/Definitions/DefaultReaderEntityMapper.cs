using System;
using System.Data;
using System.Reflection;

namespace SpecFlowHelpers.Database.Definitions
{
    public class DefaultReaderEntityMapper<TEntity> : IDataReaderEntityMapper<TEntity> where TEntity : new()
    {
        public TEntity MapToEntity(IDataReader reader)
        {
            TEntity recordEntity = new TEntity();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetValue(i) != DBNull.Value)
                {
                    var currentProperty = GetMappedProperty(reader.GetName(i));

                    if (currentProperty != null)
                    {
                        currentProperty.SetValue(recordEntity, reader.GetValue(i), null);
                    }
                }
            }

            return recordEntity;
        }

        private PropertyInfo GetMappedProperty(string field)
        {
            var entityType = typeof(TEntity);
            var properties = entityType.GetProperties();
            var fieldProperty = (PropertyInfo)null;

            foreach (var property in properties)
            {
                var attribute = property.GetCustomAttribute<DataFieldMappingAttribute>();

                if (attribute != null && attribute.MappedField.Equals(field, StringComparison.OrdinalIgnoreCase))
                {
                    fieldProperty = property;
                    break;
                }
            }

            return fieldProperty;
        }
    }
}
