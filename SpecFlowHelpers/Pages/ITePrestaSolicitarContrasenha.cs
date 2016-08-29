using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowHelpers.Pages
{
    public interface ITePrestaSolicitarContrasenha
    {
        void IngresarContrasenha(string password);
        void IngresarConfirmacionContrasena(string password);
        ITePrestaRegistroPreguntasPersonalizadas ClickSiguiente();
    }
}
