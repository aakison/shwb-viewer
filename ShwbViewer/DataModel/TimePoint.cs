using ShwbViewer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SharedWhiteboard {
    public class TimePoint  {

        [JsonPropertyName("P")]
        public Point Point { get; set; }

    }
}
