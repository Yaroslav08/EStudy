﻿using EStudy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => new
            {
                d.FirstName,
                d.MiddleName,
                d.LastName
            });
            builder.HasIndex(d => d.Login).IsUnique();
            builder.HasIndex(d => d.Username).IsUnique();
        }
    }
}