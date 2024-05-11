using PerfumeOnlineStore_Core.IRepos;
using PerfumeOnlineStore_Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeOnlineStore_Infra.ServiceImplementation
{
    public class SharedService : ISharedServiceInterface
    {
        private readonly ISharedReposInterface _repos;
        public SharedService(ISharedReposInterface repos)
        {
            _repos = repos;
        }
    }
}
