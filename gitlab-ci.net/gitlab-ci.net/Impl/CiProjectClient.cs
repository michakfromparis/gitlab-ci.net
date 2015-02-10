using System.Collections.Generic;
using Gitlab.Ci.Models;

namespace Gitlab.Ci.Impl
{
    public class CiProjectClient : ICiProjectClient
    {
        private readonly API _api;

        public CiProjectClient(API api)
        {
            _api = api;
        }

        public IEnumerable<CiProject> Accessible
        {
            get
            {
                return _api.Get().GetAll<CiProject>(CiProject.Url);
            }
        }

        public IEnumerable<CiProject> Owned
        {
            get
            {
                return _api.Get().GetAll<CiProject>(CiProject.Url + "/owned");
            }
        }

        public IEnumerable<CiProject> All
        {
            get
            {
                return _api.Get().GetAll<CiProject>(CiProject.Url + "/");
            }
        }

        public CiProject this[int id]
        {
            get
            {
                return _api.Get().To<CiProject>(CiProject.Url + "/" + id);
            }
        }

        public CiProject Create(CiProjectCreate project)
        {
            return _api.Post().With(project).To<CiProject>(CiProject.Url + "/");
        }

        public CiProject Delete(int id)
        {
            return _api.Delete().To<CiProject>(CiProject.Url + "/" + id);
        }
    }
}