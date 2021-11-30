using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Hanoi
{
    class HanoiVisualisation
    {
        Graphics g; 
        List<List<int>> towers = new List<List<int>>(){
            new List<int>(),
            new List<int>(),
            new List<int>()
        };
        Control parent;
        public int Count { get; }

        public HanoiVisualisation(int num, Control parent)
        {
            Count = num;
            for (int i = Count; i > 0; i--)
            {
                towers[0].Add(i);
            }
            this.parent = parent;
            g = parent.CreateGraphics();
        }

        public void SwapPlaces(int from, int to)
        {
            towers[to].Add(towers[from].Pop());
            DrawTowers();
            Thread.Sleep(50);
        }


        private void DrawTowers()
        {
            g.Clear(parent.BackColor);
            Size size = new Size(parent.Width * 10 / towers.Count / 15, parent.Height * 80 / 100);
            for (int i = 0; i < towers.Count; i++)
            {
                var tower = towers[i];
                Point p = new Point(parent.Width / 3 * i + parent.Width / 12, parent.Height * 10 / 100);
                int sum = towers.Sum(x => x.Count);
                int h = size.Height / sum;
                int d = h * 2 / 3;
                for (int j = 0; j < tower.Count; j++)
                {
                    int disk = tower[j];
                    int w = size.Width / sum * disk;
                    Point p1 = new Point(p.X + size.Width / 2 - w / 2, size.Height - j * h);
                    Point p2 = new Point(p.X + size.Width / 2 + w / 2, size.Height - j * h);
                    g.DrawLine(new Pen(Color.FromArgb(disk * 255 / sum, 255 - disk * 125 / sum, 200), d), p1, p2);
                }
            }
            parent.Update();
        }


    }
}
