public class LSTM
{
    private int inputSize, hiddenSize;
    private double[,] weightsForget, weightsInput, weightsOutput, weightsCandidate;
    private double[] biasForget, biasInput, biasOutput, biasCandidate;
    private double learningRate = 0.01;
    private double beta1 = 0.9, beta2 = 0.999, epsilon = 1e-8;
    private double[,] mForget, vForget, mInput, vInput, mOutput, vOutput, mCandidate, vCandidate;
    private double[] mBiasForget, vBiasForget, mBiasInput, vBiasInput, mBiasOutput, vBiasOutput, mBiasCandidate, vBiasCandidate;
    private int timestep = 1;
    private double lambda = 0.001;

    public LSTM(int inputSize, int hiddenSize)
    {
        this.inputSize = inputSize;
        this.hiddenSize = hiddenSize;

        this.weightsForget = InitializeWeights(inputSize + hiddenSize, hiddenSize);
        this.weightsInput = InitializeWeights(inputSize + hiddenSize, hiddenSize);
        this.weightsOutput = InitializeWeights(inputSize + hiddenSize, hiddenSize);
        this.weightsCandidate = InitializeWeights(inputSize + hiddenSize, hiddenSize);

        this.biasForget = new double[hiddenSize];
        this.biasInput = new double[hiddenSize];
        this.biasOutput = new double[hiddenSize];
        this.biasCandidate = new double[hiddenSize];

        this.mForget = new double[inputSize + hiddenSize, hiddenSize];
        this.vForget = new double[inputSize + hiddenSize, hiddenSize];
        this.mInput = new double[inputSize + hiddenSize, hiddenSize];
        this.vInput = new double[inputSize + hiddenSize, hiddenSize];
        this.mOutput = new double[inputSize + hiddenSize, hiddenSize];
        this.vOutput = new double[inputSize + hiddenSize, hiddenSize];
        this.mCandidate = new double[inputSize + hiddenSize, hiddenSize];
        this.vCandidate = new double[inputSize + hiddenSize, hiddenSize];
        this.mBiasForget = new double[hiddenSize];
        this.vBiasForget = new double[hiddenSize];
        this.mBiasInput = new double[hiddenSize];
        this.vBiasInput = new double[hiddenSize];
        this.mBiasOutput = new double[hiddenSize];
        this.vBiasOutput = new double[hiddenSize];
        this.mBiasCandidate = new double[hiddenSize];
        this.vBiasCandidate = new double[hiddenSize];
    }

    private static double[,] InitializeWeights(int rows, int cols)
    {
        Random rand = new Random();
        double stdDev = Math.Sqrt(2.0 / (rows + cols));
        double[,] weights = new double[rows, cols];
        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++)
                weights[i, j] = rand.NextDouble() * 2 * stdDev - stdDev;
        return weights;
    }

    public (double[], double[]) Forward(double[] input, double[] hiddenState, double[] cellState)
    {
        // Concatenando input e hiddenState
        var combined = input.Concat(hiddenState).ToArray();

        // Calculando forget gate
        var forgetGate = Sigmoid(DotProduct(combined, this.weightsForget, this.biasForget));

        // Calculando input gate
        var inputGate = Sigmoid(DotProduct(combined, this.weightsInput, this.biasInput));

        // Calculando output gate
        var outputGate = Sigmoid(DotProduct(combined, this.weightsOutput, this.biasOutput));

        // Calculando candidate cell state
        var candidateCellState = Tanh(DotProduct(combined, this.weightsCandidate, this.biasCandidate));

        // Atualizando o cell state
        cellState = Multiply(forgetGate, cellState).Zip(Multiply(inputGate, candidateCellState), (f, i) => f + i).ToArray();

        // Calculando hidden state
        hiddenState = Multiply(outputGate, Tanh(cellState));

        return (hiddenState, cellState);
    }

    private static double[] DotProduct(double[] input, double[,] weights, double[] bias)
    {
        int rows = weights.GetLength(1);
        double[] output = new double[rows];
        for (int i = 0; i < rows; i++)
        {
            output[i] = bias[i];
            for (int j = 0; j < input.Length; j++)
                output[i] += input[j] * weights[j, i];
        }
        return output;
    }

    private static double[] Sigmoid(double[] x)
    {
        return x.Select(v => 1.0 / (1.0 + Math.Exp(-v))).ToArray();
    }

    private static double[] Tanh(double[] x)
    {
        return x.Select(Math.Tanh).ToArray();
    }

    private static double[] Multiply(double[] a, double[] b)
    {
        return a.Zip(b, (x, y) => x * y).ToArray();
    }

    private void UpdateWeights(double[] gradients, double[,] weights, double[] m, double[] v, double[] bias, double[] mBias, double[] vBias)
    {
        // Atualizando momentos (parâmetros Adam)
        for (int i = 0; i < weights.GetLength(1); i++)
        {
            m[i] = this.beta1 * m[i] + (1 - this.beta1) * gradients[i];
            v[i] = this.beta2 * v[i] + (1 - this.beta2) * Math.Pow(gradients[i], 2);

            mBias[i] = this.beta1 * mBias[i] + (1 - this.beta1) * gradients[i];
            vBias[i] = this.beta2 * vBias[i] + (1 - this.beta2) * Math.Pow(gradients[i], 2);
        }

        // Corrigindo o viés
        double mCorrected = m[0] / (1 - Math.Pow(this.beta1, this.timestep));
        double vCorrected = v[0] / (1 - Math.Pow(this.beta2, this.timestep));

        // Aplicando regularização L2 e atualizando os pesos
        for (int i = 0; i < weights.GetLength(0); i++)
        {
            for (int j = 0; j < weights.GetLength(1); j++)
            {
                weights[i, j] -= this.learningRate * (mCorrected / (Math.Sqrt(vCorrected) + this.epsilon) + this.lambda * weights[i, j]);
            }
        }

        // Atualizando os vieses
        for (int i = 0; i < bias.Length; i++)
        {
            bias[i] -= this.learningRate * (mBias[i] / (Math.Sqrt(vBias[i]) + this.epsilon));
        }
    }
}