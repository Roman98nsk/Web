using System;
using System.IO;

class ReadFile {
    static void Main() {
        int j = 0;
        
        long[,] matrix = new long[10,10];

        Console.WriteLine("\n");

        //читаем файл построчно
        foreach (string line in System.IO.File.ReadLines("File.csv")) {
            //выводим то что считали
            Console.WriteLine(line);
            
            //в переменную кладем часть строки до ,
            string[] word = line.Split(',');
            //int[] word_convert;
            int i = 0;

            foreach (string value in word) {
                long number = Int64.Parse(value);
                matrix[i, j] = number;
                i++;
            }
            j++;
        }

        Console.WriteLine("\nInput operation (max, min, aver, disp): ");
        string into = Console.ReadLine();

        switch (into) {
            case "max":
                long max = matrix[0, 0];
                for (int a = 9; a >= 0; a--) {
                    for (int b = 9; b >= 0; b--) {
                        if (matrix[a, b] > max) {
                            max = matrix[a, b];
                            
                        }
                    }
                }
                Console.WriteLine($"{max}");
                break;

            case "min":
            long min = matrix[0, 0];
                for (int a = 0; a < 10; a++) {
                    for (int b = 0; b < 10; b++) {
                        if (matrix[a, b] < min) {
                            min = matrix[a, b];
                        }
                    }
                }
                Console.WriteLine($"Minimum: {min}");
                break;

            case "aver":
            long aver = 0;
                for (int a = 0; a < 10; a++) {
                    for (int b = 0; b < 10; b++) {
                        aver += matrix[a, b];
                        }
                    }
                    aver /= 100;
                Console.WriteLine($"Average: {aver}");
                break;


            case "disp":
            double S = 0, S1 = 0, S2 = 0;
            double aver1 = 0;

                for (int a = 0; a < 10; a++) {
                    for (int b = 0; b < 10; b++) {
                        aver1 += matrix[a, b];
                        }
                    }
                    aver1 /= 100;
                for (int a = 0; a < 10; a++) {
                    for (int b = 0; b < 10; b++) {
                        S = Math.Pow((matrix[a, b] - aver1), 2);
                    }
                }
                S1 = 1.0 / 99.0;
                S2 = Math.Sqrt(S * S1); 
                Console.WriteLine($"Dispersion: {S2:f3}");
                break;
            default:
                Console.WriteLine("Error of input");
                break;
        }
    }
}