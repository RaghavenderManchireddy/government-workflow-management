using GovernmentWorkflow.Models;
using Microsoft.EntityFrameworkCore;
namespace GovernmentWorkflow.Data;
public class WorkflowDb(DbContextOptions<WorkflowDb> options) : DbContext(options)
{
    public DbSet<WorkflowRequest> Requests => Set<WorkflowRequest>();
}
