using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Swapartment.Models;

namespace Swapartment.Areas.Identity.Data;

public class SwapartmentIdentityDbContext : IdentityDbContext<SwapartmentUser>
{
  public SwapartmentIdentityDbContext(DbContextOptions<SwapartmentIdentityDbContext> options)
      : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {

    #region RoleSeed
    builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "USER", NormalizedName = "USER" }, new IdentityRole { Name = "ADMIN", NormalizedName = "ADMIN" });
    #endregion

    base.OnModelCreating(builder);
    // Customize the ASP.NET Identity model and override the defaults if needed.
    // For example, you can rename the ASP.NET Identity table names and more.
    // Add your customizations after calling base.OnModelCreating(builder);


    //builder.Seed();
  }
  public virtual DbSet<Property> Properties { get; set; }
  public virtual DbSet<PropertyTag> PropertyTags { get; set; }
  public virtual DbSet<PropertyImage> PropertyImages { get; set; }
  public virtual DbSet<Rental> Rentals { get; set; }

}
