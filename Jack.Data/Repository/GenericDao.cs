using NHibernate;
using System;
using System.Collections.Generic;

namespace Jack.Data
{
    public class GenericDao<Tipo, ID> : IGenericDao<Tipo, ID>, IDisposable
    {

        public ISession oSession;
        private ITransaction oTransaction;
        private bool blnHasTransaction;
        //Private oNhTemplate As 

        /// <summary>
        /// Construtor, obtém a sessão do NHibernateHelper e inicia a transação.
        /// </summary>
        public GenericDao(bool blnWithTransaction = false)
        {
            try
            {
                Type tipoEntidade = typeof(Tipo);
                oSession = NHibernateHelper.GetCurrentSession(tipoEntidade.Assembly);
                oSession.GetSessionImplementation().PersistenceContext.Unproxy(tipoEntidade.Assembly);
                blnHasTransaction = blnWithTransaction;
                if (blnWithTransaction)
                {
                    oTransaction = oSession.BeginTransaction();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Persiste um novo objeto.
        /// </summary>
        /// <param name="Obj">Objeto a ser persistido</param>
        /// <returns>True para sucesso, False para erro.</returns>
        public virtual bool Insert(Tipo Obj)
        {
            object oRetorno = null;
            try
            {
                oRetorno = oSession.Save(Obj);
                Finish();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Atualiza um objeto existente.
        /// </summary>
        /// <param name="Obj">Objeto a ser atualizado</param>
        /// <returns>True para sucesso, False para erro.</returns>
        public virtual bool Update(Tipo Obj)
        {
            try
            {
                oSession.Update(Obj);
                Finish();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Exclui um objeto existente.
        /// </summary>
        /// <param name="Obj">Objeto a ser atualizado</param>
        /// <returns>True para sucesso, False para erro.</returns>
        public virtual bool Delete(Tipo Obj)
        {
            try
            {
                oSession.Delete(Obj);
                Finish();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        /// <summary>
        /// Recupera um objeto persistido na base de dados.
        /// </summary>
        /// <param name="Identifier">Chave primária do objeto</param>
        /// <returns>Objeto</returns>
        public virtual Tipo Find(ID Identifier)
        {
            Tipo oTipo = default(Tipo);

            try
            {
                //oTipo = (Tipo)oSession.Load(typeof(Tipo), Identifier);
                oTipo = oSession.Get<Tipo>(Identifier);
                return oTipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Retorna todos os objetos persistidos na base de dados.
        /// </summary>
        /// <returns>Coleção de objetos</returns>
        public virtual IList<Tipo> LoadAll()
        {
            IList<Tipo> lTipo = default(IList<Tipo>);
            try
            {
                //Prepare()
                lTipo = oSession.CreateCriteria(typeof(Tipo)).List<Tipo>();
                return lTipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Confirma a transação corrente (commit)
        /// </summary>
        protected virtual void Commit()
        {
            oTransaction.Commit();
        }

        /// <summary>
        /// Desfaz a transação corrente (rollback)
        /// </summary>
        protected virtual void BeginTransaction()
        {
            oTransaction = oSession.BeginTransaction();
        }

        /// <summary>
        /// Begin Trans
        /// </summary>
        /// <remarks></remarks>
        protected virtual void Rollback()
        {
            oTransaction.Rollback();
        }

        /// <summary>
        /// Reinicia a Sessão
        /// </summary>
        /// <remarks></remarks>
        protected virtual void Finish()
        {
            oSession.Flush();
            oSession.Clear();
        }

        /// <summary>
        /// Verifica se há ou não transação
        /// </summary>
        /// <value>Boolean</value>
        /// <returns>Boolean</returns>
        /// <remarks></remarks>
        public bool HasTransaction
        {
            get { return blnHasTransaction; }
            set { blnHasTransaction = value; }
        }

        /// <summary>
        /// Retorna dados através de uma query
        /// </summary>
        /// <param name="strQuery">Query</param>
        /// <param name="strValue">Valor a Filtrar</param>
        /// <param name="strParName">Nome do Parametro</param>
        /// <returns>Lista Tipada</returns>
        /// <remarks></remarks>
        public IList<Tipo> LoadByQuery(string strQuery, string strParName, string strValue)
        {

            IList<Tipo> oReturn = default(IList<Tipo>);
            NHibernate.IQuery oQuery = default(NHibernate.IQuery);

            try
            {
                oQuery = oSession.CreateQuery(strQuery).SetString(strParName, strValue);
                oReturn = oQuery.List<Tipo>();

            }
            catch (Exception ex)
            {
                oReturn = null;
                throw ex;
            }

            return oReturn;

        }


        #region "other Methods"

        //public virtual List<Tipo> LoadByQuery(string hsqlQuery, object[] values)
        //{

        //    List<Tipo> listReturn = new List<Tipo>();
        //    IList oArray = null;

        //    oArray = this.Find(hsqlQuery, values) as IList;
        //    listReturn = new List<Tipo>();
        //    foreach (Tipo oData in oArray)
        //    {
        //        listReturn.Add(oData);
        //    }

        //    return listReturn;
        //}

        //public virtual List<Tipo> LoadByQuery(string hsqlQuery)
        //{

        //    List<Tipo> listReturn = new List<Tipo>();
        //    IList oArray = null;

        //    oArray = this.Find(hsqlQuery) as IList;
        //    listReturn = new List<Tipo>();
        //    foreach (Tipo oData in oArray)
        //    {
        //        listReturn.Add(oData);
        //    }

        //    return listReturn;
        //}
        #endregion

        #region " IDisposable Support "

        // To detect redundant calls
        private bool disposedValue = false;

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    if (oSession.Transaction.IsActive)
                    {
                        oSession.Transaction.Commit();
                    }
                    oTransaction.Dispose();
                    oSession.Close();
                    oSession.Dispose();
                }
                // TODO: free shared unmanaged resources
            }
            this.disposedValue = true;
        }

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}
