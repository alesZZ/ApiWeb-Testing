using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AppWeb_Api.Tests
{
    [Binding]
    public sealed class stepTemp
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public stepTemp(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }

        [Given("the second number is (.*)")]
        public void GivenTheSecondNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }

        [When("the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            //TODO: implement act (action) logic

            _scenarioContext.Pending();
        }

        [Then("the result should be (.*)")]
        public void ThenTheResultShouldBe(int result)
        {
            //TODO: implement assert (verification) logic

            _scenarioContext.Pending();
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/announcements is available")]
        public void GivenTheEndpointHttpsLocalhostApiVAnnouncementsIsAvailable(int p0, int p1)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"Announcements is already stored")]
        public void GivenAnnouncementsIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"A Delete Request with id (.*) is sent")]
        public void WhenADeleteRequestWithIdIsSent(int p0)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"A get request with id (.*) is sent")]
        public void WhenAGetRequestWithIdIsSent(int p0)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A Announcement resource is included in Response Body")]
        public void ThenAAnnouncementResourceIsIncludedInResponseBody(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"A Company is already stored")]
        public void GivenACompanyIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A announcment resource is included in Response Body")]
        public void ThenAAnnouncmentResourceIsIncludedInResponseBody(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"A Get request is sent")]
        public void WhenAGetRequestIsSent()
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/projects is available")]
        public void GivenTheEndpointHttpsLocalhostApiVProjectsIsAvailable(int p0, int p1)
        {
            ScenarioContext.StepIsPending();
        }

        [Given(@"Projects is already stored")]
        public void GivenProjectsIsAlreadyStored(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [Then(@"A project resource is included in Response Body")]
        public void ThenAProjectResourceIsIncludedInResponseBody(Table table)
        {
            ScenarioContext.StepIsPending();
        }

        [When(@"A Get request with id (.*) is sent")]
        public void WhenAGetRequestWithIdIsSent(int p0)
        {
            ScenarioContext.StepIsPending();
        }
    }
}