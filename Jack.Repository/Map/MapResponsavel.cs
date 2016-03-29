using FluentNHibernate.Mapping;
using System;

namespace Jack.Repository.Map
{
    class MapResponsavel: ClassMap<Model.Responsavel>
    {
        public MapResponsavel()
        {
            try
            {
                //Table
                Table("tb_responsavel");

                //Fields
                Id(x => x.Codigo).Column("id_responsavel");
                Map(x => x.Responsavel1).Column("ds_nome_resp1").Not.Nullable();
                Map(x => x.Responsavel2).Column("ds_nome_resp2").Nullable();
                Map(x => x.Documento).Column("nr_doc_resp").Not.Nullable();
                Map(x => x.Endereco).Column("ds_endereco").Nullable();
                Map(x => x.Bairro).Column("ds_bairro").Not.Nullable();
                Map(x => x.Cep).Column("nr_cep").Nullable();
                Map(x => x.Cidade).Column("ds_cidade").Nullable();
                Map(x => x.Uf).Column("ds_uf").Not.Nullable();
                Map(x => x.Telefone).Column("nr_telefone").Not.Nullable();
                Map(x => x.Celular1).Column("nr_celular1").Not.Nullable();
                Map(x => x.Celular2).Column("nr_celular1").Not.Nullable();

                //Hasmany
                HasManyToMany(x => x.Criancas).Table("tb_responsavel_crianca")
                                             .ParentKeyColumn("id_responsavel")
                                             .ChildKeyColumn("id_crianca");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
