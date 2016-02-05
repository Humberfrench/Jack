using FluentNHibernate.Mapping;
using System;


namespace Jack.Data.Map
{
    class MapColaborador : ClassMap<Model.Colaborador>
    {
        public MapColaborador()
        {
            //Table
            Table("tb_colaborador");

            //Fields
            Id(x => x.Codigo);
            Map(x => x.Nome).Column("ds_nome").Not.Nullable();
            Map(x => x.Telefone).Column("ds_fone").Nullable();
            Map(x => x.Celular).Column("ds_celular").Nullable();
            Map(x => x.EMail).Column("ds_email").Nullable();
            Map(x => x.AnoNotificacao).Column("nr_ano_notificacao").Nullable();
            Map(x => x.CPF).Column("nr_cpf").Nullable();

            //References

        }
    }
}
