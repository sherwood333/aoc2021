using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cs
{
    class Program
    {
        static void Main(string[] args)
        {
            //process each line, then read trough column by column counting what the most/least used value is.
            // this means that

            List<string> inputLines = File.ReadAllLines("../input").ToList();

            int width = inputLines[0].Length;
            int length = inputLines.Count();

            Console.WriteLine($"{width}, {length}");

            byte[] gamma = new byte[width];

            //voor elke kolom
            for(int i = 0; i < width; i++){
                int colCounter = 0;
                //voor elke regel
                foreach(string line in inputLines){
                    colCounter += int.Parse(line[i].ToString());
                }

                if((colCounter * 2) > length){
                    //more than half == 1, so set bit to 1
                    gamma[width - i] = 1;
                }

            }

            foreach(var bit in gamma){
                Console.Write($"{bit}");
            }
            Console.Write("\n");

            //Console.WriteLine($"gamma: {BitConverter.ToInt32(gamma, 0)}");
            Console.WriteLine($"gamma: {~BitConverter.ToInt32(gamma, 0)}");

            //x = (x >> 11) == 0 ? x : -1 ^ 0xFFF | x;
        }
    }
}
