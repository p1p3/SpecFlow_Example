using System.Data;

namespace SpecFlowHelpers.Database.Definitions.Manager
{
    public interface IDataReaderEntityMapper<out TEntity>
    {
        TEntity MapToEntity(IDataReader row);
    }
}
