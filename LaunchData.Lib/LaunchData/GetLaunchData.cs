using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LaunchData.Lib.Models;
using System.Collections.Generic;

namespace LaunchData.Lib.LaunchData
{
    public class GetLaunchData : IGetLaunchData
    {
        public async Task<List<Launch>> ReturnLaunchData()
        {
            using (var client = new HttpClient())
            {
                var space_x_url = new Uri("https://api.spacexdata.com/v2/launchpads");
                var response = await client.GetAsync(space_x_url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<List<Launch>>(json);
            }
        }
    }
}
