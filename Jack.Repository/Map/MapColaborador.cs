using FluentNHibernate.Mapping;
using System;

namespace Jack.Repository.Map
{
    class MapColaborador : ClassMap<Model.Colaborador>
    {
        public MapColaborador()
        {
            try
            {
                //Table
                Table("tb_colaborador");

                //Fields
                Id(x => x.Codigo).Column("id_colaborador");
                Map(x => x.Nome).Column("ds_nome").Not.Nullable();
                Map(x => x.Telefone).Column("ds_fone").Nullable();
                Map(x => x.Celular).Column("ds_celular").Nullable();
                Map(x => x.Email).Column("ds_email").Nullable();
                Map(x => x.AnoNotificacao).Column("nr_ano_notificacao").Nullable();
                Map(x => x.Cpf).Column("nr_cpf").Nullable();

                //References


                //Hasmany
                HasMany(x => x.Criancas).Cascade.AllDeleteOrphan()
                                       .Fetch.Join()
                                       .Inverse().KeyColumn("id_colaborador");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
