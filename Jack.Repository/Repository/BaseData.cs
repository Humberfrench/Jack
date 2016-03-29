using Consumer.Tools;
using System;
using System.Collections.Generic;

namespace Jack.Repository
{
    public abstract class BaseData<TypeClass, ID> : GenericDao<TypeClass, ID>, IGenericDao<TypeClass, ID>
    {


        private string strClassName;
        #region "Construtor"

        public BaseData()
        {
            strClassName =  GetType().ToString();
        }

        #endregion

        #region "Métodos do Log"


        protected void Log(Exception exData, string strMethod)
        {
            Erro.Tratar(exData, strMethod, strClassName);

        }

        #endregion

        #region "Métodos Básicos da Entidade"

        /// <summary>
        /// Método para inserir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Insert(TypeClass oTipo)
        {

            bool blnRetorno = false;

            try
            {
                blnRetorno = base.Insert(oTipo);
            }
            catch (Exception ex)
            {
                Log(ex, "Insert");
                blnRetorno = false;
                if (Util.Settings["ErroAmigavel"].ToLower() == "sim")
                {
                    throw new Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs");
                }
                else {
                    throw ex;
                }
            }

            return blnRetorno;

        }

        /// <summary>
        /// Método para atualizar o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Update(TypeClass oTipo)
        {

            bool blnRetorno = false;

            try
            {
                blnRetorno = base.Update(oTipo);
            }
            catch (Exception ex)
            {
                Log(ex, "Update");
                blnRetorno = false;
                if (Util.Settings["ErroAmigavel"].ToLower() == "sim")
                {
                    throw new Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs");
                }
                else {
                    throw ex;
                }
            }

            return blnRetorno;

        }

        /// <summary>
        /// Método para excluir o registro
        /// </summary>
        /// <param name="oTipo">Entidade com os dados Preenchidos</param>
        /// <returns>Boolean. Se a operação foi um sucesso, true.</returns>
        /// <remarks></remarks>
        public override bool Delete(TypeClass oTipo)
        {

            bool blnRetorno = false;

            try
            {
                blnRetorno = base.Delete(oTipo);
            }
            catch (Exception ex)
            {
                Log(ex, "Delete");
                blnRetorno = false;
                if (Util.Settings["ErroAmigavel"].ToLower() == "sim")
                {
                    throw new Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs");
                }
                else {
                    throw ex;
                }
            }

            return blnRetorno;

        }

        /// <summary>
        /// Método para procurar um registro
        /// </summary>
        /// <param name="Identifier">Código para a Procura do Valor</param>
        /// <returns>Entidade. Se a operação foi um sucesso, A Entidade Virá preenchida.</returns>
        /// <remarks></remarks>
        public override TypeClass Find(ID Identifier)
        {

            TypeClass objReturn = default(TypeClass);

            try
            {
                objReturn = base.Find(Identifier);
            }
            catch (Exception ex)
            {
                Log(ex, "Find");
                if (Util.Settings["ErroAmigavel"].ToLower() == "sim")
                {
                    throw new Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs");
                }
                else {
                    throw ex;
                }
            }

            return objReturn;

        }

        /// <summary>
        /// Método para carregar a lista dos registros
        /// </summary>
        /// <returns>Lista. Se a operação foi um sucesso, a lista virá carregada.</returns>
        /// <remarks></remarks>
        public override IList<TypeClass> LoadAll()
        {

            IList<TypeClass> objReturn = default(IList<TypeClass>);

            try
            {
                objReturn = base.LoadAll();
            }
            catch (Exception ex)
            {
                Log(ex, "LoadAll");
                objReturn = null;
                if (Util.Settings["ErroAmigavel"].ToLower() == "sim")
                {
                    throw new Exception("Ocorreu um Erro ao efetuar a operação. Favor Verificar os Logs");
                }
                else {
                    throw ex;
                }
            }

            return objReturn;

        }
        #endregion

    }
}
