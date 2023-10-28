using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_02 {
  internal class Program {

    static void Main(string[] args) {
      MathOperations math = new MathOperations();

      // Демонстрація операцій для скалярних значень
      Console.WriteLine("Scalar operations:");
      Console.WriteLine($"Add(3, 4) = {math.Add(3, 4)}");
      Console.WriteLine($"Subtract(10, 4) = {math.Subtract(10, 4)}");
      Console.WriteLine($"Multiply(3, 4) = {math.Multiply(3, 4)}");
      Console.WriteLine($"Divide(8, 4) = {math.Divide(8, 4)}");
      Console.WriteLine();

      // Демонстрація операцій для одновимірних масивів
      Console.WriteLine("Array operations:");
      int[] array1 = { 1, 2, 3 };
      int[] array2 = { 4, 5, 6 };

      int[] sumArray = math.Add(array1, array2);
      int[] diffArray = math.Subtract(array1, array2);
      int[] prodArray = math.Multiply(array1, array2);
      int[] divArray = math.Divide(new int[] { 8, 10, 12 }, new int[] { 4, 5, 6 });

      Console.WriteLine($"Add([1, 2, 3], [4, 5, 6]) = [{string.Join(", ", sumArray)}]");
      Console.WriteLine($"Subtract([1, 2, 3], [4, 5, 6]) = [{string.Join(", ", diffArray)}]");
      Console.WriteLine($"Multiply([1, 2, 3], [4, 5, 6]) = [{string.Join(", ", prodArray)}]");
      Console.WriteLine($"Divide([8, 10, 12], [4, 5, 6]) = [{string.Join(", ", divArray)}]");
      Console.WriteLine();

      // Демонстрація операцій для двовимірних масивів (матриць)
      Console.WriteLine("Matrix operations:");
      int[,] matrix1 = { { 1, 2 }, { 3, 4 } };
      int[,] matrix2 = { { 5, 6 }, { 7, 8 } };

      int[,] sumMatrix = math.Add(matrix1, matrix2);
      int[,] diffMatrix = math.Subtract(matrix1, matrix2);
      int[,] prodMatrix = math.Multiply(matrix1, matrix2);
      int[,] divMatrix = math.Divide(new int[,] { { 8, 12 }, { 16, 20 } }, new int[,] { { 4, 6 }, { 8, 10 } });

      Console.WriteLine("Addition of matrices:");
      PrintMatrix(sumMatrix);

      Console.WriteLine("Subtraction of matrices:");
      PrintMatrix(diffMatrix);

      Console.WriteLine("Element-wise multiplication of matrices:");
      PrintMatrix(prodMatrix);

      Console.WriteLine("Element-wise division of matrices:");
      PrintMatrix(divMatrix);
      Console.ReadLine();
    }

    // Допоміжний метод для виведення матриць
    static void PrintMatrix(int[,] matrix) {
      for (int i = 0; i < matrix.GetLength(0); i++) {
        for (int j = 0; j < matrix.GetLength(1); j++) {
          Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
      }
      Console.WriteLine();
    }

  }
}
