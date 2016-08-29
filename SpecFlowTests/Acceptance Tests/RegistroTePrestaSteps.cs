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


        [Given(@"he presionado Registrarse")]
        public void DadoHePresionadoRegistrarse()
        {
            var homePage = ScenarioContext.Current.Get<ITePrestaHome>();
            var tePrestaLogin = homePage.ClickIngresar();
            ScenarioContext.Current.Set<ITePrestaLogin>(tePrestaLogin);
        }
        
        [Given(@"he ingresado mi documento único de identidad")]
        public void DadoHeIngresadoMiDocumentoUnicoDeIdentidad()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he confirmado mi número de documento")]
        public void DadoHeConfirmadoMiNumeroDeDocumento()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he ingresado un número celular diferente al registrado")]
        public void DadoHeIngresadoUnNumeroCelularDiferenteAlRegistrado()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he presionado enviar código de verificación")]
        public void DadoHePresionadoEnviarCodigoDeVerificacion()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he ingresado el código recibido en mi celular")]
        public void DadoHeIngresadoElCodigoRecibidoEnMiCelular()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he presionado verificar")]
        public void DadoHePresionadoVerificar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he ingresado mi correo electrónico")]
        public void DadoHeIngresadoMiCorreoElectronico()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he dado respuesta a las preguntas de seguridad")]
        public void DadoHeDadoRespuestaALasPreguntasDeSeguridad()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he ingresado mi contraseña de registro")]
        public void DadoHeIngresadoMiContrasenaDeRegistro()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he confirmado mi contraseña de registro")]
        public void DadoHeConfirmadoMiContrasenaDeRegistro()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"he seleccionado las preguntas personalizadas para recuperar mi contraseña")]
        public void DadoHeSeleccionadoLasPreguntasPersonalizadasParaRecuperarMiContrasena()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"presione registrar")]
        public void CuandoPresioneRegistrar()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"debo ingresar exitosamente a mi estado de cuenta")]
        public void EntoncesDeboIngresarExitosamenteAMiEstadoDeCuenta()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
