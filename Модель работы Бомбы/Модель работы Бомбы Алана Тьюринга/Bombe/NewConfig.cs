using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BombeLib;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bombe
{
    /// <summary>
    /// Class to make a new configuration for Bombe
    /// </summary>
    public partial class NewConfig : Form
    {
        int stepsAK;
        string pathField;
        List<MapEntry> entries = new List<MapEntry>();

        public NewConfig()
        {
            InitializeComponent();
            MapEntryList.HorizontalScrollbar = true;
        }

        private void rotor1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rotor1.SelectedIndex == rotor2.SelectedIndex || rotor1.SelectedIndex == rotor3.SelectedIndex)
            {
                rotor1.SelectedIndex = -1;
                MessageBox.Show("You can't use two or more equal rotors at the same time!");
            }
        }

        private void rotor2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rotor1.SelectedIndex == rotor2.SelectedIndex || rotor2.SelectedIndex == rotor3.SelectedIndex)
            {
                rotor2.SelectedIndex = -1;
                MessageBox.Show("You can't use two or more equal rotors at the same time!");
            }
        }

        private void rotor3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rotor3.SelectedIndex == rotor2.SelectedIndex || rotor1.SelectedIndex == rotor3.SelectedIndex)
            {
                rotor3.SelectedIndex = -1;
                MessageBox.Show("You can't use two or more equal rotors at the same time!");
            }
        }

        private void addME_Click(object sender, EventArgs e)
        {
            if (entries.Count == 12)
            {
                MessageBox.Show("You have reached the max amount of parts");
                return;
            }
            if (leftChar.Text == "" || rightChar.Text == "" || stepsAheadOfKey.Text == "")
            {
                MessageBox.Show("Fill the gaps!");
                return;
            }
            if (leftChar.Text.Length > 1 || rightChar.Text.Length > 1 || !IsLatin(leftChar.Text[0]) & !IsLatin(rightChar.Text[0]))
            {
                MessageBox.Show("Chars must be latin letters!");
                return;
            }
            if (!IsSuitableNum(stepsAheadOfKey.Text))
            {
                MessageBox.Show("Steps Ahead of key must be positive number! Also it can't be more than 17476.");
                return;
            }
            MapEntry newEntry;
            try
            {
                newEntry = new MapEntry(stepsAK, leftChar.Text.ToUpper()[0], rightChar.Text.ToUpper()[0]);
            }
            catch (ArgumentException ex) { MessageBox.Show(ex.Message); return; }
            if (entries.Contains(newEntry))
            {
                MessageBox.Show("Unacceptable element to add. Check entry of chars you try.");
                return;
            }
            entries.Add(newEntry);
            MapEntryList.Items.Add(newEntry);
            leftChar.Text = "";
            rightChar.Text = "";
            stepsAheadOfKey.Text = "";
        }

        bool IsLatin(char sym) => (sym >= 'A' & sym <= 'Z') || (sym >= 'a' & sym <= 'z');
        bool IsSuitableNum(string st) => (int.TryParse(st, out stepsAK) & stepsAK > 0 & stepsAK < 17477);

        private void removeSelected_Click(object sender, EventArgs e)
        {
            try
            {
                entries.RemoveAt(MapEntryList.SelectedIndex);
                MapEntryList.Items.RemoveAt(MapEntryList.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Select item first"); }
        }

        private void saveAndSerialize_Click(object sender, EventArgs e)
        {
            string path;
            saveFileDialog.Title = "Choose file directory";
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.CheckPathExists = false;
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Filter = "Json files (*.json)|*.json|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            path = saveFileDialog.FileName;
            MapConfiguration config = GetMapFromData();
            if (config == null)
            {
                MessageBox.Show("Check settings. Something might be wrong");
                return;
            }
            SaveFile(path, config);
        }

        void SaveFile(string path, MapConfiguration config)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                JObject obj = JObject.FromObject(config);
                serializer.Serialize(writer, obj);
            }
            pathField = path;
        }

        MapConfiguration GetMapFromData()
        {
            if (rotor1.SelectedIndex == -1 || rotor2.SelectedIndex == -1 || rotor3.SelectedIndex == -1
                || reflectorType.SelectedIndex == -1 || currentEntry.SelectedIndex == -1 || inputLetter.SelectedIndex == -1)
            {
                MessageBox.Show("Fill all the gaps!");
                return null;
            }
            if (MapEntryList == null)
            {
                MessageBox.Show("Fill Map Entries!");
                return null;
            }
            string[] wheelStr = { rotor1.Text, rotor2.Text, rotor3.Text };
            WheelType[] wheels = new WheelType[3];
            for (int i = 0; i < wheels.Length; i++)
            {
                switch (wheelStr[i])
                {
                    case ("I"):
                        wheels[i] = WheelType.I;
                        break;
                    case ("II"):
                        wheels[i] = WheelType.II;
                        break;
                    case ("III"):
                        wheels[i] = WheelType.III;
                        break;
                    case ("IV"):
                        wheels[i] = WheelType.IV;
                        break;
                    case ("V"):
                        wheels[i] = WheelType.V;
                        break;
                    case ("VI"):
                        wheels[i] = WheelType.VI;
                        break;
                    case ("VII"):
                        wheels[i] = WheelType.VII;
                        break;
                    case ("VIII"):
                        wheels[i] = WheelType.VIII;
                        break;
                    case ("Beta"):
                        wheels[i] = WheelType.Beta;
                        break;
                    case ("Gamma"):
                        wheels[i] = WheelType.Gamma;
                        break;
                }
            }
            ReflectorType refType = ReflectorType.A;
            switch (reflectorType.Text)
            {
                case ("A"):
                    refType = ReflectorType.A;
                    break;
                case ("B"):
                    refType = ReflectorType.B;
                    break;
                case ("C"):
                    refType = ReflectorType.C;
                    break;
                case ("B_Thin"):
                    refType = ReflectorType.B_Thin;
                    break;
                case ("C_Thin"):
                    refType = ReflectorType.C_Thin;
                    break;
            }
            bool enableDB = enableDiagonalBoard.Checked;
            char entry = currentEntry.Text[0];
            char input = inputLetter.Text[0];
            MapEntry[] mapEntries = entries.ToArray();
            return new MapConfiguration(wheels, refType, enableDB, entry, input, mapEntries);
        }

        private void currentEntry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentEntry.SelectedIndex == inputLetter.SelectedIndex)
            {
                currentEntry.SelectedIndex = -1;
                MessageBox.Show("Current entry and Input letter can't be equal!");
            }
        }

        private void inputLetter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (currentEntry.SelectedIndex == inputLetter.SelectedIndex)
            {
                inputLetter.SelectedIndex = -1;
                MessageBox.Show("Current entry and Input letter can't be equal!");
            }
        }

        private void openBombe_Click(object sender, EventArgs e)
        {
            BombeApp loadedFile;
            if (pathField == null)
            {
                loadedFile = new BombeApp();
                loadedFile.Show();
                return;
            }
            loadedFile = new BombeApp(pathField);
            loadedFile.Show();
        }

        private void StepsAheadOfKey_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                leftChar.Focus();
        }

        private void LeftChar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                rightChar.Focus();
        }

        private void RightChar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                stepsAheadOfKey.Focus();
        }
    }
}
