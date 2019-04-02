using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    [DataContract]
    public class Level
    {
        [DataMember]
        public int Number { get; set; }
        [DataMember]
        public char[,] Map { get; set; }
    }
}
