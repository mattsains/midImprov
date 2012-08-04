using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace midImprov
{
    enum Mode{Major,Minor,Diminished}
    enum Notes{A,As,B,C,Cs,D,Ds,E,F,Fs,G,Gs}
    struct Keys
    {
        public Mode mode{get;set;}
        public Notes note{get;set;}
    }
        
    class Mozart
    {
        /// <summary>
        /// gives a specific note of a scale
        /// </summary>
        /// <param name="key">The key to select the component from</param>
        /// <param name="interval">the interval to select. 1=root, 5=fifth, etc</param>
        /// <returns>the note</returns>
        public static Notes component(Keys key, int interval)
        {
            interval = ((interval - 1) % 7)+1;//translate octaves back onto the domain of this function
            byte note = (byte)key.note;
            switch (interval)
            {
                case 2: note += 2; break;
                case 3:
                    switch (key.mode)
                    {
                        case Mode.Major: note += 4; break;
                        case Mode.Minor:
                        case Mode.Diminished: note += 3; break;
                    } break;
                case 4: note += 5; break;
                case 5:
                    switch (key.mode)
                    {
                        case Mode.Diminished: note += 6; break;
                        case Mode.Minor:
                        case Mode.Major: note += 7; break;
                    } break;
                case 6:
                    switch (key.mode)
                    {
                        case Mode.Minor:
                        case Mode.Diminished: note += 8; break;
                        case Mode.Major: note += 9; break;
                    } break;
                case 7: note += 11; break;
            }
            note %= 12;
            return (Notes)note;
        }


    }
}
