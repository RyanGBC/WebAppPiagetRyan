using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppPiagetRyan.Models;

namespace WebAppPiagetRyan.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

public DbSet<WebAppPiagetRyan.Models.Aluno> Aluno { get; set; } = default!;

public DbSet<WebAppPiagetRyan.Models.Base> Base { get; set; } = default!;
}
