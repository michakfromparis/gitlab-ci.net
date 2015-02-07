using System;
using System.Runtime.Serialization;

namespace GitlabCi.Models
{
    [DataContract]
    public class Project
    {
        public const string Url = "/projects";

        [DataMember(Name = "id")]
        public int Id;

        [DataMember(Name = "name")]
        public string Name;

		[DataMember(Name = "timeout")]
		public int Timeout;

		[DataMember(Name = "token")]
		public string Token;

		[DataMember(Name = "default_ref")]
		public string DefaultBranch;

		[DataMember(Name = "gitlab_url")]
		public string GitlabUrl;

		[DataMember(Name = "always_build")]
		public bool AlwaysBuild;

		[DataMember(Name = "polling_interval")]
		public string PollingInterval;

		[DataMember(Name = "public")]
        public bool Public;

        [DataMember(Name = "ssh_url_to_repo")]
        public string SshUrl;

//        [DataMember(Name = "http_url_to_repo")]
//        public string HttpUrl;

		[DataMember(Name = "gitlab_id")]
		public int GitlabId;

		public override string ToString ()
		{
			return string.Format ("[Project #{0}] \"{1}\" at \"{2}\"", Id, Name, GitlabUrl);
		}
	}
}