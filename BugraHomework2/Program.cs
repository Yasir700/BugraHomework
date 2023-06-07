using System;

namespace BugraHomework2
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("----------------Matrix question----------------");
            MatrixQuestion();
            Console.WriteLine("----------------question 4----------------");
            Question4();

            Console.ReadLine();
        }


        static void MatrixQuestion()
        {
            double[,] coefficients = {
            { 1, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, -4763, -3.648, 0, 0, 0, 0, 0 },
            { 0, 0, -1, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, -1, 0, 1, 0, 0, 0 },
            { 0, 0, -4.74, -6.44, 0, 0, 0, 0, 0},
            { 0, 0, 0, 0, -1, 0, 1, 0, 0},
            { 0, 0, 0, 0, 0, -1, 0, 1, 0 },
            { 0, 0, 0, 0, 0, -3, 0, 0, 1 }
        };

            double[] constants = { 5.444, 2.000, -26920, 13990, 1780, -19470, 0, 0, 0 };

            double[] solutions = SolveEquations(coefficients, constants);

            Console.WriteLine("Solutions:");
            for (int i = 0; i < solutions.Length; i++)
            {
                Console.WriteLine("x{0} = {1}", i, solutions[i]);
            }
        }
        static double[] SolveEquations(double[,] coefficients, double[] constants)
        {
            int numRows = coefficients.GetLength(0);
            int numCols = coefficients.GetLength(1);

            if (numRows != constants.Length)
            {
                throw new ArgumentException("Number of equations does not match number of constants.");
            }

            for (int i = 0; i < numRows; i++)
            {
                double pivot = coefficients[i, i];
                if (pivot == 0)
                {
                    throw new InvalidOperationException("Equations are not solvable.");
                }

                for (int j = i; j < numCols; j++)
                {
                    coefficients[i, j] /= pivot;
                }

                constants[i] /= pivot;

                for (int k = 0; k < numRows; k++)
                {
                    if (k != i)
                    {
                        double factor = coefficients[k, i];
                        for (int j = i; j < numCols; j++)
                        {
                            coefficients[k, j] -= factor * coefficients[i, j];
                        }
                        constants[k] -= factor * constants[i];
                    }
                }
            }

            double[] solutions = new double[numRows];
            for (int i = 0; i < numRows; i++)
            {
                solutions[i] = constants[i];
            }

            return solutions;
        }




        static void Question4()
        {
            Console.WriteLine("Rotor Problem Solver");

            double MassR = 225;
            double MassA = 10;
            double MassB = 12;
            double RadiusA = 0.375f;
            double RadiusB = 0.45f;
            double Qa = 0;
            double Qb = 90;
            double N = 50;

            double? Qr = null;
            double? RadiusR = null;
            double? W = null;

            double cosQrTimesRadiusR = -(3.75f * Math.Cos(0) + 5.4f * Math.Cos(-90)) / 225f;
            double sinQrTimesRadiusR = -(3.75f * Math.Sin(0) + 5.4f * Math.Sin(-90)) / 225f;

            RadiusR = Math.Sqrt(Math.Pow(cosQrTimesRadiusR, 2) + Math.Pow(sinQrTimesRadiusR, 2));

            Qr = Math.Atan(sinQrTimesRadiusR / cosQrTimesRadiusR);

            Console.WriteLine(cosQrTimesRadiusR);
            Console.WriteLine(sinQrTimesRadiusR);
            Console.WriteLine(Qr);
            Console.WriteLine(RadiusR);
        }
    }
}

