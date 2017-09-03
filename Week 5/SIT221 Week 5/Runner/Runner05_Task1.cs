using System;
using DataStructures_Algorithms.Week05;

namespace Runner
{
	public class Runner05_Task1 : IRunner
	{
		
		public void Run(string[] args)
		{
			Vector<string> expression = new Vector<string>();
			expression.Add("1");
			expression.Add("2");
            expression.Add("+");
            expression.Add("4");
            expression.Add("*");
			expression.Add("5");
            expression.Add("+");
            expression.Add("3");
            expression.Add("-");

            RPNCalculator calc = new RPNCalculator(expression);
			Console.WriteLine(string.Format("Input Expression = {0}, and the result = {1}", expression.ToString(), calc.GetResult()));
		}
	}
}
