using System;
using System.Collections.Generic;
using System.Text;

namespace Lab17_18
{
    public sealed class Singleton
    {
        private static Singleton instance;
        private static object syncRoot = new object();
        public string settings;
        public ConsoleColor ForegroundColor { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }
        private Singleton(string settings, ConsoleColor forColor, ConsoleColor backColor)
        {
            this.settings = settings;
            ForegroundColor = forColor;
            BackgroundColor = backColor;
        }
        public static Singleton getInstance(string settings, ConsoleColor forColor, ConsoleColor backColor)
        {
            if(instance == null)
            {
                lock(syncRoot)
                {
                    instance = new Singleton(settings, forColor, backColor);
                }
            }
            return instance;
        }
    }
}
