using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab03
{
    public static class StatisticOperation
    {   
        public static string ConcatString(Stack stack)
        {
            if (stack.list.Count == 0)
                throw new InvalidOperationException();
            string ResultString = stack.Sum();
            return ResultString;
        }
        public static string MaxString(Stack stack)
        {
            string strmax = stack.Max();
            return strmax;
        }
        public static string MinString(Stack stack)
        {
            string strmin = stack.Min();
            return strmin;
        }
        public static int CountOfElements(this Stack stack)
        {
            if (stack.list.Count == 0)
                return 0;
            return stack.list.Count;
        }
        public static string MidlleElem(this Stack stack)
        {
            return stack.list[stack.list.Count / 2];
        }
    }
}
