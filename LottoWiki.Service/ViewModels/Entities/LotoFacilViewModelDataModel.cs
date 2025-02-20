namespace LottoWiki.Service.ViewModels.Entities
{
    public class LotoFacilViewModelDataModel
    {
        public int Concurso_Referencia { get; set; }
        public int Numero { get; set; }

        public int Frequencia_Fracionada_de_005 { get; set; }
        public int Frequencia_Fracionada_de_010 { get; set; }
        public int Frequencia_Fracionada_de_015 { get; set; }
        public int Frequencia_Fracionada_de_025 { get; set; }
        public int Frequencia_Fracionada_de_040 { get; set; }
        public int Frequencia_Fracionada_de_065 { get; set; }
        public int Frequencia_Fracionada_de_105 { get; set; }

        public int Concursos_Nescessarios_005_aparicoes { get; set; }
        public int Concursos_Nescessarios_010_aparicoes { get; set; }
        public int Concursos_Nescessarios_015_aparicoes { get; set; }
        public int Concursos_Nescessarios_025_aparicoes { get; set; }
        public int Concursos_Nescessarios_040_aparicoes { get; set; }
        public int Concursos_Nescessarios_065_aparicoes { get; set; }
        public int Concursos_Nescessarios_105_aparicoes { get; set; }

        public int Atraso_Consecutivo { get; set; }
        public int Repeticao_Consecutiva { get; set; }

        public double Media_Repeticao_Por_Linha { get; set; }
        public double Media_Repeticao_Global { get; set; }

        public double Media_Atraso_Por_Linha { get; set; }
        public double Media_Atraso_Global { get; set; }

        public double Desvio_Padrao_Repeticao_Por_Linha { get; set; }
        public double Desvio_Padrao_Repeticao_Global { get; set; }

        public double Desvio_Padrao_Atraso_Por_Linha { get; set; }
        public double Desvio_Padrao_Atraso_Global { get; set; }

        public double Media_Macro_Estado_Principal { get; set; }
        public double Macro_Estado_Concurso { get; set; }
        public double Macro_Estado_Repeticao { get; set; }
        public double Macro_Estado_Atraso { get; set; }

        public int Maior_Atraso { get; set; }
        public int Maior_Repeticao { get; set; }

        public int Par_Correlato { get; set; }
        public int Par_Divergente { get; set; }

        public char Status { get; set; }

        public LotoFacilViewModelDataModel()
        {
        }
    }
}