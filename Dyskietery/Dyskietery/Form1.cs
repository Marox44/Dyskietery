using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

using Marox.ExtensionMethods;
using System.Threading.Tasks;

namespace Dyskietery
{
    public partial class Form1 : Form
    {

        private String[] ports;
        private SerialPort serialPort;


        public Form1()
        {
            InitializeComponent();
            //
            //

            ports = SerialPort.GetPortNames();
            foreach (String port in ports)
            {
                cmbPorts.Items.Add(port);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(cmbPorts.SelectedItem.ToString());// Debug czy dobrze wybiera nazwe portu
            if (serialPort == null)
            {
                serialPort = new SerialPort(cmbPorts.SelectedItem.ToString(), Int32.Parse(txtRate.Text));
            }
            if (!serialPort.IsOpen)
            {
                serialPort.Open();
                this.btn_port_open.Enabled = false;
                this.btn_port_close.Enabled = true;
                this.cmbPorts.Enabled = false;
                this.txtRate.Enabled = false;
            }
        }

        private void btn_port_close_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
                this.btn_port_open.Enabled = true;
                this.btn_port_close.Enabled = false;
                this.cmbPorts.Enabled = true;
                this.txtRate.Enabled = true;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (serialPort != null)
            //    if (serialPort.IsOpen)
            //        if (e.KeyValue >= 65 && e.KeyValue <= 122) // C# Wcisniecie kazdego klawisza alfabetycznego czyta jako kody duzych liter
            //            // dlatego dalem przesuniecie +32 by odpowiadal on malym literom
            //            serialPort.Write(((char)(e.KeyValue + 32)).ToString()); // Najpierw zamieniam kod z int na char a pozniej to na stringa
            //        // c# przy zamianie 65(int) na string da "65" a ma byc pojedynczy
            //        // znak wiec najpierw na chara
            //        else
            //            serialPort.Write(((char)(e.KeyValue)).ToString());

            // this.richTextBox1.Text += ((char)((NUTKI.nutki[((Keys)e.KeyCode).ToString().ToLower()])));

            // string key = ((Keys)e.KeyCode).ToString();

            try
            {
                if (serialPort != null)
                {
                    if (serialPort.IsOpen)
                    {
                        char c = ((char)((NUTKI.nutki[((Keys)e.KeyCode).ToString().ToLower()])));

                        byte[] b = { (byte)c };
                        serialPort.Write(b, 0, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (serialPort != null)
            //    if (serialPort.IsOpen)
            //        if (e.KeyValue >= 48 && e.KeyValue <= 57) // W zwiazku z powyzszym przesuniecia wymagaja tylko klawisze numeryczne
            //            serialPort.Write(((char)(e.KeyValue - 32)).ToString());
            //        else
            //            serialPort.Write(((char)(e.KeyValue)).ToString());

            //this.richTextBox1.Text += ((char)((NUTKI.nutki[((Keys)e.KeyCode).ToString().ToLower()]) + 60));

            try
            {
                if (serialPort != null)
                {
                    if (serialPort.IsOpen)
                    {
                        char c = ((char)((NUTKI.nutki[((Keys)e.KeyCode).ToString().ToLower()]) + 60));

                        byte[] b = { (byte)c };
                        serialPort.Write(b, 0, 1);
                    }
                }
            }
            catch (Exception ex)
            {
                //byte[] b = { (byte)32 };
                //serialPort.Write(b, 0, 1);
                return;
            }
        }

        #region BTNS??
        //HARDCODE BUTTONOW
        private void button_MouseDown(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            pressedButton.BackColor = Color.DarkGray;

            if (serialPort != null)
                if (serialPort.IsOpen)
                    switch (pressedButton.Name)
                    {
                        case "btnQ": serialPort.Write("q"); break;
                        case "btnW": serialPort.Write("w"); break;
                        case "btnE": serialPort.Write("e"); break;
                        case "btnR": serialPort.Write("r"); break;
                        case "btnT": serialPort.Write("t"); break;
                        case "btnY": serialPort.Write("y"); break;
                        case "btnU": serialPort.Write("u"); break;
                        case "btnI": serialPort.Write("i"); break;
                        case "btnO": serialPort.Write("o"); break;
                        case "btnP": serialPort.Write("p"); break;
                        case "btnZ": serialPort.Write("z"); break;
                        case "btnX": serialPort.Write("x"); break;
                        case "btnC": serialPort.Write("c"); break;
                        case "btnV": serialPort.Write("v"); break;
                        case "btnB": serialPort.Write("b"); break;
                        case "btnN": serialPort.Write("n"); break;
                        case "btnM": serialPort.Write("m"); break;
                    }
        }
        private void button_MouseUp(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            pressedButton.BackColor = Color.White;

            if (serialPort != null)
                if (serialPort.IsOpen)
                    switch (pressedButton.Name)
                    {
                        case "btnQ": serialPort.Write("Q"); break;
                        case "btnW": serialPort.Write("W"); break;
                        case "btnE": serialPort.Write("E"); break;
                        case "btnR": serialPort.Write("R"); break;
                        case "btnT": serialPort.Write("T"); break;
                        case "btnY": serialPort.Write("Y"); break;
                        case "btnU": serialPort.Write("U"); break;
                        case "btnI": serialPort.Write("I"); break;
                        case "btnO": serialPort.Write("O"); break;
                        case "btnP": serialPort.Write("P"); break;
                        case "btnZ": serialPort.Write("Z"); break;
                        case "btnX": serialPort.Write("X"); break;
                        case "btnC": serialPort.Write("C"); break;
                        case "btnV": serialPort.Write("V"); break;
                        case "btnB": serialPort.Write("B"); break;
                        case "btnN": serialPort.Write("N"); break;
                        case "btnM": serialPort.Write("M"); break;
                    }
        }
        private void button_MouseDown1(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            pressedButton.BackColor = Color.DarkGray;

            if (serialPort != null)
                if (serialPort.IsOpen)
                    switch (pressedButton.Name)
                    {
                        case "btn2": serialPort.Write("2"); break;
                        case "btn3": serialPort.Write("3"); break;
                        case "btn5": serialPort.Write("5"); break;
                        case "btn6": serialPort.Write("6"); break;
                        case "btn7": serialPort.Write("7"); break;
                        case "btn9": serialPort.Write("9"); break;
                        case "btn0": serialPort.Write("0"); break;
                        case "btnS": serialPort.Write("s"); break;
                        case "btnD": serialPort.Write("d"); break;
                        case "btnF": serialPort.Write("f"); break;
                        case "btnH": serialPort.Write("h"); break;
                        case "btnJ": serialPort.Write("j"); break;
                    }
        }
        private void button_MouseUp1(object sender, MouseEventArgs e)
        {
            Button pressedButton = (Button)sender;
            pressedButton.BackColor = Color.Black;

            if (serialPort != null)
                if (serialPort.IsOpen)
                    switch (pressedButton.Name)
                    {
                        case "btn2": serialPort.Write(((char)18).ToString()); break;
                        case "btn3": serialPort.Write(((char)19).ToString()); break;
                        case "btn5": serialPort.Write(((char)21).ToString()); break;
                        case "btn6": serialPort.Write(((char)22).ToString()); break;
                        case "btn7": serialPort.Write(((char)23).ToString()); break;
                        case "btn9": serialPort.Write(((char)25).ToString()); break;
                        case "btn0": serialPort.Write(((char)26).ToString()); break;
                        case "btnS": serialPort.Write("S"); break;
                        case "btnD": serialPort.Write("D"); break;
                        case "btnF": serialPort.Write("F"); break;
                        case "btnH": serialPort.Write("H"); break;
                        case "btnJ": serialPort.Write("J"); break;
                    }
        }
        #endregion


        private List<dzwiek> dzwieki = new List<dzwiek>();
        private List<dzwiek> dzwieki_kopia = null;

        private string lastFileName = null;

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();

           // this.lastFileName = null;

            bool okno = false;
            if (lastFileName != null)
            {

            }
            else
            {
                var a = openFileDialog1.ShowDialog();
            }

            if (true)
            {
                try
                {
                    System.IO.StreamReader file;
                    if (lastFileName == null)
                    {
                        file = new System.IO.StreamReader(openFileDialog1.FileName);
                        this.lbl_file_name.Text = openFileDialog1.SafeFileName;
                        this.lastFileName = openFileDialog1.FileName;
                    }
                    else
                    {
                        file = new System.IO.StreamReader(lastFileName);
                        this.lbl_file_name.Text = lastFileName;
                    }

                    string line;

                    while ((line = file.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }

                    file.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.lbl_file_notes.Text = lines.Count.ToString();

            foreach (var s in lines)
            {
                if (s.IndexOf("End_track") > 0)
                {
                    dzwieki.Add(new dzwiek(0, 0, false, 0, true));
                }
                else
                {
                    //2, 0, Note_on_c, 81
                    //2, 960, Note_on_c, 76

                    //1;0;Note_off_c;60

                    if (s.IndexOf(";") > 0)
                    {
                        List<int> colons = new List<int>();
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] == ';')
                            {
                                colons.Add(i);
                            }
                        }
                        if (!(colons.Count == 3))
                        {
                            MessageBox.Show("Parse error: (line " + lines.FindIndex(x => x == s) + ")" + s);
                        }

                        uint _track = Convert.ToUInt32(s.Substring(0, colons[0]));
                        uint _time = Convert.ToUInt32(s.Substring(colons[0] + 1, (colons[1] - (colons[0] + 1))));
                        string _on_off = s.Substring(colons[1] + 1, (colons[2] - (colons[1] + 1)));
                        bool _onOff = true;
                        if (_on_off == "Note_on_c" || _on_off == " Note_on_c")
                        {
                            _onOff = true;
                        }
                        if (_on_off == "Note_off_c" || _on_off == " Note_off_c")
                        {
                            _onOff = false;
                        }
                        uint _nuta = Convert.ToUInt32(s.Substring(colons[2] + 1));


                        dzwieki.Add(new dzwiek(_track, _time, _onOff, _nuta));
                    }

                    else
                    {
                        List<int> commas = new List<int>();
                        for (int i = 0; i < s.Length; i++)
                        {
                            if (s[i] == ',')
                            {
                                commas.Add(i);
                            }
                        }
                        if (!(commas.Count == 3))
                        {
                            MessageBox.Show("Parse error: " + s);
                        }

                        uint _track = Convert.ToUInt32(s.Substring(0, commas[0]));
                        uint _time = Convert.ToUInt32(s.Substring(commas[0] + 2, (commas[1] - (commas[0] + 2))));
                        string _on_off = s.Substring(commas[1] + 2, (commas[2] - (commas[1] + 2)));
                        bool _onOff = true;
                        if (_on_off == "Note_on_c" || _on_off == " Note_on_c")
                        {
                            _onOff = true;
                        }
                        if (_on_off == "Note_off_c" || _on_off == " Note_off_c")
                        {
                            _onOff = false;
                        }
                        uint _nuta = Convert.ToUInt32(s.Substring(commas[2] + 2));


                        dzwieki.Add(new dzwiek(_track, _time, _onOff, _nuta));
                    }
                }
            }

            //Marox.Alert.Info("dzwieki[]: " + dzwieki.Count.ToString());

            dzwieki_kopia = new List<dzwiek>(dzwieki);

            this.btn_file_play.Enabled = true;
            this.btn_file_load.Enabled = false;

         
        }


        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        List<byte[]> result = new List<byte[]>();
        int notesPlayed = 0;

        public async void run()
        {
            //  List<dzwiek> dzwieki = new List<dzwiek>(this.dzwieki);

            Stopwatch stoper = new Stopwatch();
            stoper.Start();

            while (true)
            {
                if (dzwieki.Count <= 0)
                {
                    break;
                }
                if (dzwieki[0].endTrack == true)
                {
                    dzwieki.RemoveAt(0);

                    stoper.Reset();
                }
                if (dzwieki.Count <= 0)
                {
                    break;
                }

                await Task.Run(() =>
                {
                    this.lbl_timer.SafeInvoke(d => d.Text = stoper.ElapsedMilliseconds.ToString() + " (" + stoper.Elapsed.ToString(@"hh\:mm\:ss") + ")");
                });

                int _t = (int)(stoper.ElapsedMilliseconds / this.numeric_stopwatch.Value);
                //int _t = (int)(stoper.ElapsedMilliseconds * 1.5);

                while (true)
                {
                    if (dzwieki.Count <= 1)
                    {
                        break;
                    }

                    if (dzwieki[0].czas == _t || (dzwieki[0].czas < _t))
                    {
                        await Task.Run(() =>
                        {
                            this.listBox1.SafeInvoke((lb) =>
                            {
                                lb.Items.Add(dzwieki[0].nuta.ToString() + "\t" + _t);
                                lb.TopIndex = lb.Items.Count - 1;
                            });

                            notesPlayed++;
                            this.lbl_notes_played.SafeInvoke(d => d.Text = notesPlayed.ToString());
                        });


                        await Task.Run(() =>
                        {
                            this.markButton(dzwieki[0].nuta, dzwieki[0].stan);
                        });

                        //if (stoper.ElapsedMilliseconds == dzwieki[0].czas)
                        {
                            //do stacji
                            if (dzwieki[0].stan == true)
                            {
                                //nutka on
                                byte[] b = { (byte)(dzwieki[0].nuta + (int)this.numeric_oktawy.Value) };
                                serialPort.Write(b, 0, 1);
                            }
                            else
                            {
                                //nutka off
                                byte[] b = { ((byte)(dzwieki[0].nuta + 60 + (int)this.numeric_oktawy.Value)) };
                                serialPort.Write(b, 0, 1);
                            }

                            dzwieki.RemoveAt(0);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //MessageBox.Show(result.Count.ToString());

            //this.SafeInvoke(f => f.button1_Click(new object(), new EventArgs()));
            //run();

        }

        private void markButton(uint nuta, bool on_off)
        {
            List<int> C = new List<int> { 31, 43, 55, 67, 79 };
            List<int> D = new List<int> { 33, 45, 57, 69, 81 };
            List<int> E = new List<int> { 35, 47, 59, 71, 83 };
            List<int> F = new List<int> { 36, 48, 60, 72, 84 };
            List<int> G = new List<int> { 38, 50, 62, 74, 86 };
            List<int> A = new List<int> { 40, 52, 64, 76, 88 };
            List<int> H = new List<int> { 41, 53, 65, 77, 89 };

            if (C.Exists(e => e == nuta))
            {
                if (on_off)
                {
                    this.btn_keyboard_c0.BackColor = SystemColors.Highlight;
                }
                else
                {
                    this.btn_keyboard_c0.BackColor = SystemColors.ControlLightLight;
                }
                return;
            }
            if (D.Exists(e => e == nuta))
            {
                if (on_off)
                {
                    this.btn_keyboard_d0.BackColor = SystemColors.Highlight;
                }
                else
                {
                    this.btn_keyboard_d0.BackColor = SystemColors.ControlLightLight;
                }
                return;
            }
            if (E.Exists(e => e == nuta))
            {
                if (on_off)
                {
                    this.btn_keyboard_e0.BackColor = SystemColors.Highlight;
                }
                else
                {
                    this.btn_keyboard_e0.BackColor = SystemColors.ControlLightLight;
                }
                return;
            }
            if (F.Exists(e => e == nuta))
            {
                if (on_off)
                {
                    this.btn_keyboard_f0.BackColor = SystemColors.Highlight;
                }
                else
                {
                    this.btn_keyboard_f0.BackColor = SystemColors.ControlLightLight;
                }
                return;
            }
            if (G.Exists(e => e == nuta))
            {
                if (on_off)
                {
                    this.btn_keyboard_g0.BackColor = SystemColors.Highlight;
                }
                else
                {
                    this.btn_keyboard_g0.BackColor = SystemColors.ControlLightLight;
                }
                return;
            }
            if (A.Exists(e => e == nuta))
            {
                if (on_off)
                {
                    this.btn_keyboard_a0.BackColor = SystemColors.Highlight;
                }
                else
                {
                    this.btn_keyboard_a0.BackColor = SystemColors.ControlLightLight;
                }
                return;
            }
            if (H.Exists(e => e == nuta))
            {
                if (on_off)
                {
                    this.btn_keyboard_h0.BackColor = SystemColors.Highlight;
                }
                else
                {
                    this.btn_keyboard_h0.BackColor = SystemColors.ControlLightLight;
                }
                return;
            }
        }
        private void resetButtons()
        {
            List<Control> btns = new List<Control>();

            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(Button))
                {
                    btns.Add(c);
                }
            }

            btns = btns.FindAll(c => c.Name.IndexOf("btn_keyboard") > -1);

            foreach (var b in btns)
            {
                b.BackColor = SystemColors.ControlLightLight;
            }
        }

        System.Threading.Thread thread_play = null;
        private void button2_Click(object sender, EventArgs e)
        {
            // this.timer1.Start();

            thread_play = new System.Threading.Thread(new System.Threading.ThreadStart(run));
            thread_play.Name = "Auto-Play";
            thread_play.IsBackground = true;
            thread_play.Start();

            this.btn_file_play.Enabled = false;
        }

        private async void btn_file_clear_Click(object sender, EventArgs e)
        {
            //if (this.thread_play.IsAlive)
            //{
            //    this.thread_play.Abort();
            //}

            this.dzwieki.Clear();
            if (thread_play != null)
                while (thread_play.IsAlive) ;
            this.lbl_file_name.Text = "";
            this.lbl_file_notes.Text = "";
            await Task.Run(() =>
            {
                this.lbl_timer.SafeInvoke(d => d.Text = "0 (00:00:00)");
            });
            this.lbl_notes_played.Text = "0";
            this.notesPlayed = 0;
            this.resetButtons();
            this.listBox1.Items.Clear();
            if (serialPort != null)
                if (serialPort.IsOpen)
                    serialPort.Write((new byte[] { (byte)254 }), 0, 1);

            this.btn_file_load.Enabled = true;
            this.btn_file_play.Enabled = false;
        }

        private UInt64 counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (counter == dzwieki[0].czas)
            {
                //wyslij do płytki
                //   this.richTextBox1.Text += dzwieki[0].nuta.ToString();

                dzwieki.RemoveAt(0);
            }
            counter++;
            if (counter == 5 * 1000)
            {
                MessageBox.Show("5sekund");
            }

            if (dzwieki.Count <= 0)
            {
                this.timer1.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            if (true)
            {
                await Task.Run(() =>
                {
                    this.listBox1.SafeInvoke((lb) =>
                    {
                        lb.Items.Add(dzwieki[0].nuta.ToString() + "\t" + dzwieki[0].czas.ToString());
                        lb.TopIndex = lb.Items.Count - 1;
                    });

                    notesPlayed++;
                    this.lbl_notes_played.SafeInvoke(d => d.Text = notesPlayed.ToString());
                });


                await Task.Run(() =>
                {
                    this.markButton(dzwieki[0].nuta, dzwieki[0].stan);
                });

                //if (stoper.ElapsedMilliseconds == dzwieki[0].czas)
                {
                    //do stacji
                    if (dzwieki[0].stan == true)
                    {
                        //nutka on
                        byte[] b = { (byte)(dzwieki[0].nuta) };
                        serialPort.Write(b, 0, 1);
                    }

                    System.Threading.Thread.Sleep(500);

                    byte[] _b = { (byte)(dzwieki[0].nuta + 60) };
                    serialPort.Write(_b, 0, 1);


                    dzwieki.RemoveAt(0);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //this.btn_file_clear_Click(new object(), new EventArgs());
            //this.btn_file_clear_Click(new object(), new EventArgs());
            //System.Threading.Thread.Sleep(500);
            //this.btn_file_clear_Click(new object(), new EventArgs());
            //this.btn_file_clear_Click(new object(), new EventArgs());
            //this.btn_file_clear_Click(new object(), new EventArgs());

            //System.Threading.Thread.Sleep(2000);

            //  this.button1_Click(new object(), new EventArgs());

            //  System.Threading.Thread.Sleep(2000);


            //  this.button2_Click(new object(), new EventArgs());

            this.btn_file_clear.PerformClick();
            this.btn_file_load.PerformClick();
            this.btn_file_play.PerformClick();
        }





    }
}