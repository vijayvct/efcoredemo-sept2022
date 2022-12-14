// <auto-generated />
using FirstEFCoreDemo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FirstEFCoreDemo.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FirstEFCoreDemo.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(70)")
                        .HasMaxLength(70);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("AuthorId");

                    b.ToTable("Authors");

                    b.HasData(
                        new
                        {
                            AuthorId = 1,
                            Email = "vijayv@citiustech.com",
                            FirstName = "Vijay",
                            LastName = "Vishwakarma",
                            Location = "India"
                        },
                        new
                        {
                            AuthorId = 2,
                            Email = "gatesbill@microsoft.com",
                            FirstName = "Bill",
                            LastName = "Gates",
                            Location = "US"
                        },
                        new
                        {
                            AuthorId = 3,
                            Email = "scotth@microsoft.com",
                            FirstName = "Scott",
                            LastName = "Hanselman",
                            Location = "US"
                        },
                        new
                        {
                            AuthorId = 4,
                            Email = "jk@hogwarts.com",
                            FirstName = "J.K",
                            LastName = "Rowling",
                            Location = "UK"
                        });
                });

            modelBuilder.Entity("FirstEFCoreDemo.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 2,
                            Price = 108.98999999999999,
                            Title = "Sql Server 2019"
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 3,
                            Price = 399.99000000000001,
                            Title = "Azure Fundamentals"
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 3,
                            Price = 200.0,
                            Title = "Azure Administration"
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 4,
                            Price = 899.99000000000001,
                            Title = "Harry Potter and The Chambers of Secret"
                        });
                });

            modelBuilder.Entity("FirstEFCoreDemo.Models.Customer", b =>
                {
                    b.Property<int>("CustID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustID");

                    b.ToTable("Customers","MySchema");
                });

            modelBuilder.Entity("FirstEFCoreDemo.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeID = 1,
                            Designation = "Manager",
                            Name = "Malcolm"
                        },
                        new
                        {
                            EmployeeID = 2,
                            Designation = "SW Engg",
                            Name = "James"
                        });
                });

            modelBuilder.Entity("FirstEFCoreDemo.Models.Book", b =>
                {
                    b.HasOne("FirstEFCoreDemo.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
