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
using System.Threading;

namespace midImprov
{
    public partial class Form1 : Form
    {
        static Sequencer s = new Sequencer();
        Thread t;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(100);
            try
            {
                if (!t.IsAlive)
                {
                    openFileDialog1.InitialDirectory = Application.ExecutablePath;
                    openFileDialog1.ShowDialog();
                    s.GetFromCSV(openFileDialog1.FileName);
                    t = new Thread(make_play);
                    t.Start();
                }
                else { t.Abort(); }
                s.Stop();
            }
            catch (Exception)
            {
                openFileDialog1.InitialDirectory = Application.ExecutablePath;
                openFileDialog1.ShowDialog();
                s.GetFromCSV(openFileDialog1.FileName);
                t = new Thread(make_play);
                t.Start();
            }
        }

        private void make_play()
        {
            lock (s)
            {
                s.play(140);
            }
        }
    }
}
