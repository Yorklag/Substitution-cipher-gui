using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Substitution_cipher_gui
{
    public partial class Form1 : Form
    {
        static string alphabet = " abcdefghijklmnopqrstuvwxyz0123456789";
        char[] alphabetCharArray = alphabet.ToCharArray();
        public Form1()
        {
            InitializeComponent();
        }
        public string encodeString(bool encode, string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return "";
            }
            else
            {
                input = input.ToLower();
                int shift = (int)cypherNumberBox.Value;
                string output = "";
                char[] inputArray = input.ToCharArray();
                bool isValid = true;
                for (int i = 0; i < inputArray.Length; i++)
                {
                    int index = Array.IndexOf(alphabetCharArray, inputArray[i]);
                    if (index == -1)
                    {
                        isValid = false;
                        break;
                    }
                    if (encode)
                    {
                        index = index + shift;
                        while (index >= alphabetCharArray.Length)
                        {
                            index = index - alphabetCharArray.Length;
                        }
                    }
                    else
                    {
                        index = index - shift;
                        while (index < 0)
                        {
                            index = index + alphabetCharArray.Length;
                        }
                    }
                    output += alphabetCharArray[index];
                }
                if (isValid)
                {
                    return output;
                }
                else
                {
                    return "unable to encode/decode string";
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void encodeButton_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = encodeString(true, inputTextBox.Text);
        }

        private void decodeButton_Click(object sender, EventArgs e)
        {
            outputTextBox.Text = encodeString(false, inputTextBox.Text);
        }
    }
}
