using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab02 {
  internal class Program {
    // Абстрактний клас Vehicle
    public abstract class Vehicle {
      public int Speed { get; set; }
      public int Capacity { get; set; }
      public abstract void Move();
    }

    // Клас Human
    public class Human {
      public int Speed { get; set; }
      public void Move() {
        Console.WriteLine($"Human is moving at {Speed} km/h.");
      }
    }

    // Спадкоємці класу Vehicle
    public class Car : Vehicle {
      public override void Move() {
        Console.WriteLine($"Car is moving at {Speed} km/h with {Capacity} passengers.");
      }
    }

    public class Bus : Vehicle {
      public override void Move() {
        Console.WriteLine($"Bus is moving at {Speed} km/h with {Capacity} passengers.");
      }
    }

    public class Train : Vehicle {
      public override void Move() {
        Console.WriteLine($"Train is moving at {Speed} km/h with {Capacity} passengers.");
      }
    }

    // Клас TransportNetwork
    public class TransportNetwork {
      List<Vehicle> vehicles = new List<Vehicle>();

      public void AddVehicle(Vehicle vehicle) {
        vehicles.Add(vehicle);
      }

      public void MoveAll() {
        foreach (var vehicle in vehicles) {
          vehicle.Move();
        }
      }
    }

    // Клас Route
    public class Route {
      public string Start { get; set; }
      public string End { get; set; }

      public void CalculateOptimalRoute(Vehicle vehicle) {
        // Розрахунок оптимального маршруту
        Console.WriteLine($"Optimal route for {vehicle.GetType().Name} from {Start} to {End} is calculated.");
      }
    }

    static void Main(string[] args) {
      Human human = new Human { Speed = 5 };
      human.Move();

      Car car = new Car { Speed = 80, Capacity = 4 };
      Bus bus = new Bus { Speed = 60, Capacity = 20 };
      Train train = new Train { Speed = 120, Capacity = 200 };

      TransportNetwork network = new TransportNetwork();
      network.AddVehicle(car);
      network.AddVehicle(bus);
      network.AddVehicle(train);

      network.MoveAll();

      Route route = new Route { Start = "A", End = "B" };
      route.CalculateOptimalRoute(car);
      route.CalculateOptimalRoute(bus);
      route.CalculateOptimalRoute(train);
      Console.ReadKey();
    }
  }
}
