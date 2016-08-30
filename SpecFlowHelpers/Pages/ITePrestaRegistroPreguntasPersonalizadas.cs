﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowHelpers.Pages
{
    public interface ITePrestaRegistroPreguntasPersonalizadas
    {
        void ResponderPreguntas(params string[] respuestas);
        ITePrestaDashboard ClickContinuar();
    }
}
