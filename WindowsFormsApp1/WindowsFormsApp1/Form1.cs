using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Client Code
            btnOpen.Click += BtnOpen_Click;
            btnSave.Click += BtnSave_Click;
            btnFont.Click += BtnColor_Click;
            btnColor.Click += BtnColor_Click1;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.WordWrap = true;
        }

        private void BtnColor_Click1(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog.Color;
               
            }
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            if(fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog.Font;
                if(fontDialog.ShowColor == true)
                {
                    textBox1.ForeColor = fontDialog.Color;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            InitialFilter(saveFileDialog);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;
                File.WriteAllText(fileName, textBox1.Text);
            }
            else
            {
                return;
            }
        }
       

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDiolog = new OpenFileDialog();
            InitialFilter(openFileDiolog);
            if(openFileDiolog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = File.ReadAllText(openFileDiolog.FileName);
            }
        }
        private void InitialFilter(FileDialog dialog)
        {
            dialog.Filter = "Веб-страница(*.html)|*.html|Text Files(*.txt)|*.txt|C# Code(*.cs)|*.cs|All Files (*.*)|*.*";
            dialog.FilterIndex = 3;
        }
    }
}
