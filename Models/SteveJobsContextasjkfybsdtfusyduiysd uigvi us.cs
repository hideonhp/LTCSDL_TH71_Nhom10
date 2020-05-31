
    public partial class SteveJobsContext : DbContext
    {
        public SteveJobsContext()
        {
        }

        public SteveJobsContext(DbContextOptions<SteveJobsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<KieuNguoiDung> KieuNguoiDung { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-PO58C85;Initial Catalog=SteveJobs;Persist Security Info=True;User ID=sa;Password=123456;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.IdSanPham, e.IdDonHang });

                entity.Property(e => e.SoLuong)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDonHangNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.IdDonHang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");

                entity.HasOne(d => d.IdSanPhamNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.IdSanPham)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_SanPham");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.IdDonHang);

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.Property(e => e.TinhTrangDonHang).HasMaxLength(50);

                entity.Property(e => e.TongTien).HasMaxLength(50);
            });

            modelBuilder.Entity<KieuNguoiDung>(entity =>
            {
                entity.HasKey(e => e.IdTypeUser);

                entity.Property(e => e.IdTypeUser).ValueGeneratedNever();

                entity.Property(e => e.TypeUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.IdLoai);

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.HoVaTen).HasMaxLength(50);

                entity.Property(e => e.MatKhau)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenDangNhap)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTypeUserNavigation)
                    .WithMany(p => p.NguoiDung)
                    .HasForeignKey(d => d.IdTypeUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NguoiDung_KieuNguoiDung");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.IdSanPham);

                entity.Property(e => e.Gia).HasMaxLength(50);

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdLoaiNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.IdLoai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_LoaiSanPham");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

