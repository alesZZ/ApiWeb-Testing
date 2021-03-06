// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace AppWebApi.Test.Postulant
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class GetPostulantsFeature : object, Xunit.IClassFixture<GetPostulantsFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "GetPostulants.feature"
#line hidden
        
        public GetPostulantsFeature(GetPostulantsFeature.FixtureData fixtureData, AppWebApi_Test_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Postulant", "Get Postulants", "\tAs a developer\r\n\tI want to get postulant information through the API\r\n\tSo that i" +
                    "t can be use for show in their profiles", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
 #line hidden
#line 7
  testRunner.Given("The Endpoint https://localhost:5001/api/v1/postulants is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "id",
                        "Name",
                        "LastName",
                        "Email",
                        "Password",
                        "MySpecialty",
                        "MyExperience",
                        "Description"});
            table1.AddRow(new string[] {
                        "1",
                        "Alex",
                        "Liza",
                        "developer-97@gmail.com",
                        "12345678",
                        "Ciencia de Datos",
                        "Junior",
                        "descripcion"});
            table1.AddRow(new string[] {
                        "2",
                        "John",
                        "Doe",
                        "developer-21@gmail.com",
                        "abcdefgh",
                        "Inteligencia Artifcial",
                        "Senior",
                        "descripcion"});
#line 8
  testRunner.And("the Postulant is already stored", ((string)(null)), table1, "And ");
#line hidden
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Get postulant")]
        [Xunit.TraitAttribute("FeatureTitle", "Get Postulants")]
        [Xunit.TraitAttribute("Description", "Get postulant")]
        [Xunit.TraitAttribute("Category", "postulant-getting")]
        public virtual void GetPostulant()
        {
            string[] tagsOfScenario = new string[] {
                    "postulant-getting"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get postulant", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 13
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line hidden
#line 14
  testRunner.Given("The Endpoint https://localhost:5001/api/v1/postulants/id is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 15
  testRunner.When("A Get request is sent", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 16
  testRunner.Then("A response with Status 200 is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "Name",
                            "LastName",
                            "Email",
                            "Password",
                            "MySpecialty",
                            "MyExperience",
                            "Description"});
                table2.AddRow(new string[] {
                            "1",
                            "Alex",
                            "Liza",
                            "developer-97@gmail.com",
                            "12345678",
                            "Ciencia de Datos",
                            "Junior",
                            "descripcion"});
#line 17
  testRunner.And("A postulant resource is included in Response Body", ((string)(null)), table2, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Get all postulants")]
        [Xunit.TraitAttribute("FeatureTitle", "Get Postulants")]
        [Xunit.TraitAttribute("Description", "Get all postulants")]
        public virtual void GetAllPostulants()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get all postulants", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 21
 this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 this.FeatureBackground();
#line hidden
#line 22
  testRunner.Given("The Endpoint https://localhost:5001/api/v1/postulants is available", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
  testRunner.When("A Get request is sent", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
  testRunner.Then("A response with Status 200 is received", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
                TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                            "id",
                            "Name",
                            "LastName",
                            "Email",
                            "Password",
                            "MySpecialty",
                            "MyExperience",
                            "Description"});
                table3.AddRow(new string[] {
                            "1",
                            "Alex",
                            "Liza",
                            "developer-97@gmail.com",
                            "12345678",
                            "Ciencia de Datos",
                            "Junior",
                            "descripcion"});
                table3.AddRow(new string[] {
                            "1",
                            "Alex",
                            "Liza",
                            "developer-97@gmail.com",
                            "12345678",
                            "Ciencia de Datos",
                            "Junior",
                            "descripcion"});
#line 25
  testRunner.And("A postulant resource is included in Response Body", ((string)(null)), table3, "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                GetPostulantsFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                GetPostulantsFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
