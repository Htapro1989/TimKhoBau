using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
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
    public IActionResult Solve([FromBody] TreasureMap request)
    {
        int[,] matrix = JsonSerializer.Deserialize<int[,]>(request.Matrix);
        double fuel = TreasureSolver.FindMinimumFuel(request.Rows, request.Columns, request.P, matrix);

        _context.TreasureMaps.Add(request);
        _context.SaveChanges();

        return Ok(new { fuel });
    }

    [HttpGet("maps")]
    public IActionResult GetMaps()
    {
        var maps = _context.TreasureMaps.ToList();
        return Ok(maps);
    }
}