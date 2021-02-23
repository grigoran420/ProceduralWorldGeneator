using System;
using System.Drawing;
using System.Windows.Forms;
using ProceduralWorldGeneator.Alg;

namespace ProceduralWorldGeneator
{
    public partial class Form1 : Form
    {
        Bitmap map;
        public Form1()
        {
            InitializeComponent();
        }

        internal void Generate_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            AlgGenerate algGenerate = new AlgGenerate();
            map = algGenerate.Generate(Int32.Parse(textBox1.Text));
            DisplacementMap.Image = map;
        }

        private void Apply_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplacementMap.Image.Save("ball.jpeg");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Smoothing smoothing = new Smoothing();
            //map = smoothing.SmoothintMap(map);
            map = smoothing.MakeGrayscale(map);
            DisplacementMap.Image = map;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Coloring coloring = new Coloring();
            map = coloring.ColorB(map);

            DisplacementMap.Image = map;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Analysis analysis = new Analysis();
            listBox1.Items.Add($"Average = {analysis.Average(map)}");
            listBox1.Items.Add($"Max = {analysis.Max(map)}");
            listBox1.Items.Add($"Min = {analysis.Min(map)}");
            listBox1.Items.Add("");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Addition addition = new Addition();
            AlgGenerate algGenerate = new AlgGenerate();
            map = addition.Add(map, algGenerate.Generate(Int32.Parse(textBox1.Text)));
            DisplacementMap.Image = map;
        }
    }
}
