using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace TG_Test
{
    public class TG_Tests
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Program> _factory;
        public TG_Tests(ITestOutputHelper outputHelper)
        {
            _factory = new WebApplicationFactory<Program>();
            _outputHelper = outputHelper;
        }

        [Fact]
        public async void TestGetAllProducts()
        {
            //Arrrange
            var client = _factory.CreateClient();
            //Act
            var response =  await client.GetAsync("/Product/All");
            var responsecontent = response.Content.ReadAsStringAsync().Result;
            var responseStatus = response.Content.ReadAsStringAsync().Status;
            _outputHelper.WriteLine(responsecontent);
            _outputHelper.WriteLine(responseStatus.ToString());
            //Assert
            Assert.True(responsecontent!=null);
        }
    }
}