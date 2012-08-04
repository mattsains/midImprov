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
            
            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 0;
            builder.Data1 = 57 + (int)Mozart.component(k, 1);
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);
            System.Threading.Thread.Sleep(500);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 0;
            builder.Data1 = 57 + (int)Mozart.component(k, 3);
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);
            System.Threading.Thread.Sleep(500);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 0;
            builder.Data1 = 57 + (int)Mozart.component(k, 5);
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);
            System.Threading.Thread.Sleep(500);

            builder.Command = ChannelCommand.NoteOn;
            builder.MidiChannel = 0;
            builder.Data1 = 57 + (int)Mozart.component(k, 1)+12;
            builder.Data2 = 127;
            builder.Build();
            outDevice.Send(builder.Result);
            
            System.Threading.Thread.Sleep(2000);

            outDevice.Close();
        }

        private void cmbMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
