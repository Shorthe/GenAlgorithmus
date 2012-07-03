using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GenAlgorithmus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Individuum.SetNumberOfGens(3);
            Gen.setSize(8);
            Gen.setIntervalBounds(-100, 100);


            //new Gleichungssystem().berechneFitness(new Individuum());
            new Algorithmus(10, new Gleichungssystem()).ermittleLoesung();
        }
    }
}
