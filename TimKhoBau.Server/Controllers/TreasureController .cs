using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using TimKhoBau.Server.Model;

[ApiController]
[Route("api/treasure")]
public class TreasureController : ControllerBase
{
    private readonly TreasureContext _context;

    public TreasureController(TreasureContext context)
    {
        _context = context;
    }

    [HttpPost("solve")]
    public IActionResult Solve([FromBody] TreasureMapInput input)
    {
        // Save the input
        var treasureMap = new TreasureMap
        {
            n = input.n,
            m = input.m,
            P = input.P,
            Matrix = JsonConvert.SerializeObject(input.Matrix)
        };
        _context.TreasureMaps.Add(treasureMap);
        _context.SaveChanges();

        // Solve for the minimum fuel
        var minFuel = CalculateMinFuel(input.n, input.m, input.P, input.Matrix);
        return Ok(new { MinFuel = minFuel });
    }

    [HttpGet("history")]
    public IActionResult History()
    {
        var history = _context.TreasureMaps.ToList();
        return Ok(history);
    }

    private double CalculateMinFuel(int n, int m, int p, int[][] matrix)
    {
        var positions = new Dictionary<int, List<(int, int)>>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                int chest = matrix[i][j];
                if (!positions.ContainsKey(chest))
                    positions[chest] = new List<(int, int)>();
                positions[chest].Add((i, j));
            }
        }

        double totalFuel = 0;
        var currentPositions = new List<(int, int)> { (0, 0) };

        for (int k = 1; k <= p; k++)
        {
            double minFuel = double.MaxValue;
            var nextPositions = positions[k];
            foreach (var curr in currentPositions)
            {
                foreach (var next in nextPositions)
                {
                    double fuel = Math.Sqrt(Math.Pow(curr.Item1 - next.Item1, 2) + Math.Pow(curr.Item2 - next.Item2, 2));
                    minFuel = Math.Min(minFuel, fuel);
                }
            }
            totalFuel += minFuel;
            currentPositions = nextPositions;
        }

        return totalFuel;
    }
}