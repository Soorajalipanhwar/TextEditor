using System;
using System.IO;


namespace TextEditor
{
    public partial class Form1 : Form
    {
        bool isFileModified = false;
        string savePath = "";


        public Form1()
        {
            InitializeComponent();
            panel4.Hide();
        }

        public void openFile()// open a file
        {
            checkIfFileNeedsSaving();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    savePath = openFileDialog.FileName;
                    richTextBox1.Text = File.ReadAllText(savePath);
                    isFileModified = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }

        }
        public void saveFile()// save the changes
        {
            try
            {
                if (!string.IsNullOrEmpty(savePath))
                {
                    File.WriteAllText(savePath, richTextBox1.Text);
                    isFileModified = false;
                }
                else
                {
                    saveFileAs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void saveFileAs() //save as
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveDialog.FileName, richTextBox1.Text);
                    savePath = saveDialog.FileName;
                    isFileModified = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void closeFile()// Close the file
        {
            checkIfFileNeedsSaving();
            richTextBox1.Clear();
            savePath = "";
        }
        public void checkIfFileNeedsSaving()
        {
            if (isFileModified)
            {
                DialogResult Result = MessageBox.Show("Do you want to save the changes?", "Confirmation",
                    MessageBoxButtons.YesNoCancel);
                if (Result == DialogResult.Yes)
                {
                    saveFile();
                }
                else if (Result == DialogResult.No)
                {
                    return;

                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (isFileModified)
            {
                checkIfFileNeedsSaving();
            }
            Application.Exit();
        }


        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkIfFileNeedsSaving();
            richTextBox1.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void closeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //Close a File
            closeFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save this file
            saveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //save as
            saveFileAs();

        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //print function
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Undo Function
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            //Redo Function
            if (richTextBox1.CanRedo)
            {
                richTextBox1.Redo();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            //Copy Text Function
            richTextBox1.Select(0, richTextBox1.Text.Length);
            richTextBox1.Copy();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0)
                isFileModified = true;
            materialLabel1.Text = richTextBox1.Lines.Length.ToString();
            materialLabel2.Text = richTextBox1.Text.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length.ToString();
            materialLabel6.Text = richTextBox1.Text.Replace(" ", "").Length.ToString();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var layoutArea = e.MarginBounds;
            var font = new Font("Arial", 12, FontStyle.Regular);
            e.Graphics.DrawString(richTextBox1.Text, font, Brushes.Black, layoutArea);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            checkIfFileNeedsSaving();
            Application.Exit();
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.White;
        }

        private void label3_MouseHover_1(object sender, EventArgs e)
        {
            label3.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            toolStrip1.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();

            panel4.Show();
            richTextBox2.Text = "Skilled .NET developer proficient in C# and ASP.NET. Experienced in building robust and scalable applications. Proficient in Python for data science, machine learning, and data analysis. Passionate about leveraging technology to solve complex problems." +
                "\n As a software developer with a strong foundation in computer science, I thrive on solving complex coding challenges and building user-friendly applications. My journey is defined by hands-on experience, continual learning, and a commitment to staying current in tech";
        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {
            panel4.Hide();
            toolStrip1.Show();
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
        }
    }
}
