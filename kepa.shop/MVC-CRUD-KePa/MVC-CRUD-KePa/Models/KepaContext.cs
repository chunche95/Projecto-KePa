using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_CRUD_KePa.Models;

public partial class KepaContext : DbContext
{
    public KepaContext()
    {
    }

    public KepaContext(DbContextOptions<KepaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CarritoCompra> CarritoCompras { get; set; }

    public virtual DbSet<DetalleVentum> DetalleVenta { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VentaPedido> VentaPedidos { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=DESKTOP-8JRUFD9\\KEPA; database=kepa; integrated security=true; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CarritoCompra>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("carrito_compras");

            entity.Property(e => e.CClave).HasColumnName("c_clave");
            entity.Property(e => e.PCantidad).HasColumnName("p_cantidad");
            entity.Property(e => e.PClave).HasColumnName("p_clave");
            entity.Property(e => e.UClave).HasColumnName("u_clave");
        });

        modelBuilder.Entity<DetalleVentum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("detalle_venta");

            entity.Property(e => e.DClave).HasColumnName("d_clave");
            entity.Property(e => e.PCantidad).HasColumnName("p_cantidad");
            entity.Property(e => e.PClave).HasColumnName("p_clave");
            entity.Property(e => e.PCosto)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("p_costo");
            entity.Property(e => e.VClave).HasColumnName("v_clave");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("pedido");

            entity.Property(e => e.PeClave).HasColumnName("pe_clave");
            entity.Property(e => e.PeDireccion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("pe_direccion");
            entity.Property(e => e.PeEstado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pe_estado");
            entity.Property(e => e.PeFechaEnt)
                .HasColumnType("date")
                .HasColumnName("pe_fecha_ent");
            entity.Property(e => e.PeFechaEnv)
                .HasColumnType("date")
                .HasColumnName("pe_fecha_env");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("producto");

            entity.Property(e => e.PCantidad).HasColumnName("p_cantidad");
            entity.Property(e => e.PClave).HasColumnName("p_clave");
            entity.Property(e => e.PCosto)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("p_costo");
            entity.Property(e => e.PDescripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("p_descripcion");
            entity.Property(e => e.PImagen)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("p_imagen");
            entity.Property(e => e.PNombre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("p_nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usuario");

            entity.Property(e => e.UAlias)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("u_alias");
            entity.Property(e => e.UClave).HasColumnName("u_clave");
            entity.Property(e => e.UContrasena)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("u_contrasena");
            entity.Property(e => e.URol)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("u_rol");
        });

        modelBuilder.Entity<VentaPedido>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("venta_pedido");

            entity.Property(e => e.PeClave).HasColumnName("pe_clave");
            entity.Property(e => e.VClave).HasColumnName("v_clave");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("venta");

            entity.Property(e => e.UClave).HasColumnName("u_clave");
            entity.Property(e => e.VClave).HasColumnName("v_clave");
            entity.Property(e => e.VEstado)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("v_estado");
            entity.Property(e => e.VFecha)
                .HasColumnType("date")
                .HasColumnName("v_fecha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
