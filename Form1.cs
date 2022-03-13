using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Flipnic_Video_Deocde
{
    public partial class Form1 : Form
    {
        int x1_start = 0;
        int x1_end = 320;
        int x2_start = 321;
        int x2_end = 637;
        int y_step = 30;
        bool doneonce = false;
        bool rendering = false;
        bool ntsc_weirdness = false;
        List<Image> imagelist = new List<Image>();
        Image output;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Enabled = !Program.unattended;
            textBox1.Text = x1_start.ToString();
            textBox2.Text = x1_end.ToString();
            textBox4.Text = x2_start.ToString();
            textBox3.Text = x2_end.ToString();
            textBox5.Text = y_step.ToString();
            if (Program.unattended)
            {
                List<string> files = new List<string>();
                string template = Program.input.Replace(".png", "");
                for (int i = 0; i < 999999; i++)
                {
                    if (File.Exists(template + i.ToString() + ".png"))
                    {
                        files.Add(template + i.ToString() + ".png");
                    }
                }
                if (files.Count == 0)
                {
                    MessageBox.Show("Please specify a template to enumerate files in arguments.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
                foreach (string s in files)
                {
                    Image i = Image.FromFile(s);
                    imagelist.Add(i);
                }
                RefreshList();
                exportImages.FileName = Program.output;
                rendering = true;
                trackBar1.Value = trackBar1.Maximum;
                trackBar1.Value = trackBar1.Minimum;
                play.Enabled = true;
                Unattend u = new Unattend();
                u.Show();
                this.Hide();
            }
        }

        void RefreshList()
        {
            trackBar1.Maximum = imagelist.Count - 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            if (openImages.ShowDialog() == DialogResult.OK)
            {
                if (openImages.FileNames.Length > 0)
                {
                    foreach (Image img in imagelist)
                    {
                        img.Dispose();
                    }
                    imagelist.Clear();
                    foreach (string s in openImages.FileNames)
                    {
                        Image i = Image.FromFile(s);
                        imagelist.Add(i);
                    }
                    RefreshList();
                }
            }
            button1.Enabled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            if (imagelist.Count > 0)
            { 
                if (doneonce && !Program.unattended) { 
                    chroma.Image.Dispose();
                    luma.Image.Dispose();
                    composite.Image.Dispose();
                } else { doneonce = true;  }
                Bitmap rgb = new Bitmap(320, 320);
                Bitmap a255 = new Bitmap(320, 320);
                int id = trackBar1.Value;
                Image current = imagelist[id];
                int final_x = 0;
                int final_y = 0;
                for (int line = 0; line < 8; line++)
                {
                    int y_start = line * y_step;
                    int y_end = y_start + y_step;
                    // some crap to deal with the fact that line 2 and 6 have different
                    // heights in NTSC
                    if (ntsc_weirdness)
                    {
                        if (line == 2)
                        {
                            y_start += 1;
                            y_end += 1;
                            y_start += 1;
                        }
                        if (line == 3)
                        {
                            y_start += 1;
                            y_end += 1;
                            y_start += 1;
                        }
                        if (line == 4)
                        {
                            y_start += 1;
                            y_end += 1;
                        }
                        if (line == 5)
                        {
                            y_start += 1;
                            y_end += 1;
                        }
                        if (line == 6)
                        {
                            y_start += 1;
                            y_end += 1;
                        }
                        if (line == 7)
                        {
                            y_start += 1;
                            y_end += 1;
                        }
                        if (line > 5)
                        {
                            y_start += 1;
                            y_end += 1;
                        }
                    }
                    if (line == 4)
                    {
                        final_y = 0;
                    }
                    for (int y = y_start; y < y_end; y++)
                    {
                        final_x = 0;
                        for (int x = x1_start; x < x1_end; x++)
                        {
                            if (line < 4)
                            {
                                if ((y < current.Height) && (final_y < current.Height) && (x < current.Width) && (final_x < current.Width))
                                {
                                    rgb.SetPixel(final_x, final_y, ((Bitmap)current).GetPixel(x, y));
                                }
                            }
                            else
                            {
                                if ((y < current.Height) && (final_y < current.Height) && (x < current.Width) && (final_x < current.Width))
                                {
                                    a255.SetPixel(final_x, final_y, ((Bitmap)current).GetPixel(x, y));
                                }
                            }
                            final_x++;
                        }
                        final_y++;
                    }
                a:
                    for (int y = y_start; y < y_end; y++)
                    {
                        final_x = 0;
                        for (int x = x2_start; x < x2_end; x++)
                        {
                            if (line < 4)
                            {
                                if ((y < current.Height) && (final_y < current.Height) && (x < current.Width) && (final_x < current.Width))
                                {
                                    rgb.SetPixel(final_x, final_y, ((Bitmap)current).GetPixel(x, y));
                                }
                            }
                            else
                            {
                                if ((y < current.Height) && (final_y < current.Height) && (x < current.Width) && (final_x < current.Width))
                                {
                                    a255.SetPixel(final_x, final_y, ((Bitmap)current).GetPixel(x, y));
                                }
                            }
                            final_x++;
                        }
                        final_y++;
                    }
                }
                Bitmap argb = new Bitmap(final_x, final_y);
                for (int y = 0; y < final_y; y++)
                {
                    for (int x = 0; x < final_x; x++)
                    {
                        int a = a255.GetPixel(x, y).R;
                        int r = rgb.GetPixel(x, y).R;
                        int g = rgb.GetPixel(x, y).G;
                        int b = rgb.GetPixel(x, y).B;
                        argb.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                    }
                }
                if (!rendering)
                {
                    chroma.Image = rgb;
                    luma.Image = a255;
                    composite.Image = argb;
                } else
                {
                    output = argb;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text, out x1_start);
            Reload();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox2.Text, out x1_end);
            Reload();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox4.Text, out x2_start);
            Reload();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox3.Text, out x2_end);
            Reload();
        }

        private void play_Tick(object sender, EventArgs e)
        {
            if (trackBar1.Value != trackBar1.Maximum)
            {
                if (rendering)
                {
                    play.Enabled = false;
                    try
                    {
                        output.Save(exportImages.FileName.Replace(".png", trackBar1.Value.ToString() + ".png"), System.Drawing.Imaging.ImageFormat.Png);
                        output.Dispose();
                    }
                    catch { }
                    play.Enabled = true;
                    if (Program.unattended)
                    {
                        Program.max = trackBar1.Maximum;
                        Program.progress = trackBar1.Value;
                    }
                }
                trackBar1.Value++;
            }
            else
            {
                play.Enabled = false;
                button2.Text = "Play";
                trackBar1.Value = 0;
                if (rendering)
                {
                    rendering = false;
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button3.Enabled = true;
                    textBox1.Enabled = true;
                    textBox2.Enabled = true;
                    textBox3.Enabled = true;
                    textBox4.Enabled = true;
                    textBox5.Enabled = true;
                    trackBar1.Enabled = true;
                    if (Program.unattended)
                    {
                        this.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            play.Enabled = !play.Enabled;
            if (play.Enabled) { button2.Text = "Pause"; }
            else { button2.Text = "Play"; }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (play.Enabled)
            {
                Reload();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox5.Text, out y_step);
            Reload();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (exportImages.ShowDialog() == DialogResult.OK)
            {
                trackBar1.Value = trackBar1.Maximum;
                trackBar1.Value = trackBar1.Minimum;
                rendering = true;
                play.Enabled = true;
                if (doneonce)
                {
                    chroma.Image.Dispose();
                    luma.Image.Dispose();
                }
                button2.Text = "Rendering...";
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                trackBar1.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!ntsc_weirdness)
            {
                textBox5.Text = "34";
                ntsc_weirdness = true;
            }
            else
            {
                textBox5.Text = "30";
                ntsc_weirdness = false;
            }
        }
    }
}
