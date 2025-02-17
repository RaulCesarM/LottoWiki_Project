namespace LottoWiki.Service.ViewModels.Entities
{
    public class LotoFacilViewModelDataModel
    {
        public int Concurso_Referencia { get; set; }
        public int Numero { get; set; }

        public int Frequencia_Integral { get; set; }
        public int Frequencia_Fracionada_de_005 { get; set; }
        public int Frequencia_Fracionada_de_010 { get; set; }
        public int Frequencia_Fracionada_de_050 { get; set; }
        public int Frequencia_Fracionada_de_100 { get; set; }

        public int Concursos_Nescessarios_005_aparicoes { get; set; }
        public int Concursos_Nescessarios_010_aparicoes { get; set; }
        public int Concursos_Nescessarios_020_aparicoes { get; set; }
        public int Concursos_Nescessarios_050_aparicoes { get; set; }
        public int Concursos_Nescessarios_100_aparicoes { get; set; }

        public int Media_Ocorrencia { get; set; }
        public int Media_Repeticao { get; set; }
        public int Media_Atraso { get; set; }

        public int Atraso_Consecutivo { get; set; }
        public int Repeticao_Consecutiva { get; set; }

        public int Macro_Estado_Concurso { get; set; }
        public int Macro_Estado_Repeticao { get; set; }
        public int Macro_Estado_Atraso { get; set; }

        public int Limite_Maximo_Que_Atrasou { get; set; }
        public int Limite_Maxico_Que_Repetiu_Consecutivamente { get; set; }

        public int Desvio_Padrao_Media_Ocorrencia { get; set; }
        public int Desvio_Padrao_Media_Repeticao { get; set; }
        public int Desvio_Padrao_Media_Atraso { get; set; }


        public int Par_Correlato { get; set; }
        public int Par_Divergente { get; set; }

        public char Status { get; set; }

        public LotoFacilViewModelDataModel()
        {
            
        }
    }
}