﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TexEntities1 : DbContext
    {
        private static TexEntities1 _context;
        public TexEntities1()
            : base("name=TexEntities1")
        {
        }

        public static TexEntities1 GetContext()
        {
            if (_context == null)
                _context = new TexEntities1();

            return _context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Inv> Invs { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}