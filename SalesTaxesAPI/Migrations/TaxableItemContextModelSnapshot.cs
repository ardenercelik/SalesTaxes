// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesTaxesAPI.Contexts;

namespace SalesTaxesAPI.Migrations
{
    [DbContext(typeof(TaxableItemContext))]
    partial class TaxableItemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("SalesTaxesAPI.Models.TaxableItem", b =>
                {
                    b.Property<int>("TaxableItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("BasePrice")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("date()");

                    b.Property<DateTime>("DateUpdated")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("date()");

                    b.Property<bool>("IsExempt")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsImported")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("TaxRate")
                        .HasColumnType("REAL");

                    b.HasKey("TaxableItemId");

                    b.ToTable("TaxableItem");
                });
#pragma warning restore 612, 618
        }
    }
}
