using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreTranslators.Models
{
    public partial class quickbeedev1Context : DbContext
    {
        public quickbeedev1Context()
        {
        }

        public quickbeedev1Context(DbContextOptions<quickbeedev1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ApiClaims> ApiClaims { get; set; }
        public virtual DbSet<ApiProperties> ApiProperties { get; set; }
        public virtual DbSet<ApiResources> ApiResources { get; set; }
        public virtual DbSet<ApiScopeClaims> ApiScopeClaims { get; set; }
        public virtual DbSet<ApiScopes> ApiScopes { get; set; }
        public virtual DbSet<ApiSecrets> ApiSecrets { get; set; }
        public virtual DbSet<ClientClaims> ClientClaims { get; set; }
        public virtual DbSet<ClientCorsOrigins> ClientCorsOrigins { get; set; }
        public virtual DbSet<ClientGrantTypes> ClientGrantTypes { get; set; }
        public virtual DbSet<ClientIdPrestrictions> ClientIdPrestrictions { get; set; }
        public virtual DbSet<ClientPostLogoutRedirectUris> ClientPostLogoutRedirectUris { get; set; }
        public virtual DbSet<ClientProperties> ClientProperties { get; set; }
        public virtual DbSet<ClientRedirectUris> ClientRedirectUris { get; set; }
        public virtual DbSet<ClientScopes> ClientScopes { get; set; }
        public virtual DbSet<ClientSecrets> ClientSecrets { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<ConnectionSettings> ConnectionSettings { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<IdentityClaims> IdentityClaims { get; set; }
        public virtual DbSet<IdentityProperties> IdentityProperties { get; set; }
        public virtual DbSet<IdentityResources> IdentityResources { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<OrderLines> OrderLines { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<Ports> Ports { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Shipments> Shipments { get; set; }
        public virtual DbSet<States> States { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<SystemDefaultValues> SystemDefaultValues { get; set; }
        public virtual DbSet<Translators> Translators { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Wards> Wards { get; set; }
        public virtual DbSet<Warehouses> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=10.0.0.43;Initial Catalog=quickbee.dev1; User ID=sa;Password=Vu@123;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApiClaims>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiClaims)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiProperties>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiProperties)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiResources>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ApiScopeClaims>(entity =>
            {
                entity.HasIndex(e => e.ApiScopeId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiScope)
                    .WithMany(p => p.ApiScopeClaims)
                    .HasForeignKey(d => d.ApiScopeId);
            });

            modelBuilder.Entity<ApiScopes>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiScopes)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ApiSecrets>(entity =>
            {
                entity.HasIndex(e => e.ApiResourceId);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.ApiResource)
                    .WithMany(p => p.ApiSecrets)
                    .HasForeignKey(d => d.ApiResourceId);
            });

            modelBuilder.Entity<ClientClaims>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientClaims)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientCorsOrigins>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientCorsOrigins)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientGrantTypes>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.GrantType)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientGrantTypes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientIdPrestrictions>(entity =>
            {
                entity.ToTable("ClientIdPRestrictions");

                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientIdPrestrictions)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientPostLogoutRedirectUris>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.PostLogoutRedirectUri)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientPostLogoutRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientProperties>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientProperties)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientRedirectUris>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.RedirectUri)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientRedirectUris)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientScopes>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Scope)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientScopes)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<ClientSecrets>(entity =>
            {
                entity.HasIndex(e => e.ClientId);

                entity.Property(e => e.Description).HasMaxLength(2000);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.ClientSecrets)
                    .HasForeignKey(d => d.ClientId);
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasIndex(e => e.ClientId)
                    .IsUnique();

                entity.Property(e => e.BackChannelLogoutUri).HasMaxLength(2000);

                entity.Property(e => e.ClientClaimsPrefix).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ClientName).HasMaxLength(200);

                entity.Property(e => e.ClientUri).HasMaxLength(2000);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.FrontChannelLogoutUri).HasMaxLength(2000);

                entity.Property(e => e.LogoUri).HasMaxLength(2000);

                entity.Property(e => e.PairWiseSubjectSalt).HasMaxLength(200);

                entity.Property(e => e.ProtocolType)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserCodeType).HasMaxLength(100);
            });

            modelBuilder.Entity<ConnectionSettings>(entity =>
            {
                entity.Property(e => e.PartnerCode).HasMaxLength(30);

                entity.Property(e => e.Password).HasMaxLength(30);

                entity.Property(e => e.Url)
                    .HasColumnName("URL")
                    .HasMaxLength(256);

                entity.Property(e => e.Username).HasMaxLength(30);
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.IsoAlpha2).HasMaxLength(2);

                entity.Property(e => e.IsoAlpha3).HasMaxLength(3);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasIndex(e => e.ConnectionSettingId)
                    .IsUnique()
                    .HasFilter("([ConnectionSettingId] IS NOT NULL)");

                entity.HasIndex(e => e.CountryId);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TransportSettingId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.ConnectionSetting)
                    .WithOne(p => p.Customers)
                    .HasForeignKey<Customers>(d => d.ConnectionSettingId);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode)
                    .IsUnique();

                entity.HasIndex(e => e.Expiration);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.HasIndex(e => e.ProvinceId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId);
            });

            modelBuilder.Entity<IdentityClaims>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityClaims)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityProperties>(entity =>
            {
                entity.HasIndex(e => e.IdentityResourceId);

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.HasOne(d => d.IdentityResource)
                    .WithMany(p => p.IdentityProperties)
                    .HasForeignKey(d => d.IdentityResourceId);
            });

            modelBuilder.Entity<IdentityResources>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.DisplayName).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Notifications>(entity =>
            {
                entity.Property(e => e.DataKey)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.IsHiden)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsRead)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MessageHtmlUs)
                    .IsRequired()
                    .HasColumnName("MessageHtmlUS")
                    .HasMaxLength(1000);

                entity.Property(e => e.MessageHtmlVn)
                    .IsRequired()
                    .HasColumnName("MessageHtmlVN")
                    .HasMaxLength(1000);

                entity.Property(e => e.MessageUs).HasColumnName("MessageUS");

                entity.Property(e => e.MessageVn).HasColumnName("MessageVN");
            });

            modelBuilder.Entity<OrderLines>(entity =>
            {
                entity.HasIndex(e => e.CustomsStatusId);

                entity.HasIndex(e => e.DeliveryStatusId);

                entity.HasIndex(e => e.OrderId);

                entity.Property(e => e.AmountUsd)
                    .HasColumnName("AmountUSD")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.AmountVnd)
                    .HasColumnName("AmountVND")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Cbm)
                    .HasColumnName("CBM")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CurrencyRate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.DescriptionOfGoods).HasMaxLength(200);

                entity.Property(e => e.Eancode)
                    .HasColumnName("EANCode")
                    .HasMaxLength(50);

                entity.Property(e => e.Hscode)
                    .HasColumnName("HSCode")
                    .HasMaxLength(50);

                entity.Property(e => e.InsuranceAmountUsd)
                    .HasColumnName("InsuranceAmountUSD")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.InsuranceAmountVnd)
                    .HasColumnName("InsuranceAmountVND")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ItemNo).HasMaxLength(50);

                entity.Property(e => e.PriceUsd)
                    .HasColumnName("PriceUSD")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.PriceVnd)
                    .HasColumnName("PriceVND")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ProductNo).HasMaxLength(50);

                entity.Property(e => e.TaxAmountUsd)
                    .HasColumnName("TaxAmountUSD")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TaxAmountVnd)
                    .HasColumnName("TaxAmountVND")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TaxRate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Weight).HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.CustomsStatus)
                    .WithMany(p => p.OrderLinesCustomsStatus)
                    .HasForeignKey(d => d.CustomsStatusId);

                entity.HasOne(d => d.DeliveryStatus)
                    .WithMany(p => p.OrderLinesDeliveryStatus)
                    .HasForeignKey(d => d.DeliveryStatusId);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderLines)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasIndex(e => e.ConsigneeCountryId);

                entity.HasIndex(e => e.ConsigneeDistrictId);

                entity.HasIndex(e => e.ConsigneeProvinceId);

                entity.HasIndex(e => e.ConsigneeStateId);

                entity.HasIndex(e => e.ConsigneeWardId);

                entity.HasIndex(e => e.CustomsStatusId);

                entity.HasIndex(e => e.DeliveryStatusId);

                entity.HasIndex(e => e.ShipmentId);

                entity.HasIndex(e => e.ShipperCountryId);

                entity.HasIndex(e => e.ShipperDistrictId);

                entity.HasIndex(e => e.ShipperProvinceId);

                entity.HasIndex(e => e.ShipperStateId);

                entity.HasIndex(e => e.ShipperWardId);

                entity.Property(e => e.Cdchanel).HasColumnName("CDChanel");

                entity.Property(e => e.Codamount)
                    .HasColumnName("CODAmount")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.ConsigneeAddress1).HasMaxLength(200);

                entity.Property(e => e.ConsigneeAddress2).HasMaxLength(200);

                entity.Property(e => e.ConsigneeCountryName).HasMaxLength(100);

                entity.Property(e => e.ConsigneeDistrictName).HasMaxLength(100);

                entity.Property(e => e.ConsigneeName).HasMaxLength(200);

                entity.Property(e => e.ConsigneePostalCode).HasMaxLength(7);

                entity.Property(e => e.ConsigneeProvinceName).HasMaxLength(100);

                entity.Property(e => e.ConsigneeTelephone).HasMaxLength(20);

                entity.Property(e => e.ConsigneeWardName).HasMaxLength(100);

                entity.Property(e => e.DeliveryInstruction).HasMaxLength(1000);

                entity.Property(e => e.IsIncludedBattery)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsRemoteAreaDestination)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MeasumentUnit).HasMaxLength(3);

                entity.Property(e => e.Notes).HasMaxLength(1000);

                entity.Property(e => e.OrderNo).HasMaxLength(20);

                entity.Property(e => e.ShipperAddress1).HasMaxLength(200);

                entity.Property(e => e.ShipperAddress2).HasMaxLength(200);

                entity.Property(e => e.ShipperCountryName).HasMaxLength(100);

                entity.Property(e => e.ShipperDistrictName).HasMaxLength(100);

                entity.Property(e => e.ShipperName).HasMaxLength(200);

                entity.Property(e => e.ShipperPostalCode).HasMaxLength(7);

                entity.Property(e => e.ShipperProvinceName).HasMaxLength(100);

                entity.Property(e => e.ShipperTelephone).HasMaxLength(20);

                entity.Property(e => e.ShipperWardName).HasMaxLength(100);

                entity.Property(e => e.TotalAmountUsd)
                    .HasColumnName("TotalAmountUSD")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalAmountVnd)
                    .HasColumnName("TotalAmountVND")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalCbm)
                    .HasColumnName("TotalCBM")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalChargeWeight).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalGrossWeight).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalInsuranceAmountUsd)
                    .HasColumnName("TotalInsuranceAmountUSD")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalInsuranceAmountVnd)
                    .HasColumnName("TotalInsuranceAmountVND")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalTaxAmountUsd)
                    .HasColumnName("TotalTaxAmountUSD")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalTaxAmountVnd)
                    .HasColumnName("TotalTaxAmountVND")
                    .HasColumnType("decimal(18, 6)");

                entity.HasOne(d => d.ConsigneeCountry)
                    .WithMany(p => p.OrdersConsigneeCountry)
                    .HasForeignKey(d => d.ConsigneeCountryId);

                entity.HasOne(d => d.ConsigneeDistrict)
                    .WithMany(p => p.OrdersConsigneeDistrict)
                    .HasForeignKey(d => d.ConsigneeDistrictId);

                entity.HasOne(d => d.ConsigneeProvince)
                    .WithMany(p => p.OrdersConsigneeProvince)
                    .HasForeignKey(d => d.ConsigneeProvinceId);

                entity.HasOne(d => d.ConsigneeState)
                    .WithMany(p => p.OrdersConsigneeState)
                    .HasForeignKey(d => d.ConsigneeStateId);

                entity.HasOne(d => d.ConsigneeWard)
                    .WithMany(p => p.OrdersConsigneeWard)
                    .HasForeignKey(d => d.ConsigneeWardId);

                entity.HasOne(d => d.CustomsStatus)
                    .WithMany(p => p.OrdersCustomsStatus)
                    .HasForeignKey(d => d.CustomsStatusId);

                entity.HasOne(d => d.DeliveryStatus)
                    .WithMany(p => p.OrdersDeliveryStatus)
                    .HasForeignKey(d => d.DeliveryStatusId);

                entity.HasOne(d => d.Shipment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ShipperCountry)
                    .WithMany(p => p.OrdersShipperCountry)
                    .HasForeignKey(d => d.ShipperCountryId);

                entity.HasOne(d => d.ShipperDistrict)
                    .WithMany(p => p.OrdersShipperDistrict)
                    .HasForeignKey(d => d.ShipperDistrictId);

                entity.HasOne(d => d.ShipperProvince)
                    .WithMany(p => p.OrdersShipperProvince)
                    .HasForeignKey(d => d.ShipperProvinceId);

                entity.HasOne(d => d.ShipperState)
                    .WithMany(p => p.OrdersShipperState)
                    .HasForeignKey(d => d.ShipperStateId);

                entity.HasOne(d => d.ShipperWard)
                    .WithMany(p => p.OrdersShipperWard)
                    .HasForeignKey(d => d.ShipperWardId);
            });

            modelBuilder.Entity<PersistedGrants>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.Expiration);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type });

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ports>(entity =>
            {
                entity.HasIndex(e => e.CountryId);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(10);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Ports)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.HasIndex(e => e.CountryId);

                entity.HasIndex(e => e.StateId);

                entity.Property(e => e.MappingCode1).HasMaxLength(20);

                entity.Property(e => e.MappingCode2).HasMaxLength(20);

                entity.Property(e => e.MappingCode3).HasMaxLength(20);

                entity.Property(e => e.MappingCode4).HasMaxLength(20);

                entity.Property(e => e.MappingCode5).HasMaxLength(20);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ProvinceType).HasMaxLength(30);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.CountryId);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.StateId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique()
                    .HasFilter("([Name] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Shipments>(entity =>
            {
                entity.HasIndex(e => e.CreatedUserId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.CustomsStatusId);

                entity.HasIndex(e => e.PortOfDischargeId);

                entity.HasIndex(e => e.PortOfLoadingId);

                entity.HasIndex(e => e.ShipmentStatusId);

                entity.Property(e => e.Awb)
                    .HasColumnName("AWB")
                    .HasMaxLength(200);

                entity.Property(e => e.CurrencyRate).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.CustomsDeclarationNo).HasMaxLength(200);

                entity.Property(e => e.Eta).HasColumnName("ETA");

                entity.Property(e => e.ImportFileName).HasMaxLength(512);

                entity.Property(e => e.MainCurrency).HasMaxLength(3);

                entity.Property(e => e.TotalAmountUsd)
                    .HasColumnName("TotalAmountUSD")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalAmountVnd)
                    .HasColumnName("TotalAmountVND")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalCbm)
                    .HasColumnName("TotalCBM")
                    .HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalChargeWeight).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.TotalGrossWeight).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.VesselName).HasMaxLength(100);

                entity.Property(e => e.Voyage).HasMaxLength(30);

                entity.HasOne(d => d.CreatedUser)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.CreatedUserId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Shipments)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.CustomsStatus)
                    .WithMany(p => p.ShipmentsCustomsStatus)
                    .HasForeignKey(d => d.CustomsStatusId);

                entity.HasOne(d => d.PortOfDischarge)
                    .WithMany(p => p.ShipmentsPortOfDischarge)
                    .HasForeignKey(d => d.PortOfDischargeId);

                entity.HasOne(d => d.PortOfLoading)
                    .WithMany(p => p.ShipmentsPortOfLoading)
                    .HasForeignKey(d => d.PortOfLoadingId);

                entity.HasOne(d => d.ShipmentStatus)
                    .WithMany(p => p.ShipmentsShipmentStatus)
                    .HasForeignKey(d => d.ShipmentStatusId);
            });

            modelBuilder.Entity<States>(entity =>
            {
                entity.HasIndex(e => e.CountryId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.Property(e => e.Color).HasMaxLength(30);

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.NameTrackingUs)
                    .HasColumnName("NameTrackingUS")
                    .HasMaxLength(50);

                entity.Property(e => e.NameTrackingVn)
                    .HasColumnName("NameTrackingVN")
                    .HasMaxLength(50);

                entity.Property(e => e.NameUs)
                    .IsRequired()
                    .HasColumnName("NameUS")
                    .HasMaxLength(50);

                entity.Property(e => e.NameVn)
                    .IsRequired()
                    .HasColumnName("NameVN")
                    .HasMaxLength(50);

                entity.Property(e => e.TypeCode)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<SystemDefaultValues>(entity =>
            {
                entity.Property(e => e.DataKey).HasMaxLength(20);

                entity.Property(e => e.DataType).HasMaxLength(20);

                entity.Property(e => e.DataValueUs)
                    .HasColumnName("DataValueUS")
                    .HasMaxLength(500);

                entity.Property(e => e.DataValueVn)
                    .HasColumnName("DataValueVN")
                    .HasMaxLength(500);
            });

            modelBuilder.Entity<Translators>(entity =>
            {
                entity.Property(e => e.DataKey)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OriginalValue)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TranslatedValue)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(400);

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(256);

                entity.Property(e => e.LastName).HasMaxLength(256);

                entity.Property(e => e.PasswordHash).HasMaxLength(256);

                entity.Property(e => e.PhoneNumber).HasMaxLength(30);

                entity.Property(e => e.Salt).HasMaxLength(100);

                entity.Property(e => e.Timestamp)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<Wards>(entity =>
            {
                entity.HasIndex(e => e.DistrictId);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Wards)
                    .HasForeignKey(d => d.DistrictId);
            });

            modelBuilder.Entity<Warehouses>(entity =>
            {
                entity.HasIndex(e => e.CountryId);

                entity.HasIndex(e => e.DistrictId);

                entity.HasIndex(e => e.ProvinceId);

                entity.HasIndex(e => e.StateId);

                entity.HasIndex(e => e.WardId);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.NameUs)
                    .IsRequired()
                    .HasColumnName("NameUS")
                    .HasMaxLength(100);

                entity.Property(e => e.NameVn)
                    .IsRequired()
                    .HasColumnName("NameVN")
                    .HasMaxLength(10);

                entity.Property(e => e.Pic)
                    .HasColumnName("PIC")
                    .HasMaxLength(100);

                entity.Property(e => e.Tel).HasMaxLength(30);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.WardId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
