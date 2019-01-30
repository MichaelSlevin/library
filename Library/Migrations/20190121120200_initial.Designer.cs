using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Library.Models;

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20190121120200_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);


            modelBuilder.Entity("Library.Models.Book", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("Author");
                b.Property<string>("Title");
                b.Property<string>("ISBN");
                b.Property<long>("OwnerId");
                b.Property<bool>("Available");

                b.HasKey("Id");

                b.ToTable("Books");
            });
            modelBuilder.Entity("Library.Models.User", b =>
            {
                b.Property<long>("Id")
                    .ValueGeneratedOnAdd();

                b.Property<string>("FullName");
                b.Property<string>("Username");
                b.Property<string>("Email");
                b.Property<string>("PhoneNumber");
                b.Property<string>("Password");

                b.HasKey("Id");

                b.ToTable("Users");
            });
            modelBuilder.Entity("Library.Models.Book_info", b =>
            {
                b.Property<string>("ISBN");
                b.Property<string>("Author");
                b.Property<string>("Title");
                b.Property<string>("Description");
                b.Property<string>("ImageUrl");
                b.Property<string>("LinkToGoogleBooks");

                b.HasKey("ISBN");

                b.ToTable("Book_info");
            });
#pragma warning restore 612, 618
        }
    }
}
