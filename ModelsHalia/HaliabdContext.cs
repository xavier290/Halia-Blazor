using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NovaLaundryAppWebAdminBlazor.ModelsHalia;

public partial class HaliabdContext : DbContext
{
    public HaliabdContext()
    {
    }

    public HaliabdContext(DbContextOptions<HaliabdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AjustesInventario> AjustesInventarios { get; set; }

    public virtual DbSet<Almacene> Almacenes { get; set; }

    public virtual DbSet<AuditoriaSistema> AuditoriaSistemas { get; set; }

    public virtual DbSet<Banco> Bancos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<EmpresasTercera> EmpresasTerceras { get; set; }

    public virtual DbSet<Imagene> Imagenes { get; set; }

    public virtual DbSet<Inventario> Inventarios { get; set; }

    public virtual DbSet<MotivosCancelacion> MotivosCancelacions { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<RelAlmacenDetalle> RelAlmacenDetalles { get; set; }

    public virtual DbSet<RelAlmacenProducto> RelAlmacenProductos { get; set; }

    public virtual DbSet<RelBancoTipo> RelBancoTipos { get; set; }

    public virtual DbSet<RelProductoSucursale> RelProductoSucursales { get; set; }

    public virtual DbSet<RolPermiso> RolPermisos { get; set; }

    public virtual DbSet<RolUsuario> RolUsuarios { get; set; }

    public virtual DbSet<ServiciosEstadare> ServiciosEstadares { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<TipoCambio> TipoCambios { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<TipoTarjetum> TipoTarjeta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=haliabd.mssql.somee.com;Database=haliabd;UID=Rolando03_SQLLogin_1;PWD=Facil123$;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Modern_Spanish_CI_AS");

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

        modelBuilder.Entity<AuditoriaSistema>(entity =>
        {
            entity.HasKey(e => e.IdAuditoria);

            entity.ToTable("AuditoriaSistema");

            entity.Property(e => e.Campo).HasMaxLength(50);
            entity.Property(e => e.Fecha).HasMaxLength(50);
            entity.Property(e => e.Nivel)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Sector).HasMaxLength(50);
            entity.Property(e => e.Tipo).HasMaxLength(50);
            entity.Property(e => e.Usuario).HasMaxLength(100);
        });

        modelBuilder.Entity<Banco>(entity =>
        {
            entity.Property(e => e.BancoId).HasColumnName("BancoID");
            entity.Property(e => e.Banco1)
                .HasMaxLength(100)
                .HasColumnName("Banco");
            entity.Property(e => e.Estado).HasMaxLength(50);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D5946642123EB7A3");

            entity.ToTable("Clientes", "RRHH");

            entity.Property(e => e.Cedula).HasMaxLength(255);
            entity.Property(e => e.Celular).HasMaxLength(50);
            entity.Property(e => e.Departamento).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(60);
            entity.Property(e => e.EstadoCivil)
                .HasMaxLength(255)
                .HasColumnName("Estado Civil");
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.FechaNac).HasColumnType("date");
            entity.Property(e => e.NoRuc).HasMaxLength(50);
            entity.Property(e => e.Observacion)
                .HasMaxLength(400)
                .HasColumnName("observacion");
            entity.Property(e => e.Pais)
                .HasMaxLength(100)
                .HasColumnName("pais");
            entity.Property(e => e.Papellido)
                .HasMaxLength(255)
                .HasColumnName("PApellido");
            entity.Property(e => e.Pnombre)
                .HasMaxLength(255)
                .HasColumnName("PNombre");
            entity.Property(e => e.Profesion).HasMaxLength(255);
            entity.Property(e => e.Sapellido)
                .HasMaxLength(255)
                .HasColumnName("SAPellido");
            entity.Property(e => e.Sexo).HasMaxLength(255);
            entity.Property(e => e.Snombre)
                .HasMaxLength(255)
                .HasColumnName("SNombre");
            entity.Property(e => e.Telefono).HasMaxLength(50);
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

        modelBuilder.Entity<EmpresasTercera>(entity =>
        {
            entity.HasKey(e => e.EmpresasTercerasId);

            entity.Property(e => e.EmpresasTercerasId).HasColumnName("EmpresasTercerasID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.NombreComercial).HasMaxLength(200);
            entity.Property(e => e.Ruc).HasMaxLength(50);
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.Telefono).HasMaxLength(50);
        });

        modelBuilder.Entity<Imagene>(entity =>
        {
            entity.HasKey(e => e.IdImagen).HasName("PK__Imagenes__B42D8F2AB83BC61E");

            entity.ToTable("Imagenes", "RECURSOS");

            entity.Property(e => e.Imagen)
                .HasColumnType("image")
                .HasColumnName("imagen");
        });

        modelBuilder.Entity<Inventario>(entity =>
        {
            entity.ToTable("Inventario");

            entity.Property(e => e.InventarioId).HasColumnName("InventarioID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
        });

        modelBuilder.Entity<MotivosCancelacion>(entity =>
        {
            entity.HasKey(e => e.MotivoCancelacionId);

            entity.ToTable("MotivosCancelacion");

            entity.Property(e => e.MotivoCancelacionId).HasColumnName("MotivoCancelacionID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.Motivo).HasMaxLength(100);
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__E8B631AFC844EB8F");

            entity.ToTable("Proveedores", "OPERATIVOS");

            entity.Property(e => e.Correo).HasMaxLength(30);
            entity.Property(e => e.Direccion).HasMaxLength(200);
            entity.Property(e => e.NoRuc).HasMaxLength(30);
            entity.Property(e => e.NoTelefono).HasMaxLength(30);
            entity.Property(e => e.NombreEmpresa).HasMaxLength(200);
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

        modelBuilder.Entity<RelBancoTipo>(entity =>
        {
            entity.HasKey(e => e.RelBancoTarjetaTipo);

            entity.ToTable("RelBancoTipo");

            entity.Property(e => e.BancoId).HasColumnName("BancoID");
            entity.Property(e => e.TarjetaTipoId).HasColumnName("TarjetaTipoID");
        });

        modelBuilder.Entity<RelProductoSucursale>(entity =>
        {
            entity.HasKey(e => e.RelProductoSucursalesId);

            entity.Property(e => e.RelProductoSucursalesId).HasMaxLength(50);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
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

        modelBuilder.Entity<ServiciosEstadare>(entity =>
        {
            entity.HasKey(e => e.IdEstandar).HasName("PK__Servicio__BB570ABD4589517F");

            entity.ToTable("Servicios_Estadares", "OPERATIVOS");

            entity.Property(e => e.ClasificacionInventario).HasMaxLength(50);
            entity.Property(e => e.Codigo).HasMaxLength(100);
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.MontoVd).HasColumnName("MontoVD");
            entity.Property(e => e.NombreEstandar).HasMaxLength(100);
            entity.Property(e => e.TipoServicio).HasMaxLength(50);
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

        modelBuilder.Entity<TipoCambio>(entity =>
        {
            entity.HasKey(e => e.IdTasaCambio).HasName("PK__TipoCamb__E5C307FB17CC6D75");

            entity.ToTable("TipoCambio", "OPERATIVOS");

            entity.Property(e => e.FechaCambio).HasColumnType("datetime");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.TipoServicionId).HasName("PK_OPERATIVOS.TipoServicios");

            entity.Property(e => e.TipoServicionId).HasColumnName("TipoServicionID");
            entity.Property(e => e.Descripcion).HasMaxLength(100);
            entity.Property(e => e.Estado).HasMaxLength(50);
        });

        modelBuilder.Entity<TipoTarjetum>(entity =>
        {
            entity.HasKey(e => e.TipoTarjetaId);

            entity.Property(e => e.TipoTarjetaId)
                .ValueGeneratedNever()
                .HasColumnName("TipoTarjetaID");
            entity.Property(e => e.Estado).HasMaxLength(50);
            entity.Property(e => e.NombreTipo).HasMaxLength(100);
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
