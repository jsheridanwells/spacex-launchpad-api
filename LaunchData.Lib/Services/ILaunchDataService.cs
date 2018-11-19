using System.Collections.Generic;
using System.Threading.Tasks;
using LaunchData.Lib.Models;

namespace LaunchData.Lib.Services
{
    public interface ILaunchDataService
    {
         Task<List<Launchpad>> GetLaunchData();
         Task<Launchpad> GetLaunchpadDataById(string id);
    }
}
