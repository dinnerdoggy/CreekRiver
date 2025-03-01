using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    // Variable Setups, Campsites
    public static Campsite ChurchOfElleh = new Campsite { Id = 1, CampsiteTypeId = 1, Nickname = "Church of Elleh", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg" };
    public static Campsite ArtistsShack = new Campsite { Id = 2, CampsiteTypeId = 4, Nickname = "Artist's Shack", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg" };
    public static Campsite ChurchOfDragons = new Campsite { Id = 3, CampsiteTypeId = 3, Nickname = "Church of Dragon Communion", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg" };
    public static Campsite Cliffs = new Campsite { Id = 4, CampsiteTypeId = 2, Nickname = "Lake-Facing Cliffs", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg" };
    public static Campsite Hill = new Campsite { Id = 5, CampsiteTypeId = 1, Nickname = "Erdtree-Gazing Hill", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg" };
    public static Campsite Roots = new Campsite { Id = 6, CampsiteTypeId = 3, Nickname = "Haligtree Roots", ImageUrl = "https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg" };

    // Variable Setups, CampsiteTypes
    public static CampsiteType Tent = new CampsiteType { Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7 };
    public static CampsiteType RV = new CampsiteType { Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14 };
    public static CampsiteType Primitive = new CampsiteType { Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3 };
    public static CampsiteType Hammock = new CampsiteType { Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7 };

    // Variable Setups, UserProfile
    public static UserProfile Casey = new UserProfile { Id = 1, Email = "dinnerdoggy@gmail.com", FirstName = "Casey", LastName = "Cunningham"};
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            Tent,
            RV,
            Primitive,
            Hammock
        });

        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            ChurchOfElleh,
            ArtistsShack,
            ChurchOfDragons,
            Cliffs,
            Hill,
            Roots
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            Casey
        });

        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation{Id = 1, CampsiteId = 1, UserProfileId = 1, CheckinDate = new DateTime(2025, 8, 1), CheckoutDate = new DateTime(2025, 8, 7)}
        });
    }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
}