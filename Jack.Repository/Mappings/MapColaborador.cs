using FluentNHibernate.Mapping;
using Jack.Domain.Entity;

namespace Jack.Repository.Mappings
{
    class MapColaborador : ClassMap<Colaborador>
    {
        public MapColaborador()
        {
            //Table
            Table("Colaborador");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Nome).Column("Nome").Not.Nullable();
            Map(x => x.Telefone).Column("Telefone").Nullable();
            Map(x => x.Celular).Column("Celular").Nullable();
            Map(x => x.Email).Column("Email").Nullable();
            Map(x => x.AnoNotificacao).Column("AnoNotificacao").Nullable();
            Map(x => x.Cpf).Column("Cpf").Nullable();

            //Hasmany
            HasMany(x => x.Criancas).KeyColumn("Colaborador").Inverse().Not.LazyLoad(); ;

        }
    }
}
