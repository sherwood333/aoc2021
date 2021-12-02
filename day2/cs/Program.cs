using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace cs
{
    class Program
    {
        enum Direction{
            up,
            down,
            forward,
        }

        static void Main(string[] args)
        {
            //prep
            List<string> inputLines = File.ReadAllLines("../input").ToList();
            //List<commands>

            int horizontal = 0;
            int depth = 0;

            foreach(string command in inputLines){
                var bla = parseCommand(command);
                switch(bla.direction){
                    case Direction.up:
                        depth -= bla.value;
                        break;
                    case Direction.down:
                        depth += bla.value;
                        break;
                    case Direction.forward:
                        horizontal += bla.value;
                        break;
                }
            }

            Console.WriteLine($"horizontal: {horizontal}, depth: {depth}");
            Console.WriteLine($"answer: {horizontal * depth}");
        }

        static (Direction direction, int value) parseCommand(string cmd){
            var parts = cmd.Split(" ");
            return ( ParseEnum<Direction>(parts[0]), int.Parse(parts[1]));
        
        }


        static T ParseEnum<T>(string value)
        {
            return (T) Enum.Parse(typeof(T), value, true);
        }
    }

}
