﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PMRU.Persistence.Configurations
{
    public class AvailabilityConfiguration : IEntityTypeConfiguration<Availability>
    {
        public void Configure(EntityTypeBuilder<Availability> builder)
        {
            builder.HasKey(a => a.Id);

            // Doctor ile ilişki
            builder.HasOne(a => a.Doctor)
                .WithMany(d => d.Availabilities)
                .HasForeignKey(a => a.DoctorID)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.StartTime).IsRequired();
            builder.Property(a => a.EndTime).IsRequired();
            builder.Property(a => a.CreatedDate).IsRequired();
            builder.Property(a => a.LastModifiedDate);

            // BaseEntity sınıfından gelen alanlar
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.IsActive).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
            builder.Property(a => a.DeletedDate);

            // Oluşturulan tarih alanlarını varsayılan değerlerle ayarlama
            builder.Property(a => a.CreatedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(a => a.LastModifiedDate).HasDefaultValue(null);
            builder.Property(a => a.DeletedDate).HasDefaultValue(null);

            builder.HasData(
                new Availability
                {
                    Id = 1,
                    DoctorID = 1,
                    Date = new DateOnly(2024, 1, 2),
                    StartTime = new TimeOnly(8, 0),
                    EndTime = new TimeOnly(8, 20)
                },
                new Availability
                {
                    Id = 2,
                    DoctorID = 1,
                    Date = new DateOnly(2024, 1, 2),
                    StartTime = new TimeOnly(8, 20),
                    EndTime = new TimeOnly(8, 40)
                },
                new Availability
                {
                    Id = 3,
                    DoctorID = 1,
                    Date = new DateOnly(2024, 1, 2),
                    StartTime = new TimeOnly(8, 40),
                    EndTime = new TimeOnly(9, 0)
                },
                new Availability
                {
                    Id = 4,
                    DoctorID = 2,
                    Date = new DateOnly(2024, 1, 2),
                    StartTime = new TimeOnly(8, 0),
                    EndTime = new TimeOnly(8, 20)
                },
                new Availability
                {
                    Id = 5,
                    DoctorID = 2,
                    Date = new DateOnly(2024, 1, 2),
                    StartTime = new TimeOnly(8, 20),
                    EndTime = new TimeOnly(8, 40)
                },
                new Availability
                {
                    Id = 6,
                    DoctorID = 2,
                    Date = new DateOnly(2024, 1, 2),
                    StartTime = new TimeOnly(8, 40),
                    EndTime = new TimeOnly(9, 0)
                }
                );
        }
    }
}
