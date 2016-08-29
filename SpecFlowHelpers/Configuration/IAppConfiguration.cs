using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowHelpers.Configuration
{
    public interface IAppConfiguration
    {
        int CommandTimeoutSql { get; }

        string GetValue(string key);
    }
}
