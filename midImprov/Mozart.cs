using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace midImprov
{
    enum Mode { Major, Minor, Diminished }
    class Keys
    {
        public Mode mode { get; set; }
        public int note { get; set; }

        public Keys(int n, Mode m) { SetNote(n); SetMode(m); }
        public Keys(string n, string m) { SetNote(n); SetMode(m); }

        public void SetMode(Mode m) { mode = m; }
        public void SetMode(string m)
        {
            switch (m)
            {
                case "M": mode = Mode.Major; break;
                case "m": mode = Mode.Minor; break;
                case "d": mode = Mode.Diminished; break;
            }
        }

        public void SetNote(int n) { note = n; }
        public void SetNote(string n)
        {
            n.Replace("#", "s");
            switch (n)
            {
                case "A": note = 0; break;
                case "As": note = 1; break;
                case "B": note = 2; break;
                case "C": note = 3; break;
                case "Cs": note = 4; break;
                case "D": note = 5; break;
                case "Ds": note = 6; break;
                case "E": note = 7; break;
                case "F": note = 8; break;
                case "Fs": note = 9; break;
                case "G": note = 10; break;
                case "Gs": note = 11; break;
            }
        }
    }

    class Mozart
    {
        /// <summary>
        /// gives a specific note of a scale
        /// </summary>
        /// <param name="key">The key to select the component from</param>
        /// <param name="interval">the interval to select. 1=root, 5=fifth, etc</param>
        /// <returns>the note offset from middle A (57)</returns>
        public static byte Component(Keys key, int interval)
        {
            interval = ((interval - 1) % 7) + 1;//translate octaves back onto the domain of this function
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
                case 8: note = (byte)(Component(key, interval) + 12); break;
            }
            note %= 12;
            return note;
        }
    }

}
