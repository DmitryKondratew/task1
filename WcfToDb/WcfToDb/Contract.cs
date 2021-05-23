using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace WcfToDb
{
    [DataContract]
    public class Contract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Contract_Number { get; set; }

        [DataMember]
        public string Date_Time { get; set; }

        [DataMember]
        public string Date_Update { get; set; }

        [DataMember]
        public bool Relevance { get; set; }


    }
}
