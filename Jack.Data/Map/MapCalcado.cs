using FluentNHibernate.Mapping;
using System;

namespace Jack.Data.Map
{
    class MapCalcado : ClassMap<Model.Calcado>
    {
        public MapCalcado()
        {
            try
            {
                //Table
                Table("tb_calcado");

                //Fields
                Id(x => x.Codigo).Column("id_calcado");
                Map(x => x.Numero).Column("nr_calcado").Not.Nullable();
                Map(x => x.Sexo).Column("ds_sexo").Not.Nullable();
                Map(x => x.NumeroInicio).Column("nr_inicio").Not.Nullable();
                Map(x => x.NumeroFim).Column("nr_fim").Not.Nullable();
                Map(x => x.MedidaIdade).Column("ds_medida_idade").Nullable();

                //References
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}

