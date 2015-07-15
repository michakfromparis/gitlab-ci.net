using Gitlab.Ci.Impl;

namespace Gitlab.Ci
{
	public class GitLabCiClient
	{
		private GitLabCiClient(string hostUrl, string gitlabUrl, string apiToken)
		{
            GitLabCiClient.Api = new API(hostUrl, gitlabUrl, apiToken);
            Projects = new CiProjectClient(Api);
            Runners = new CiRunnerClient(Api);
		}

		public static GitLabCiClient Connect(string hostUrl, string gitlabUrl, string apiToken)
		{
			return new GitLabCiClient(hostUrl, gitlabUrl, apiToken);
		}

        public static API Api;

        public readonly ICiProjectClient Projects;

        public readonly ICiRunnerClient Runners;
	}
}