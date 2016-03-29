using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jack.Repository
{
    public class Sacolas
    {

        /// <summary>
        /// Processa as Sacolas
        /// </summary>
        /// <param name="intAno"></param>
        /// <returns>Lista de Pessoas</returns>
        /// <remarks>Este é um processo Simples e Poderá ser usado para consistir as presenças e Sacolas</remarks>
        public IList<Model.Sacolas> ProcessaSacolas(int intAno)
        {

            Command oCommand = null;
            IList<Model.Sacolas> lstRetorno = null;
            DataTable dtDados = null;
            Model.Sacolas oRetorno = null;
            try
            {
                lstRetorno = new List<Model.Sacolas>();

                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_gerar_sacolinhas";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@nr_ano", System.Data.DbType.Int32, 75, intAno));
                dtDados = oCommand.GetDataTable();

                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.Sacolas();
                    oRetorno.NumeroSacola = Convert.ToInt32(dr["id_sacolinha"].ToString());
                    oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr["nr_sacola_familia"].ToString());
                    oRetorno.CodigoFamilia = Convert.ToInt32(dr["id_familia"].ToString());
                    oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr["id_familia_rep"].ToString());
                    oRetorno.CodigoCrianca = Convert.ToInt32(dr["id_crianca"].ToString());
                    oRetorno.NomeMae = dr["nm_mae"].ToString();
                    oRetorno.NomeMaeRep = dr["nm_mae_rep"].ToString();
                    oRetorno.NomeCrianca = dr["nm_crianca"].ToString();
                    oRetorno.Idade = Convert.ToInt32(dr["nr_idade"].ToString());
                    oRetorno.MedidaIdade = dr["ds_medida_idade"].ToString();
                    oRetorno.NumeroNivel = Convert.ToInt32(dr["nr_nivel"].ToString());
                    oRetorno.CodigoKit = Convert.ToInt32(dr["id_kit"].ToString());
                    oRetorno.CodigoStatus = Convert.ToInt32(dr["id_status"].ToString());
                    oRetorno.DescricaoKit = dr["ds_kit"].ToString();
                    oRetorno.DescricaoStatus = dr["ds_status"].ToString();
                    oRetorno.Sexo = dr["ds_sexo"].ToString();
                    oRetorno.Impresso = dr["is_printed"].ToString();
                    lstRetorno.Add(oRetorno);
                }
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
                oRetorno = null;
                dtDados = null;
            }
            return lstRetorno;

        }

        public IList<Model.Sacolas> ObterSacolas(int intKit, int intNivel, string isPrinted)
        {


            Command oCommand = null;
            IList<Model.Sacolas> lstRetorno = null;
            DataTable dtDados = null;
            Model.Sacolas oRetorno = null;
            try
            {
                lstRetorno = new List<Model.Sacolas>();

                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_print_sacolas";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //[pr_print_sacolas] (@ds_sexo varchar(1), @id_kit int, @nr_nivel int, @is_printed varchar(1))

                oCommand.Parameters.Add(new Parameter("@id_kit", System.Data.DbType.Int32, intKit));
                oCommand.Parameters.Add(new Parameter("@nr_nivel", System.Data.DbType.Int32, intNivel));
                oCommand.Parameters.Add(new Parameter("@is_printed", System.Data.DbType.String, 1, isPrinted));
                dtDados = oCommand.GetDataTable();

                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.Sacolas();
                    oRetorno.NumeroSacola = Convert.ToInt32(dr["id_sacolinha"].ToString());
                    oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr["nr_sacola_familia"].ToString());
                    oRetorno.CodigoFamilia = Convert.ToInt32(dr["id_familia"].ToString());
                    oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr["id_familia_rep"].ToString());
                    oRetorno.CodigoCrianca = Convert.ToInt32(dr["id_crianca"].ToString());
                    oRetorno.NomeMae = dr["nm_mae"].ToString();
                    oRetorno.NomeMaeRep = dr["nm_mae_rep"].ToString();
                    oRetorno.NomeCrianca = dr["nm_crianca"].ToString();
                    oRetorno.Idade = Convert.ToInt32(dr["nr_idade"].ToString());
                    oRetorno.MedidaIdade = dr["ds_medida_idade"].ToString();
                    oRetorno.NumeroNivel = Convert.ToInt32(dr["nr_nivel"].ToString());
                    oRetorno.CodigoKit = Convert.ToInt32(dr["id_kit"].ToString());
                    oRetorno.CodigoStatus = Convert.ToInt32(dr["id_status"].ToString());
                    oRetorno.DescricaoKit = dr["ds_kit"].ToString();
                    oRetorno.DescricaoStatus = dr["ds_status"].ToString();
                    oRetorno.Sexo = dr["ds_sexo"].ToString();
                    oRetorno.Impresso = dr["is_printed"].ToString();
                    lstRetorno.Add(oRetorno);
                }
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
                oRetorno = null;
                dtDados = null;
            }
            return lstRetorno;

        }

        public IList<Model.Sacolas> ObterSacolasLivres(int intKit, int intNivel, string isPrinted)
        {


            Command oCommand = null;
            IList<Model.Sacolas> lstRetorno = null;
            DataTable dtDados = null;
            Model.Sacolas oRetorno = null;
            try
            {
                lstRetorno = new List<Model.Sacolas>();

                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_print_sacolas_livres";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                //[pr_print_sacolas] (@ds_sexo varchar(1), @id_kit int, @nr_nivel int, @is_printed varchar(1))

                oCommand.Parameters.Add(new Parameter("@id_kit", System.Data.DbType.Int32, intKit));
                oCommand.Parameters.Add(new Parameter("@nr_nivel", System.Data.DbType.Int32, intNivel));
                oCommand.Parameters.Add(new Parameter("@is_printed", System.Data.DbType.String, 1, isPrinted));
                dtDados = oCommand.GetDataTable();

                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.Sacolas();
                    oRetorno.NumeroSacola = Convert.ToInt32(dr["id_sacolinha"].ToString());
                    oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr["nr_sacola_familia"].ToString());
                    oRetorno.CodigoFamilia = Convert.ToInt32(dr["id_familia"].ToString());
                    oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr["id_familia_rep"].ToString());
                    oRetorno.CodigoCrianca = Convert.ToInt32(dr["id_crianca"].ToString());
                    oRetorno.NomeMae = dr["nm_mae"].ToString();
                    oRetorno.NomeMaeRep = dr["nm_mae_rep"].ToString();
                    oRetorno.NomeCrianca = dr["nm_crianca"].ToString();
                    oRetorno.Idade = Convert.ToInt32(dr["nr_idade"].ToString());
                    oRetorno.MedidaIdade = dr["ds_medida_idade"].ToString();
                    oRetorno.NumeroNivel = Convert.ToInt32(dr["nr_nivel"].ToString());
                    oRetorno.CodigoKit = Convert.ToInt32(dr["id_kit"].ToString());
                    oRetorno.CodigoStatus = Convert.ToInt32(dr["id_status"].ToString());
                    oRetorno.DescricaoKit = dr["ds_kit"].ToString();
                    oRetorno.DescricaoStatus = dr["ds_status"].ToString();
                    oRetorno.Sexo = dr["ds_sexo"].ToString();
                    oRetorno.Impresso = dr["is_printed"].ToString();
                    lstRetorno.Add(oRetorno);
                }
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
                oRetorno = null;
                dtDados = null;
            }
            return lstRetorno;

        }

        public IList<Model.Sacolas> ObterSacolas()
        {


            Command oCommand = null;
            IList<Model.Sacolas> lstRetorno = null;
            DataTable dtDados = null;
            Model.Sacolas oRetorno = null;
            try
            {
                lstRetorno = new List<Model.Sacolas>();

                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_print_sacolas_todas";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                dtDados = oCommand.GetDataTable();

                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.Sacolas();
                    oRetorno.NumeroSacola = Convert.ToInt32(dr["id_sacolinha"].ToString());
                    oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr["nr_sacola_familia"].ToString());
                    oRetorno.CodigoFamilia = Convert.ToInt32(dr["id_familia"].ToString());
                    oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr["id_familia_rep"].ToString());
                    oRetorno.CodigoCrianca = Convert.ToInt32(dr["id_crianca"].ToString());
                    oRetorno.NomeMae = dr["nm_mae"].ToString();
                    oRetorno.NomeMaeRep = dr["nm_mae_rep"].ToString();
                    oRetorno.NomeCrianca = dr["nm_crianca"].ToString();
                    oRetorno.Idade = Convert.ToInt32(dr["nr_idade"].ToString());
                    oRetorno.MedidaIdade = dr["ds_medida_idade"].ToString();
                    oRetorno.NumeroNivel = Convert.ToInt32(dr["nr_nivel"].ToString());
                    oRetorno.CodigoKit = Convert.ToInt32(dr["id_kit"].ToString());
                    oRetorno.CodigoStatus = Convert.ToInt32(dr["id_status"].ToString());
                    oRetorno.DescricaoKit = dr["ds_kit"].ToString();
                    oRetorno.DescricaoStatus = dr["ds_status"].ToString();
                    oRetorno.Sexo = dr["ds_sexo"].ToString();
                    oRetorno.Impresso = dr["is_printed"].ToString();
                    lstRetorno.Add(oRetorno);
                }
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
                oRetorno = null;
                dtDados = null;
            }
            return lstRetorno;

        }

        public IList<Model.Sacolas> ObterSacolas(string strListSacolasIn)
        {


            Command oCommand = null;
            IList<Model.Sacolas> lstRetorno = null;
            DataTable dtDados = null;
            Model.Sacolas oRetorno = null;
            try
            {
                lstRetorno = new List<Model.Sacolas>();

                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_print_sacolas_execute";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@list_sacolas", System.Data.DbType.String, strListSacolasIn));
                dtDados = oCommand.GetDataTable();

                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.Sacolas();
                    oRetorno.NumeroSacola = Convert.ToInt32(dr["id_sacolinha"].ToString());
                    oRetorno.NumeroSacolaFamilia = Convert.ToInt32(dr["nr_sacola_familia"].ToString());
                    oRetorno.CodigoFamilia = Convert.ToInt32(dr["id_familia"].ToString());
                    oRetorno.CodigoFamiliaRep = Convert.ToInt32(dr["id_familia_rep"].ToString());
                    oRetorno.CodigoCrianca = Convert.ToInt32(dr["id_crianca"].ToString());
                    oRetorno.Idade = Convert.ToInt32(dr["nr_idade"].ToString());
                    oRetorno.MedidaIdade = dr["ds_medida_idade"].ToString();
                    oRetorno.NomeCrianca = dr["nm_crianca"].ToString();
                    oRetorno.NomeMae = dr["nm_mae"].ToString();
                    oRetorno.NomeMaeRep = dr["nm_mae_rep"].ToString();
                    oRetorno.NumeroNivel = Convert.ToInt32(dr["nr_nivel"].ToString());
                    oRetorno.CodigoKit = Convert.ToInt32(dr["id_kit"].ToString());
                    oRetorno.CodigoStatus = Convert.ToInt32(dr["id_status"].ToString());
                    oRetorno.DescricaoKit = dr["ds_kit"].ToString();
                    oRetorno.DescricaoStatus = dr["ds_status"].ToString();
                    oRetorno.Sexo = dr["ds_sexo"].ToString();
                    oRetorno.Impresso = dr["is_printed"].ToString();
                    oRetorno.Calcado = Convert.ToInt32(dr["nr_calcado"].ToString());
                    oRetorno.Roupa = dr["nr_roupa"].ToString();
                    lstRetorno.Add(oRetorno);
                }
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
                oRetorno = null;
                dtDados = null;
            }
            return lstRetorno;

        }

        public IList<Model.KitSacola> ObterKitSacolas(int intKit)
        {

            Command oCommand = null;
            IList<Model.KitSacola> lstRetorno = null;
            DataTable dtDados = null;
            Model.KitSacola oRetorno = null;
            try
            {
                lstRetorno = new List<Model.KitSacola>();

                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_mostrar_itens_kit";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_kit", System.Data.DbType.Int16, intKit));
                dtDados = oCommand.GetDataTable();

                foreach (DataRow dr in dtDados.Rows)
                {
                    oRetorno = new Model.KitSacola();
                    oRetorno.Ordem = dr["nr_ordem"].ToString();
                    oRetorno.MsgOpcional = dr["msg_opcional"].ToString();
                    oRetorno.KitItem = dr["ds_tipo_item"].ToString();
                    oRetorno.NomeKit = dr["ds_kit"].ToString();
                    oRetorno.Sexo = dr["ds_sexo"].ToString();
                    lstRetorno.Add(oRetorno);
                }
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
                oRetorno = null;
                dtDados = null;
            }
            return lstRetorno;

        }


        public void GravarLogSacolas(int intSacola)
        {
            Command oCommand = null;

            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_update_print";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_sacola", System.Data.DbType.Int16, intSacola));
                oCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }

        }

        public bool AddSacolaCrianca(int intCrianca)
        {

            Command oCommand = null;
            bool blnRetorno = false;


            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_add_crianca_sacola";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_crianca", System.Data.DbType.Int16, intCrianca));
                oCommand.ExecuteNonQuery();
                blnRetorno = true;

            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return blnRetorno;

        }

        public bool AddSacolaColaboradorCrianca(int intCrianca, int intColaborador, int intAno, bool isDevolvida)
        {

            Command oCommand = null;
            bool blnRetorno = false;


            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_add_sacola_colaborador_crianca";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_crianca", System.Data.DbType.Int16, intCrianca));
                oCommand.Parameters.Add(new Parameter("@id_colaborador", System.Data.DbType.Int16, intColaborador));
                oCommand.Parameters.Add(new Parameter("@int_ano", System.Data.DbType.Int16, intAno));
                oCommand.Parameters.Add(new Parameter("@is_devolvida", System.Data.DbType.String, 1, isDevolvida));
                oCommand.ExecuteNonQuery();
                blnRetorno = true;

            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return blnRetorno;

        }


        public bool AddSacolaColaboradorSacola(int intSacola, int intColaborador, int intAno, bool isDevolvida)
        {

            Command oCommand = null;
            bool blnRetorno = false;


            try
            {
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_add_sacola_colaborador_sacola";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@id_sacola", System.Data.DbType.Int16, intSacola));
                oCommand.Parameters.Add(new Parameter("@id_colaborador", System.Data.DbType.Int16, intColaborador));
                oCommand.Parameters.Add(new Parameter("@int_ano", System.Data.DbType.Int16, intAno));
                oCommand.Parameters.Add(new Parameter("@is_devolvida", System.Data.DbType.String, 1, isDevolvida));
                oCommand.ExecuteNonQuery();
                blnRetorno = true;

            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return blnRetorno;

        }

    }
}
