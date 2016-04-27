using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Jack.Library.Extensions;

namespace Jack.DTO
{
    public class DTOReuniao
    {
        public DTOReuniao()
        {
            ano = 0;
            anoCorrente = 0;
            data = DateTime.Now;
            dataReuniao = data.ToDateFormated();
        }
        private int codigo;
        private int ano;
        private int anoCorrente;
        string dataReuniao;
        private DateTime data;

        [Description("Código")]
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

        [Required(ErrorMessage = "Preencher o Ano")]
        [Description("Ano")]
        public virtual int Ano
        {
            get
            {
                return ano;
            }
            set
            {
                ano = value;
            }
        }

        [Description("Ano Corrente")]
        [Required( ErrorMessage = "Preencher o Ano Corrente")]
        public virtual int AnoCorrente
        {
            get
            {
                return anoCorrente;
            }
            set
            {
                anoCorrente = value;
            }
        }

        [Description("Data da Reunião")]
        [Required(ErrorMessage = "Preencher a Data da Reuniao")]
        public virtual DateTime Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
                dataReuniao = data.ToDateFormated();
            }
        }

        [Description("Data da Reunião")]
        [ScaffoldColumn(false)]
        public virtual string DataReuniao
        {
            get
            {
                return dataReuniao;
            }
        }
    }
}