﻿using FluentNHibernate.Mapping;
using System;


namespace Jack.Repository.Map
{
    class MapKit : ClassMap<Model.Kit>
    {
        public MapKit()
        {
            try
            {
                //Table
                Table("tb_kit");

                //Fields
                Id(x => x.Codigo).Column("id_kit");
                Map(x => x.Descricao).Column("ds_kit").Not.Nullable();
                Map(x => x.IdadeMinima).Column("vl_idade_min").Not.Nullable();
                Map(x => x.IdadeMaxima).Column("vl_idade_max").Not.Nullable();
                Map(x => x.Sexo).Column("ds_sexo").Not.Nullable();
                Map(x => x.IsNecessidadeEspecial).Column("is_necessidade_especial").Nullable();

                //References

                //HasMany
                HasMany(x => x.Items).KeyColumn("id_kit");
                //HasMany
                HasMany(x => x.Criancas).KeyColumn("id_kit");
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}