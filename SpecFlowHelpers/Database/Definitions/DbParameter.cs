using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace SpecFlowHelpers.Database.Definitions
{
    public class DbParameter
    {
        public string Name { get; set; }

        public ParameterDirection Direction { get; set; }

        public object Value { get; set; }

        public int Size { get; set; }

        public DbParameter(string name, ParameterDirection direction, object value)
        {
            Name = name;
            Direction = direction;
            Value = value;
            Size = 0;
        }

        [ExcludeFromCodeCoverage]
        public DbParameter(string name, ParameterDirection direction, object value, int size)
        {
            Name = name;
            Direction = direction;
            Value = value;
            Size = size;
        }
    }
}
