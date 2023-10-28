using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02_03 {
  internal class Program {
    static void Main(string[] args) {
      Quaternion q1 = new Quaternion(1, 2, 3, 4);
      Quaternion q2 = new Quaternion(5, 6, 7, 8);

      Console.WriteLine("Quaternion 1: " + q1);
      Console.WriteLine("Quaternion 2: " + q2);

      Console.WriteLine("Sum: " + (q1 + q2));
      Console.WriteLine("Difference: " + (q1 - q2));
      Console.WriteLine("Product: " + (q1 * q2));

      Console.WriteLine("Norm of Quaternion 1: " + q1.Norm());
      Console.WriteLine("Conjugate of Quaternion 1: " + q1.Conjugate());
      Console.WriteLine("Inverse of Quaternion 1: " + q1.Inverse());

      Console.WriteLine("Are they equal? " + (q1 == q2));
      Console.ReadKey();
    }
  }
}
