using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            //prep
            List<string> inputLines = File.ReadAllLines("../input").ToList();
            List<int> input = new List<int>();
            inputLines.ForEach((line)=> input.Add(int.Parse(line)));
            var sw = new Stopwatch();

            //algo part 1
            sw.Start();
            int prev = -1;
            int totalIncrease = 0;
            foreach(int curr in input){
                if(prev != -1){
                    if(curr > prev){
                        totalIncrease++;
                    }
                }
                prev = curr;
            }
            sw.Stop();
            Console.WriteLine($"total increase {totalIncrease}, took {sw.ElapsedTicks}ticks");

            sw.Reset();

            //algo part 2
            sw.Start();
            int prevSum = -1;
            int totalWindowIncrease = 0;
            for(int i = 0; i < input.Count; i++){
                //make window, but only if we have enough elements.
                if((input.Count - i > 2) ){
                    int currSum = input[i] + input[i+1] + input[i+2];
                    if(prevSum != -1 && currSum > prevSum){
                        totalWindowIncrease++;
                    }
                    prevSum = currSum;
                }
            }
            sw.Stop();
            Console.WriteLine($"total increase window {totalWindowIncrease}, took {sw.ElapsedTicks}ticks");
        }
    }
}
