using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Windows;

namespace SharedWhiteboard.DataModel {
    public class WordBox {
        public WordBox(string word) {
            Word = word;
        }

        [JsonPropertyName("W")]
        public string Word { get; private set; }

        [JsonPropertyName("B")]
        public ObservableCollection<Rect> Boxes {
            get {
                if(boxes == null) {
                    boxes = new ObservableCollection<Rect>();
                }
                return boxes;
            }
        }
        private ObservableCollection<Rect> boxes;

        public Rect AddBox(Rect box) {
            var intBox = new Rect(Math.Floor(box.Left), Math.Floor(box.Top), Math.Ceiling(box.Width), Math.Ceiling(box.Height));
            Boxes.Add(intBox);
            return intBox;
        }

        public int Relevance {
            get {
                return Word.Length * Word.Length * Boxes.Count;
            }
        }
    }
}
