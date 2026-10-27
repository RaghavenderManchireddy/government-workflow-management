using GovernmentWorkflow.Data;
using GovernmentWorkflow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace GovernmentWorkflow.Controllers;
[ApiController]
[Route("api/requests")]
public class RequestsController(WorkflowDb db) : ControllerBase
{
    [HttpGet] public async Task<ActionResult<List<WorkflowRequest>>> Get() => await db.Requests.OrderByDescending(x => x.CreatedUtc).ToListAsync();
    [HttpPost] public async Task<ActionResult<WorkflowRequest>> Create(CreateRequest input)
    {
        if (string.IsNullOrWhiteSpace(input.Title) || string.IsNullOrWhiteSpace(input.Department)) return BadRequest("Title and department are required.");
        var item = new WorkflowRequest { Title = input.Title.Trim(), Department = input.Department.Trim(), Description = input.Description?.Trim() ?? "" };
        db.Requests.Add(item); await db.SaveChangesAsync(); return Created($"/api/requests/{item.Id}", item);
    }
    [HttpPatch("{id:int}/status")] public async Task<IActionResult> UpdateStatus(int id, StatusChange input)
    {
        if (input.Status is not ("Approved" or "Rejected" or "Pending")) return BadRequest("Invalid status.");
        var item = await db.Requests.FindAsync(id); if (item is null) return NotFound();
        item.Status = input.Status; await db.SaveChangesAsync(); return NoContent();
    }
}
public record CreateRequest(string Title, string Department, string? Description);
public record StatusChange(string Status);
