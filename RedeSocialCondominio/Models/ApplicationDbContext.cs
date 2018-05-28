using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RedeSocialCondominio.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Mudanca> Mudancas { get; set; }
        public DbSet<Funcionalidade> Funcionalidades { get; set; }
        public DbSet<TipoMudanca> TiposMudanca { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }
        public DbSet<Encomenda> Encomendas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Local> Locais { get; set; }
        public DbSet<HorariosLocais> HorariosLocais { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }
        public DbSet<UsuarioNotificacao> UsuarioNotificacoes { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<NotificacaoOcorrencia> NotificacaoOcorrencia { get; set; }
        public DbSet<NotificacaoReserva> NotificacaoReserva { get; set; }
        public DbSet<Reuniao> Reunioes { get; set; }
        public DbSet<NotificacaoReuniao> NotificacaoReuniao { get; set; }
        public DbSet<NotificacaoEncomenda> NotificacaoEncomenda { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<NotificacaoMudanca> NotificacaoMudanca { get; set; }

        public List<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            ApplicationUsers = new List<ApplicationUser>();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<ApplicationUser>()
            // .HasMany(u => u.UsuarioNotificacoes)
            // .WithRequired(u => u.Usuario)
            // .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UsuarioNotificacao>()
            // .HasRequired(n => n.Usuario)
            // .WithMany(u => u.UsuarioNotificacoes)
            // .WillCascadeOnDelete(false);
                
            
            base.OnModelCreating(modelBuilder);
        }
    }
}