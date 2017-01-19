﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Administracion.Repositorio.Contexto
{
    using Administracion.Modelos.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AdministracionEntities : DbContext
    {
        public AdministracionEntities()
            : base("name=AdministracionEntities")
        {
        }

        public AdministracionEntities(string conectionString)
        {
            Database.Connection.ConnectionString = conectionString;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<BIOMETRICO_FORMATO> BIOMETRICO_FORMATO { get; set; }
        public DbSet<BIOMETRICO_TIPO> BIOMETRICO_TIPO { get; set; }
        public DbSet<CELDA> CELDAs { get; set; }
        public DbSet<CENTRO> CENTROes { get; set; }
        public DbSet<EDIFICIO> EDIFICIOs { get; set; }
        public DbSet<EMPLEADO> EMPLEADOes { get; set; }
        public DbSet<IMPUTADO> IMPUTADOes { get; set; }
        //public DbSet<INCIDENCIA> INCIDENCIAs { get; set; }
        //public DbSet<INCIDENTE_TIPO> INCIDENTE_TIPO { get; set; }
        public DbSet<INGRESO> INGRESOes { get; set; }
        public DbSet<PARAMETRO> PARAMETROes { get; set; }
        //public DbSet<PASELISTA_ASIGNADO> PASELISTA_ASIGNADO { get; set; }
        //public DbSet<PASELISTA_CATALOGO> PASELISTA_CATALOGO { get; set; }
        //public DbSet<PASELISTA_CATALOGO_ESTATUS> PASELISTA_CATALOGO_ESTATUS { get; set; }
        //public DbSet<PASELISTA_PROGRAMADO> PASELISTA_PROGRAMADO { get; set; }
        //public DbSet<PASELISTA_PROGRAMADO_ESTATUS> PASELISTA_PROGRAMADO_ESTATUS { get; set; }
        //public DbSet<PASELISTA_RESULTADO> PASELISTA_RESULTADO { get; set; }
        public DbSet<PERSONA> PERSONAs { get; set; }
        public DbSet<PERSONA_BIOMETRICO> PERSONA_BIOMETRICO { get; set; }
        public DbSet<SECTOR> SECTORs { get; set; }
        public DbSet<TIPO_EMPLEADO> TIPO_EMPLEADO { get; set; }
        public DbSet<IMPUTADO_BIOMETRICO> IMPUTADO_BIOMETRICO { get; set; }
    }
}
