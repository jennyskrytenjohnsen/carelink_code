using Microsoft.EntityFrameworkCore;
using carelink_api.Models;

namespace carelink_api.Data
{
    public class AppDbContext : DbContext //Instansiates a AppDbContext class which inheriters from
    //  DbContext. DbContext is a part of EF Core and is used to represent the database in C#.
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet <Refugee> Refugees { get; set; }
        public DbSet <RefugeeFamily> RefugeeFamilies { get; set; }
        public DbSet <PlaceOfResidence> PlaceOfResidences { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    //The key for the placeofresidence database
    modelBuilder.Entity<PlaceOfResidence>().HasKey(p => new { p.StreetName, p.StreetNumber, p.PostalCode });

    //Defines the realtionship between the placeofresidence og refugee classes. 
    // And says that the refugee has a foreing key from the place of residence
    modelBuilder.Entity<Refugee>().HasOne(r=> r.PlaceOfResidence).WithMany(p =>p.Refugees)
    .HasForeignKey(r=>new{r.StreetName, r.StreetNumber, r.PostalCode});

    // Sammensatt primærnøkkel
    modelBuilder.Entity<RefugeeFamily>().HasKey(rf => new { rf.FamilyID, rf.AsylumCardID}); 

    // Fremmednøkkel til Refugee
    modelBuilder.Entity<RefugeeFamily>()
        .HasOne(rf => rf.Refugee)
        .WithMany()
        .HasForeignKey(rf => rf.AsylumCardID);
}
}
}