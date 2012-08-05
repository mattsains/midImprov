using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Sanford.Multimedia.Midi;

namespace midImprov
{
    /// <summary>
    /// this class should handle reading chords in, and playing them out.
    /// Want it to be seperate from form code.
    /// </summary>
    class Sequencer
    {
        public List<Tuple<Keys, byte>> song = new List<Tuple<Keys, byte>>();
        private OutputDevice outDevice = new OutputDevice(0);
        private int low;
        /// <summary>
        /// Gets notes from a file in the following format:
        /// Cm,1 (1=number of beats)
        /// E,3
        /// F#m,4
        /// </summary>
        /// <param name="filepath">the path to the file.</param>
        /// <returns>true if success, false if fail.</returns>
        public bool GetFromCSV(string filepath){
            StreamReader file = new StreamReader(filepath);
            string line = "";
            song.Clear(); //make way for new notes

            while ((line = file.ReadLine()) != null) //while getting a new line doens't fail
            {
                string note, mode;
                string[] parms= line.Split(',');
                string key = parms[0];
                string len = parms[1];

                if (key.Length > 1)
                {
                    if (key[1] == '#') { note = key.Substring(0, 2); key = key.Substring(2); }
                    else { note = key.Substring(0, 1); key = key.Substring(1); }
                }
                else { note = key[0].ToString(); key = key.Substring(1); }

                if (key.Length > 0) { mode = key; }
                else { mode = "M"; }
                Keys k = new Keys(note, mode);
                byte l =byte.Parse(len);
                song.Add(new Tuple<Keys,byte>(k,l));               
            }
            return true;
        }

        /// <summary>
        /// Warning: always do this in another thread
        /// </summary>
        public void play(int tempo=120)
        {
            low = song[0].Item1.note+57;
            ChannelMessageBuilder builder = new ChannelMessageBuilder();
            if (outDevice.IsDisposed) { outDevice = new OutputDevice(0); }
            foreach (Tuple<Keys, byte> line in song)
            {
                play_chord(line.Item1, (60000 / tempo) * line.Item2);
            }            
            outDevice.Close();
        }
        private void play_chord(Keys k, int t)
        {
            int n1 = (int)Mozart.Component(k, 1) + 57;
            int n2 = (int)Mozart.Component(k, 3) + 57;
            int n3 = (int)Mozart.Component(k, 5) + 57;

            while (n1 < low) { n1 += 12; }
            while (n2 < n1) { n2 += 12; }
            while (n3 < n2) { n3 += 12; }
            
            ChannelMessageBuilder builder = new ChannelMessageBuilder();
            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 0;
            builder.Data1 = n1;
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 0;
            builder.Data1 = n2;
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 0;
            builder.Data1 = n3;
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);

            System.Threading.Thread.Sleep(t);

            builder.Command = ChannelCommand.NoteOff;
            builder.MidiChannel = 0;
            builder.Data1 = n1;
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);

            builder.Command = ChannelCommand.NoteOff;
            builder.MidiChannel = 0;
            builder.Data1 = n2;
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);

            builder.Command = ChannelCommand.NoteOff;
            builder.MidiChannel = 0;
            builder.Data1 = n3;
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);
        }
        public void Stop()
        {
            outDevice.Close();
        }
    }
}
