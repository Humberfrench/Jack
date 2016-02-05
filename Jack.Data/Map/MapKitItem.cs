using FluentNHibernate.Mapping;
using System;


namespace Jack.Data.Map
{
    class MapKitItem : ClassMap<Model.KitItem>
    {
        public MapKitItem()
        {
            //Table
            Table("tb_kit_item");

            //Fields
            Id(x => x.Codigo);
            Map(x => x.Numero).Column("nr_calcado").Not.Nullable();
            Map(x => x.Sexo).Column("ds_sexo").Not.Nullable();
            Map(x => x.NumeroInicio).Column("nr_inicio").Not.Nullable();
            Map(x => x.NumeroFim).Column("nr_fim").Not.Nullable();
            Map(x => x.MedidaIdade).Column("ds_medida_idade").Nullable();

            //References

        }
    }
}
  //<class name="KitItem" table="tb_kit_item">
  //  <id name = "Codigo" column="id_kit_item">
  //    <generator class="native"/>
  //  </id>
  //  <property column = "id_kit" name="Kit" not-null="true"/>
  //  <property column = "id_tipo_item" name="TipoItem" not-null="true"/>
  //  <property column = "ds_observacao" name="Observacao" not-null="false"/>
  //  <property column = "nr_ordem" name="Ordem" not-null="true"/>

  //</class>