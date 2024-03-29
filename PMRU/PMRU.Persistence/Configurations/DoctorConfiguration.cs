﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMRU.Persistence.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Surname).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(256).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(10); 
            builder.Property(x => x.IdentityNumber).HasMaxLength(11).IsRequired();

            builder.HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorID)
                 .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(d => d.Availabilities)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(d => d.Location)
                .WithMany()
                .HasForeignKey(d => d.LocationID)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "Aylin",
                    Surname = "Güneş",
                    Email = "aylin.gunes@email.com",
                    Phone = "5556123456",
                    IdentityNumber = "12345678901",
                    RegistrationNumber = "110",
                    LocationID = 35,
                },
                new Doctor
                {
                    Id = 2,
                    Name = "Eren",
                    Surname = "Akçay",
                    Email = "eren.akcay@email.com",
                    Phone = "5556234567",
                    IdentityNumber = "12345678923",
                    RegistrationNumber = "111",
                    LocationID = 41,
                },
                new Doctor
                {
                    Id = 3,
                    Name = "Gülay",
                    Surname = "Kaya",
                    Email = "gulay.kaya@email.com",
                    Phone = "5556345678",
                    IdentityNumber = "12343458923",
                    RegistrationNumber = "112",
                    LocationID = 72,
                },
                new Doctor
                {
                    Id = 4,
                    Name = "Gülsüm",
                    Surname = "Aydın",
                    Email = "gulsum.aydin@email.com",
                    Phone = "5556678901",
                    IdentityNumber = "12343458205",
                    RegistrationNumber = "116",
                    LocationID = 34,
                },
                new Doctor
                {
                    Id = 5,
                    Name = "Meryem",
                    Surname = "Kuzey",
                    Email = "meryem.kuzey@email.com",
                    Phone = "5556345358",
                    IdentityNumber = "3972226751",
                    RegistrationNumber = "121",
                    LocationID = 35,
                },
                new Doctor
                {
                    Id = 6,
                    Name = "Ali",
                    Surname = "Atabey",
                    Email = "ali.atabey@email.com",
                    Phone = "5551862565",
                    IdentityNumber = "1971927981",
                    RegistrationNumber = "122",
                    LocationID = 34,
                }
            );
        }
    }
}
