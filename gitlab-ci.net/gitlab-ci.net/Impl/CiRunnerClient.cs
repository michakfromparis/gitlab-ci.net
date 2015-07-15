using System.Collections.Generic;
using Gitlab.Ci.Models;

namespace Gitlab.Ci.Impl
{
    public class CiRunnerClient : ICiRunnerClient
    {
        private readonly API _api;

        public CiRunnerClient(API api)
        {
            _api = api;
        }

        public IEnumerable<CiRunner> Accessible
        {
            get
            {
                return _api.Get().GetAll<CiRunner>(CiRunner.Url);
            }
        }

        public IEnumerable<CiRunner> Owned
        {
            get
            {
                return _api.Get().GetAll<CiRunner>(CiRunner.Url + "/owned");
            }
        }

        public IEnumerable<CiRunner> All
        {
            get
            {
                return _api.Get().GetAll<CiRunner>(CiRunner.Url + "/");
            }
        }

        public CiRunner this[int id]
        {
            get
            {
                return _api.Get().To<CiRunner>(CiRunner.Url + "/" + id);
            }
        }

//        public CiRunner Create(CiRunnerCreate project)
//        {
//            return _api.Post().With(project).To<CiRunner>(CiRunner.Url + "/");
//        }

        public CiRunner Delete(int id)
        {
            return _api.Delete().To<CiRunner>(CiRunner.Url + "/" + id);
        }
    }
}