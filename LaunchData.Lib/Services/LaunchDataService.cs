using System.Collections.Generic;
using System.Threading.Tasks;
using LaunchData.Lib.LaunchData;
using LaunchData.Lib.Models;

namespace LaunchData.Lib.Services
{
    public class LaunchDataService : ILaunchDataService
    {
        private readonly IGetLaunchData _getLaunchData;
        public LaunchDataService(IGetLaunchData getLaunchData)
        {
            _getLaunchData = getLaunchData; 
        }
        public async Task<List<Launchpad>> GetLaunchData()
        {
            return await _getLaunchData.ReturnLaunchData();
        }

        public async Task<Launchpad> GetLaunchpadDataById(string id)
        {
            return await _getLaunchData.ReturnLaunchpadDataById(id);
        }
    }
}
