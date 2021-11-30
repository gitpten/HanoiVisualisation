using System;
using System.Collections.Generic;
using System.Text;

namespace Hanoi
{
    public static class Extantions
    {

        public static int Pop(this List<int> list)
        {
            int item = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return item;
        }

    }
}
