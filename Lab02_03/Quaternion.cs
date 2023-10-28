using System;

namespace Lab02_03 {
  // Визначення класу для роботи з кватерніонами
  public class Quaternion {
    // Компоненти кватерніона
    public double A { get; }
    public double B { get; }
    public double C { get; }
    public double D { get; }

    // Конструктор для ініціалізації кватерніона
    public Quaternion(double a, double b, double c, double d) {
      A = a;
      B = b;
      C = c;
      D = d;
    }

    // Перевантаження оператора додавання для кватерніонів
    public static Quaternion operator +(Quaternion q1, Quaternion q2) {
      return new Quaternion(q1.A + q2.A, q1.B + q2.B, q1.C + q2.C, q1.D + q2.D);
    }

    // Перевантаження оператора віднімання для кватерніонів
    public static Quaternion operator -(Quaternion q1, Quaternion q2) {
      return new Quaternion(q1.A - q2.A, q1.B - q2.B, q1.C - q2.C, q1.D - q2.D);
    }

    // Перевантаження оператора множення для кватерніонів
    public static Quaternion operator *(Quaternion q1, Quaternion q2) {
      return new Quaternion(
          q1.A * q2.A - q1.B * q2.B - q1.C * q2.C - q1.D * q2.D,
          q1.A * q2.B + q1.B * q2.A + q1.C * q2.D - q1.D * q2.C,
          q1.A * q2.C - q1.B * q2.D + q1.C * q2.A + q1.D * q2.B,
          q1.A * q2.D + q1.B * q2.C - q1.C * q2.B + q1.D * q2.A
      );
    }

    // Розрахунок норми кватерніона
    public double Norm() {
      return Math.Sqrt(A * A + B * B + C * C + D * D);
    }

    // Обчислення спряженого кватерніона
    public Quaternion Conjugate() {
      return new Quaternion(A, -B, -C, -D);
    }

    // Обчислення інверсного кватерніона
    public Quaternion Inverse() {
      double norm = Norm();
      if (norm == 0) {
        throw new InvalidOperationException("Cannot invert a zero-norm quaternion.");
      }
      Quaternion conjugate = Conjugate();
      return new Quaternion(conjugate.A / (norm * norm), conjugate.B / (norm * norm), conjugate.C / (norm * norm), conjugate.D / (norm * norm));
    }

    // Перевантаження операторів рівності та нерівності
    public static bool operator ==(Quaternion q1, Quaternion q2) {
      return q1.A == q2.A && q1.B == q2.B && q1.C == q2.C && q1.D == q2.D;
    }

    public static bool operator !=(Quaternion q1, Quaternion q2) {
      return !(q1 == q2);
    }

    // Метод для виводу кватерніона у зрозумілому форматі
    public override string ToString() {
      return $"{A} + {B}i + {C}j + {D}k";
    }
  }
}
