﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class SystemAdminContext : DbContext
{
    public SystemAdminContext()
    {
    }

    public SystemAdminContext(DbContextOptions<SystemAdminContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AjustesInventario> AjustesInventarios { get; set; }

    public virtual DbSet<Almacene> Almacenes { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<RelAlmacenDetalle> RelAlmacenDetalles { get; set; }

    public virtual DbSet<RelAlmacenProducto> RelAlmacenProductos { get; set; }

    public virtual DbSet<RelProductoSucursale> RelProductoSucursales { get; set; }

    public virtual DbSet<RelUsuarioSucursale> RelUsuarioSucursales { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=haliabd.mssql.somee.com;Database=haliabd;UID=Rolando03_SQLLogin_1;PWD=Facil123$;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AjustesInventario>(entity =>
        {
            entity.HasKey(e => e.AjusteId);

            entity.ToTable("AjustesInventario");

            entity.Property(e => e.TipoProducto).HasMaxLength(50);
        });

        modelBuilder.Entity<Almacene>(entity =>
        {
            entity.HasKey(e => e.AlmacenId);

            entity.Property(e => e.AlmacenId).HasColumnName("AlmacenID");
            entity.Property(e => e.Estatus).HasMaxLength(50);
            entity.Property(e => e.NombreAlmacen).HasMaxLength(100);
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.EmpresaId).HasName("PK_Empresa");

            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.CreadoPor).HasMaxLength(50);
            entity.Property(e => e.EmailPublico).HasMaxLength(50);
            entity.Property(e => e.EstatusId)
                .HasMaxLength(50)
                .HasDefaultValueSql("('Activo')")
                .HasColumnName("EstatusID");
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.ModificadoPor).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.NombreComercial).HasMaxLength(50);
            entity.Property(e => e.PaginaWeb).HasMaxLength(50);
            entity.Property(e => e.RazonSocial).HasMaxLength(100);
            entity.Property(e => e.RegimenFiscal).HasMaxLength(3);
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.ToTable("Inventario");

            entity.Property(e => e.InventarioId).HasColumnName("InventarioID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
        });

        modelBuilder.Entity<RelAlmacenDetalle>(entity =>
        {
            entity.HasKey(e => e.IdRelAlmacenDetalle);

            entity.ToTable("RelAlmacenDetalle");

            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Modelo).HasMaxLength(50);
            entity.Property(e => e.Serie).HasMaxLength(50);
            entity.Property(e => e.Talla).HasMaxLength(50);
        });

        modelBuilder.Entity<RelAlmacenProducto>(entity =>
        {
            entity.ToTable("RelAlmacenProducto");

            entity.Property(e => e.RelAlmacenProductoId).HasColumnName("RelAlmacenProductoID");
        });

        modelBuilder.Entity<RelProductoSucursale>(entity =>
        {
            entity.HasKey(e => e.RelProductoSucursalesId);

            entity.Property(e => e.RelProductoSucursalesId).HasMaxLength(50);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
        });

        modelBuilder.Entity<RelUsuarioSucursale>(entity =>
        {
            entity.HasKey(e => e.RelUsuarioSucursalId).HasName("PK_RelUsuarioEmpresaID");

            entity.Property(e => e.RelUsuarioSucursalId)
                .ValueGeneratedNever()
                .HasColumnName("RelUsuarioSucursalID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.UsuariId).HasColumnName("UsuariID");
        });

        modelBuilder.Entity<RolPermiso>(entity =>
        {
            entity.HasKey(e => e.PermisosId);

            entity.Property(e => e.Caja)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.CajaHistorialRecibos)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.CajaRecibosOficiales)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.CatalogoClientes)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.CatalogoProveedores)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Catalogos)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Contratos)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ContratosBuscarProforma)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ContratosContratosRetirados)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ContratosCrearContratos)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ContratosCrearProforma)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ContratosFactura)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ContratosGestionCuotas)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ContratosInformacionGeneral)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ContratosRetiroServicios)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Inventario)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.InventarioInventarioServicios)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.InventarioModificacionesProductos)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Opciones)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.OpcionesTipoCambio)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Personal)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Seguridad)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SeguridadAuditoria)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SeguridadGestionPermisos)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.SeguridadGestionUsuario)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.VentarRetiros)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Ventas)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.VentasBuscarProformas)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.VentasCrearProforma)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.VentasDirectas)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.VentasFacturas)
                .IsRequired()
                .HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<RolUsuario>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__RolUsuar__F92302F1E0C90261");

            entity.ToTable("RolUsuario");

            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Rol).HasMaxLength(100);
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.SucursalId);

            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.Correo).HasMaxLength(200);
            entity.Property(e => e.Direccion).HasMaxLength(500);
            entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.NombreSucursal).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuarios).HasName("PK__Usuario__AEF904291193A69F");

            entity.ToTable("Usuario");

            entity.Property(e => e.IdUsuarios).HasColumnName("Id_Usuarios");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("date")
                .HasColumnName("Fecha_Creacion");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Pass).HasMaxLength(100);
            entity.Property(e => e.PrimerApellido).HasMaxLength(100);
            entity.Property(e => e.PrimerNombre).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
