namespace OpenTK_winforms_z03
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelOpenGL;
        private OpenTK.GLControl glControl1;

        private System.Windows.Forms.Panel panelSlots;
        private System.Windows.Forms.PictureBox slot1;
        private System.Windows.Forms.PictureBox slot2;
        private System.Windows.Forms.PictureBox slot3;

        private System.Windows.Forms.NumericUpDown numericCycles;
        private System.Windows.Forms.Label lblCycles;

        private System.Windows.Forms.Button btnTrage;
        private System.Windows.Forms.Label lblResult;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelOpenGL = new System.Windows.Forms.Panel();
            this.glControl1 = new OpenTK.GLControl();
            this.panelSlots = new System.Windows.Forms.Panel();
            
            this.slot1 = new System.Windows.Forms.PictureBox();
            this.slot2 = new System.Windows.Forms.PictureBox();
            this.slot3 = new System.Windows.Forms.PictureBox();

            this.numericCycles = new System.Windows.Forms.NumericUpDown();
            this.lblCycles = new System.Windows.Forms.Label();

            this.btnTrage = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();

            this.panelOpenGL.Location = new System.Drawing.Point(0, 0);
            this.panelOpenGL.Size = new System.Drawing.Size(900, 700);
            this.panelOpenGL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOpenGL.Controls.Add(this.glControl1);

            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.BackColor = System.Drawing.Color.Black;

 
            this.panelSlots.Location = new System.Drawing.Point(910, 20);
            this.panelSlots.Size = new System.Drawing.Size(360, 340);
            this.panelSlots.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            this.slot1.Location = new System.Drawing.Point(10, 10);
            this.slot1.Size = new System.Drawing.Size(100, 100);
            this.slot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.slot2.Location = new System.Drawing.Point(125, 10);
            this.slot2.Size = new System.Drawing.Size(100, 100);
            this.slot2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.slot3.Location = new System.Drawing.Point(240, 10);
            this.slot3.Size = new System.Drawing.Size(100, 100);
            this.slot3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            this.lblCycles.Text = "Număr cicluri:";
            this.lblCycles.Location = new System.Drawing.Point(20, 130);
            this.lblCycles.AutoSize = true;

      
            this.numericCycles.Location = new System.Drawing.Point(150, 128);
            this.numericCycles.Minimum = 1;
            this.numericCycles.Maximum = 50;
            this.numericCycles.Value = 10;

            this.btnTrage.Text = "Trage!";
            this.btnTrage.Location = new System.Drawing.Point(100, 170);
            this.btnTrage.Size = new System.Drawing.Size(150, 40);

            this.lblResult.Location = new System.Drawing.Point(100, 230);
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Segoe UI", 12F);

            this.panelSlots.Controls.Add(this.slot1);
            this.panelSlots.Controls.Add(this.slot2);
            this.panelSlots.Controls.Add(this.slot3);
            this.panelSlots.Controls.Add(this.lblCycles);
            this.panelSlots.Controls.Add(this.numericCycles);
            this.panelSlots.Controls.Add(this.btnTrage);
            this.panelSlots.Controls.Add(this.lblResult);

            this.ClientSize = new System.Drawing.Size(1300, 720);
            this.Controls.Add(this.panelOpenGL);
            this.Controls.Add(this.panelSlots);
            this.Text = "OpenGL + Slot Machine";
        }
    }
}
