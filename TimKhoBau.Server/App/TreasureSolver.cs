using System;
using System.Collections.Generic;
using System.Linq;

public class TreasureSolver
{
    public static double FindMinimumFuel(int n, int m, int p, int[,] matrix)
    {
        var positions = new Dictionary<int, List<(int x, int y)>>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int key = matrix[i, j];
                if (!positions.ContainsKey(key))
                    positions[key] = new List<(int x, int y)>();
                positions[key].Add((i, j));
            }
        }

        double fuel = 0.0;
        List<(int x, int y)> currentLevel = new() { (0, 0) };

        for (int key = 1; key <= p; key++)
        {
            double minFuel = double.MaxValue;
            List<(int x, int y)> nextLevel = positions[key];

            foreach (var curr in currentLevel)
            {
                foreach (var next in nextLevel)
                {
                    double cost = Math.Sqrt(Math.Pow(curr.x - next.x, 2) + Math.Pow(curr.y - next.y, 2));
                    minFuel = Math.Min(minFuel, cost);
                }
            }

            fuel += minFuel;
            currentLevel = nextLevel;
        }

        return fuel;
    }
}