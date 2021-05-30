using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedWhiteboard {
    [DataContract]
    public enum ScribbleType {
        /// <summary>
        /// A scribble that has been drawn on this client.
        /// </summary>
        [EnumMember]
        Local,
        /// <summary>
        /// A scribble that has been drawn on another client and has been recieved.
        /// </summary>
        [EnumMember]
        Remote,
        /// <summary>
        /// A partial scribble that is a subset of another, local or remote scribble, used for transmitting deltas
        /// </summary>
        [EnumMember]
        Delta
    }
}
