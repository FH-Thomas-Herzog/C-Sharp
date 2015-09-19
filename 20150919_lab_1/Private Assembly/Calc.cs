

// Visibility definable but not required, default internal (all classes in the assembly)
public class Calc
{
	protected double sum = 0;
	protected int n = 0;

	// Method names start with upper case letter (convention)
	public void Add(double number) 
	{
		sum += number;
		n++;
	}
	
	public double GetSum() {
		return sum;
	}
}