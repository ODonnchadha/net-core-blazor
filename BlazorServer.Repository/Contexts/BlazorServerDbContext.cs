namespace BlazorServer.Repository.Contexts
{
    using BlazorServer.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    public class BlazorServerDbContext : DbContext
    {
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public BlazorServerDbContext(
            DbContextOptions<BlazorServerDbContext> options) : base (options)
        {
        }
    }
}
