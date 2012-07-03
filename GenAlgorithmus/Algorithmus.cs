using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenAlgorithmus
{
    class Algorithmus
    {
	// test
	    private int populationSize;
	    private Gleichungssystem gls;
	    private List<Individuum> oldPopulation;
	    private List<Individuum> newPopulation;
	    private int generations = 5;
	    private Random random = new Random();
	
	    public Algorithmus(int populationSize, Gleichungssystem aGls)
	    {
		    this.populationSize = populationSize;
		    gls = aGls;
		
		    oldPopulation = new List<Individuum>();
		    for (int i = 0; i < this.populationSize; i++)
		    {
			    oldPopulation.Add(new Individuum());
		    }
		
		    newPopulation = new List<Individuum>();
		
		    System.Console.WriteLine("Ausgangspopulation");
		    for (int j = 0; j < oldPopulation.Count; j++)
		    {
			    System.Console.WriteLine(oldPopulation[j].toString());
		    }
	    }
	
	    public void ermittleLoesung()
	    {
		    for (int i = 0; i < generations; i++)
		    {
			    System.Console.WriteLine("*******************************\nGeneration " + (i+1));
			    newPopulation.Clear();
			    // erst rekombinieren dann mutieren, 
			    // sonst hat neue Population nicht gleiche Größe wie alte Population!!!
			    recombine();
			    mutate();
			
			    for(int j = 0; j < newPopulation.Count; j++)
			    {
				    newPopulation[j].guete = gls.berechneFitness(newPopulation[j]);  
			    }

                newPopulation.OrderBy(x=>x.guete);			   
			    for (int j = 0; j < newPopulation.Count; j++)
			    {
                    System.Console.WriteLine(newPopulation[j].toString());
			    }
		    }
	    }
	
	    public void mutate()
	    {
		    Random random = new Random();

		    int size = newPopulation.Count;
		    int allelPointer;
		    for(int i=0; i < oldPopulation.Count - size; i++)
		    {
			    // ??? = anzahl der gene * länge der sequenz
			    // -> zufallszahl im intervall 0 bis ???
			    // diesen Wert in der Sequenz invertieren (nutze Int-Division zur ermittlung der Gen-Nummer und Modulo für Allel)
			    allelPointer = random.Next(Individuum.GetNumberOfGens() * Gen.getSize());
                int genNumber = allelPointer / Gen.getSize();
                int allelNumber = allelPointer - (genNumber * Gen.getSize());
                if (oldPopulation[i].gens[genNumber].sequence[allelNumber] == 1)
                    oldPopulation[i].gens[genNumber].sequence[allelNumber] = 0;
                else
                    oldPopulation[i].gens[genNumber].sequence[allelNumber] = 1;
			
		    }
	    }
	
	    public void recombine()
	    {	
		    int sequencePointer;
		    Individuum parent1;
		    Individuum parent2;
		    Individuum child1; // = new Individuum();
		    Individuum child2; // = new Individuum();
		
		
		    for(int i=0; i < 0.35 * oldPopulation.Count; i++)
		    {	
			    sequencePointer = random.Next(Gen.getSize()); 
			    child1 = new Individuum();
			    child2 = new Individuum();
			    parent1 = oldPopulation[random.Next(oldPopulation.Count)];
			    parent2 = oldPopulation[random.Next(oldPopulation.Count)];
						
			    for (int j = 0; j < parent1.gens.Count; j++)
			    {
                    child1.gens[j].sequence.Clear();
                    child2.gens[j].sequence.Clear();
				    if (sequencePointer > 0)
				    {
					    child1.gens[j].sequence.InsertRange(0, parent1.gens[j].sequence.GetRange(0, sequencePointer));
					    child2.gens[j].sequence.InsertRange(0, parent2.gens[j].sequence.GetRange(0, sequencePointer));
				    }				
				    child1.gens[j].sequence.InsertRange(sequencePointer, parent2.gens[j].sequence.GetRange(sequencePointer, Gen.getSize() - sequencePointer));
                    child2.gens[j].sequence.InsertRange(sequencePointer, parent1.gens[j].sequence.GetRange(sequencePointer, Gen.getSize() - sequencePointer));				
			    }
			
			    newPopulation.Add(child1);
			    newPopulation.Add(child2);
			
			    //Ausgabe
                System.Console.WriteLine("Pointer: " + sequencePointer);
                for (int j = 0; j < Individuum.GetNumberOfGens(); j++)
                {
                    System.Console.WriteLine("Parent1: " + string.Join(", ", parent1.gens[j].sequence.ToArray()));
                    System.Console.WriteLine("Parent2: " + string.Join(", ", parent2.gens[j].sequence.ToArray()));
                    System.Console.WriteLine("Child1: " + string.Join(", ", child1.gens[j].sequence.ToArray()));
                    System.Console.WriteLine("Child2: " + string.Join(", ", child2.gens[j].sequence.ToArray()));
                    System.Console.WriteLine("-------------------------------");
                }
		    }
	    }
	
    }

}
