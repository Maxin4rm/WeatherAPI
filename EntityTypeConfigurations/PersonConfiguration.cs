using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using WeatherApp.Server.Models;

namespace WeatherApp.Server.EntityTypeConfigurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("tblPerson");
            builder.HasKey(person => person.PersonId);
            builder.HasIndex(person => person.Login).IsUnique();
            builder.Property(person => person.Login).HasMaxLength(64).IsRequired();
            builder.Property(editor => editor.Password).HasMaxLength(128).IsRequired();
            builder.Property(editor => editor.Role).HasMaxLength(64).IsRequired();
        }
    }
}
