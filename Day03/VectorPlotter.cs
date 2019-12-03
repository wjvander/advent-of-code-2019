using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CodeKata.Day03
{
    public static class VectorPlotter
    {
        public static List<Vector2> Plot(Vector2 startVector, string instruction)
        {
            var direction = instruction.Substring(0, 1);
            var numberOfPointsToMove = int.Parse(instruction.Substring(1, instruction.Length - 1));

            var plotted = new List<Vector2>();

            switch (direction)
            {
                case "R":
                    for (int i = 1; i <= numberOfPointsToMove; i++)
                    {
                        plotted.Add(new Vector2(startVector.X + i, startVector.Y));
                    }

                    break;
                case "L":
                    for (int i = 1; i <= numberOfPointsToMove; i++)
                    {
                        plotted.Add(new Vector2(startVector.X - i, startVector.Y));
                    }

                    break;
                case "U":
                    for (int i = 1; i <= numberOfPointsToMove; i++)
                    {
                        plotted.Add(new Vector2(startVector.X, startVector.Y - i));
                    }

                    break;
                case "D":
                    for (int i = 1; i <= numberOfPointsToMove; i++)
                    {
                        plotted.Add(new Vector2(startVector.X, startVector.Y + i));
                    }

                    break;
            }

            return plotted;
        }

        public static List<Vector2> PlotPath(Vector2 startVector, string instructions)
        {
            var path = new List<Vector2>();
            var splittedInstructions = instructions
                .Split(",");

            foreach (var splittedInstruction in splittedInstructions)
            {
                var plotted = Plot(startVector, splittedInstruction);
                startVector = plotted.Last();
                path.AddRange(plotted);
            }

            return path;
        }


        public static List<Vector2> FindIntersections(List<Vector2> path1, List<Vector2> path2)
        {
            return path1.Intersect(path2).ToList();
        }
    }
}