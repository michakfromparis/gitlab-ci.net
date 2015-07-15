using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Gitlab.Ci.Models
{
    [DataContract]
    public class CiProjectRunnerAssign
    {
        [Required]
        [DataMember(Name = "id")]
        public int CiProjectId;

		[Required]
		[DataMember(Name = "runner_id")]
		public int RunnerId;

   }
}