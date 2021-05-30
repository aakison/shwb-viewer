using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace SharedWhiteboard.DataModel {
    [CollectionDataContract]
    public class WordBoxCollection : ObservableCollection<WordBox> {
        public WordBox AddWordBox(string word, Rect box) {
            // Check if the word exists to add to the word's boxes or to create a new wordbox.
            var existingWord = this.FirstOrDefault(e => e.Word.ToUpperInvariant() == word.ToUpperInvariant());
            if(existingWord != null) {
                // Check if the word already has this box before adding.
                var existingBox = existingWord.Boxes.FirstOrDefault(e => e == box);
                //if(existingBox != null) {
                //    // word and box already exist, short circuit return to avoid raising event.
                //    return existingWord;
                //}
                existingWord.AddBox(box);
            }
            else {
                existingWord = new WordBox(word);
                existingWord.AddBox(box);
                Add(existingWord);
            }
            if(WordAdded != null) {
                var args = new WordBoxAddedEventArgs { Word = word, Box = box };
                WordAdded(this, args);
            }
            return existingWord;
        }

        public event EventHandler<WordBoxAddedEventArgs> WordAdded;
    }

    public class WordBoxAddedEventArgs : EventArgs {
        public string Word { get; set; }
        public Rect Box { get; set; }
    }
}
