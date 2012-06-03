using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace webapi_metadata.Models
{
    [DataContract]
    public class Blog
    {
        [DataMember]
        public int BlogId { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Author { get; set; }
    }
}