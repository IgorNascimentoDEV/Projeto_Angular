﻿using back.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace back.Map
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : Base
    {
        private readonly string _tableName;

        public BaseMap(string tableName)
        {
            this._tableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if(string .IsNullOrEmpty(_tableName)) builder.ToTable(this._tableName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
        }
    }
}
