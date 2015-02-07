using GitlabCi.Impl;

namespace GitlabCi
{
	public class GitLabCiClient
	{
		private GitLabCiClient(string hostUrl, string gitlabUrl, string apiToken)
		{
			_api = new API(hostUrl, gitlabUrl, apiToken);
			Projects = new ProjectClient(_api);
		}

		public static GitLabCiClient Connect(string hostUrl, string gitlabUrl, string apiToken)
		{
			return new GitLabCiClient(hostUrl, gitlabUrl, apiToken);
		}

		private readonly API _api;

		public readonly IProjectClient Projects;
	}
}