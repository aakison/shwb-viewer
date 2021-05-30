using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SharedWhiteboard {
    [DataContract]
    public class User  {

        public User() {
            IsLocalUser = false;
            CurrentColor = Colors.Blue;
        }

        public Uri MarkerUri {
            get {
                if(CurrentColor == Colors.Red) {
                    return new Uri("ms-appx:///Assets/RedMarker.png");
                }
                else if(CurrentColor == Colors.Green) {
                    return new Uri("ms-appx:///Assets/GreenMarker.png");
                }
                else if(CurrentColor == Colors.Blue) {
                    return new Uri("ms-appx:///Assets/BlueMarker.png");
                }
                else if(CurrentColor == Color.FromArgb(255, 225, 234, 239)) {
                    return new Uri("ms-appx:///Assets/WhiteMarker.png");
                }
                else {
                    return new Uri("ms-appx:///Assets/BlackMarker.png");
                }
            }
        }

        [DataMember]
        public Color CurrentColor { get; set; }

        [DataMember]
        public Uri ImageUri { get; set; }

        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string DisplayName { get; set; }

        [DataMember]
        public UserType UserType { get; set; }

        public bool IsLocalUser { get; private set; }

    }
}
