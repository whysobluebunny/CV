using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using BombeLib;
using Newtonsoft.Json.Linq;

namespace Bombe
{
    /// <summary>
    /// Bombe application
    /// </summary>
    public partial class BombeApp : Form
    {
        BombeCL bombe;
        string currentPath;

        public BombeApp()
        {
            InitializeComponent();
            infoPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            textBoxStatus.ScrollBars = ScrollBars.Vertical;
            textBoxParams.ScrollBars = ScrollBars.Both;
            solutions.HorizontalScrollbar = true;
        }

        public BombeApp(string path)
        {
            InitializeComponent();
            infoPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            textBoxStatus.ScrollBars = ScrollBars.Vertical;
            textBoxParams.ScrollBars = ScrollBars.Both;
            solutions.HorizontalScrollbar = true;
            currentPath = path;
            LoadFile();
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            currentPath = openFileDialog.FileName;
            LoadFile();
        }

        void ClearData()
        {
            textBoxStatus.Text = " ";
            solutions.Items.Clear();
            LoadFile();
        }

        private void runBombe_Click(object sender, EventArgs e)
        {
            ClearData();
            //try
            //{
                if (bombe == null)
                {
                    MessageBox.Show("First load a config file");
                    return;
                }
                bombe.Run();
                foreach (var solution in bombe.solutions)
                {
                    textBoxStatus.Text += solution.ToString();
                    solutions.Items.Add(solution);
                }
            //}
            //catch (Exception ex)
            //{
                //MessageBox.Show(ex.Message);
            //}
        }

        void LoadFile()
        {
            try
            {
                string readedfile;
                using (StreamReader fs = new StreamReader(currentPath))
                {
                    readedfile = fs.ReadToEnd();
                }
                var jsObj = JObject.Parse(readedfile);
                bombe = new BombeCL(jsObj.ToObject<MapConfiguration>());
                textBoxParams.Text = File.ReadAllText(currentPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"It seems like you try to open invalid file type." +
                    $"\r\nFull error code: \r\n{ex.GetType()}:{ex.Message}.");
            }
        }

        private void solutions_Click(object sender, EventArgs e)
        {
            if (solutions.SelectedIndex != -1)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to load solution in Enigma?",
                    "Enigma App", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    EnigmaApp enigmaApp = new EnigmaApp(bombe.wheels, bombe.reflector,
                    bombe.solutions[solutions.SelectedIndex].plugboardSets, bombe.solutions[solutions.SelectedIndex].rotorSets);
                    enigmaApp.Show();
                }
            }
        }

        private void Info_Click(object sender, EventArgs e)
        {
            FAQForm faq = new FAQForm();
            faq.Show();
        }
    }
}
