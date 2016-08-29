using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowHelpers.Pages
{
    public interface ITePrestaLogin:IPage
    {
        void SetEmail(string email);
        void SetPassword(string password);
        ITePrestaDashboard Ingresar();
    }
}
