using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = -1;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    //textBox1.Text = text;
                    string input = text;


                    string pattern = @"\b(\d{16})(?:[\/\s:|]*(\d\d)[\/\s|]*(\d{2,4})[\/\s|-]*(\d{3})|Cvv:\s*(\d{3})Expm:\s*(\d\d)Expy:\s*(\d\d))\b";
                    RegexOptions options = RegexOptions.IgnoreCase;
                    string finale = "";
                    foreach (Match m in Regex.Matches(input, pattern, options))
                    {
                        Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
                        finale += m.Value + "\n";
                    }
                    textBox1.Text = finale;
                }
                catch (IOException)
                {
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Andrea-Paperini") { UseShellExecute = true });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://github.com/Andrea-Paperini") { UseShellExecute = true });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text file | *.txt";
            saveFileDialog1.Title = "Salva file";

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
                return;

            File.WriteAllText(saveFileDialog1.FileName, textBox1.Text);
        }
    }
}
