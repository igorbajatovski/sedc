using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    class Program
    {   
        public static void RaceCars(Car car1, Car car2)
        {
            if (car1.CalculateSpeed() > car2.CalculateSpeed())
                Console.WriteLine("Car no. 1 was faster");
            else if(car2.CalculateSpeed() > car1.CalculateSpeed())
                Console.WriteLine("Car no. 2 was faster");
            else
                Console.WriteLine("No car was faster");
        }

        public static void removeElementsFromArray<T>(ref T[] array, params int[] elementIndexesToRemove)
        {
            if (elementIndexesToRemove != null && elementIndexesToRemove.Length > 0)
            {
                Array.Sort(elementIndexesToRemove);
                int count = elementIndexesToRemove.Length-1;
                for (int i = array.Length - 1; i >= 0 ; --i)
                {
                    if(i == elementIndexesToRemove[count])
                    {
                        for(int j = i; j < array.Length-1; ++j)
                        {
                            array[j] = array[j + 1];
                        }
                        --count;
                        if (count < 0)
                            break;
                    }
                }
            }
            Array.Resize(ref array, array.Length - elementIndexesToRemove.Length);
        }

        public static void printArray<T>(T[] array)
        {
            foreach(T elem in array)
            {
                Console.Write(elem + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[] arr = new int[] {1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};
            printArray(arr);
            removeElementsFromArray(ref arr, 5, 9, 2, 1);
            printArray(arr);

            Driver[] drivers = new Driver[4] { new Driver() { Name = "Bob", Skill = 3 },
                                               new Driver() { Name = "Greg", Skill = 2 },
                                               new Driver() { Name = "Jill", Skill = 4 },
                                               new Driver() { Name = "Anne", Skill = 1 }};

            Car[] cars = new Car[4] { new Car() { Model = "Hyundai", Speed = 180 },
                                      new Car() { Model = "Mazda", Speed = 200 },
                                      new Car() { Model = "Ferrari", Speed = 190 },
                                      new Car() { Model = "Porsche", Speed = 195 }
            };


            Car selectedCar1 = null;
            while (selectedCar1 == null)
            {
                Console.WriteLine("Choose a car no.1:");
                for (int i = 0; i < cars.Length; ++i)
                    Console.WriteLine($"{i + 1}) {cars[i].Model}");

                int selectedCar1Index;
                if (!int.TryParse(Console.ReadLine(), out selectedCar1Index))
                {
                    Console.WriteLine("Incorrect option. Select correct option");
                    continue;
                }

                if (selectedCar1Index >= 1 && selectedCar1Index <= cars.Length)
                {
                    selectedCar1 = cars[selectedCar1Index - 1];
                    removeElementsFromArray(ref cars, selectedCar1Index - 1);
                }
                else
                    Console.WriteLine("Incorrect option. Select correct option");
            }

            Driver selectedDriver1 = null;
            while (selectedDriver1 == null)
            {
                Console.WriteLine("Choose Driver:");
                for (int i = 0; i < drivers.Length; ++i)
                    Console.WriteLine($"{i + 1}) {drivers[i].Name}");

                int selectedDriver1Index;
                if (!int.TryParse(Console.ReadLine(), out selectedDriver1Index))
                {
                    Console.WriteLine("Incorrect option. Select correct option");
                    continue;
                }

                if (selectedDriver1Index >= 1 && selectedDriver1Index <= drivers.Length)
                {
                    selectedDriver1 = drivers[selectedDriver1Index - 1];
                    removeElementsFromArray(ref drivers, selectedDriver1Index - 1);
                }
                else
                    Console.WriteLine("Incorrect option. Select correct option");
            }

            selectedCar1.Driver = selectedDriver1;

            Car selectedCar2 = null;
            while (selectedCar2 == null)
            {
                Console.WriteLine("Choose a car no.2:");
                for (int i = 0; i < cars.Length; ++i)
                    Console.WriteLine($"{i + 1}) {cars[i].Model}");

                int selectedCar2Index;
                if (!int.TryParse(Console.ReadLine(), out selectedCar2Index))
                {
                    Console.WriteLine("Incorrect option. Select correct option");
                    continue;
                }

                if (selectedCar2Index >= 1 && selectedCar2Index <= cars.Length)
                    selectedCar2 = cars[selectedCar2Index - 1];
                else
                    Console.WriteLine("Incorrect option. Select correct option");
            }

            Driver selectedDriver2 = null;
            while (selectedDriver2 == null)
            {
                Console.WriteLine("Choose Driver:");
                for (int i = 0; i < drivers.Length; ++i)
                    Console.WriteLine($"{i + 1}) {drivers[i].Name}");

                int selectedDriver2Index;
                if (!int.TryParse(Console.ReadLine(), out selectedDriver2Index))
                {
                    Console.WriteLine("Incorrect option. Select correct option");
                    continue;
                }

                if (selectedDriver2Index >= 1 && selectedDriver2Index <= drivers.Length)
                    selectedDriver2 = drivers[selectedDriver2Index - 1];
                else
                    Console.WriteLine("Incorrect option. Select correct option");
            }

            selectedCar2.Driver = selectedDriver2;

            RaceCars(selectedCar1, selectedCar2);

            Console.ReadLine();
        }
    }
}
