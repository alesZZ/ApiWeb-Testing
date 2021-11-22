using TechTalk.SpecFlow;

namespace AppWebApi.Test.Postulant
{
    [Binding]
    public class UpdatePostulantSteps
    {
        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/postulants/id is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPostulantsIdIsAvailable(int p0, int p1)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"the Postulant is already stored")]
        public void GivenThePostulantIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"A Put request is sent")]
        public void WhenAPutRequestIsSent(Table table)
        {
            ScenarioContext.StepIsPending();
        }
    }
}