using System;
using System.IO;
using System.Windows.Forms;

namespace DragToBase64
{
    public partial class Form1 : Form
    {
        private readonly string _defaultText = "Drag Here";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            var filePath = ((string[])e.Data.GetData("FileDrop", true))[0];
            var data = File.ReadAllBytes(filePath);

            Clipboard.SetText(Convert.ToBase64String(data));

            label1.Text = "Copied!";
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = _defaultText;
            timer1.Stop();
        }
    }
}