using System;
using System.Windows.Forms;
using SharpGL;
using System.Collections.Generic;

namespace SimpleDrawingSample
{
    public partial class Home : Form
    {
       private float width = 250.0f;
       private float height = 250.0f;
        private List<int> pntX = new List<int>();
        private List<int> pntY = new List<int>();
        float rtri = 0;
        float rquad = 0;



        public Home()
        {
            InitializeComponent();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();
            panel9.Hide();
        }
        
        private void drawPolygon()
        {
            OpenGL gl = this.openGLControl2.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, 0.0f);
            gl.Color(0.5f, 0.8f, 0.0f);
            gl.Begin(OpenGL.GL_POLYGON);
            for (int i = 0; i < pntX.Count; i++)
            {
                gl.Vertex(pntX[i]/width, pntY[i]/height);
            }
            gl.End();
            gl.Flush();
        }

        void drawPolygonTrans(int x, int y)
        {
            OpenGL gl = this.openGLControl2.OpenGL;
           // gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, 0.0f);

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(0.0f,0.2f, 1.0f);
            for (int i = 0; i < pntX.Count; i++)
            {
                gl.Vertex((pntX[i]+x) / width, (pntY[i]+y) / height);
            }
            gl.End();
            gl.Flush();
        }

        void drawPolygonScale(double x, double y)
        {
            OpenGL gl = this.openGLControl2.OpenGL;
            // gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, 0.0f);

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f, 0.2f, 0.0f);
            for (int i = 0; i < pntX.Count; i++)
            {
                gl.Vertex((pntX[i] * x) / width, (pntY[i] * y) / height);
            }
            gl.End();
            gl.Flush();
        }

        void drawPolygonRotation(double angleRad)
        {
            OpenGL gl = this.openGLControl2.OpenGL;
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, 0.0f);

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f, 0.0f, 1.0f);
            for (int i = 0; i < pntX.Count; i++)
            {
                gl.Vertex(Math.Round((pntX[i] * Math.Cos(angleRad)) - (pntY[i] * Math.Sin(angleRad))) / width, Math.Round((pntX[i] * Math.Sin(angleRad)) + (pntY[i] * Math.Cos(angleRad))) / height);
            }
            gl.End();
            gl.Flush();
           
        }
        void drawPolygonShearing(char shearingAxis,int shearingX,int shearingY)
        {
            OpenGL gl = this.openGLControl2.OpenGL;
            // gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, 0.0f);

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(0.0f, 1.0f, 1.0f);
            if (shearingAxis == 'x' || shearingAxis == 'X')
            {
                gl.Vertex(pntX[0] / width, pntY[0] / height);

                gl.Vertex((pntX[1] + shearingX) / width, pntY[1] / height);
                gl.Vertex((pntX[2] + shearingX) / width, pntY[2] / height);

                gl.Vertex(pntX[3], pntY[3] / height);
            }
            else if (shearingAxis == 'y' || shearingAxis == 'Y')
            {
                gl.Vertex(pntX[0] / width, pntY[0] / height);
                gl.Vertex(pntX[1] / width, pntY[1] / height);

                gl.Vertex(pntX[2] / width, (pntY[2] + shearingY) / height);
                gl.Vertex(pntX[3] / width, (pntY[3] + shearingY) / height);
            }
            gl.End();
            gl.Flush();
        }
        void drawPolygonMirrorReflection(char reflectionAxis)
        {
            OpenGL gl = this.openGLControl2.OpenGL;
            // gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, 0.0f);

            gl.Begin(OpenGL.GL_POLYGON);
            gl.Color(1.0f, 1.0f, 0.0f);
            if (reflectionAxis == 'x' || reflectionAxis == 'X')
            {
                for (int i = 0; i < pntX.Count; i++)
                {
                    gl.Vertex((pntX[i]) / width, (pntY[i] * -1) / height);
                }
            }
            else if (reflectionAxis == 'y' || reflectionAxis == 'Y')
            {
                for (int i = 0; i < pntX.Count; i++)
                {
                    gl.Vertex((pntX[i] * -1) / width, (pntY[i]) / height);

                }
            }
            gl.End();
            gl.Flush();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel6.Hide();
            pntX.Add(int.Parse(textBox1.Text));
            pntX.Add(int.Parse(textBox3.Text));
            pntX.Add(int.Parse(textBox5.Text));

            pntY.Add(int.Parse(textBox2.Text));
            pntY.Add(int.Parse(textBox4.Text));
            pntY.Add(int.Parse(textBox6.Text));

            drawPolygon();
            panel2.Show();
            panel3.Show();
            panel4.Show();
            panel5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            drawPolygonTrans(int.Parse(textBox7.Text), int.Parse(textBox8.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            drawPolygonScale(double.Parse(textBox9.Text), double.Parse(textBox10.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            drawPolygonRotation(double.Parse(textBox11.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            drawPolygonMirrorReflection(char.Parse(comboBox1.Text));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pntX.Clear();
            pntY.Clear();
            textBox1.Text = "0";
            textBox3.Text = "-50";
            textBox5.Text = "50";

            textBox2.Text = "0";
            textBox4.Text = "-50";
            textBox6.Text = "-50";
            OpenGL gl = this.openGLControl2.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();
            panel9.Hide();
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel9.Show();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();

        }

        private void dPrimitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel7.Show();
            panel6.Show();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel8.Hide();
            panel9.Hide();

            OpenGL gl = this.openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);	
            gl.LoadIdentity();

            
            gl.Translate(-1.5f, 0.0f, -6.0f);

            gl.Rotate(rtri, 0.0f, 1.0f, 0.0f);

            gl.Begin(OpenGL.GL_TRIANGLES);	

            gl.Color(1.0f, 0.0f, 0.0f);	
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);	
            gl.Vertex(1.0f, -1.0f, 1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);	
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);	
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);	
            gl.Vertex(1.0f, -1.0f, -1.0f);	
            gl.Color(0.0f, 0.0f, 1.0f);	
            gl.Vertex(-1.0f, -1.0f, -1.0f);	

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 0.0f, 1.0f);	
            gl.Vertex(-1.0f, -1.0f, -1.0f);	
            gl.Color(0.0f, 1.0f, 0.0f);	
            gl.Vertex(-1.0f, -1.0f, 1.0f);	
            gl.End(); 
            gl.Flush();

            rtri += float.Parse(comboBox5.Text);

        }
        
        private void dCubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel6.Show();
            panel8.Show();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel7.Hide();
            panel9.Hide();

            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();	
           
            gl.Translate(1.5f, 0.0f, -7.0f); 
            gl.Rotate(rquad, 1.0f, 1.0f, 1.0f);
            gl.Begin(OpenGL.GL_QUADS);	

            gl.Color(0.0f, 1.0f, 0.0f);	
            gl.Vertex(1.0f, 1.0f, -1.0f);	
            gl.Vertex(-1.0f, 1.0f, -1.0f);	
            gl.Vertex(-1.0f, 1.0f, 1.0f);	
            gl.Vertex(1.0f, 1.0f, 1.0f);	

            gl.Color(1.0f, 0.5f, 0.0f);	
            gl.Vertex(1.0f, -1.0f, 1.0f);	
            gl.Vertex(-1.0f, -1.0f, 1.0f);	
            gl.Vertex(-1.0f, -1.0f, -1.0f);		
            gl.Vertex(1.0f, -1.0f, -1.0f);		

            gl.Color(1.0f, 0.0f, 0.0f);	
            gl.Vertex(1.0f, 1.0f, 1.0f);	
            gl.Vertex(-1.0f, 1.0f, 1.0f);	
            gl.Vertex(-1.0f, -1.0f, 1.0f);		
            gl.Vertex(1.0f, -1.0f, 1.0f);		

            gl.Color(1.0f, 1.0f, 0.0f);		
            gl.Vertex(1.0f, -1.0f, -1.0f);		
            gl.Vertex(-1.0f, -1.0f, -1.0f);		
            gl.Vertex(-1.0f, 1.0f, -1.0f);	
            gl.Vertex(1.0f, 1.0f, -1.0f);

            gl.Color(0.0f, 0.0f, 1.0f);		
            gl.Vertex(-1.0f, 1.0f, 1.0f);		
            gl.Vertex(-1.0f, 1.0f, -1.0f);	
            gl.Vertex(-1.0f, -1.0f, -1.0f);	
            gl.Vertex(-1.0f, -1.0f, 1.0f);

            gl.Color(1.0f, 0.0f, 1.0f);	
            gl.Vertex(1.0f, 1.0f, -1.0f);
            gl.Vertex(1.0f, 1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);	
            gl.End();	
            
            gl.Flush();

            rquad -= 5.0f;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel7.Show();
            panel6.Show();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            OpenGL gl = this.openGLControl1.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();


            gl.Translate(-1.5f, 0.0f, -6.0f);

            gl.Rotate(rtri, float.Parse(comboBox2.Text), float.Parse(comboBox3.Text), float.Parse(comboBox4.Text));

            gl.Begin(OpenGL.GL_TRIANGLES);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.End();
            gl.Flush();

            rtri += float.Parse(comboBox5.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel6.Show();
            panel7.Hide();
            panel1.Hide();
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();

            OpenGL gl = this.openGLControl1.OpenGL;
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            gl.Translate(1.5f, 0.0f, -7.0f);
            gl.Rotate(rquad, float.Parse(comboBox6.Text), float.Parse(comboBox7.Text), float.Parse(comboBox8.Text));
            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, 1.0f, -1.0f);
            gl.Vertex(-1.0f, 1.0f, -1.0f);
            gl.Vertex(-1.0f, 1.0f, 1.0f);
            gl.Vertex(1.0f, 1.0f, 1.0f);

            gl.Color(1.0f, 0.5f, 0.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);

            gl.Color(1.0f, 0.0f, 0.0f);
            gl.Vertex(1.0f, 1.0f, 1.0f);
            gl.Vertex(-1.0f, 1.0f, 1.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);

            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Vertex(-1.0f, 1.0f, -1.0f);
            gl.Vertex(1.0f, 1.0f, -1.0f);

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Vertex(-1.0f, 1.0f, 1.0f);
            gl.Vertex(-1.0f, 1.0f, -1.0f);
            gl.Vertex(-1.0f, -1.0f, -1.0f);
            gl.Vertex(-1.0f, -1.0f, 1.0f);

            gl.Color(1.0f, 0.0f, 1.0f);
            gl.Vertex(1.0f, 1.0f, -1.0f);
            gl.Vertex(1.0f, 1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, 1.0f);
            gl.Vertex(1.0f, -1.0f, -1.0f);
            gl.End();

            gl.Flush();

            rquad -= float.Parse(comboBox9.Text);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pntX.Add(int.Parse(textBox12.Text));
            pntX.Add(int.Parse(textBox13.Text));
            pntX.Add(int.Parse(textBox14.Text));
            pntX.Add(int.Parse(textBox19.Text));

            pntY.Add(int.Parse(textBox17.Text));
            pntY.Add(int.Parse(textBox16.Text));
            pntY.Add(int.Parse(textBox15.Text));
            pntY.Add(int.Parse(textBox18.Text));

            drawPolygon();
            panel2.Show();
            panel3.Show();
            panel4.Show();
            panel5.Show();
        }
    }
}