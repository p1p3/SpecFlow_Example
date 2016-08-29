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
            tePrestaVerCel.IngresarDocumentoIdentidad(Constants.SignUpUserId + "-9");
        }

        [Given(@"he confirmado mi número de documento")]
        public void DadoHeConfirmadoMiNumeroDeDocumento()
        {
            var tePrestaVerCel = ScenarioContext.Current.Get<ITePrestaRegistroVerificacionCelular>();
            tePrestaVerCel.IngresarConfirmacionDocumento(Constants.SignUpUserId + "-9");
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
            // ScenarioContext.Current.Pending();
        }

        [Given(@"he ingresado mi contraseña de registro")]
        public void DadoHeIngresadoMiContrasenaDeRegistro()
        {
            // ScenarioContext.Current.Pending();
        }

        [Given(@"he confirmado mi contraseña de registro")]
        public void DadoHeConfirmadoMiContrasenaDeRegistro()
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"he seleccionado las preguntas personalizadas para recuperar mi contraseña")]
        public void DadoHeSeleccionadoLasPreguntasPersonalizadasParaRecuperarMiContrasena()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"presione registrar")]
        public void CuandoPresioneRegistrar()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"debo ingresar exitosamente a mi estado de cuenta")]
        public void EntoncesDeboIngresarExitosamenteAMiEstadoDeCuenta()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
