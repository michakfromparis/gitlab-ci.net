using Gitlab.Ci.Impl;

namespace Gitlab.Ci
{
	public class GitLabCiClient
	{
		private GitLabCiClient(string hostUrl, string gitlabUrl, string apiToken)
		{
			_api = new API(hostUrl, gitlabUrl, apiToken);
			Projects = new CiProjectClient(_api);
		}

		public static GitLabCiClient Connect(string hostUrl, string gitlabUrl, string apiToken)
		{
			return new GitLabCiClient(hostUrl, gitlabUrl, apiToken);
		}

		private readonly API _api;

		public readonly ICiProjectClient Projects;
	}
}