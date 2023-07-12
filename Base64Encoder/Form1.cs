using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base64Encoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Base64 Encoder";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Base64 base64 = new Base64();
            string toEncodeString = richTextBox1.Text;
            byte[] textBytes = Encoding.UTF8.GetBytes(toEncodeString);

            richTextBox2.Text = base64.Encode(textBytes);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Base64 base64 = new Base64();
            string toDecode = richTextBox3.Text;

            richTextBox4.Text = Encoding.UTF8.GetString(base64.Decode(toDecode));
        }
    }
}
