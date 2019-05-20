using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace VPLab9
{
    public partial class Form1 : Form
    {

        private ShapeList ShapeList;
        private Color currentColor;
        String FileName = null;

        public Form1()
        {
            InitializeComponent();
            ShapeList = new ShapeList();
            currentColor = Color.Blue;
            this.DoubleBuffered = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            ShapeList.Draw(e.Graphics);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShapeList.AddShape(e.X, e.Y, currentColor);
            Invalidate();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {
            //////////////////
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {
            ///////////////////////
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            DialogResult result = colorDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                currentColor = colorDialog.Color;
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if(FileName == null)
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "SimpleDraw file (*odr)|*.odr";
                saveFileDialog1.Title = "Save a simpleDraw file";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    FileName = saveFileDialog1.FileName;
            }
            if (FileName != null)
            {
                IFormatter fmt = new BinaryFormatter();

                FileStream strm = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                fmt.Serialize(strm, ShapeList);
                strm.Close();
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            /////////////////////////
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "SimpleDraw file (*odr)|*.odr";
            openFileDialog1.Title = "Open a simple file";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileName = openFileDialog1.FileName;
                    IFormatter fmt = new BinaryFormatter();
                    FileStream strm = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.None);
                    ShapeList = (ShapeList)fmt.Deserialize(strm);
                    strm.Close();
                }catch(Exception ex)
                {
                    MessageBox.Show("Error: Could not read file \"" + FileName + "\" from disk. Original error: " + ex.Message);
                    FileName = null;
                }
            }
            Invalidate(true);
        }
    }
}
