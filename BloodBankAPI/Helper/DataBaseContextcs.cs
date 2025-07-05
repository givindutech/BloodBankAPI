using BloodBankAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BloodBankAPI.Helper

{
    public class DataBaseContextcs : DbContext
    {
        public DataBaseContextcs()
        {

        }
        public DataBaseContextcs(DbContextOptions<DataBaseContextcs> options) : base(options)
        {

        }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<BloodDonor> BloodDonors { get; set; }
        public DbSet<BloodDonationCamp> BloodDonationCamps { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<BloodDonorDonation> BloodDonorDonations { get; set; }
        public DbSet<BloodInventory> BloodInventories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BloodDonorDonation>()
           .HasOne(b => b.BloodDonor)
           .WithMany(b => b.BloodDonorDonations)
           .HasForeignKey(b => b.BloodDonorId)
           .OnDelete(DeleteBehavior.Cascade);
        }



    }
}
