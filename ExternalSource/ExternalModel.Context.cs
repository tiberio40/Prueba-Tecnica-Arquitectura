﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExternalSource
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ExternalContext : DbContext
    {
        public ExternalContext()
            : base("name=ExternalContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_INV_CO_DESPACHADAS_N> TBL_INV_CO_DESPACHADAS_N { get; set; }
        public virtual DbSet<TBL_INV_NP_COMPROMETIDAS_N> TBL_INV_NP_COMPROMETIDAS_N { get; set; }
        public virtual DbSet<TBL_INV_UBICACIONES_N> TBL_INV_UBICACIONES_N { get; set; }
    }
}
