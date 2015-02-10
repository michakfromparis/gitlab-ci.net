using System;
using System.Runtime.Serialization;

namespace Gitlab.Ci.Models
{
    [DataContract]
    public class CiJobCreate
    {
        [DataMember(Name = "name")]
        public string Name;

        [DataMember(Name = "commands")]
        public string Commands;

        public override string ToString ()
        {
            return string.Format ("[JobCreate] \"{0}\" -> \"{1}\"", Name, Commands);
        }
    }
}