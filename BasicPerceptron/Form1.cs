using System;
using System.Windows.Forms;

namespace BasicPerceptron
{
    public partial class Form1 : Form
    {
        double weight1, weight2;
        double bias;
        double learningRate;
        int numberOfEpochs;
        int[,] inputs;
        int[] outputs;
        Random rand = new Random();

        private void btnTrain_Click(object sender, EventArgs e)
        {
            for (int epochItr = 0; epochItr < numberOfEpochs; epochItr++)
            {
                for(int inputItr = 0; inputItr < inputs.GetLength(0); inputItr++)
                {
                    double result_temp = inputs[inputItr, 0] * weight1 + inputs[inputItr, 1] * weight2 + bias;
                    int result = result_temp > 0 ? 1 : 0;
                    int delta = outputs[inputItr] - result;
                    if (delta != 0)
                    {
                        weight1 += learningRate * delta * inputs[inputItr, 0];
                        weight2 += learningRate * delta * inputs[inputItr, 1];
                        bias += learningRate * delta;
                    }
                }
            }
            MessageBox.Show("Training finished");
            txtInput1.Enabled = true;
            txtInput2.Enabled = true;
            btnTest.Enabled = true;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                int input1 = int.Parse(txtInput1.Text);
                int input2 = int.Parse(txtInput2.Text);
                double result_temp = input1 * weight1 + input2 * weight2 + bias;
                int result = (result_temp > 0) ? 1 : 0;
                txtOutput.Text = "" + result;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Please input only 1 or 0");
            }
        }

        public Form1()
        {
            InitializeComponent();
            numberOfEpochs = 10;
            learningRate = 0.1;

            inputs = new int[,]
            {
                {0,0 },
                {0,1 },
                {1,0 },
                {1,1 }
            };

            outputs = new int[]
            {
                0,
                0,
                0,
                1
            };

            weight1 = rand.NextDouble();
            weight2 = rand.NextDouble();
            bias = rand.NextDouble();
        }
    }
}
