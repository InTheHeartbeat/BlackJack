using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Base
{
    public static class CollectionExtensions
    {
        public static void Shuffle<T>(this Stack<T> stack)
        {
            Random rand = new Random();
            T[] values = stack.ToArray();
            stack.Clear();
            foreach (T value in values.OrderBy(val => rand.Next()))
            {
                stack.Push(value);
            }
        }

        public static IEnumerable<T> GetEnumValues<T>()
        {
            return (IEnumerable<T>) Enum.GetValues(typeof(T));
        }
    }
}
