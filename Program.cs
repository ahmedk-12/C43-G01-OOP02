namespace Assignment2OOP
{
    struct Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    struct Rectangle
    {
        private double width;
        private double height;

        public double Width
        {
            get => width;
            set => width = value >= 0 ? value : throw new ArgumentException("Width cannot be negative.");
        }

        public double Height
        {
            get => height;
            set => height = value >= 0 ? value : throw new ArgumentException("Height cannot be negative.");
        }

        public double Area => width * height;

        public void DisplayInfo()
        {
            Console.WriteLine($"Width: {width}, Height: {height}, Area: {Area}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose a task to execute (1-4):");
            Console.WriteLine("1. Display details of persons");
            Console.WriteLine("2. Calculate distance between two points");
            Console.WriteLine("3. Find the oldest person");
            Console.WriteLine("4. Display rectangle details");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                return;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        Task1();
                        break;
                    case 2:
                        Task2();
                        break;
                    case 3:
                        Task3();
                        break;
                    case 4:
                        Task4();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        #region 1.Define a struct "Person" with properties "Name" and "Age". Create an array of three "Person" objects and populate it with data. Then, write a C# program to display the details of all the persons in the array.
        static void Task1()
        {
            Person[] persons = new Person[3]
            {
                new Person { Name = "Ahmed", Age = 25 },
                new Person { Name = "Sara", Age = 30 },
                new Person { Name = "Omar", Age = 20 }
            };

            Console.WriteLine("Details of Persons:");
            foreach (var person in persons)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
        }
        #endregion
        #region 2.Create a struct called "Point" to represent a 2D point with properties "X" and   "Y". Write a C# program that takes two points as input from the user and calculates the distance between them.
        static void Task2()
        {
            Point p1 = GetPointInput("Point 1");
            Point p2 = GetPointInput("Point 2");

            double distance = Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
            Console.WriteLine($"Distance between points: {distance:F2}");
        }

        static Point GetPointInput(string pointName)
        {
            Console.WriteLine($"Enter coordinates for {pointName}:");
            Console.Write("X: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Y: ");
            double y = double.Parse(Console.ReadLine());
            return new Point { X = x, Y = y };
        }
        #endregion
        #region 3.Create a struct called "Person" with properties "Name" and "Age". Write a C# program that takes details of 3 persons as input from the user and displays the name and age of the oldest person.
        static void Task3()
        {
            Person[] persons = new Person[3];

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter name of person {i + 1}: ");
                string name = Console.ReadLine();
                Console.Write($"Enter age of person {i + 1}: ");
                int age = int.Parse(Console.ReadLine());
                persons[i] = new Person { Name = name, Age = age };
            }

            Person oldest = persons[0];
            foreach (var person in persons)
            {
                if (person.Age > oldest.Age)
                {
                    oldest = person;
                }
            }

            Console.WriteLine($"Oldest person is {oldest.Name} with age {oldest.Age}.");
        }
        #endregion
        #region 4.Create a struct named Rectangle that represents a rectangle with the following fields:width(type: double)height(type: double)
        static void Task4()
        {
            try
            {
                Console.Write("Enter width of rectangle: ");
                double width = double.Parse(Console.ReadLine());
                Console.Write("Enter height of rectangle: ");
                double height = double.Parse(Console.ReadLine());

                Rectangle rect = new Rectangle { Width = width, Height = height };
                rect.DisplayInfo();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
