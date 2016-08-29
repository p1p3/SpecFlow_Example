using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowHelpers.Pages
{
    public interface ITePrestaHome : IPage
    {
        ITePrestaLogin ClickIngresar();
        ITePrestaRegistroVerificacionCelular ClickRegistrarse();
    }
}
