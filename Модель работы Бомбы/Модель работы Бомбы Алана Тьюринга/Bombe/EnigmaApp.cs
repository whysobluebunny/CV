using BombeLib;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bombe
{
    /// <summary>
    /// Enigma application
    /// </summary>
    public partial class EnigmaApp : Form
    {
        readonly string alphabetStr = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        bool isLoadedFromWindow = false;
        Enigma enigma;
        WheelType[] wheels = new WheelType[3];
        ReflectorType reflector;
        List<Tuple<char, char>> plugboardSets = new List<Tuple<char, char>>();
        List<Tuple<char, char>> newPlugboardSets = new List<Tuple<char, char>>();
        char[] loadedCharPositions = new char[] { 'Z', 'Z', 'Z' };
        string[] rotorSets = new string[3];
        string reflectorStr;
        int currentInputLength = 0;

        public EnigmaApp()
        {
            InitializeComponent();
        }

        public EnigmaApp(WheelType[] wTypes, ReflectorType rType, List<Tuple<char, char>> pSets, List<string> rotorPos)
        {
            InitializeComponent();
            wheels = wTypes;
            reflector = rType;
            plugboardSets = pSets;
            enigma = new Enigma(wheels, reflector, plugboardSets);
            loadedCharPositions = new char[] { rotorPos[0][0], rotorPos[1][0], rotorPos[2][0] };
            enigma.SetWheelPositions(loadedCharPositions);
            isLoadedFromWindow = true;
            LoadFromWindow();
        }

        private void input_TextChanged(object sender, EventArgs e)
        {
            if (enigma == null)
            {
                try
                {
                    SetNewSettings();
                    enigma = new Enigma(wheels, reflector, plugboardSets);
                    enigma.SetWheelPositions(new char[] { rotorLab1.Text[0], rotorLab2.Text[0], rotorLab3.Text[0] });
                    SetUIToCurrentSets();
                    currentInputLength = 0;
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Select all settings");
                    return;
                }
            }

            if (input.Text == "")
            {
                SetUIToCurrentSets();
                output.Text = "";
                enigma.SetWheelPositions(loadedCharPositions);
                return;
            }

            if (input.Text.Length == currentInputLength)
                return;

            if (input.Text.Length == currentInputLength - 1)
            {
                output.Text = output.Text.Substring(0, output.Text.Length - 1);
                enigma.RightWheel.RotateBack();
                SetUIToCurrentSets();
                return;
            }

            if (input.Text.Length < currentInputLength - 1 || input.Text.Length > currentInputLength + 1)
            {
                MessageBox.Show("That's an inappropriate move! You can only enter chars one by one. " +
                    "\r\n Process has been reseted.");
                input.Text = "";
                output.Text = "";
                enigma.SetWheelPositions(loadedCharPositions);
                SetUIToCurrentSets();
                return;
            }

            if (!Array.TrueForAll(input.Text.ToCharArray(), s => IsLatin(s)))
            {
                MessageBox.Show("Only latin letters are allowed!");
                input.Text = input.Text.Remove(input.Text.Length - 1);
                return;
            }
            else
            {
                if (!CheckSettings())
                {
                    SetNewSettings();
                    enigma = new Enigma(wheels, reflector, plugboardSets);
                    input.Text = "";
                    output.Text = "";
                    SetUIToCurrentSets();
                    MessageBox.Show("New settings have appeared. Process has been restarted.");
                    return;
                }
            }
            output.Text += enigma.RotateAndEncode(input.Text.ToUpper()[input.Text.Length - 1]);
            SetUIToCurrentSets();
        }

        void SetUIToCurrentSets()
        {
            rotorLab1.Text = ((char)(enigma.Wheels[0].Position + 64)).ToString();
            rotorLab2.Text = ((char)(enigma.Wheels[1].Position + 64)).ToString();
            rotorLab3.Text = ((char)(enigma.Wheels[2].Position + 64)).ToString();
            currentInputLength = input.Text.Length;
            output.SelectionStart = output.Text.Length;
            output.ScrollToCaret();
        }

        void SetNewSettings()
        {
            rotorSets[0] = rotor1.Text;
            rotorSets[1] = rotor2.Text;
            rotorSets[2] = rotor3.Text;
            reflectorStr = refType.Text;
            for (int i = 0; i < rotorSets.Length; i++)
            {
                switch (rotorSets[i])
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
            switch (refType.Text)
            {
                case ("A"):
                    reflector = ReflectorType.A;
                    break;
                case ("B"):
                    reflector = ReflectorType.B;
                    break;
                case ("C"):
                    reflector = ReflectorType.C;
                    break;
                case ("B_Thin"):
                    reflector = ReflectorType.B_Thin;
                    break;
                case ("C_Thin"):
                    reflector = ReflectorType.C_Thin;
                    break;
            }
            plugboardSets = newPlugboardSets;
            if (enigma != null)
                enigma.SetWheelPositions(new char[] { rotorLab1.Text[0], rotorLab2.Text[0], rotorLab3.Text[0] });
        }

        private void plgElem1_TextChanged(object sender, EventArgs e)
        {
            plgElem1.Text = plgElem1.Text.ToUpper();
            if (plgElem1.Text.Length > 1)
                plgElem1.Text = plgElem1.Text[0].ToString();
            if (plgElem1.Text == "")
                return;
            if (alphabet.Text.Contains(plgElem1.Text) & plgElem1.Text != " ")
                plgElem2.Focus();
            if (alphabet.Text.Contains(plgElem1.Text) && alphabet.Text.Contains(plgElem2.Text)
                && plgElem1.Text != "" && plgElem2.Text != "")
            {
                alphabet.Text = alphabet.Text.Replace(plgElem1.Text, " ");
                alphabet.Text = alphabet.Text.Replace(plgElem2.Text, " ");
                plugboardSettings.Items.Add(new Tuple<char, char>(plgElem1.Text[0], plgElem2.Text[0]));
                newPlugboardSets.Add(new Tuple<char, char>(plgElem1.Text[0], plgElem2.Text[0]));
                plgElem1.Text = "";
                plgElem2.Text = "";
                plgElem1.Focus();
            }
            if ((!alphabet.Text.Contains(plgElem1.Text) || !alphabet.Text.Contains(plgElem2.Text))
                && plgElem1.Text != "" && plgElem2.Text != "")
            {
                plgElem1.Text = "";
                plgElem2.Text = "";
                plgElem1.Focus();
            }
        }

        private void plgElem2_TextChanged(object sender, EventArgs e)
        {
            plgElem2.Text = plgElem2.Text.ToUpper();
            if (plgElem2.Text.Length > 1)
                plgElem2.Text = plgElem1.Text[0].ToString();
            if (plgElem2.Text == "")
                return;
            if (alphabet.Text.Contains(plgElem2.Text) & plgElem2.Text != " ")
                plgElem1.Focus();
            if (alphabet.Text.Contains(plgElem1.Text) && alphabet.Text.Contains(plgElem2.Text)
                && plgElem1.Text != "" && plgElem2.Text != "")
            {
                alphabet.Text = alphabet.Text.Replace(plgElem1.Text, " ");
                alphabet.Text = alphabet.Text.Replace(plgElem2.Text, " ");
                plugboardSettings.Items.Add(new Tuple<char, char>(plgElem1.Text[0], plgElem2.Text[0]));
                newPlugboardSets.Add(new Tuple<char, char>(plgElem1.Text[0], plgElem2.Text[0]));
                plgElem1.Text = "";
                plgElem2.Text = "";
                plgElem1.Focus();
            }
            if ((!alphabet.Text.Contains(plgElem1.Text) || !alphabet.Text.Contains(plgElem2.Text))
                && plgElem1.Text != "" && plgElem2.Text != "")
            {
                plgElem1.Text = "";
                plgElem2.Text = "";
                plgElem1.Focus();
            }
        }

        private void alphabet_Click(object sender, EventArgs e)
        {
        }

        private void remove_Click(object sender, EventArgs e)
        {
            try
            {
                alphabet.Text += newPlugboardSets[plugboardSettings.SelectedIndex].Item1 + " " 
                    + newPlugboardSets[plugboardSettings.SelectedIndex].Item2;
                newPlugboardSets.RemoveAt(plugboardSettings.SelectedIndex);
                plugboardSettings.Items.RemoveAt(plugboardSettings.SelectedIndex);
            }
            catch (ArgumentOutOfRangeException) { MessageBox.Show("Select item first"); }
        }

        bool CheckSettings() => isLoadedFromWindow || (rotorSets[0] == rotor1.Text & rotorSets[1] == rotor2.Text & rotorSets[2] == rotor3.Text
                & reflectorStr == refType.Text & newPlugboardSets == plugboardSets);

        bool IsLatin(char c) => (c >= 'a' & c <= 'z') || (c >= 'A' & c <= 'Z');

        void LoadFromWindow()
        {
            for (int i = 0; i < wheels.Length; i++)
            {
                switch (wheels[i])
                {
                    case (WheelType.I):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 0;
                            if (i == 1)
                                rotor2.SelectedIndex = 0;
                            if (i == 2)
                                rotor3.SelectedIndex = 0;
                            break;
                        }
                    case (WheelType.II):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 1;
                            if (i == 1)
                                rotor2.SelectedIndex = 1;
                            if (i == 2)
                                rotor3.SelectedIndex = 1;
                            break;
                        }
                    case (WheelType.III):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 2;
                            if (i == 1)
                                rotor2.SelectedIndex = 2;
                            if (i == 2)
                                rotor3.SelectedIndex = 2;
                            break;
                        }
                    case (WheelType.IV):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 3;
                            if (i == 1)
                                rotor2.SelectedIndex = 3;
                            if (i == 2)
                                rotor3.SelectedIndex = 3;
                            break;
                        }
                    case (WheelType.V):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 4;
                            if (i == 1)
                                rotor2.SelectedIndex = 4;
                            if (i == 2)
                                rotor3.SelectedIndex = 4;
                            break;
                        }
                    case (WheelType.VI):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 5;
                            if (i == 1)
                                rotor2.SelectedIndex = 5;
                            if (i == 2)
                                rotor3.SelectedIndex = 5;
                            break;
                        }
                    case (WheelType.VII):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 6;
                            if (i == 1)
                                rotor2.SelectedIndex = 6;
                            if (i == 2)
                                rotor3.SelectedIndex = 6;
                            break;
                        }
                    case (WheelType.VIII):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 7;
                            if (i == 1)
                                rotor2.SelectedIndex = 7;
                            if (i == 2)
                                rotor3.SelectedIndex = 7;
                            break;
                        }
                    case (WheelType.Beta):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 8;
                            if (i == 1)
                                rotor2.SelectedIndex = 8;
                            if (i == 2)
                                rotor3.SelectedIndex = 8;
                            break;
                        }
                    case (WheelType.Gamma):
                        {
                            if (i == 0)
                                rotor1.SelectedIndex = 9;
                            if (i == 1)
                                rotor2.SelectedIndex = 9;
                            if (i == 2)
                                rotor3.SelectedIndex = 9;
                            break;
                        }
                }
                switch (reflector)
                {
                    case (ReflectorType.A):
                        {
                            refType.SelectedIndex = 0;
                            break;
                        }
                    case (ReflectorType.B):
                        {
                            refType.SelectedIndex = 1;
                            break;
                        }
                    case (ReflectorType.C):
                        {
                            refType.SelectedIndex = 2;
                            break;
                        }
                    case (ReflectorType.B_Thin):
                        {
                            refType.SelectedIndex = 3;
                            break;
                        }
                    case (ReflectorType.C_Thin):
                        {
                            refType.SelectedIndex = 4;
                            break;
                        }
                }
            }
            newPlugboardSets = plugboardSets;
            for (int i = 0; i < plugboardSets.Count; i++)
                plugboardSettings.Items.Add(plugboardSets[i]);
            SetUIToCurrentSets();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            EnigmaApp newOne = new EnigmaApp();
            newOne.Show();
            Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value == 0)
                numericUpDown1.Value = 26;
            if (numericUpDown1.Value == 27)
                numericUpDown1.Value = 1;
            rotorLab1.Text = alphabetStr.Substring((int)numericUpDown1.Value - 1, 1);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown2.Value == 0)
                numericUpDown2.Value = 26;
            if (numericUpDown2.Value == 27)
                numericUpDown2.Value = 1;
            rotorLab2.Text = alphabetStr.Substring((int)numericUpDown2.Value - 1, 1);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value == 0)
                numericUpDown3.Value = 26;
            if (numericUpDown3.Value == 27)
                numericUpDown3.Value = 1;
            rotorLab3.Text = alphabetStr.Substring((int)numericUpDown3.Value - 1, 1);
        }

        private void Input_KeyUp(object sender, KeyEventArgs e)
        {
            input.SelectionStart = input.Text.Length;
            input.ScrollToCaret();
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
    }
}
