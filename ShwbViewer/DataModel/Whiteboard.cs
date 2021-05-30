using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace SharedWhiteboard.DataModel {
    [DataContract]
    public class Whiteboard {

        [DataMember]
        public WordBoxCollection Words { get; set; } = new WordBoxCollection();

        /// <summary>
        /// An ordered list of the most important words in the document
        /// </summary>
        public IEnumerable<string> Keywords {
            get {
                return Words.Where(e => e.Relevance > 4).OrderByDescending(e => e.Relevance).Select(e => e.Word).AsEnumerable();
            }
        }

        public string KeywordDisplay {
            get {
                return String.Join(", ", Keywords);
            }
        }

        [DataMember]
        public Collection<Scribble> Scribbles { get; set; } = new();

        [DataMember]
        public Collection<User> Users { get; set; } = new();

        [DataMember(Name = "Id")]
        public Guid Guid { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public WhiteboardState State { get; set; }


    }
}
