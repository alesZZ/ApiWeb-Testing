using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using AppWeb_Api;
using AppWeb_Api.BoundedPostulant.Resources;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AppWebApi.Test.Postulant
{
    [Binding]
    public class PostulantRegisterSteps : WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        
        private Task<HttpResponseMessage> Response { get; set; }
        // resources
        private PostulantResource Postulant { get; set; }

        public PostulantRegisterSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/postulants is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPostulantsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/postulants");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions {BaseAddress = BaseUri});
        }

        [When(@"A post request is sent")]
        public void WhenAPostRequestIsSent(Table savePostResource)
        {
            var resource = savePostResource.CreateSet<SavePostulantResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.GetAwaiter().GetResult().StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [Then(@"A postulant resource is included in Response Body")]
        public async void ThenAPostulantResourceIsIncludedInResponseBody(Table expectedPostulantResource)
        {
            var expectedResource = expectedPostulantResource.CreateSet<PostulantResource>().First();
            var responseData = await Response.Result.Content.ReadAsStringAsync();
            var resource = JsonConvert.DeserializeObject<PostulantResource>(responseData);
            expectedResource.Id = resource.Id;
            var jsonExpectedResource = expectedResource.ToJson();
            var jsonActualResource = resource.ToJson();
            Assert.Equal(jsonExpectedResource, jsonActualResource);
        }

        [Given(@"A Email is already stored")]
        public async void GivenAEmailIsAlreadyStored(Table existingPostulantResource)
        {
            var resource = existingPostulantResource.CreateSet<SavePostulantResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, MediaTypeNames.Application.Json);
            var postulantResponse = Client.PostAsync(BaseUri, content);
            var postulantResponseData = await postulantResponse.Result.Content.ReadAsStringAsync();
            var existingPostulant = JsonConvert.DeserializeObject<PostulantResource>(postulantResponseData);
            Postulant = existingPostulant;
        }

        [Then(@"A message is included in Response Body with value ""(.*)""")]
        public async void ThenAMessageIsIncludedInResponseBodyWithValue(string expectedMessage)
        {
            var actualMessage = await Response.Result.Content.ReadAsStringAsync();
            var jsonExpectedMessage = expectedMessage.ToJson();
            var jsonActualMessage = actualMessage.ToJson();
            Assert.Equal(jsonExpectedMessage, jsonActualMessage);
        }
    }
}