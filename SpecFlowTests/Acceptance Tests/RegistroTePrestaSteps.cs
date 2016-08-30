using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpecFlowHelpers;
using SpecFlowHelpers.Database.Definitions;
using SpecFlowHelpers.Pages;
using SpecFlowTests.Utils;
using TechTalk.SpecFlow;

namespace SpecFlowTests.Acceptance_Tests
{
    [Binding]
    public class RegistroTePrestaSteps
    {
        private readonly ITestDriver _testDriver;
        private readonly ITeprestaFunctions _teprestaFunctions;

        public RegistroTePrestaSteps(ITestDriver testDriver, ITeprestaFunctions teprestaFunctions)
        {
            _testDriver = testDriver;
            _teprestaFunctions = teprestaFunctions;
        }

        [BeforeScenario]
        public void Setup()
        {
            _testDriver.Start();
            _teprestaFunctions.DeleteUser(Constants.SignUpEmail);
        }

        [AfterScenario]
        public void TearDown()
        {
            _testDriver.Stop();
        }


        [Given(@"he presionado Registrarse")]
        public void DadoHePresionadoRegistrarse()
        {
            var homePage = ScenarioContext.Current.Get<ITePrestaHome>();
            var tePrestaLogin = homePage.ClickRegistrarse();
            ScenarioContext.Current.Set<ITePrestaRegistroVerificacionCelular>(tePrestaLogin);
        }

        [Given(@"he ingresado mi documento único de identidad")]
        public void DadoHeIngresadoMiDocumentoUnicoDeIdentidad()
        {
            var tePrestaVerCel = ScenarioContext.Current.Get<ITePrestaRegistroVerificacionCelular>();
            tePrestaVerCel.IngresarDocumentoIdentidad(Constants.SignUpUserId);
        }

        [Given(@"he confirmado mi número de documento")]
        public void DadoHeConfirmadoMiNumeroDeDocumento()
        {
            var tePrestaVerCel = ScenarioContext.Current.Get<ITePrestaRegistroVerificacionCelular>();
            tePrestaVerCel.IngresarConfirmacionDocumento(Constants.SignUpUserId);
        }

        [Given(@"he ingresado un número celular diferente al registrado")]
        public void DadoHeIngresadoUnNumeroCelularDiferenteAlRegistrado()
        {
            var tePrestaVerCel = ScenarioContext.Current.Get<ITePrestaRegistroVerificacionCelular>();
            tePrestaVerCel.IngresoNumeroCelular(Constants.SignUpCellPhone);
        }

        [Given(@"he presionado enviar código de verificación")]
        public void DadoHePresionadoEnviarCodigoDeVerificacion()
        {
            var tePrestaVerCel = ScenarioContext.Current.Get<ITePrestaRegistroVerificacionCelular>();
            tePrestaVerCel.ClickEnviarCodigoVerificacion();
        }

        [Given(@"he ingresado el código recibido en mi celular")]
        public void DadoHeIngresadoElCodigoRecibidoEnMiCelular()
        {
            var tePrestaVerCel = ScenarioContext.Current.Get<ITePrestaRegistroVerificacionCelular>();
            tePrestaVerCel.IngresarCodigoVerificacion(Constants.PinSMS);
        }

        [Given(@"he presionado verificar")]
        public void DadoHePresionadoVerificar()
        {
            var tePrestaVerCel = ScenarioContext.Current.Get<ITePrestaRegistroVerificacionCelular>();
            tePrestaVerCel.ClickVerificar();
        }

        [Given(@"he ingresado mi correo electrónico")]
        public void DadoHeIngresadoMiCorreoElectronico()
        {
            var tePrestaVerCel = ScenarioContext.Current.Get<ITePrestaRegistroVerificacionCelular>();
            tePrestaVerCel.IngresarCorreoElectronico(Constants.SignUpEmail);
        }

        [Given(@"he presionado continuar")]
        public void DadoHePresionadoContinuar()
        {
            var tePrestaVerCel = ScenarioContext.Current.Get<ITePrestaRegistroVerificacionCelular>();
            var tePrestaPreguntasSeguridad = tePrestaVerCel.ClickContinuar();
            ScenarioContext.Current.Set<ITePrestaRegistroPreguntasSeguridad>(tePrestaPreguntasSeguridad);
        }


        [Given(@"he dado respuesta a las preguntas de seguridad")]
        public void DadoHeDadoRespuestaALasPreguntasDeSeguridad()
        {
            var tePrestaPreguntasSeguridad = ScenarioContext.Current.Get<ITePrestaRegistroPreguntasSeguridad>();
            var respuestas = new[] { 0, 0, 0, 0 };
            tePrestaPreguntasSeguridad.ResponderPreguntas(respuestas);
        }

        [Given(@"he presionado validar preguntas de seguridad")]
        public void DadoHePresionadoValidarPreguntasDeSeguridad()
        {
            var tePrestaPreguntasSeguridad = ScenarioContext.Current.Get<ITePrestaRegistroPreguntasSeguridad>();
            var tePrestaSolicitarContrasenha = tePrestaPreguntasSeguridad.ClickValidar();
            ScenarioContext.Current.Set<ITePrestaRegistroSolicitarContrasenha>(tePrestaSolicitarContrasenha);
        }


        [Given(@"he ingresado mi contraseña de registro")]
        public void DadoHeIngresadoMiContrasenaDeRegistro()
        {
            var tePrestaSolicitarContrasenha = ScenarioContext.Current.Get<ITePrestaRegistroSolicitarContrasenha>();
            tePrestaSolicitarContrasenha.IngresarContrasenha(Constants.SignUpPassword);
        }

        [Given(@"he confirmado mi contraseña de registro")]
        public void DadoHeConfirmadoMiContrasenaDeRegistro()
        {
            var tePrestaSolicitarContrasenha = ScenarioContext.Current.Get<ITePrestaRegistroSolicitarContrasenha>();
            tePrestaSolicitarContrasenha.IngresarConfirmacionContrasena(Constants.SignUpPassword);
            var tePrestaPreguntasPersonalizadas = tePrestaSolicitarContrasenha.ClickSiguiente();
            ScenarioContext.Current.Set<ITePrestaRegistroPreguntasPersonalizadas>(tePrestaPreguntasPersonalizadas);
        }

        [Given(@"he seleccionado las preguntas personalizadas para recuperar mi contraseña")]
        public void DadoHeSeleccionadoLasPreguntasPersonalizadasParaRecuperarMiContrasena()
        {
            var tePrestaPreguntasPersonalizadas = ScenarioContext.Current.Get<ITePrestaRegistroPreguntasPersonalizadas>();
            var respuestas = new[] { "Respuesta pruebas", "Respuesta pruebas", "Respuesta pruebas", "Respuesta pruebas", "Respuesta pruebas" };
            tePrestaPreguntasPersonalizadas.ResponderPreguntas(respuestas);
        }


        [When(@"presione continuar para terminar el proceso de registro")]
        public void CuandoPresioneContinuarParaTerminarElProcesoDeRegistro()
        {
            var tePrestaPreguntasPersonalizadas = ScenarioContext.Current.Get<ITePrestaRegistroPreguntasPersonalizadas>();
            var tePrestaEstadoCuenta = tePrestaPreguntasPersonalizadas.ClickContinuar();
            ScenarioContext.Current.Set<ITePrestaDashboard>(tePrestaEstadoCuenta);
        }



        [Then(@"debo ingresar exitosamente a mi estado de cuenta")]
        public void EntoncesDeboIngresarExitosamenteAMiEstadoDeCuenta()
        {
            var tePrestaDashBoard = ScenarioContext.Current.Get<ITePrestaDashboard>();
            var msgBienvenida = tePrestaDashBoard.MensajeBienvenida();
            var mensajeCorrecto = msgBienvenida.Contains(Constants.WelcomeMessage);
            Assert.IsTrue(mensajeCorrecto);
        }


    }
}
