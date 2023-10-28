using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_02 {
  public class MathOperations {
    // Додавання
    public int Add(int a, int b) => a + b;
    public int[] Add(int[] a, int[] b) {
      ValidateSameLength(a, b);
      return ElementwiseOperation(a, b, (x, y) => x + y);
    }
    public int[,] Add(int[,] a, int[,] b) {
      ValidateSameDimensions(a, b);
      return ElementwiseOperation(a, b, (x, y) => x + y);
    }

    // Віднімання
    public int Subtract(int a, int b) => a - b;
    public int[] Subtract(int[] a, int[] b) {
      ValidateSameLength(a, b);
      return ElementwiseOperation(a, b, (x, y) => x - y);
    }
    public int[,] Subtract(int[,] a, int[,] b) {
      ValidateSameDimensions(a, b);
      return ElementwiseOperation(a, b, (x, y) => x - y);
    }

    // Множення
    public int Multiply(int a, int b) => a * b;
    public int[] Multiply(int[] a, int[] b) {
      ValidateSameLength(a, b);
      return ElementwiseOperation(a, b, (x, y) => x * y);
    }
    public int[,] Multiply(int[,] a, int[,] b) {
      ValidateSameDimensions(a, b);
      return ElementwiseOperation(a, b, (x, y) => x * y);
    }

    // Ділення
    public int Divide(int a, int b) {
      if (b == 0) throw new DivideByZeroException();
      return a / b;
    }
    public int[] Divide(int[] a, int[] b) {
      ValidateSameLength(a, b);
      return ElementwiseOperation(a, b, (x, y) => {
        if (y == 0) throw new DivideByZeroException();
        return x / y;
      });
    }
    public int[,] Divide(int[,] a, int[,] b) {
      ValidateSameDimensions(a, b);
      return ElementwiseOperation(a, b, (x, y) => {
        if (y == 0) throw new DivideByZeroException();
        return x / y;
      });
    }

    // Допоміжні методи для валідації
    private void ValidateSameLength(int[] a, int[] b) {
      if (a.Length != b.Length) {
        throw new ArgumentException("Arrays must have the same length");
      }
    }

    private void ValidateSameDimensions(int[,] a, int[,] b) {
      if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1)) {
        throw new ArgumentException("Matrices must have the same dimensions");
      }
    }

    // Допоміжний метод для елементарних операцій
    private int[] ElementwiseOperation(int[] a, int[] b, Func<int, int, int> operation) {
      int[] result = new int[a.Length];
      for (int i = 0; i < a.Length; i++) {
        result[i] = operation(a[i], b[i]);
      }
      return result;
    }

    private int[,] ElementwiseOperation(int[,] a, int[,] b, Func<int, int, int> operation) {
      int rows = a.GetLength(0);
      int cols = a.GetLength(1);
      int[,] result = new int[rows, cols];
      for (int i = 0; i < rows; i++) {
        for (int j = 0; j < cols; j++) {
          result[i, j] = operation(a[i, j], b[i, j]);
        }
      }
      return result;
    }
  }
}
