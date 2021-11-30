using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Hanoi
{

    public partial class Form1 : Form
    {
        HanoiVisualisation hanoi;

        public Form1()
        {
            InitializeComponent();
            hanoi = new HanoiVisualisation(10, this);
        }

        void Hanoi(int n, int from, int to)
        {
            if (n == 0) return;

            Hanoi(n - 1, from, 3 - from - to);
            hanoi.SwapPlaces(from, to);
            Hanoi(n - 1, 3 - from - to, to);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Hanoi(0, 1);
        }

        private void Hanoi(int from, int to)
        {
            Hanoi(hanoi.Count, from, to);
        }
    }
}
