using System;

namespace Jack.Model
{
    [Serializable()]
    public class FamiliaPresenca
    {


        public FamiliaPresenca()
        {
            Nivel = 0;
            Familia = string.Empty;
            Data = new DateTime();

        }



        public FamiliaPresenca(string strFamilia, int intNivel, DateTime DataReuniao)
        {
            Nivel = intNivel;
            Familia = strFamilia;
            Data = DataReuniao;

        }

        public string Familia { get; set; }
        public int Nivel { get; set; }
        public DateTime Data { get; set; }

        public string DataFormated
        {
            get { return Data.Day.ToString("00") + "/" + Data.Month.ToString("00") + "/" + Data.Year.ToString("0000"); }
        }

    }
}
