using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenAlgorithmus
{
    class Individuum
    {
        public List<Gen> gens = new List<Gen>();
	    private static int numberOfGens = 0;
	    public double guete;
	
	    public static void SetNumberOfGens(int value)
	    {
		    if(numberOfGens==0)
			    numberOfGens = value;
	    }
	
	    public static int GetNumberOfGens()
	    {
		    return numberOfGens;		
	    }
	
	    public String toString()
	    {
		    String result = "X: (";
		
		    for(int i=0; i < gens.Count; i++)
		    {
			    result += gens[i].getDouble();
			    if(i < gens.Count-1)
				    result += ", ";
		    }
		    result += ") ---> RESULT: " + guete;
		
		    return result;
	    }
	
	    public Individuum()
	    {
		    for(int i=0; i < numberOfGens; i++)
		    {
			    gens.Add(new Gen());
		    }
	    }
    }
}
