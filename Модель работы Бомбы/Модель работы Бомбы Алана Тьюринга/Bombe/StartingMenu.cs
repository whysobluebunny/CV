using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombe
{
    /// <summary>
    /// Main menu form
    /// </summary>
    public partial class StartingMenu : Form
    {
        BombeApp fileApp;
        NewConfig newFile;
        EnigmaApp enigma;
        FAQForm faq;

        public StartingMenu()
        {
            InitializeComponent();
            showInfo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void loadFile_Click(object sender, EventArgs e)
        {
            fileApp = new BombeApp();
            fileApp.Show();
        }

        private void newConfig_Click(object sender, EventArgs e)
        {
            newFile = new NewConfig();
            newFile.Show();
        }

        private void openEnigma_Click(object sender, EventArgs e)
        {
            enigma = new EnigmaApp();
            enigma.Show();
        }

        private void ShowInfo_Click(object sender, EventArgs e)
        {
            faq = new FAQForm();
            faq.Show();
        }
    }
}
