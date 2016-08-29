using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowHelpers.Pages
{
    public interface ITePrestaRegistroVerificacionCelular
    {
        void IngresarDocumentoIdentidad(string documento);
        void IngresarConfirmacionDocumento(string documento);
        void IngresoNumeroCelular(string celular);
        ITePrestaVerificacionCodigo ClickEnviarCodigoVerificacion();
    }
}
