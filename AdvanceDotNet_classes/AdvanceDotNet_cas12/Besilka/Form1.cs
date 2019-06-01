using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Besilka
{
    public partial class Form1 : Form
    {
        string[] words = { "skopje", "veles", "stip", "kumanovo" };
        Random rand = new Random();
        Button[] alphabetButtons;
        List<Label> labels = new List<Label>();
        int stage = 0;
        bool ignore = false;

        public Form1()
        {
            InitializeComponent();
            this.Paint += Form1_Paint;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            alphabetButtons = this.Controls.OfType<Button>().ToArray()
                                .Except(new Button[] { buttonNew }).ToArray();
            Array.ForEach(alphabetButtons, b => b.Click += button_Click);
            this.buttonNew.PerformClick();
        }

        private void button_Click(object sender, EventArgs e)
        {
            if (ignore)
                return;

            Button btn = (Button)sender;
            btn.Enabled = false;
            Array.ForEach(labels.ToArray(), lbl => lbl.Text = (lbl.Tag.Equals(btn.Text)) ? btn.Text : lbl.Text);
            int n = labels.Count - 1;
            for(int i = 1; i <= n; i++)
            {
                labels[i].Left = labels[i - 1].Right;
            }

            if (labels[n].Right > this.ClientSize.Width - 14)
            {
                this.SetClientSizeCore(labels[n].Right + 14, 250);
            }

            stage += !labels.Any(lbl => lbl.Text == btn.Text) ? 1 : 0;
            ignore = (stage == 10) || (labels.All(lbl => lbl.Text != " "));
            this.Invalidate();

            if (stage == 10)
                MessageBox.Show("Sory you lose!!!");

            if(ignore && stage < 10)
                MessageBox.Show("YOU WON!!!");
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            Array.ForEach(labels.ToArray(), lbl => lbl.Dispose());
            Array.ForEach(alphabetButtons.ToArray(), btn => btn.Enabled = true);
            string word;
            word = words[rand.Next(0, words.Length - 1)].ToUpper();
            int startX = 14;
            labels = new List<Label>();
            foreach(var c in word)
            {
                Label lbl = new Label();
                lbl.Tag = c.ToString();
                lbl.Text = " ";
                lbl.Font = new Font(this.Font.Name, 25, FontStyle.Underline);
                lbl.Location = new Point(startX, 330);
                lbl.AutoSize = true;
                this.Controls.Add(lbl);
                startX = lbl.Right;
                labels.Add(lbl);
            }

            stage = 0;
            ignore = false;
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (stage >= 1)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 85, 190, 210, 190);
            }
            if (stage >= 2)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 190, 148, 50);
            }
            if (stage >= 3)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 148, 50, 198, 50);
            }
            if (stage >= 4)
            {
                e.Graphics.DrawLine(new Pen(Color.Black, 2), 198, 50, 198, 70);
            }
            if (stage >= 5)
            {
                e.Graphics.DrawEllipse(new Pen(Color.Red, 2), new Rectangle(188, 70, 20, 20));
            }
            if (stage >= 6)
            {
                e.Graphics.DrawLine(new Pen(Color.Red, 2), 198, 90, 198, 130);
            }
            if (stage >= 7)
            {
                e.Graphics.DrawLine(new Pen(Color.Red, 2), 198, 95, 183, 115);
            }
            if (stage >= 8) {
                e.Graphics.DrawLine(new Pen(Color.Red, 2), 198, 95, 213, 115);
            }
            if (stage >= 9)
            {
                e.Graphics.DrawLine(new Pen(Color.Red, 2), 198, 130, 183, 170);
            }
            if (stage >= 10)
            {
                e.Graphics.DrawLine(new Pen(Color.Red, 2), 198, 130, 213, 170);
            }
        }
    }
}
