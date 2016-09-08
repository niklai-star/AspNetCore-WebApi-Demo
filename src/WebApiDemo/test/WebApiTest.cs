﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using WebApiDemo.Models;
using Xunit;

namespace WebApiDemo.Test
{
    public class WebApiTest
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public WebApiTest()
        {
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetAllTest()
        {
            var response = await _client.GetAsync("/api/users");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            IList<User> users = JsonConvert.DeserializeObject<IList<User>>(responseString);

            Assert.Equal(3, users.Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetTest(int id)
        {
            var response = await _client.GetAsync($"/api/users/{id}");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            User user = JsonConvert.DeserializeObject<User>(responseString);

            Assert.NotNull(user);
        }
    }
}