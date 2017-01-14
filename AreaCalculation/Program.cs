using System;
using System.Collections;
using System.Linq;

namespace AreaCalculation
{
    class Program
    {
        static int i = 1;
        static Hashtable operations = new Hashtable();
        static string header = "";
        static string separator="";

        abstract class Shape
        {
            public const double PI = Math.PI;
            protected DateTime localDate; //Date and Time of operation (calculation of Area)
            protected double x, y; // parameters of shape
            protected string name;

            public Shape()
            {

            }
            public Shape(string name, double x, double y)
            {
                this.name = name;
                this.x = x;
                this.y = y;
            }

            public abstract double Area(); // adstract method for calculation area
            public override string ToString()
            {
                return localDate.ToString() +" : "+ name + "\t" + Area();
            }
        }

        class Square : Shape
        {
            public Square(double a) : base("square", a, 0)
            {

            }
            public override double Area()
            {
                localDate = DateTime.Now;
                return x * x;
                
            }
        }

        class Rectangle : Shape
        {
            public Rectangle(double a,double b) : base("rectangle", a, b)
            {

            }
            public override double Area()
            {
                localDate = DateTime.Now;
                return x * y;
            }
        }

        class Circle : Shape
        {
            public Circle(double r): base("circle", r, 0)
            {

            }
            public override double Area()
            {
                localDate = DateTime.Now;
                return PI * x * x;
            }
        }

        static void hello()
        {
            Console.WriteLine("Welcome to Area Calculation.Enter Command.");
        }
        static void exit()
        {
            operations.Clear(); // clean hashtable
            Environment.Exit(0); //close application
        }
        static void showall()
        {
            ICollection valueColl = operations.Values; // collection of values from hashtable
            foreach(object c in valueColl)
            {
                Console.WriteLine(header+"\r\n"+separator+c.ToString()+separator);
            }
        }
        static void Calculation(string secondword,double a, double b)
        {
            switch (secondword)
            {
                case "square":
                    Shape sq = new Square(a);
                    Console.WriteLine("Area of Shape = {0}", sq.Area());
                    operations.Add("HashedItem" + Convert.ToString(i), sq);
                    i++;
                    break;
                case "rectangle":
                    Shape rc = new Rectangle(a,b);
                    Console.WriteLine("Area of Shape = {0}", rc.Area());
                    operations.Add("HashedItem" + Convert.ToString(i), rc);
                    i++;
                    break;
                case "circle":
                    Shape circ = new Circle(a);
                    Console.WriteLine("Area of Shape = {0}", circ.Area());
                    operations.Add("HashedItem" + Convert.ToString(i), circ);
                    i++;
                    break;
                default:
                    Console.WriteLine("Error.We have no such a figure.");
                    break;
            }
        }
        static void Main(string[] args)
        {
            string CommandString; //Command from user
            char delimiter = ' '; //delimiter to divide string into words

            hello();
            while (true)
            {
                CommandString = Console.ReadLine();
                string[] command=CommandString.Split(delimiter); //divide string into words
                switch (command[0])//command[0]- the first word in string
                {
                    case "hello":
                        hello();
                        break;
                    case "exit":
                        exit();
                        break;
                    case "showall":
                        //Check if we have parameters for showall method or not (if we have the second word in command or not)
                        if (Convert.ToInt32(command.Count())==2)
                        {
                            switch (command[1])
                            {
                                case "dotted":
                                    header = "............................................";
                                    separator = "..";
                                    break;
                                case "dashed":
                                    header = "--------------------------------------------";
                                    separator = "--";
                                    break;
                                default:
                                    Console.WriteLine("Error.We haven`t this type of report. Try one more command.");
                                    break;
                            }
                        }
                        showall();
                        break;
                    case "area":
                        if (command[1] == "rectangle")
                        {
                            //Check if we have 2 parameters for rectangle, if we haven`t - display a message
                            try
                            {
                                Calculation(command[1], Convert.ToDouble(command[2]), Convert.ToDouble(command[3]));
                            }
                            catch
                            {
                                Console.WriteLine("Wrong data. Try one more time.");
                            }
                        }
                        else
                        {
                            Calculation(command[1], Convert.ToDouble(command[2]), 0);
                        }
                        break;
                    default:
                        Console.WriteLine("Error. Try one more command.");
                        break;
                }
            }
        }
    }
}
