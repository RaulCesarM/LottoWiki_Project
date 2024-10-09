using Microsoft.ML.SearchSpace;

namespace LottoWiki.Service.ViewModels.MachineLearning
{
    public class TrainingOptions
    {
        /// <summary>
        /// Peso de regularização L2
        /// </summary>
        [Range(0.03125f, 32768f, 1, true)]
        public float L2Regularization { get; set; }

        /// <summary>
        /// Peso de regularização L1
        /// </summary>

        [Range(0.03125f, 32768f, 1, true)]
        public float L1Regularization { get; set; }

        /// <summary>
        ///
        /// Parâmetro de tolerância para convergência de otimização. (Baixo = mais lento, mais preciso).
        /// </summary>
        [Range(1e-7f, 1e-1f, 1e-4f, true)]
        public float OptimizationTolerance { get; set; }

        /// <summary>
        /// Número de iterações anteriores a serem lembradas para estimar o Hessiano. Valores mais baixos significam estimativas mais rápidas, mas menos precisas.
        /// </summary>
        [Range(2, 512, 2, true)]
        public int HistorySize { get; set; }

        /// <summary>
        /// Numero de interação
        /// </summary>
        [Range(1, int.MaxValue, 1, true)]
        public int MaximumNumberOfIterations { get; set; }

        /// <summary>
        /// Execute o SGD para inicializar os pesos LR, convergindo para esta tolerância.
        /// </summary>
        public float StochasticGradientDescentInitilaizationTolerance { get; set; } = 0;

        /// <summary>
        /// Determina se deve produzir saída durante o treinamento ou não.
        /// </summary>
        /// <value>
        /// Se definido para <see langword="true"/> nenhuma saída é produzida.
        /// </value>
        public bool Quiet { get; set; } = false;

        /// <summary>
        /// Escala de pesos iniciais.
        /// </summary>
        /// <value>
        /// Esta propriedade só é usada se o valor fornecido for positivo.
        /// Os pesos serão selecionados aleatoriamente no intervalo InitialWeights * [-0,5,0,5] com distribuição uniforme.
        /// </value>
        [Range(0f, 1f, 0f, false)]
        public float InitialWeightsDiameter { get; set; } = 0;

        /// <summary>
        /// Densificação de força dos vetores de otimização internos. O padrão é falso.
        /// </summary>
        [BooleanChoice]
        public bool DenseOptimizer { get; set; } = false;

        /// <summary>
        /// Aplique pesos não negativos. O padrão é falso.
        /// </summary>
        [BooleanChoice]
        public bool EnforceNonNegativity { get; set; }
    }
}