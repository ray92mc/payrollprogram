/*
 * Created by SharpDevelop.
 * User: rcfe367
 * Date: 14/11/2018
 * Time: 15:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace PayrollProgram
{
	/// <summary>
	/// Payroll Program to calculate an employee's weeks wages minus paye, usc and prsi. 
	/// </summary>
	public class Payroll
	{
		private decimal gross;
		private decimal paye; 
		private decimal prsi;		                               //class member fields
		private decimal usc;
		private decimal netpay;		
		
		private const decimal TAX_CREDIT = 63.46m;
		private const decimal PAYE_ON_650 = 130m;                  //constants
		
		
		public Payroll()                                           //constructor method
		{
		}
		
		public decimal CalculateGross (decimal hours, decimal rate){
			return gross = hours * rate;                           //calculates gross pay
		}
		
		
		public decimal CalculateUSC (decimal gross){
			
			if (gross>1347){
				usc += (gross-1347)*0.08m +49.35m +3.25m +1.16m;   //8% paid on gross above 1347 euro
			}
			
			else if (gross>361 && gross<=1347){
				usc += (gross-361m)*0.05m +3.25m+1.16m;            //5% paid on gross between 361 and 1347
			}
			
			else if (gross>231 && gross<=361){
				usc += (gross-231)*0.025m +1.16m;                  //2.5% paid on gross between 231 and 361
			}
			
			else if (gross<=231){
				usc += (gross-231)*0.005m;                         //0.5% paid on gross below 231
			}
			
			return usc;
		}
		
		public decimal CalculatePAYE (decimal gross){
			
			if(gross<=650){
				paye = gross*0.2m-TAX_CREDIT;                      //calculates paye under 650 gross
			}
			
			else{
				paye = (gross-650m)*0.4m-TAX_CREDIT+PAYE_ON_650;   //calculates paye over 650 gross
			}
			
			return paye;
		}
		
			
		public decimal CalculatePRSI (decimal gross){
				return prsi = (gross)*0.04m;                       //calculates PRSI
		}  
			
			
			
		public decimal CalculateNetPay (decimal gross){
				return netpay = (gross-paye-usc-prsi);             //calculates net pay                                                
		}
			
			
			
		public void DisplayPayslip(){
				Console.WriteLine("\n\t\tWeekly Payslip\n");
				
				Console.Write("Gross Pay: \t\t\t ");
				Console.Write(Math.Round(gross, 2));
				
				Console.Write("\nEE PRSI: \t\t ");
				Console.Write(Math.Round(prsi, 2));
				
				Console.Write("\nPAYE - Tax Credit:\t ");
				Console.Write(Math.Round(paye, 2));
				
				Console.Write("\nUSC:\t\t\t ");
				Console.Write(Math.Round(usc, 2));
				
				Console.Write("\n\nNet Pay:\t\t\t ");
				Console.Write(Math.Round(netpay, 2));              //writes payslip
		}
			
			
	}
		
}
		