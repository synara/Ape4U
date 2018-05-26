namespace RedeSocialCondominio.Migrations
{
    using RedeSocialCondominio.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RedeSocialCondominio.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RedeSocialCondominio.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Funcionalidades.AddOrUpdate(
            //f => f.Nome,
            //new Funcionalidade { Nome = "Agendar mudança", Controller = "Mudanca", Action = "Index", PerfilId = 1 },
            //new Funcionalidade { Nome = "Agendar mudança", Controller = "Mudanca", Action = "Index", PerfilId = 2 },
            //new Funcionalidade { Nome = "Agendar mudança", Controller = "Mudanca", Action = "Index", PerfilId = 3 }
            //);

            context.Perfis.AddOrUpdate(
                p => p.Nome,
                new Perfil { Nome = "Morador" },
                new Perfil { Nome = "Sindico" },
                new Perfil { Nome = "Funcionario" },
                new Perfil { Nome = "Proprietario" }
                );

            context.TiposMudanca.AddOrUpdate(
                m => m.Descricao,
                new TipoMudanca { Descricao = "De um apartamento para outro" },
                new TipoMudanca { Descricao = "Novo morador" },
                new TipoMudanca { Descricao = "Deixar condomínio" }
                );

            context.Locais.AddOrUpdate(
                l => l.Nome,
                new Local { Nome = "Deck" },
                new Local { Nome = "Piscina" },
                new Local { Nome = "Salão de Jogos" },
                new Local { Nome = "Sauna" },
                new Local { Nome = "Salão de Festa"}
                );

            context.HorariosLocais.AddOrUpdate(
                h => h.Id,
                new HorariosLocais { HorarioInicial = Convert.ToDateTime("09:00"), HorarioFinal = Convert.ToDateTime("22:00"), LocalId = 1 }, 
                new HorariosLocais { HorarioInicial = Convert.ToDateTime("08:00"), HorarioFinal = Convert.ToDateTime("12:00"), LocalId = 2 },
                new HorariosLocais { HorarioInicial = Convert.ToDateTime("13:00"), HorarioFinal = Convert.ToDateTime("19:00"), LocalId = 2 },
                new HorariosLocais { HorarioInicial = Convert.ToDateTime("09:00"), HorarioFinal = Convert.ToDateTime("12:00"), LocalId = 3 },
                new HorariosLocais { HorarioInicial = Convert.ToDateTime("14:00"), HorarioFinal = Convert.ToDateTime("22:00"), LocalId = 3 },
                new HorariosLocais { HorarioInicial = Convert.ToDateTime("08:00"), HorarioFinal = Convert.ToDateTime("22:00"), LocalId = 4 },
                new HorariosLocais { HorarioInicial = Convert.ToDateTime("09:00"), HorarioFinal = Convert.ToDateTime("02:00"), LocalId = 5 }

                );
        }
    }
}
