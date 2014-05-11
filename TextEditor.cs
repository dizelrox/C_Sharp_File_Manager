using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    public partial class TextEditor : Form
    {
        private string _path;

        public TextEditor(string path)
        {
            
            _path = path + ".txt";

            InitializeComponent();
            this.Show();
        }

        private void TextEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            var save = MessageBox.Show("Do you want to save the file?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (save == DialogResult.Yes)
            {
                Save();
            }
        }

        private void Save()
        {
            if (!File.Exists(_path))
                File.WriteAllText(_path, richTextBox.Text);
            else
            {
                var overWriteConfirm = MessageBox.Show("This file already exists!\nDo you want to overwrite?",
                    "Confirm Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (overWriteConfirm == DialogResult.Yes)
                {
                    File.WriteAllText(_path, richTextBox.Text);
                }
                //MessageBox.Show("This file already exists!", "Can't overwrite");
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
