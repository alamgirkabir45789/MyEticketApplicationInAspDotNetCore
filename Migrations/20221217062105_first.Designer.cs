// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyEticketApplication.Data;

#nullable disable

namespace MyEticketApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221217062105_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyEticketApplication.Models.RouteFrom", b =>
                {
                    b.Property<int>("RouteFromId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteFromId"));

                    b.Property<string>("RouteFromName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RouteToId")
                        .HasColumnType("int");

                    b.HasKey("RouteFromId");

                    b.HasIndex("RouteToId");

                    b.ToTable("RouteFroms");
                });

            modelBuilder.Entity("MyEticketApplication.Models.RouteTo", b =>
                {
                    b.Property<int>("RouteToId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteToId"));

                    b.Property<string>("RouteToName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RouteToId");

                    b.ToTable("RouteToFroms");
                });

            modelBuilder.Entity("MyEticketApplication.Models.RouteFrom", b =>
                {
                    b.HasOne("MyEticketApplication.Models.RouteTo", "RouteTo")
                        .WithMany()
                        .HasForeignKey("RouteToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RouteTo");
                });
#pragma warning restore 612, 618
        }
    }
}
