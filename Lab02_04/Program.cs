using System;
using System.Collections.Generic;

namespace Lab02_04 {
  internal class Program {
    // Абстрактний клас для графічних примітивів
    public abstract class GraphicPrimitive {
      // Координати примітива
      public int X { get; set; }
      public int Y { get; set; }

      // Метод для малювання примітива, реалізація буде у спадкоємцях
      public abstract void Draw();

      // Метод для масштабування примітива
      public abstract void Scale(float factor);

      // Віртуальний метод для переміщення примітива
      public virtual void Move(int x, int y) {
        X += x;
        Y += y;
      }
    }

    // Клас для круга, наслідує GraphicPrimitive
    public class Circle : GraphicPrimitive {
      // Радіус круга
      public int Radius { get; set; }

      // Реалізація методу Draw для круга
      public override void Draw() {
        Console.WriteLine($"Drawing a circle at ({X}, {Y}) with radius {Radius}");
      }

      // Реалізація методу Scale для круга
      public override void Scale(float factor) {
        Radius = (int)(Radius * factor);
      }
    }

    // Клас для прямокутника
    public class Rectangle : GraphicPrimitive {
      // Ширина та висота прямокутника
      public int Width { get; set; }
      public int Height { get; set; }

      // Реалізація методу Draw для прямокутника
      public override void Draw() {
        Console.WriteLine($"Drawing a rectangle at ({X}, {Y}) with width {Width} and height {Height}");
      }

      // Реалізація методу Scale для прямокутника
      public override void Scale(float factor) {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
      }
    }

    // Клас для трикутника
    public class Triangle : GraphicPrimitive {
      // Довжина сторони трикутника
      public int Side { get; set; }

      // Реалізація методу Draw для трикутника
      public override void Draw() {
        Console.WriteLine($"Drawing a triangle at ({X}, {Y}) with side {Side}");
      }

      // Реалізація методу Scale для трикутника
      public override void Scale(float factor) {
        Side = (int)(Side * factor);
      }
    }

    // Клас для групи примітивів
    public class Group : GraphicPrimitive {
      // Колекція елементів у групі
      public List<GraphicPrimitive> Elements { get; } = new List<GraphicPrimitive>();

      // Реалізація методу Draw для групи
      public override void Draw() {
        Console.WriteLine("Drawing a group:");
        foreach (var element in Elements) {
          element.Draw();
        }
      }

      // Реалізація методу Scale для групи
      public override void Scale(float factor) {
        foreach (var element in Elements) {
          element.Scale(factor);
        }
      }

      // Перевизначення методу Move для групи
      public override void Move(int x, int y) {
        base.Move(x, y);
        foreach (var element in Elements) {
          element.Move(x, y);
        }
      }
    }

    // Клас для редактора графіки
    public class GraphicsEditor {
      // Колекція всіх графічних примітивів
      private readonly List<GraphicPrimitive> _elements = new List<GraphicPrimitive>();

      // Метод для додавання нового примітива
      public void AddElement(GraphicPrimitive element) {
        _elements.Add(element);
      }

      // Метод для малювання всіх примітивів
      public void DrawAll() {
        foreach (var element in _elements) {
          element.Draw();
        }
      }
    }

    // Головний метод програми
    static void Main(string[] args) {
      // Створення екземпляра редактора графіки
      GraphicsEditor editor = new GraphicsEditor();

      // Створення різних графічних примітивів
      Circle circle = new Circle { X = 1, Y = 1, Radius = 5 };
      Rectangle rect = new Rectangle { X = 2, Y = 2, Width = 3, Height = 4 };
      Triangle triangle = new Triangle { X = 3, Y = 3, Side = 6 };

      // Додавання примітивів до редактора
      editor.AddElement(circle);
      editor.AddElement(rect);
      editor.AddElement(triangle);

      // Вивід на екран до масштабування
      Console.WriteLine("Before scaling:");
      editor.DrawAll();

      // Масштабування примітивів
      circle.Scale(2);
      rect.Scale(0.5f);
      triangle.Scale(1.5f);

      // Вивід на екран після масштабування
      Console.WriteLine("\nAfter scaling:");
      editor.DrawAll();

      // Створення групи примітивів
      Group group = new Group();
      group.Elements.Add(circle);
      group.Elements.Add(rect);
      group.Elements.Add(triangle);

      // Вивід на екран до переміщення групи
      Console.WriteLine("\nBefore moving group:");
      group.Draw();

      // Переміщення групи
      group.Move(1, 1);

      // Вивід на екран після переміщення групи
      Console.WriteLine("\nAfter moving group:");
      group.Draw();

      // Затримка для перегляду результату
      Console.ReadLine();
    }
  }
}
