using AnyShareHandling.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnyShareHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnyShareApisController : ControllerBase
    {
        // GET: api/<AnyShareApisController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AnyShareApisController>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="folders_id"></param>
        /// <param name="client_id"></param>
        /// <returns></returns>
        [HttpGet("{client_id}")]
        public async Task<string> GetAsync(string folders_id, string client_id)
        {
            string as_code = JwtGenerator.GetToken("tccai", "eisoo.com");

            using var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://anyshare.cntcc.cn/api/authentication/v1/sso");
            var content = new StringContent("{\r\n    \"client_id\": \"" + client_id + "\",\r\n    \"redirect_uri\": \"https://localhost/callback\",\r\n    \"response_type\": \"token id_token\",\r\n    \"scope\": \"offline openid all\",\r\n    \"udids\": [\r\n        \"\"\r\n    ],\r\n    \"credential\": {\r\n        \"id\": \"tianchen\",\r\n        \"params\": {\r\n            \"as_code\": \"" + as_code + "\"\r\n        }\r\n    }\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);

            // 反序列化 JSON
            TokenResponse tokenResponse = JsonSerializer.Deserialize<TokenResponse>(responseBody);

            // 获取 access_token
            string accessToken = tokenResponse.AccessToken;
            Console.WriteLine(accessToken);

            using var folderClient = new HttpClient();
            var folderRequest = new HttpRequestMessage(HttpMethod.Get, $"https://anyshare.cntcc.cn/api/efast/v1/folders/{folders_id}/sub_objects?limit=1000");
            folderRequest.Headers.Add("Authorization", $"Bearer {accessToken}");
            var folderResponse = await folderClient.SendAsync(folderRequest);
            folderResponse.EnsureSuccessStatusCode();
            string folderResponseBody = await folderResponse.Content.ReadAsStringAsync();
            Console.WriteLine(folderResponseBody);

            return folderResponseBody;
        }

        // POST api/<AnyShareApisController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AnyShareApisController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AnyShareApisController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
