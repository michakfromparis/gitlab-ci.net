using System;
using GitlabCi.Impl;
using GitlabCi.Models;
using System.Net;

namespace GitlabCi.net.Tests
{
	class MainClass
	{
		private static readonly string _gitlabCiUrl = "https://ci.example.com";
		private static readonly string _gitlabUrl  = "https://gitlab.example.com";
		private static readonly string _token = "XXXXXX-XXXXXXXXXXXXX";

		public static int Main(string[] args)
		{
			ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
			GitLabCiClient client = null;
			try
			{
				Console.WriteLine("Connecting to \"{0}\"", _gitlabCiUrl);
				client = GitLabCiClient.Connect(_gitlabCiUrl, _gitlabUrl, _token);
				Console.WriteLine("Listing projects");
				foreach (Project project in client.Projects.All)
				{
					Console.WriteLine(project);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error connecting to \"{0}\": {1}", _gitlabCiUrl, ex.Message);
				return -1;
			}
			ProjectCreate projectCreate = new ProjectCreate ();
			projectCreate.Name = "Existing Project Name on gitlab";
			projectCreate.GitlabId = "Existing Project Gitlab Id";
			projectCreate.GitlabUrl = "Existing Project Gitlab Url";
			projectCreate.SshUrl = "Existing Project Gitlab Ssh Url";
			try
			{
				Console.WriteLine("Creating project \"{0}\"", projectCreate.Name);
				client.Projects.Create(projectCreate);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error creating project \"{0}\": {1}", projectCreate.Name, ex.Message);
				return -1;
			}
			Console.WriteLine("Successfully created project \"{0}\"", projectCreate.Name);
			return 0;
		}
	}
}
