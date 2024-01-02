using Microsoft.EntityFrameworkCore;
using HillarysHaircare.Models;

public class HillarysHaircareDbContext : DbContext
{
    //Each Db set corresponds to and represents a table in the database
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<AppointmentDetail> AppointmentDetails { get; set; }

    public HillarysHaircareDbContext(DbContextOptions<HillarysHaircareDbContext> context) : base(context)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<Customer>().HasData(new Customer[]
        {
            new Customer { Id = 1, FirstName = "John", LastName = "Doe" },
            new Customer { Id = 2, FirstName = "Jane", LastName = "Smith" },
            new Customer { Id = 3, FirstName = "Alice", LastName = "Johnson" },
            new Customer { Id = 4, FirstName = "Bob", LastName = "Williams" },
            new Customer { Id = 5, FirstName = "Emma", LastName = "Brown" },
            new Customer { Id = 6, FirstName = "Michael", LastName = "Jones" },
            new Customer { Id = 7, FirstName = "Olivia", LastName = "Garcia" },
            new Customer { Id = 8, FirstName = "William", LastName = "Martinez" },
            new Customer { Id = 9, FirstName = "Sophia", LastName = "Miller" },
            new Customer { Id = 10, FirstName = "Liam", LastName = "Davis" },
            new Customer { Id = 11, FirstName = "Ava", LastName = "Rodriguez" },
            new Customer { Id = 12, FirstName = "Ethan", LastName = "Gomez" },
            new Customer { Id = 13, FirstName = "Mia", LastName = "Hernandez" },
            new Customer { Id = 14, FirstName = "James", LastName = "Perez" },
            new Customer { Id = 15, FirstName = "Charlotte", LastName = "Flores" },
            new Customer { Id = 16, FirstName = "Alexander", LastName = "Adams" },
            new Customer { Id = 17, FirstName = "Grace", LastName = "Cook" },
            new Customer { Id = 18, FirstName = "Daniel", LastName = "Bailey" },
            new Customer { Id = 19, FirstName = "Luna", LastName = "Kelly" },
            new Customer { Id = 20, FirstName = "Henry", LastName = "Wright" }
        });

        modelBuilder.Entity<Stylist>().HasData(new Stylist[]
        {
            new Stylist { Id = 1, FirstName = "Emily", LastName = "Anderson", IsActive = true },
            new Stylist { Id = 2, FirstName = "David", LastName = "Brown", IsActive = true },
            new Stylist { Id = 3, FirstName = "Sophia", LastName = "Clark", IsActive = true },
            new Stylist { Id = 4, FirstName = "James", LastName = "Davis", IsActive = true },
            new Stylist { Id = 5, FirstName = "Olivia", LastName = "Garcia", IsActive = true },
            new Stylist { Id = 6, FirstName = "Michael", LastName = "Harris", IsActive = true },
            new Stylist { Id = 7, FirstName = "Isabella", LastName = "Jackson", IsActive = true },
            new Stylist { Id = 8, FirstName = "Daniel", LastName = "Johnson", IsActive = true },
            new Stylist { Id = 9, FirstName = "Ava", LastName = "Lee", IsActive = true },
            new Stylist { Id = 10, FirstName = "Ethan", LastName = "Martinez", IsActive = true },
            new Stylist { Id = 11, FirstName = "Emma", LastName = "Moore", IsActive = true },
            new Stylist { Id = 12, FirstName = "William", LastName = "Perez", IsActive = true },
            new Stylist { Id = 13, FirstName = "Charlotte", LastName = "Rivera", IsActive = false },
            new Stylist { Id = 14, FirstName = "Liam", LastName = "Roberts", IsActive = false },
            new Stylist { Id = 15, FirstName = "Grace", LastName = "Smith", IsActive = false }
        });
        modelBuilder.Entity<Service>().HasData(new Service[]
        {
            new Service { Id = 1, ServiceName = "Women's Haircut", Price = 50.00m },
            new Service { Id = 2, ServiceName = "Men's Haircut", Price = 40.00m },
            new Service { Id = 3, ServiceName = "Barber Service", Price = 45.00m },
            new Service { Id = 4, ServiceName = "Hair Coloring", Price = 80.00m },
            new Service { Id = 5, ServiceName = "Highlights", Price = 70.00m },
            new Service { Id = 6, ServiceName = "Blowout Styling", Price = 60.00m },
            new Service { Id = 7, ServiceName = "Hair Extensions", Price = 120.00m },
            new Service { Id = 8, ServiceName = "Perms", Price = 90.00m },
            new Service { Id = 9, ServiceName = "Bridal Hair Styling", Price = 100.00m },
            new Service { Id = 10, ServiceName = "Deep Conditioning Treatment", Price = 55.00m },
            new Service { Id = 11, ServiceName = "Beard Trim", Price = 25.00m },
            new Service { Id = 12, ServiceName = "Shave", Price = 30.00m },
            new Service { Id = 13, ServiceName = "Facial", Price = 35.00m },
            new Service { Id = 14, ServiceName = "Scalp Massage", Price = 20.00m },
            new Service { Id = 15, ServiceName = "Waxing", Price = 40.00m }
        });
        modelBuilder.Entity<Appointment>().HasData(new Appointment[]
        {
            new Appointment { Id = 1, AppointmentTime = DateTime.Now.Date.AddHours(8).AddDays(20), IsCancelled = false, CustomerId = 1, StylistId = 1 },
            new Appointment { Id = 2, AppointmentTime = DateTime.Now.Date.AddHours(9).AddDays(21), IsCancelled = false, CustomerId = 2, StylistId = 2 },
            new Appointment { Id = 3, AppointmentTime = DateTime.Now.Date.AddHours(10).AddDays(22), IsCancelled = false, CustomerId = 3, StylistId = 3 },
            new Appointment { Id = 4, AppointmentTime = DateTime.Now.Date.AddHours(11).AddDays(23), IsCancelled = false, CustomerId = 4, StylistId = 4 },
            new Appointment { Id = 5, AppointmentTime = DateTime.Now.Date.AddHours(12).AddDays(24), IsCancelled = false, CustomerId = 5, StylistId = 5 },
            new Appointment { Id = 6, AppointmentTime = DateTime.Now.Date.AddHours(13).AddDays(25), IsCancelled = false, CustomerId = 6, StylistId = 6 },
            new Appointment { Id = 7, AppointmentTime = DateTime.Now.Date.AddHours(14).AddDays(26), IsCancelled = false, CustomerId = 7, StylistId = 7 },
            new Appointment { Id = 8, AppointmentTime = DateTime.Now.Date.AddHours(15).AddDays(27), IsCancelled = false, CustomerId = 8, StylistId = 8 },
            new Appointment { Id = 9, AppointmentTime = DateTime.Now.Date.AddHours(16).AddDays(28), IsCancelled = false, CustomerId = 9, StylistId = 9 },
            new Appointment { Id = 10, AppointmentTime = DateTime.Now.Date.AddHours(17).AddDays(29), IsCancelled = false, CustomerId = 10, StylistId = 10 },
            new Appointment { Id = 11, AppointmentTime = DateTime.Now.Date.AddHours(18).AddDays(30), IsCancelled = false, CustomerId = 11, StylistId = 11 },
            new Appointment { Id = 12, AppointmentTime = DateTime.Now.Date.AddHours(19).AddDays(31), IsCancelled = false, CustomerId = 12, StylistId = 12 },
            new Appointment { Id = 13, AppointmentTime = DateTime.Now.Date.AddHours(20).AddDays(32), IsCancelled = false, CustomerId = 13, StylistId = 12 },
            new Appointment { Id = 14, AppointmentTime = DateTime.Now.Date.AddHours(21).AddDays(33), IsCancelled = false, CustomerId = 14, StylistId = 11 },
            new Appointment { Id = 15, AppointmentTime = DateTime.Now.Date.AddHours(22).AddDays(34), IsCancelled = false, CustomerId = 15, StylistId = 10 },
            new Appointment { Id = 16, AppointmentTime = DateTime.Now.Date.AddHours(23).AddDays(35), IsCancelled = false, CustomerId = 16, StylistId = 1 },
            new Appointment { Id = 17, AppointmentTime = DateTime.Now.Date.AddHours(24).AddDays(36), IsCancelled = false, CustomerId = 17, StylistId = 2 },
            new Appointment { Id = 18, AppointmentTime = DateTime.Now.Date.AddHours(25).AddDays(37), IsCancelled = false, CustomerId = 18, StylistId = 3 },
            new Appointment { Id = 19, AppointmentTime = DateTime.Now.Date.AddHours(26).AddDays(38), IsCancelled = false, CustomerId = 19, StylistId = 4 },
            new Appointment { Id = 20, AppointmentTime = DateTime.Now.Date.AddHours(27).AddDays(39), IsCancelled = false, CustomerId = 20, StylistId = 5 }
        });
        modelBuilder.Entity<AppointmentDetail>().HasData(new AppointmentDetail[]
        {
            new AppointmentDetail { Id = 1, AppointmentId = 1, ServiceId = 1 },
            new AppointmentDetail { Id = 2, AppointmentId = 1, ServiceId = 2 },
            new AppointmentDetail { Id = 3, AppointmentId = 2, ServiceId = 3 },
            new AppointmentDetail { Id = 4, AppointmentId = 2, ServiceId = 4 },
            new AppointmentDetail { Id = 5, AppointmentId = 3, ServiceId = 5 },
            new AppointmentDetail { Id = 6, AppointmentId = 3, ServiceId = 6 },
            new AppointmentDetail { Id = 7, AppointmentId = 4, ServiceId = 7 },
            new AppointmentDetail { Id = 8, AppointmentId = 4, ServiceId = 8 },
            new AppointmentDetail { Id = 9, AppointmentId = 5, ServiceId = 9 },
            new AppointmentDetail { Id = 10, AppointmentId = 5, ServiceId = 10 },
            new AppointmentDetail { Id = 11, AppointmentId = 6, ServiceId = 11 },
            new AppointmentDetail { Id = 12, AppointmentId = 6, ServiceId = 12 },
            new AppointmentDetail { Id = 13, AppointmentId = 7, ServiceId = 13 },
            new AppointmentDetail { Id = 14, AppointmentId = 7, ServiceId = 14 },
            new AppointmentDetail { Id = 15, AppointmentId = 8, ServiceId = 15 },
            new AppointmentDetail { Id = 16, AppointmentId = 8, ServiceId = 1 },
            new AppointmentDetail { Id = 17, AppointmentId = 9, ServiceId = 2 },
            new AppointmentDetail { Id = 18, AppointmentId = 9, ServiceId = 3 },
            new AppointmentDetail { Id = 19, AppointmentId = 10, ServiceId = 4 },
            new AppointmentDetail { Id = 20, AppointmentId = 10, ServiceId = 5 },
            new AppointmentDetail { Id = 21, AppointmentId = 11, ServiceId = 6 },
            new AppointmentDetail { Id = 22, AppointmentId = 11, ServiceId = 7 },
            new AppointmentDetail { Id = 23, AppointmentId = 12, ServiceId = 8 },
            new AppointmentDetail { Id = 24, AppointmentId = 12, ServiceId = 9 },
            new AppointmentDetail { Id = 25, AppointmentId = 13, ServiceId = 10 },
            new AppointmentDetail { Id = 26, AppointmentId = 13, ServiceId = 11 },
            new AppointmentDetail { Id = 27, AppointmentId = 14, ServiceId = 12 },
            new AppointmentDetail { Id = 28, AppointmentId = 14, ServiceId = 13 },
            new AppointmentDetail { Id = 29, AppointmentId = 15, ServiceId = 14 },
            new AppointmentDetail { Id = 30, AppointmentId = 15, ServiceId = 15 },
            new AppointmentDetail { Id = 31, AppointmentId = 16, ServiceId = 1 },
            new AppointmentDetail { Id = 32, AppointmentId = 16, ServiceId = 2 },
            new AppointmentDetail { Id = 33, AppointmentId = 17, ServiceId = 3 },
            new AppointmentDetail { Id = 34, AppointmentId = 17, ServiceId = 4 },
            new AppointmentDetail { Id = 35, AppointmentId = 18, ServiceId = 5 },
            new AppointmentDetail { Id = 36, AppointmentId = 18, ServiceId = 6 },
            new AppointmentDetail { Id = 37, AppointmentId = 19, ServiceId = 7 },
            new AppointmentDetail { Id = 38, AppointmentId = 19, ServiceId = 8 },
            new AppointmentDetail { Id = 39, AppointmentId = 20, ServiceId = 9 },
            new AppointmentDetail { Id = 40, AppointmentId = 20, ServiceId = 10 }

        });
    }
}