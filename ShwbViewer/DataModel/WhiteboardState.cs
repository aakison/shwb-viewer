using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedWhiteboard {
    [DataContract]
    public enum WhiteboardState {
        Unknown,

        [EnumMember]
        Private,

        [EnumMember]
        Shared,

        [EnumMember]
        ReadOnly
    }
}
