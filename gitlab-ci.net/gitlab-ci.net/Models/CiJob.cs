using System;
using System.Runtime.Serialization;

namespace Gitlab.Ci.Models
{
    [DataContract]
    public class CiJob
    {
        public const string Url = "/jobs";

        [DataMember(Name = "id")]
        public int Id;

        [DataMember(Name = "project_id")]
        public int ProjectId;

        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "commands")]
        public string Commands;

        [DataMember(Name = "active")]
        public bool Active;

        [DataMember(Name = "build_branches")]
        public bool BuildBranches;

        [DataMember(Name = "build_tags")]
        public bool BuildTags;

        public override string ToString ()
        {
            return string.Format ("[Job #{0}] \"{1}\" -> \"{2}\"", Id, Name, Commands);
        }
    }
}