﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpecFlowTests.AcceptanceTests
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class RegistroTePrestaFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RegistroTePresta.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("es-CO"), "RegistroTePresta", "Yo como cliente de una de las marcas de Grupo Gente Te Presta (Beto Te Presta, Pe" +
                    "pe Te Presta, Chamba Te Presta, Chepe Te Presta)\r\nQuiero registrarme en la sucur" +
                    "sal virtual \r\nPara solicitar créditos", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "RegistroTePresta")))
            {
                SpecFlowTests.AcceptanceTests.RegistroTePrestaFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Registro usuario con teléfono diferente")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "RegistroTePresta")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("HU017,HU018")]
        public virtual void RegistroUsuarioConTelefonoDiferente()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Registro usuario con teléfono diferente", new string[] {
                        "HU017,HU018"});
#line 7
this.ScenarioSetup(scenarioInfo);
#line 8
 testRunner.Given("he ingresado a te presta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line 9
  testRunner.And("he presionado Registrarse", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 10
  testRunner.And("he ingresado mi documento único de identidad", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 11
  testRunner.And("he confirmado mi número de documento", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 12
  testRunner.And("he ingresado un número celular diferente al registrado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 13
  testRunner.And("he presionado enviar código de verificación", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 14
  testRunner.And("he ingresado el código recibido en mi celular", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 15
  testRunner.And("he presionado verificar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 16
  testRunner.And("he ingresado mi correo electrónico", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 17
  testRunner.And("he presionado continuar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 18
  testRunner.And("he dado respuesta a las preguntas de seguridad", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 19
  testRunner.And("he ingresado mi contraseña de registro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 20
  testRunner.And("he confirmado mi contraseña de registro", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 21
  testRunner.And("he seleccionado las preguntas personalizadas para recuperar mi contraseña", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Y ");
#line 22
 testRunner.When("presione registrar", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Cuando ");
#line 23
 testRunner.Then("debo ingresar exitosamente a mi estado de cuenta", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Entonces ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
