/*
 * Created by RaymondMcCarthy.
 * User: rcfe367
 * Date: 14/11/2018
 * Time: 15:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PayrollProgram
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			var employee1 = new Payroll();                           //create object
			
			Console.WriteLine("Please enter your rate: ");
			decimal rate = Convert.ToDecimal(Console.ReadLine());    //read the rate from the user
			
			Console.WriteLine("Please enter your hours: ");
			decimal hours = Convert.ToDecimal(Console.ReadLine());   //read the hours from the user
			
			decimal gross = employee1.CalculateGross(rate, hours);
			employee1.CalculatePAYE(gross);
			employee1.CalculateUSC(gross);
			employee1.CalculatePRSI(gross);
			employee1.CalculateNetPay(gross);
			employee1.DisplayPayslip();                               //call methods
			
			
			Console.ReadKey();                                        //closes payslip
			
		}
		
	}
}
