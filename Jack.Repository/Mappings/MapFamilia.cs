using FluentNHibernate.Mapping;
using Jack.Domain.Entity;


namespace Jack.Repository.Mappings
{
    class MapFamilia : ClassMap<Familia>
    {
        public MapFamilia()
        {
            //Table
            Table("Familia");
            LazyLoad();

            //Fields
            Id(x => x.Codigo).Column("Codigo");
            Map(x => x.Nome).Column("Nome").Not.Nullable();
            Map(x => x.Sacolinha).Column("Sacolinha").Not.Nullable();
            Map(x => x.Consistente).Column("Consistente").Not.Nullable();
            Map(x => x.PermiteExcedenteCriancas).Column("PermiteExcedenteCriancas").Not.Nullable();
            Map(x => x.PermiteExcedenteRepresentantes).Column("PermiteExcedenteRepresentantes").Not.Nullable();
            Map(x => x.Contato).Column("Contato").Nullable();
            Map(x => x.DataAtualizacao).Column("DataAtualizacao").Nullable();
            Map(x => x.DataCriacao).Column("DataCriacao").Nullable();
            Map(x => x.BlackListPasso1).Column("BlackListPasso1").Not.Nullable();
            Map(x => x.BlackListPasso2).Column("BlackListPasso2").Not.Nullable();
            Map(x => x.Fake).Column("Fake").Not.Nullable();
            Map(x => x.PresencaJustificada).Column("PresencaJustificada").Not.Nullable();

            //References
            References(x => x.Nivel).Column("Nivel").Not.Nullable().Not.LazyLoad(); 
            References(x => x.Status).Column("Status").Not.Nullable().Not.LazyLoad();

            //HasMany
            HasMany(x => x.Criancas).KeyColumn("Familia").Inverse().Not.LazyLoad(); 
            HasMany(x => x.Presencas).KeyColumn("Familia").Inverse().Not.LazyLoad();
            HasMany(x => x.Representantes).KeyColumn("FamiliaRepresentante").Inverse().Not.LazyLoad(); 

        }
    }
}
