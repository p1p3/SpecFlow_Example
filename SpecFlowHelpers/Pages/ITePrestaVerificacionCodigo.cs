﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowHelpers.Pages
{
    public interface ITePrestaVerificacionCodigo
    {
        void IngresarCodigoVerificacion(string codigo);
        void ClickVerificar();
        void IngresarCorreoElectronico(string correo);
        ITePrestaRegistroPreguntasSeguridad ClickContinuar();
    }
}
