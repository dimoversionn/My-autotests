using System.Net;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using AQATests.API_Testing;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AQATests.Tests
{
    
    class APITests
    {
        /*[Test]
        public async Task GET_CCO()
        {
            RestClient client = new RestClient("https://swapi.dev");
            RestRequest request = new RestRequest("/api/", Method.Get);
            var response = client.Execute<StarWarsObject>(request);
            var response1 = await client.GetJsonAsync<StarWarsObject>("/api/");
            string message = response.Data.planets;
            string message1 = response1.planets;
            Assert.AreEqual(message, message1);
        }*/

        [Test]
        public void GET_PlanetsURL_WhenWeRequestStarWarsObjects()
        {
            string expectedMesssage = "https://swapi.dev/api/planets/";
            RestClient client = new RestClient("https://swapi.dev");
            RestRequest request = new RestRequest("/api/", Method.Get);
            var response = client.Execute<StarWarsObject>(request);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedMesssage, response.Data.planets);
                Assert.That(response.StatusCode.ToString, Is.EqualTo("OK"));
            });

        }
        [Test]
        public void GET_SucsessJsonObject_WhenRequestDogObject()
        {
            string expectedMesssage = "success";
            RestClient client = new RestClient("https://dog.ceo");
            RestRequest request = new RestRequest("/api/breeds/image/random", Method.Get);
            var response = client.Execute<DogModel>(request);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(expectedMesssage, response.Data.status);
                Assert.That(response.StatusCode.ToString, Is.EqualTo("OK"));
            });

        }

        [Test]
        public void POST_CheckIdAndStatusCodeOfNewUser_AfterAddingNewUser()
        {
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("api/users", Method.Post);
            UserModel user = new UserModel()
            {
                id = 13,
                email = "Vasyamail@mail.com",
                first_name = "Sanchoys",
                last_name = "Sanin",
                avatar = "https://google.com"
            };

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(user);
            var response = client.Execute<UserModel>(request);
            Assert.Multiple(() =>
            {
                Assert.That(response.Data.id, Is.EqualTo(13));
                Assert.That(response.Data.last_name, Is.EqualTo("Sanin"));
                Assert.That(response.StatusCode.ToString, Is.EqualTo("OK"));

            });
        }

        [Test]
        public void POST_NameAndMoviesOfNewUser_AfterAddingNewUser()
        {
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("api/users", Method.Post);
            UserModel user = new UserModel()
            {
                id = 999,
                email = "User@mail.com",
                first_name = "First",
                last_name = "Name",
                avatar = "https://google.com"
            };

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(user);
            var response = client.Execute<UserModel>(request);
            Assert.Multiple(() =>
            {
                Assert.That(response.Data.id, Is.EqualTo(999));
                Assert.That(response.Data.last_name, Is.EqualTo("Name"));
                Assert.That(response.StatusCode.ToString, Is.EqualTo("Created"));

            });
        }

        [Test]
        public void PUT_CheckThatNewUserIsUpdated_AfterUpdatingNewUser()
        {
            RestClient client = new RestClient("https://reqres.in/");
            RestRequest request = new RestRequest("api/users/2", Method.Put);
            UserModel user = new UserModel()
            {
                name = "morpheus",
                job = "zion resident"
            };

            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(user);
            var response = client.Execute<UserModel>(request);
            Assert.Multiple(() =>
            {
                Assert.That(response.Data.name, Is.EqualTo("morpheus"));
                Assert.That(response.Data.updateAt.ToString, Is.EqualTo("01.01.0001 00:00:00"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }
        
        [Test]
        public void DELETE_CheckStatusCode_AfterDeletingUser()
        {
            RestClient client = new RestClient("https://reqres.in");
            RestRequest request = new RestRequest("/api/users/2", Method.Delete);
            RestResponse response = client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

    }
}
