using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Gitlab.Ci.Impl;

namespace Gitlab.Ci.Models
{
    [DataContract]
    public class CiProject
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

		[DataMember(Name = "gitlab_id")]
		public int GitlabId;

        public IEnumerable<CiJob> Jobs
        {
            get
            {
                return GitLabCiClient.Api.Get().GetAll<CiJob>(CiProject.Url + "/" + Id + "/jobs");
            }
        }

        public CiJob CreateJob(string name, string commands)
        {
            CiJobCreate job = new CiJobCreate();
            job.Name = name;
            job.Commands = commands;
            return CreateJob(job);
        }

        public CiJob CreateJob(CiJobCreate job)
        {
            return GitLabCiClient.Api.Post().With(job).To<CiJob>(CiProject.Url + "/" + Id + "/jobs");
        }

        public CiJob DeleteJob(int id)
        {
            return GitLabCiClient.Api.Delete().To<CiJob>(CiProject.Url + "/" + Id + "/jobs/" + id);
        }
		public override string ToString ()
		{
			return string.Format ("[Project #{0}] \"{1}\" at \"{2}\"", Id, Name, GitlabUrl);
		}
	}
}