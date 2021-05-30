using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SharedWhiteboard {
    [DataContract]
    public class Scribble {

        public Scribble() {
            Completed = false;
            Guid = Guid.NewGuid();
            Color = Colors.Blue;
            ScribbleType = ScribbleType.Local;
        }

        [DataMember]
        public Guid UserGuid { get; set; }

        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public Color Color { get; set; }

        [DataMember]
        public int StrokeThickness { get; set; }

        [DataMember]
        public Collection<TimePoint> Points { get; set; } = new();

        [DataMember]
        public bool Completed { get; set; }

        [DataMember]
        public ScribbleType ScribbleType { get; set; }


    }

}
