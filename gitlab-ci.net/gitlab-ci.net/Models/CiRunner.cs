using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Gitlab.Ci.Models
{
    [DataContract]
    public class CiRunner
    {
        public const string Url = "/runners";

        [DataMember(Name = "id")]
        public int Id;

        [DataMember(Name = "token")]
        public string Token;

	}
}