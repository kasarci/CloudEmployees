using CloudEmployees.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CloudEmployees.DataAccess.DataContext;

public class CloudEmployeesContext : DbContext {
  public DbSet<Company> Companies => Set<Company>();
  public DbSet<Employee> Employees => Set<Employee>();
  public DbSet<Department> Departments => Set<Department>();
  public DbSet<Address> Addresses => Set<Address>();

  public CloudEmployeesContext(DbContextOptions options) : base(options) { }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    // Configure primary keys
    modelBuilder.Entity<Company>().HasKey(c => c.Id);
    modelBuilder.Entity<Employee>().HasKey(e => e.Id);
    modelBuilder.Entity<Department>().HasKey(d => d.Id);
    modelBuilder.Entity<Address>().HasKey(a => a.Id);

    //Configure columns
    //Address columns
    modelBuilder.Entity<Address>()
                .Property(a => a.Id)
                .HasColumnType("char(36)")
                .IsRequired();
    modelBuilder.Entity<Address>()
                .Property(a => a.Street)
                .HasColumnType("nvarchar(256)")
                .IsRequired();
    modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .HasColumnType("nvarchar(50)")
                .IsRequired();
    modelBuilder.Entity<Address>()
                .Property(a => a.Zipcode)
                .HasColumnType("nvarchar(10)")
                .IsRequired();
    modelBuilder.Entity<Address>()
                .Property(a => a.Country)
                .HasColumnType("nvarchar(50)")
                .IsRequired();

    //Company columns
    modelBuilder.Entity<Company>()
                .Property(c => c.Id)
                .HasColumnType("char(36)")
                .IsRequired();
    modelBuilder.Entity<Company>()
                .Property(c => c.Name)
                .HasColumnType("nvarchar(256)")
                .IsRequired();
    
    //Department columns
    modelBuilder.Entity<Department>()
                .Property(e => e.Id)
                .HasColumnType("char(36)")
                .IsRequired();
    modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .HasColumnType("nvarchar(256)")
                .IsRequired();

    //Employee columns
    modelBuilder.Entity<Employee>()
                .Property(e => e.Id)
                .HasColumnType("char(36)")
                .IsRequired();
    modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .HasColumnType("nvarchar(64)")
                .IsRequired();
    modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .HasColumnType("nvarchar(64)")
                .IsRequired();
    modelBuilder.Entity<Employee>()
                .Property(e => e.Title)
                .HasColumnType("nvarchar(64)")
                .IsRequired();
    modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .HasColumnType("nvarchar(256)")
                .IsRequired();
    modelBuilder.Entity<Employee>()
                .Property(e => e.PhoneNumber)
                .HasColumnType("nvarchar(15)")
                .IsRequired();
    modelBuilder.Entity<Employee>()
                .Property(e => e.Gender)
                .HasConversion<int>()
                .HasColumnType("int16")
                .IsRequired();
    modelBuilder.Entity<Employee>()
                .Property(e => e.BirthDate)
                .HasColumnType("date")
                .IsRequired();
    modelBuilder.Entity<Employee>()
                .Property(e => e.StartDate)
                .HasColumnType("date")
                .IsRequired();

    //Add relations
    modelBuilder.Entity<Company>()
                .HasMany<Department>()
                .WithOne()
                .HasForeignKey(d => d.CompanyId);
    modelBuilder.Entity<Company>()
                .HasMany<Employee>()
                .WithOne()
                .HasForeignKey(e => e.CompanyId);
    modelBuilder.Entity<Company>()
                .HasOne<Address>(c => c.Address)
                .WithOne(a => a.Company)
                .HasForeignKey<Address>(a => a.CompanyId);

    modelBuilder.Entity<Department>()
                .HasMany<Employee>()
                .WithOne()
                .HasForeignKey(e => e.DepartmentId);
                
    modelBuilder.Entity<Employee>()
                .HasOne<Address>(e => e.Address)
                .WithOne(a => a.Employee)
                .HasForeignKey<Address>(a => a.EmployeeId);
    modelBuilder.Entity<Employee>()
                .HasOne<EmployeeManager>(e => e.Manager)
                .WithMany(e => e.Employee)
                .HasForeignKey(e => e.ManagerId)
                .IsRequired(false);
    modelBuilder.Entity<Employee>()
                .HasMany<EmployeeSubordinate>(e => e.Subordinates)
                .WithOne(e => e.Employee)
                .HasForeignKey(e => e.EmployeeId)
                .IsRequired(false);
  }
  
}