using System.Data;

namespace SpecFlowHelpers.Database.Definitions
{
    public interface IDataReaderEntityMapper<out TEntity>
    {
        TEntity MapToEntity(IDataReader row);
    }
}
