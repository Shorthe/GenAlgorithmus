using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenAlgorithmus
{
    class Gleichungssystem
    {	
	    public double berechneFitness(Individuum ind)
	    {
		    if (ind.gens.Count < 3)
		    {
			    throw new Exception("Genanzahl im individuum  kleiner 3. ("+ind.gens.Count+")");
		    }		
		
		    double x1 = ind.gens[0].getDouble();
		    double x2 = ind.gens[1].getDouble();
		    double x3 = ind.gens[2].getDouble();
		
		    return berechneGleichungen(x1, x2, x3);
	    }
	
	    private double berechneGleichungen(double x1, double x2, double x3)
	    {
		    //System.out.println("X: ("+x1+", "+x2+", "+x3+")");
		    double z1 = Math.Pow(x1, 2) + 2*Math.Pow(x2, 2) -4;
		    double z2 = Math.Pow(x1, 2) + Math.Pow(x2, 2) + x3 -8;
		    double z3 = Math.Pow(x1-1, 2) + Math.Pow(2*x2 -Math.Sqrt(2), 2) + Math.Pow(x3-5, 2) -4;
		
		    //System.out.println("Z: ("+z1+", "+z2+", "+z3+") ----> RESULT: "+(Math.pow(z1, 2) + Math.pow(z2, 2) + Math.pow(z3, 2)));	
		    return Math.Pow(z1, 2) + Math.Pow(z2, 2) + Math.Pow(z3, 2);
	    }

    }
}
