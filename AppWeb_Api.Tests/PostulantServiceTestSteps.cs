using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using TechTalk.SpecFlow;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AppWeb_Api.BoundedPostulant.Resources;
using SpecFlow.Internal.Json;
using TechTalk.SpecFlow.Assist;
using Xunit;

namespace AppWeb_Api.Tests
{
    [Binding]
    public class PostulantServiceTestSteps  : WebApplicationFactory<Startup>
    {
        private readonly WebApplicationFactory<Startup> _factory;
        private HttpClient Client { get; set; }
        private Uri BaseUri { get; set; }
        private Task<HttpResponseMessage> Response { get; set; }

        public PostulantServiceTestSteps(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Given(@"The Endpoint https://localhost:(.*)/api/v(.*)/postulants is available")]
        public void GivenTheEndpointHttpsLocalhostApiVPostulantsIsAvailable(int port, int version)
        {
            BaseUri = new Uri($"https://localhost:{port}/api/v{version}/postulants");
            Client = _factory.CreateClient(new WebApplicationFactoryClientOptions{BaseAddress = BaseUri});
            
        }

        [When(@"A Post Request is sent")]
        public void WhenAPostRequestIsSent(Table savePostResource)
        {
            var resource = savePostResource.CreateSet<SavePostulantResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = Client.PostAsync(BaseUri, content);
        }

        [Then(@"A Response with Status (.*) is received")]
        public void ThenAResponseWithStatusIsReceived(int expectedStatus)
        {
            var expectedStatusCode = ((HttpStatusCode) expectedStatus).ToString();
            var actualStatusCode = Response.Result.StatusCode.ToString();
            Assert.Equal(expectedStatusCode, actualStatusCode);
        }

        [When(@"A Post Request incomplete is sent")]
        public void WhenAPostRequestIncompleteIsSent(Table savePostResource)
        {
            var resource = savePostResource.CreateSet<SavePostulantResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = Client.PostAsync(BaseUri, content);
        }

        [When(@"A Update Request is sent")]
        public void WhenAUpdateRequestIsSent(Table updatePostResource)
        {
            var resource = updatePostResource.CreateSet<UpdatePostulantResource>().First();
            var content = new StringContent(resource.ToJson(), Encoding.UTF8, "application/json");
            Response = Client.PostAsync(BaseUri, content);
        }

    }
}