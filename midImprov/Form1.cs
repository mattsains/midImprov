using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sanford.Multimedia.Midi;
using Sanford.Multimedia.Midi.UI;

namespace midImprov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OutputDevice outDevice = new OutputDevice(0);

            ChannelMessageBuilder builder = new ChannelMessageBuilder();

            scaleList.Items.Clear();
            Keys k=new Keys();
            k.note=(Notes)cmbNote.SelectedIndex;
            k.mode=(Mode)cmbMode.SelectedIndex;
            int lastNote = 0;
            int Oct=0;
            for (byte i = 1; i < 16; i++)
            {

                System.Threading.Thread.Sleep(50);
                byte n = Mozart.component(k, i);

                Oct = lastNote%12 > (int)n ? Oct + 1 : Oct;
                lastNote = (int)n + 12 * Oct;

                scaleList.Items.Add(n);
                this.Refresh();
                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 0;
                builder.Data1 = (int)lastNote + 57;
                builder.Data2 = 127;
                builder.Build();
                outDevice.Send(builder.Result);

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 0;
                builder.Data1 = (int)lastNote+57+12;
                builder.Data2 = 127;
                builder.Build();
                outDevice.Send(builder.Result);
                System.Threading.Thread.Sleep(250);

                builder.Command = ChannelCommand.NoteOff;
                builder.MidiChannel = 0;
                builder.Data1 = (int)lastNote+57;
                builder.Data2 = 127;
                builder.Build();
                outDevice.Send(builder.Result);
                builder.Command = ChannelCommand.NoteOff;
                builder.MidiChannel = 0;
                builder.Data1 = (int)lastNote + 57+12;
                builder.Data2 = 127;
                builder.Build();
                outDevice.Send(builder.Result);
            }
            lastNote = int.MaxValue;
            for (byte i = 14; i >0; i--)
            {

                System.Threading.Thread.Sleep(50);
                byte n = Mozart.component(k, i);

                Oct = lastNote % 12 < (int)n ? Oct - 1 : Oct;
                lastNote = (int)n + 12 * Oct;

                scaleList.Items.Add(n);
                this.Refresh();
                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 0;
                builder.Data1 = (int)lastNote + 57;
                builder.Data2 = 127;
                builder.Build();
                outDevice.Send(builder.Result);

                builder.Command = ChannelCommand.NoteOn;
                builder.MidiChannel = 0;
                builder.Data1 = (int)lastNote + 57 + 12;
                builder.Data2 = 127;
                builder.Build();
                outDevice.Send(builder.Result);
                System.Threading.Thread.Sleep(250);

                builder.Command = ChannelCommand.NoteOff;
                builder.MidiChannel = 0;
                builder.Data1 = (int)lastNote + 57;
                builder.Data2 = 127;
                builder.Build();
                outDevice.Send(builder.Result);
                builder.Command = ChannelCommand.NoteOff;
                builder.MidiChannel = 0;
                builder.Data1 = (int)lastNote + 57 + 12;
                builder.Data2 = 127;
                builder.Build();
                outDevice.Send(builder.Result);
            }
            outDevice.Close();
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
