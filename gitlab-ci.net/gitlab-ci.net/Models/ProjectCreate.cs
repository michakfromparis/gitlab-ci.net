using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace GitlabCi.Models
{
    [DataContract]
    public class ProjectCreate
    {
        [Required]
        [DataMember(Name = "name")]
        public string Name;

		[Required]
		[DataMember(Name = "gitlab_id")]
		public string GitlabId;

		[Required]
		[DataMember(Name = "gitlab_url")]
		public string GitlabUrl;

		[Required]
		[DataMember(Name = "ssh_url_to_repo")]
		public string SshUrl;

		[DataMember(Name = "default_ref")]
		public string DefaultBranch;
   }
}