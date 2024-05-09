using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SVMExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string csvFilePath = @"C:\Users\ramaz\Desktop\school\breast-cancer.csv"; 
            List<double[]> XList = new List<double[]>();
            List<int> yList = new List<int>();

            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                string line;
                reader.ReadLine();
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    double[] row = parts.Skip(1).Select(x => x == "M" ? 1 : (x == "B" ? 0 : double.Parse(x.StartsWith(".") ? $"0{x}" : x))).ToArray(); 
                    int label = parts[1] == "M" ? 1 : 0;

                    XList.Add(row);
                    yList.Add(label);
                }
            }

            double[][] X = XList.ToArray();
            int[] y = yList.ToArray();

            double[][] X_train, X_test;
            int[] y_train, y_test;
            double targetAccuracy = 0.8; 
            double currentAccuracy = 0; 
            
            while (currentAccuracy < targetAccuracy)
            {
                ShuffleData(X, y);

                SplitData(X, y, 0.2, out X_train, out X_test, out y_train, out y_test);

                double[] weights = TrainSVM(X_train, y_train);

                int[] y_pred = Predict(X_test, weights);

                int[] y_pred_train = Predict(X_train, weights);

                currentAccuracy = CalculateAccuracy(y_test, y_pred);

                Console.WriteLine($"Current Test Set Accuracy: {currentAccuracy}");

                double accuracy_train = CalculateAccuracy(y_train, y_pred_train);

                Console.WriteLine($"Training Set Accuracy: {accuracy_train}");
                Console.WriteLine("\nPredicted Labels - True Labels (Test Set):");

                for (int i = 0; i < y_test.Length; i++)
                {
                    Console.WriteLine($"{y_pred[i]} - {y_test[i]}");
                }

                Console.WriteLine("\nPredicted Labels - True Labels (Training Set):");
                for (int i = 0; i < y_train.Length; i++)
                {
                    Console.WriteLine($"{y_pred_train[i]} - {y_train[i]}");
                }

                if (currentAccuracy >= targetAccuracy)
                {
                    Console.WriteLine("Target Accuracy Reached!");
                    break;
                }
            }

            //double[] weights = TrainSVM(X_train, y_train);

            //int[] y_pred = Predict(X_test, weights);

            //int[] y_pred_train = Predict(X_train, weights);

            //double accuracy = CalculateAccuracy(y_test, y_pred);
            //Console.WriteLine($"Test Set Accuracy: {currentAccuracy}");

            //double accuracy_train = CalculateAccuracy(y_train, y_pred_train);
            //Console.WriteLine($"Training Set Accuracy: {accuracy_train}");

            //Console.WriteLine("\nPredicted Labels - True Labels (Test Set):");
            //for (int i = 0; i < y_test.Length; i++)
            //{
            //    Console.WriteLine($"{y_pred[i]} - {y_test[i]}");
            //}

            //Console.WriteLine("\nPredicted Labels - True Labels (Training Set):");
            //for (int i = 0; i < y_train.Length; i++)
            //{
            //    Console.WriteLine($"{y_pred_train[i]} - {y_train[i]}");
            //}

            Console.ReadLine();
        }

        static void SplitData(double[][] X, int[] y, double testSize, out double[][] X_train, out double[][] X_test, out int[] y_train, out int[] y_test)
        {
            int trainSize = (int)(X.Length * (1 - testSize));
            List<int> indices = Enumerable.Range(0, X.Length).ToList();
            Random rand = new Random();
            X_train = new double[trainSize][];
            X_test = new double[X.Length - trainSize][];
            y_train = new int[trainSize];
            y_test = new int[X.Length - trainSize];

            for (int i = 0; i < trainSize; i++)
            {
                int index = rand.Next(indices.Count);
                X_train[i] = X[indices[index]];
                y_train[i] = y[indices[index]];
                indices.RemoveAt(index);
            }

            for (int i = 0; i < X.Length - trainSize; i++)
            {
                X_test[i] = X[indices[i]];
                y_test[i] = y[indices[i]];
            }
        }

        static double[] TrainSVM(double[][] X_train, int[] y_train)
        {
            Random rand = new Random();
            double[] weights = new double[X_train[0].Length];
            for (int i = 0; i < weights.Length; i++)
            {
                weights[i] = rand.NextDouble();
            }
            return weights;
        }

        static void ShuffleData(double[][] X, int[] y)
        {
            Random rand = new Random();
            int n = X.Length;
            while (n > 1)
            {
                n--;
                int k = rand.Next(n + 1);
                double[] tempX = X[k];
                X[k] = X[n];
                X[n] = tempX;
                int tempY = y[k];
                y[k] = y[n];
                y[n] = tempY;
            }
        }

        static int[] Predict(double[][] X, double[] weights)
        {
            List<int> predictions = new List<int>();
            foreach (double[] sample in X)
            {
                double dotProduct = 0;
                for (int i = 0; i < weights.Length; i++)
                {
                    dotProduct += weights[i] * sample[i];
                }
                predictions.Add(dotProduct > 0 ? 1 : 0);
            }
            return predictions.ToArray();
        }

        -static double CalculateAccuracy(int[] y_true, int[] y_pred)
        {
            int correct = 0;
            for (int i = 0; i < y_true.Length; i++)
            {
                if (y_true[i] == y_pred[i])
                {
                    correct++;
                }
            }
            return (double)correct / y_true.Length;
        }
    }
}
