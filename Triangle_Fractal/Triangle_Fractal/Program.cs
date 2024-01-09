using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleFractal
{
    class Program
    {
        static readonly int windowWidth = 100;
        static readonly int windowHeight = 40;

        const string str = "||";

        static readonly int[,] triangle = { 
            { windowWidth/2, 0 }, 
            { 0, windowHeight }, 
            { windowWidth, windowHeight }, 
        };


        protected static void WriteAt(string s, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        }

        static void Main(string[] args)
        {
            Console.Clear();

            Console.SetWindowSize(windowWidth + 1, windowHeight + 1);
            Console.SetBufferSize(windowWidth + 1, windowHeight + 1);

            WriteAt(str, triangle[0, 0], triangle[0, 1]);
            WriteAt(str, triangle[1, 0], triangle[1, 1]);
            WriteAt(str, triangle[2, 0], triangle[2, 1]);

            Random rand = new Random();
            int cursorX = windowWidth;
            int cursorY = windowHeight;
            int x = 0;
            int y = 0;
            for (int i = 0; i < 100_000; i++)
            {
                int num = rand.Next(0, 3);

                x = (cursorX + triangle[num, 0]) / 2;
                y = (cursorY + triangle[num, 1]) / 2;
                cursorX = x;
                cursorY = y;

                WriteAt(str, cursorX, cursorY);
            }
            Thread.Sleep(5000);
        }
    }
}