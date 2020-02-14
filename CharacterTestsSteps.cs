using System;
using System.Net.Http;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using System.Threading.Tasks;
using NUnit.Framework;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;

namespace MarvelAPI
{
    [Binding]
    public class CharacterTestsSteps
    {
        
        private HttpResponseMessage _response;

        private string _content;

        [Given(@"I make a get call to the Characters API")]
        public async Task GivenIMakeAGetCallToTheCharactersAPI(Table table)
        {

            var parameterProprties = table.CreateInstance<ParameterProprties>();

            
            
                using (var client = new HttpClient())
                {
                    var limitvalue = parameterProprties.Limit;
                    var offsetvalue = parameterProprties.OffSet;
                    var baseUri = $"https://gateway.marvel.com/v1/public/characters?ts=1&apikey={parameterProprties.ApiKey}&hash={parameterProprties.Hash}";

                    client.BaseAddress = new Uri(baseUri);

                     _response = await client.GetAsync(client.BaseAddress + "&limit=" + limitvalue + "&offset=" + offsetvalue);

                    _content = await _response.Content.ReadAsStringAsync();
                };          
            
        }


        [Then(@"I receive a success response")]
        public void ThenIReceiveASuccessResponse()
        {
            Assert.IsTrue(_response.IsSuccessStatusCode);
        }


        [Then(@"verify every record includes all JSON properties")]
        public void ThenVerifyEveryRecordIncludesAllJSONProperties()
        {           

           var jsonObject = JObject.Parse(_content);            


            foreach (var item in jsonObject["data"]["results"])
            {
                Assert.That(item["id"], Is.Not.Null);
                Assert.That(item["description"], Is.Not.Null);
                Assert.That(item["name"], Is.Not.Null);
                Assert.That(item["modified"], Is.Not.Null);
                Assert.That(item["thumbnail"], Is.Not.Null);
                Assert.That(item["resourceURI"], Is.Not.Null);
                Assert.That(item["comics"], Is.Not.Null);
                Assert.That(item["series"], Is.Not.Null);
                Assert.That(item["stories"], Is.Not.Null);
                Assert.That(item["events"], Is.Not.Null);
                Assert.That(item["urls"], Is.Not.Null);
            }

        }

        [Then(@"I receive a (.*) response with (.*) and Error (.*)")]
        public void ThenIReceiveAResponseAndError(string response, string errorCode, string errorMessage)
        {
            Assert.IsTrue(_response.StatusCode.ToString() == response);

            var responseBody = JsonConvert.DeserializeObject<ErrorResponseBody>(_content);
            Assert.IsTrue(responseBody.Code.Contains(errorCode));
            Assert.IsTrue(responseBody.Message.Contains(errorMessage));


        }


        [Then(@"I receive a (.*) response with (.*) and Status Message (.*)")]
        public void ThenIReceiveAConflictResponseWithAndStatusMessageYouMustPassAnIntegerLimitGreaterThan(string response, string errorCode, string errorStatus)
        {
            Assert.IsTrue(_response.StatusCode.ToString() == response);

            var responseBody = JsonConvert.DeserializeObject<ErrorResponseBody>(_content);
            Assert.IsTrue(responseBody.Code.Contains(errorCode));
            Assert.IsTrue(responseBody.Status.Contains(errorStatus));
        }     


    }

    public class ParameterProprties
    {
        public long Limit { get; set; }
        public long OffSet { get; set; }

        public string ApiKey { get; set; }

        public string Hash { get; set; }
    }
}

