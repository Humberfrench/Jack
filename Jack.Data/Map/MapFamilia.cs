using FluentNHibernate.Mapping;

namespace Jack.Data.Map
{
    class MapFamilia: ClassMap<Model.Familia>
    {
        public MapFamilia()
        {
            //Table
            Table("tb_familia");

            //Fields
            Id(x => x.Codigo);
            Map(x => x.Descricao).Column("ds_status").Not.Nullable();
            Map(x => x.Descricao).Column("is_permite_sacola").Not.Nullable();
            Map(x => x.Descricao).Column("ds_nivel_status").Not.Nullable();

            //References

        }
    }
}
	<class name="Familia" table="tb_familia">
		<id name = "Codigo" column="id_familia">
			<generator class="native"/>
		</id>
		<property column = "nm_mae" name="Nome" not-null="false" />
        <property column = "nr_nivel_espera" name="Nivel" not-null="false" />
        <property column = "is_sacolinha" name="IsSacolinha" not-null="false" />
        <property column = "is_consistente" name="IsConsistente" not-null="false" />
        <many-to-one name = "Status" column="id_status" class="Status" not-null="true" />    
        <property column = "ds_contato" name="Contato" not-null="false"/>
        <property column = "dt_update" name="DataAtualizacao" not-null="false"/>
 </class>
