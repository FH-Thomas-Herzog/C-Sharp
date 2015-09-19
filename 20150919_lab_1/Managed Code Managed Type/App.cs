using System;

public class App 
{
	public static void Main(string[] args)
	{
		// using ensures call of diposable in any cases
		using (Calc c = new Calc())
		{
			c.Add(5);
			c.Add(10);
			c.Add(15);
			c.Add(20);
			
			Console.WriteLine("Sum {0:f2}", c.GetSum());				
		}
		
		// only is no using but not ensured that always called
		c.Dispose();
	}
}