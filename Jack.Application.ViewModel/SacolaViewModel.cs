
using System.ComponentModel.DataAnnotations;

namespace Jack.Application.ViewModel
{
    public class SacolaViewModel
    {


        [Display(Name = "Sac.Id")]
        [DisplayFormat(NullDisplayText = "")]
        public virtual int Id { get; set; }
        
        [Display(Name = "Sac.Num.")]
        [DisplayFormat(NullDisplayText = "")]
        public int Codigo { get; set; }

        [Display(Name = "Sac.Fam.")]
        [DisplayFormat(NullDisplayText = "")]
        public int SacolaFamilia { get; set; }

        [Display(Name = "Familia")]
        [DisplayFormat(NullDisplayText = "")]
        public FamiliaViewModel Familia { get; set; }

        [Display(Name = "Familia Repr.")]
        [DisplayFormat(NullDisplayText = "")]
        public FamiliaViewModel FamiliaRepresentante { get; set; }

        [Display(Name = "Crianca")]
        [DisplayFormat(NullDisplayText = "")]
        public CriancaViewModel Crianca { get; set; }

        [Display(Name = "Sexo")]
        [DisplayFormat(NullDisplayText = "")]
        public string Sexo { get; set; }

        [Display(Name = "Kit")]
        [DisplayFormat(NullDisplayText = "")]
        public KitViewModel Kit { get; set; }

        [Display(Name = "Nivel")]
        [DisplayFormat(NullDisplayText = "")]
        public NivelViewModel Nivel { get; set; }

        [Display(Name = "Impressa")]
        [DisplayFormat(NullDisplayText = "")]
        public bool Impressa { get; set; }

        [Display(Name = "QrCode")]
        [DisplayFormat(NullDisplayText = "")]
        public byte[] QrCode { get; set; }

        [Display(Name = "Liberado")]
        [DisplayFormat(NullDisplayText = "")]
        public bool Liberado { get; set; }

    }
}