﻿using System;
using System.Collections.Generic;

namespace BasicLambdaExpression
{
	// this delegate will return "true" or false"
	// for the passed in employee
	delegate bool isPromotable(Employee empl);

	class Employee
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public Gender gender { get; set; }
		public int Experience { get; set; }

		// the delegate has to be passed in as a parameter.
		// this delegate will point to a function

		public static void PromoteEmployee(List<Employee> employeeList, isPromotable isEligibleToPromote)
		{
			foreach (Employee emp in employeeList)
			{
				// the passed in delegate is being  thrown in for the condition	
				if (isEligibleToPromote(emp))
				{
					Console.WriteLine("{0} promoted", emp.Name);
				}
			}
		}
	}

	public enum Gender
	{
		Unknown,
		Male,
		Female
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			List<Employee> empList = new List<Employee>();
			empList.Add(new Employee() { ID = 101, Name = "Steve", gender = Gender.Male, Experience = 5 });
			empList.Add(new Employee() { ID = 102, Name = "James", gender = Gender.Male, Experience = 3 });
			empList.Add(new Employee() { ID = 103, Name = "Kim", gender = Gender.Female, Experience = 7 });

			Employee.PromoteEmployee(empList, emp => emp.Experience >= 5);
		}
	}
}