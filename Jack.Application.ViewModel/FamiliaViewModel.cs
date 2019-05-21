using Newtonsoft.Json;
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
            tratamento = new List<TratamentoViewModel>();
        }

        #endregion

        #region Fields

        private IList<CriancaViewModel> criancas;
        private IList<SacolaViewModel> sacolas;
        private IList<PresencaViewModel> presencas;
        private IList<RepresentanteViewModel> representantes;
        private IList<TratamentoViewModel> tratamento;

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

        [Display(Name = "Endereço Família")]
        [DisplayFormat(NullDisplayText = "")]
        [MaxLength(50)]
        public virtual string EnderecoFamilia { get; set; }

        [Display(Name = "Bairro")]
        [DisplayFormat(NullDisplayText = "")]
        [MaxLength(30)]
        public virtual string Bairro { get; set; }

        [Display(Name = "Cidade")]
        [DisplayFormat(NullDisplayText = "")]
        [MaxLength(50)]
        public virtual string Cidade { get; set; }

        [Display(Name = "Estado")]
        [DisplayFormat(NullDisplayText = "")]
        [MaxLength(2)]
        public virtual string Estado { get; set; }

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

        [Display(Name = "Ativo")]
        [DisplayFormat(NullDisplayText = "")]
        public bool Ativo { get; set; }

        [JsonIgnore]
        [Display(Name = "Crianças")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual IList<CriancaViewModel> Criancas
        {
            get => criancas;
            set => criancas = value;
        }

        [JsonIgnore]
        [Display(Name = "Sacolas")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual IList<SacolaViewModel> Sacolas
        {
            get => sacolas;
            set => sacolas = value;
        }

        [Display(Name = "Data de Atualização")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual DateTime DataAtualizacao { get; set; }

        [Display(Name = "Data de Criação")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual DateTime DataCriacao { get; set; }

        [JsonIgnore]
        [Display(Name = "Presenças")]
        [DisplayFormat(NullDisplayText = "")]
        public IList<PresencaViewModel> Presencas
        {
            get => presencas;
            set => presencas = value;
        }
        [JsonIgnore]
        [Display(Name = "Tratamento")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual IList<TratamentoViewModel> Tratamento
        {
            get => tratamento;
            set => tratamento = value;
        }

        [JsonIgnore]
        [Display(Name = "Repr.")]
        [DisplayFormat(NullDisplayText = "")]
        public IList<RepresentanteViewModel> Representantes
        {
            get => representantes;
            set => representantes = value;
        }

        [Display(Name = "Crianças")]
        public int QuantidadeCriancas => Criancas.ToList().Count;

        [Display(Name = "Crianças")]
        public int QuantidadeCriancasAtivas => Criancas.Where(c => c.Status.PermiteSacola).ToList().Count;

        [Display(Name = "Presenças")]
        public int QuantidadePresencas
        {
            get
            {
                return Presencas.Where(p => p.Reuniao.AnoCorrente == DateTime.Now.Year).ToList().Count;
            }
        }

        [Display(Name = "Repr.")]
        public int QuantidadeFamiliasRepresentadas => Representantes.ToList().Count;
    }
}
