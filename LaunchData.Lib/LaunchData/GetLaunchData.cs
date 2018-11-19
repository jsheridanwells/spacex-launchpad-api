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
        /// <summary>
        /// Calls the /launchpads endpoint of the spacexdata api.
        /// Deserializes json response.
        /// </summary>
        /// <returns>List of launch data</returns>
        public async Task<List<Launchpad>> ReturnLaunchData()
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
                return JsonConvert.DeserializeObject<List<Launchpad>>(json);
            }
        }

        /// <summary>
        /// Calls /launchpads/:id endpoint of spacexdata api.
        /// Deserializes json response
        /// </summary>
        /// <param name="id">Id of launchpad</param>
        /// <returns>launchpad data</returns>
        public async Task<Launchpad> ReturnLaunchpadDataById(string id)
        {
            using (var client = new HttpClient())
            {
                var space_x_url = new Uri($"https://api.spacexdata.com/v2/launchpads/{id}");
                var response = await client.GetAsync(space_x_url);
                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }
                return JsonConvert.DeserializeObject<Launchpad>(json);
            }
        }
    }
}
