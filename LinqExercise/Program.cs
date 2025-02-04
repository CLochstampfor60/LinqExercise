﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Xml;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             */

            //TODO: Print the Sum of numbers
            var sumOfNumbers = numbers.Sum();
            Console.WriteLine(sumOfNumbers);
            Console.WriteLine("***********\n");

            //TODO: Print the Average of numbers
            var averageOfNumbers = numbers.Average();
            Console.WriteLine(averageOfNumbers);
            Console.WriteLine("***********\n");

            //TODO: Order numbers in ascending order and print to the console
            var ascendingOrderNumbers = numbers.OrderBy(x => x).ToList();
            foreach( var number in ascendingOrderNumbers)   
                Console.WriteLine(number);
            Console.WriteLine("***********\n");

            //TODO: Order numbers in descending order and print to the console
            var descendingOrderNumbers = numbers.OrderByDescending(x => x);
            foreach (var number in descendingOrderNumbers)
                Console.WriteLine(number);
           
            Console.WriteLine("***********\n");


            //TODO: Print to the console only the numbers greater than 6
            var greaterThanSix = numbers.Where(x => x > 6).ToList();
            foreach ( var number in greaterThanSix) Console.WriteLine(number);

            Console.WriteLine("***********\n");
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            var ascendingNumbersFour = ascendingOrderNumbers.Take(4).ToList();
            foreach (var number in ascendingNumbersFour)
                Console.WriteLine(number);
            Console.WriteLine("***********\n");

            //TODO: Change the value at index 4 to your age, then print the numbers in descending order

            numbers[Array.IndexOf(numbers, 4)] = 41;

            var newDescending = numbers.OrderByDescending(num => num);
            foreach (var number in newDescending)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine("***********\n");
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            var newEmployeeList = employees.FindAll(employee => employee.FirstName.ToLower()[0] == 'c' || employee.FirstName.ToLower()[0] == 's').OrderBy(employee => employee.FirstName);

          foreach (var employee in newEmployeeList) { Console.WriteLine(employee.FirstName); }


            Console.WriteLine("***********\n");
            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.

            var anotherEmployeeList = employees.Where(employee => employee.Age > 26).OrderBy(employee => employee.Age).ThenBy(employee => employee.FirstName);

            foreach (var employee in anotherEmployeeList) { 
/*                Console.WriteLine(employee.Age);
            Console.WriteLine(employee.FullName);*/
                Console.WriteLine($"Age: {employee.Age}, Name: {employee.FullName}");
            }

            Console.WriteLine("***********\n");
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.

            var lessExperienced = employees.Where(employee => employee.YearsOfExperience <= 10 && employee.Age > 35);

                Console.WriteLine(
                    $"Total Years of Experience: {lessExperienced.Sum(employee => employee.YearsOfExperience)} \n");
            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine(
                    $"Average Years of Experience: {lessExperienced.Average(employee => employee.YearsOfExperience)}"
                    );

            Console.WriteLine("***********\n");
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Joe", "Mamma", 121, 69)).ToList();

            Console.WriteLine();
            foreach (var employee in employees)
            {
                /*  Console.WriteLine(employee.FullName);
                  Console.WriteLine(employee.Age);
                  Console.WriteLine(employee.YearsOfExperience);*/
                Console.WriteLine(
                    $"Name: {employee.FullName} \n " +
                    $"Age: {employee.Age}\n " +
                    $"Years of Experience: {employee.YearsOfExperience}\n"
                    );
            }

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
