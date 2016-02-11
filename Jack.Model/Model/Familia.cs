using System;
using System.Collections.Generic;

namespace Jack.Model
{
    [Serializable()]
    public class Familia
    {

        #region "Construtor"

        public Familia()
        {
            codigo = 0;
            nome = string.Empty;
            isSacolinha = string.Empty;
            isConsistente = string.Empty;
            contato = string.Empty;
            nivel = 99;
            status = new Status();
            reunioes = new List<FamiliaPresenca>();
            criancas = new List<FamiliaCrianca>();
        }

    #endregion

    #region Fields
    private int codigo ;
        private string nome ;
        private string isSacolinha ;
        private string isConsistente ;
        private string contato ;
        private int nivel ;
        private Status status ;
        private List<FamiliaPresenca> reunioes ;
        private List<FamiliaCrianca> criancas ;
        private DateTime dataAtualizacao;

        #endregion

    #region Properties

    public virtual int Codigo
    {
        get
        {
            return codigo;
        }
        set
        {
            codigo = value;
        }
    }

    public virtual string Nome
    {
        get
        {
            return nome;
        }
        set
        {
            nome = value;
        }
    }

    public virtual string IsSacolinha
    {
        get
        {
            return isSacolinha;
        }
        set
        {
            isSacolinha = value;
        }
    }

    public virtual string IsConsistente
    {
        get
        {
            return isConsistente;
        }
        set
        {
            isConsistente = value;
        }
    }

    public virtual string Contato
    {
        get
        {
            return contato;
        }
        set
        {
            contato = value;
        }
    }

    public virtual int Nivel
    {
        get
        {
            return nivel;
        }
        set
        {
            nivel = value;
        }
    }

    public virtual Status Status
    {
        get
        {
            return status;
        }
        set
        {
            status = value;
        }
    }

    public virtual List<FamiliaPresenca> Reunioes
    {
        get
        {
            return reunioes;
        }
        set
        {
            reunioes = value;
        }
    }

    public virtual List<FamiliaCrianca> Criancas
    {
        get
        {
            return criancas;
        }
        set
        {
            criancas = value;
        }
    }

    public virtual DateTime DataAtualizacao
    {
        get
        {
            return dataAtualizacao;
        }
        set
        {
            dataAtualizacao = value;
        }
    }

    public virtual int StatusCodigo
    {
        get { return Status.Codigo; }
    }

    public virtual string StatusNome
    {
        get { return Status.Descricao; }
    }

    public virtual string DataAtualizacaoString
    {
        get { return DataAtualizacao.ToShortDateString(); }
    }

    public virtual string DataFormated
    {
        get { return DataAtualizacao.Day.ToString("00") + "/" + DataAtualizacao.Month.ToString("00") + "/" + DataAtualizacao.Year.ToString("0000"); }
    }

    public virtual string Sacolinha
    {
        get
        {
            if (IsSacolinha == "S")
            {
                return "Sim";
            }
            else {
                return "Não";
            }
        }
    }

    public virtual string Consistente
    {
        get
        {
            if (IsConsistente == "S")
            {
                return "Sim";
            }
            else {
                return "Não";
            }
        }
    }

    #endregion

    }
}
