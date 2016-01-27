using Consumer.Data.Basic.Data;
using System;
using System.Collections.Generic;
using System.Data;

namespace Jack.Data
{
    public class Representante
    {

        public Representante() : base()
        {
        }

        public List<Model.Familia> ObterMaes(int intFamilia)
        {

            Command oDados = null;
            List<Model.Familia> lstDados = null;
            Model.Familia objDados = null;
            DataTable dtDados = null;

            try
            {
                oDados = new Command("CECAMKey");
                dtDados = new DataTable();

                oDados.CommandText = "pr_list_maes_representadas";
                oDados.CommandType = CommandType.StoredProcedure;

                oDados.Parameters.Add(new Parameter("@id_familia", DbType.Int32, intFamilia));
                dtDados = oDados.GetDataTable();


                lstDados = new List<Model.Familia>();

                foreach (DataRow dr in dtDados.Rows)
                {
                    objDados = new Model.Familia();
                    objDados.Codigo = Convert.ToInt32(dr["id_familia"]);
                    objDados.NomeFamilia = dr["nm_mae"].ToString();
                    objDados.Contato = dr["ds_contato"].ToString();
                    objDados.IsConsistente = dr["is_consistente"].ToString();
                    objDados.IsSacolinha = dr["is_sacolinha"].ToString();
                    objDados.Nivel = Convert.ToInt32(dr["nr_nivel_espera"]);
                    objDados.Status = new Model.Status(Convert.ToInt32(dr["id_status"]),dr["ds_status"].ToString());
                    lstDados.Add(objDados);
                }
            }
            catch (Exception ex)
            {
                lstDados = null;
                throw ex;
            }
            finally
            {
                objDados = null;
                dtDados = null;
                oDados.Dispose();
                oDados = null;
            }

            return lstDados;

        }

        public bool Add(int intFamilaRepresentante, int intFamilaRepresentada)
        {

            Command oCommand = null;
            IList<Model.Familia> lstRetorno = null;
            bool oRetorno = false;
            try
            {
                lstRetorno = new List<Model.Familia>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_add_representante";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@intFamilaRepresentante", System.Data.DbType.Int32, 75, intFamilaRepresentante));
                oCommand.Parameters.Add(new Parameter("@intFamilaRepresentada", System.Data.DbType.Int32, 75, intFamilaRepresentada));
                oCommand.ExecuteNonQuery();
                oRetorno = true;
            }
            catch (Exception ex)
            {
                oRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return oRetorno;


        }
        public bool Del(int intFamilaRepresentante, int intFamilaRepresentada)
        {

            Command oCommand = null;
            IList<Model.Familia> lstRetorno = null;
            bool oRetorno = false;
            try
            {
                lstRetorno = new List<Model.Familia>();
                oCommand = new Command("CECAMKey");
                oCommand.CommandText = "pr_del_representante";
                oCommand.CommandType = System.Data.CommandType.StoredProcedure;
                oCommand.Parameters.Add(new Parameter("@intFamilaRepresentante", System.Data.DbType.Int32, 75, intFamilaRepresentante));
                oCommand.Parameters.Add(new Parameter("@intFamilaRepresentada", System.Data.DbType.Int32, 75, intFamilaRepresentada));
                oCommand.ExecuteNonQuery();
                oRetorno = true;
            }
            catch (Exception ex)
            {
                oRetorno = false;
                throw ex;
            }
            finally
            {
                oCommand.Dispose();
                oCommand = null;
            }
            return oRetorno;


        }
    }
}
