using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace OpenTK_winforms_z03
{
    public partial class Form1 : Form
    {
        int texBrick, texLogo, activeTex;


        Image[] slotImages;
        Random rnd = new Random();
        Timer slotTimer;
        int cycles, maxCycles;
        int i1, i2, i3;

        public Form1()
        {
            InitializeComponent();

            Load += Form1_Load;
            btnTrage.Click += BtnTrage_Click;

            glControl1.Paint += GlControl1_Paint;
            glControl1.Resize += GlControl1_Resize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            glControl1.MakeCurrent();

            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
            GL.Enable(EnableCap.Texture2D);

            texBrick = LoadGLTexture("brickTexture.jpg");
            texLogo = LoadGLTexture("OpenGLTexture.png");
            activeTex = texBrick;

            slotImages = new Image[]
            {
                Image.FromFile("img1.png"),
                Image.FromFile("img2.png"),
                Image.FromFile("img3.png"),
                Image.FromFile("img4.png")
            };

            slot1.Image = slotImages[0];
            slot2.Image = slotImages[1];
            slot3.Image = slotImages[2];

            slotTimer = new Timer();
            slotTimer.Interval = 500; 
            slotTimer.Tick += SlotTimer_Tick;

            lblResult.Text = "";
        }

        private void BtnTrage_Click(object sender, EventArgs e)
        {
            cycles = 0;
            maxCycles = (int)numericCycles.Value; 
            lblResult.Text = "";
            slotTimer.Start();
        }

        private void SlotTimer_Tick(object sender, EventArgs e)
        {
            i1 = rnd.Next(4);
            i2 = rnd.Next(4);
            i3 = rnd.Next(4);

            slot1.Image = slotImages[i1];
            slot2.Image = slotImages[i2];
            slot3.Image = slotImages[i3];

            cycles++;
            if (cycles >= maxCycles)
            {
                slotTimer.Stop();
                CheckResult();
            }
        }

        private void CheckResult()
        {
            if (i1 == i2 && i2 == i3)
            {
                lblResult.Text = "🎉 Ai câștigat!";
                lblResult.ForeColor = Color.LimeGreen;
                activeTex = texLogo;
                glControl1.Invalidate();
            }
            else
            {
                lblResult.Text = "❌ Ai pierdut!";
                lblResult.ForeColor = Color.Red;
            }
        }

        private void GlControl1_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, glControl1.Width, glControl1.Height);
            glControl1.Invalidate();
        }

        private void GlControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 proj = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                (float)glControl1.Width / glControl1.Height,
                1f, 500f
            );

            Matrix4 view = Matrix4.LookAt(100, 100, 100, 0, 0, 0, 0, 1, 0);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref proj);

            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref view);

            GL.BindTexture(TextureTarget.Texture2D, activeTex);
            DrawCube();
            GL.BindTexture(TextureTarget.Texture2D, 0);

            glControl1.SwapBuffers();
        }

        private void DrawCube()
        {
            float s = 30;
            GL.Begin(PrimitiveType.Quads);

       
            GL.TexCoord2(0, 0); GL.Vertex3(-s, -s, s);
            GL.TexCoord2(1, 0); GL.Vertex3(s, -s, s);
            GL.TexCoord2(1, 1); GL.Vertex3(s, s, s);
            GL.TexCoord2(0, 1); GL.Vertex3(-s, s, s);

     
            GL.TexCoord2(0, 0); GL.Vertex3(-s, -s, -s);
            GL.TexCoord2(1, 0); GL.Vertex3(s, -s, -s);
            GL.TexCoord2(1, 1); GL.Vertex3(s, s, -s);
            GL.TexCoord2(0, 1); GL.Vertex3(-s, s, -s);

            GL.End();
        }

        private int LoadGLTexture(string file)
        {
            if (!File.Exists(file)) return 0;

            Bitmap bmp = new Bitmap(file);
            BitmapData data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb
);

            int tex;
            GL.GenTextures(1, out tex);
            GL.BindTexture(TextureTarget.Texture2D, tex);

            GL.TexImage2D(TextureTarget.Texture2D, 0,
                PixelInternalFormat.Rgba,
                data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0);

            bmp.UnlockBits(data);
            bmp.Dispose();

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            return tex;
        }
    }
}
