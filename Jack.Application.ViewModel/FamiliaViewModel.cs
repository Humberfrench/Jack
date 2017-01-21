using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Jack.Application.ViewModel
{
    public class FamiliaViewModel 
    {

        #region "Construtor"

        public FamiliaViewModel()
        {
            criancas = new List<CriancaViewModel>();
            sacolas = new List<SacolaViewModel>();
            presencas = new List<PresencaViewModel>();
            representantes = new List<RepresentanteViewModel>();
        }

        #endregion
        
        #region Fields

        private IList<CriancaViewModel> criancas;
        private IList<SacolaViewModel> sacolas;
        private IList<PresencaViewModel> presencas;
        private IList<RepresentanteViewModel> representantes;

        #endregion


        [Display(Name = "#")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Codigo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(50)]
        [DisplayFormat(NullDisplayText = "")]
        public virtual string Nome { get; set; }

        [Display(Name = "Sacolinha")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool Sacolinha { get; set; }

        [Display(Name = "Consistente")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool Consistente { get; set; }

        [Display(Name = "Permite Excedente Crianças")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool PermiteExcedenteCriancas { get; set; }

        [Display(Name = "Permite Excedente Representantes")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool PermiteExcedenteRepresentantes { get; set; }

        [Display(Name = "Familia Fake")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool Fake { get; set; }

        [Display(Name = "Contato")]
        [DisplayFormat(NullDisplayText = "")]
        [MaxLength(50)]
        public virtual string Contato { get; set; }

        [Display(Name = "Nível")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual NivelViewModel Nivel { get; set; }

        [Display(Name = "Presenca Justificada")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool PresencaJustificada { get; set; }

        [Display(Name = "Black List Passo 1")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool BlackListPasso1 { get; set; }

        [Display(Name = "Black List Passo 1 ")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual bool BlackListPasso2 { get; set; }

        [Display(Name = "Status")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual StatusFamiliaViewModel Status { get; set; }

        [Display(Name = "Crianças")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual IList<CriancaViewModel> Criancas
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

        [Display(Name = "Sacolas")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual IList<SacolaViewModel> Sacolas 
        {
            get
            {
                return sacolas;
            }
            set
            {
                sacolas = value;
            }
        }

        [Display(Name = "Data de Atualização")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual DateTime DataAtualizacao { get; set; }

        [Display(Name = "Data de Criação")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual DateTime DataCriacao { get; set; }

        [Display(Name = "Presenças")]
        [DisplayFormat(NullDisplayText = "")]
        public IList<PresencaViewModel> Presencas 
        {
            get
            {
                return presencas;
            }
            set
            {
                presencas = value;
            }
        }

        [Display(Name = "Representantes")]
        [DisplayFormat(NullDisplayText = "")]
        public IList<RepresentanteViewModel> Representantes
        {
            get
            {
                return representantes;
            }
            set
            {
                representantes = value;
            }
        }

        [Display(Name = "Crianças")]
        public int QuantidadeCriancas
        {
            get
            {
                return Criancas.ToList().Count;
            }
        }

        [Display(Name = "Presenças")]
        public int QuantidadePresencas
        {
            get
            {
                return Presencas.Where(p => p.Reuniao.AnoCorrente == DateTime.Now.Year).ToList().Count;
            }
        }

        [Display(Name = "Representantes")]
        public int QuantidadeFamiliasRepresentadas
        {
            get
            {
                return Representantes.ToList().Count;
            }
        }

    }
}
