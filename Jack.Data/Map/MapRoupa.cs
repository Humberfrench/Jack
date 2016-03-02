using FluentNHibernate.Mapping;
using System;


namespace Jack.Data.Map 
{
    class MapRoupa : ClassMap<Model.Roupa>
    {
        public MapRoupa()
        {
            try
            {
                //Table
                Table("tb_roupa");

                //Fields
                Id(x => x.Codigo).Column("id_roupa");
                Map(x => x.Tamanho).Column("ds_tamanho").Not.Nullable();
                Map(x => x.Idade).Column("nr_idade").Not.Nullable();
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
