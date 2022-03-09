
namespace Flipnic_Video_Deocde
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.chroma = new System.Windows.Forms.PictureBox();
            this.luma = new System.Windows.Forms.PictureBox();
            this.composite = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openImages = new System.Windows.Forms.OpenFileDialog();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.play = new System.Windows.Forms.Timer(this.components);
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.exportImages = new System.Windows.Forms.SaveFileDialog();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chroma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.composite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // chroma
            // 
            this.chroma.Location = new System.Drawing.Point(12, 11);
            this.chroma.Name = "chroma";
            this.chroma.Size = new System.Drawing.Size(320, 240);
            this.chroma.TabIndex = 0;
            this.chroma.TabStop = false;
            // 
            // luma
            // 
            this.luma.Location = new System.Drawing.Point(338, 11);
            this.luma.Name = "luma";
            this.luma.Size = new System.Drawing.Size(320, 240);
            this.luma.TabIndex = 1;
            this.luma.TabStop = false;
            // 
            // composite
            // 
            this.composite.BackgroundImage = global::Flipnic_Video_Deocde.Properties.Resources.trans_text;
            this.composite.Location = new System.Drawing.Point(12, 257);
            this.composite.Name = "composite";
            this.composite.Size = new System.Drawing.Size(320, 240);
            this.composite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.composite.TabIndex = 2;
            this.composite.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(558, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openImages
            // 
            this.openImages.Filter = "Bitmap, PNG, or JPEG images|*.bmp;*.jpg;*.jpeg;*.jpe;*.png|All files|*.*";
            this.openImages.Multiselect = true;
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(338, 257);
            this.trackBar1.Maximum = 0;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(320, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(347, 305);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(45, 23);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "0";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(398, 305);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(45, 23);
            this.textBox2.TabIndex = 7;
            this.textBox2.Text = "304";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(398, 332);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(45, 23);
            this.textBox3.TabIndex = 9;
            this.textBox3.Text = "604";
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(347, 332);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(45, 23);
            this.textBox4.TabIndex = 8;
            this.textBox4.Text = "300";
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(452, 305);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 26);
            this.button2.TabIndex = 10;
            this.button2.Text = "Play";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // play
            // 
            this.play.Interval = 40;
            this.play.Tick += new System.EventHandler(this.play_Tick);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(347, 359);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(45, 23);
            this.textBox5.TabIndex = 11;
            this.textBox5.Text = "30";
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(452, 354);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 26);
            this.button3.TabIndex = 12;
            this.button3.Text = "Export sequence";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // exportImages
            // 
            this.exportImages.Filter = "Portable Network Graphics|*.png";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(452, 386);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(123, 23);
            this.button4.TabIndex = 13;
            this.button4.Text = "NTSC/PAL";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 514);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.composite);
            this.Controls.Add(this.luma);
            this.Controls.Add(this.chroma);
            this.Name = "Form1";
            this.Text = "Flipnic frame extract";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chroma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.composite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox chroma;
        private System.Windows.Forms.PictureBox luma;
        private System.Windows.Forms.PictureBox composite;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openImages;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer play;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.SaveFileDialog exportImages;
        private System.Windows.Forms.Button button4;
    }
}

