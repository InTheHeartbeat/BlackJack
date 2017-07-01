using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Game.Base
{
    public static class ShuffleStackExtension
    {
        public static void Shuffle<T>(this Stack<T> stack)
        {
            Random rand = new Random();
            T[] values = stack.ToArray();
            stack.Clear();
            foreach (T value in values.OrderBy(val=>rand.Next()))
                stack.Push(value);
        }
    }
}
