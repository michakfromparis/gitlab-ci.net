using System;
using System.Diagnostics;

namespace GitlabCi.Impl
{
    [DebuggerStepThrough]
    public class API
    {
        public readonly string APIToken;
		private readonly string _hostUrl;
		private readonly string _gitlabUrl;
        private const string APINamespace = "/api/v1";

		public API(string hostUrl, string gitlabUrl, string apiToken)
        {
			_hostUrl = hostUrl.EndsWith("/") ? hostUrl.Replace("/$", "") : hostUrl;
			_gitlabUrl = gitlabUrl.EndsWith("/") ? gitlabUrl.Replace("/$", "") : gitlabUrl;
            APIToken = apiToken;
        }
        
        public HttpRequestor Get()
        {
            return new HttpRequestor(this, MethodType.Get);
        }

        public HttpRequestor Post()
        {
            return new HttpRequestor(this, MethodType.Post);
        }

        public HttpRequestor Put()
        {
            return new HttpRequestor(this, MethodType.Put);
        }
        
        public HttpRequestor Delete()
        {
            return new HttpRequestor(this, MethodType.Delete);
        }

        public Uri GetAPIUrl(string tailAPIUrl)
        {
            if (APIToken != null)
            {
				tailAPIUrl = tailAPIUrl + (tailAPIUrl.IndexOf('?') > 0 ? '&' : '?') + "private_token=" + APIToken + "&url=" + _gitlabUrl;
            }

            if (!tailAPIUrl.StartsWith("/"))
            {
                tailAPIUrl = "/" + tailAPIUrl;
            }
            return new Uri(_hostUrl + APINamespace + tailAPIUrl);
        }

        public Uri GetUrl(string tailAPIUrl)
        {
            if (!tailAPIUrl.StartsWith("/"))
            {
                tailAPIUrl = "/" + tailAPIUrl;
            }

            return new Uri(_hostUrl + tailAPIUrl);
        }
    }
}