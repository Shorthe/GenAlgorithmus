using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenAlgorithmus
{
    class Gen
    {
	    private static int size = 0;
	    public List<int> sequence;
        private static double gu = 0;
        private static double go = 0;
	    private static double decimalFactor;
        private Random random = new Random();
	
	    public static void setSize(int value)
	    {
		    if(size == 0)
			    size = value;		
	    }
	
	    public static int getSize()
	    {
		    return size;
	    }
	
	    public Gen()
	    {
            sequence = new List<int>();
            
            System.Console.Write("GEN: ");
		    for(int i = 0; i < size; i++)
		    {
                sequence.Add(UsefulFunctions.GenerateRandomNumber(0, 2));
		    }            
            System.Console.WriteLine(string.Join(", ", sequence.ToArray()));
	    }
	
	    public static void setIntervalBounds(double aGu, double aGo)
	    {
            gu = aGu;
            go = aGo;
		    decimalFactor = (go - gu) / (Math.Pow(2, size) - 1);
	    }
	
	    public double getDouble()
	    {	
		    double sum = 0;
		
		    for (int j = 0; j < size; j++)
		    {
			    sum+= sequence[size-j-1] * Math.Pow(2, j);
		    }
		    return gu + decimalFactor*sum;
	    }
    }
}
