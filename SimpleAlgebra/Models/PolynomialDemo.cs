using SimpleAlgebra.utils;

namespace SimpleAlgebra.Models
{
    public class PolynomialDemo
    {
        //Fields for 3rd degree polynomial 1
        public int Cubic1z1;
        public int Cubic1z2;
        public int Cubic1z3;
        public int Cubic1a;
        public int[] Cubic1Coefficients;
        public string[] Cubic1SignsAndZeroes;
        public string Cubic1SVGPath;

        //Fields for 4th degree polynomial 1 (2nd overall)
        public int Quartic2z1;
        public int Quartic2z2;
        public int Quartic2z3;
        public int Quartic2z4;
        public int Quartic2a;
        public int[] Quartic2Coefficients;
        public string[] Quartic2SignsAndZeroes;
        public string Quartic2SVGPath;

        //Default Constructor
        public PolynomialDemo()
        {
            //Fields for first 3rd degree polynomial
            Cubic1z1 = Calc.ReselectIfZero(9);
            Cubic1z2 = Calc.ReselectIfZero(9);
            Cubic1z3 = Calc.ReselectIfZero(9);
            Cubic1Coefficients = Calc.ZeroesToPolyCoefficients(new int[] { Cubic1z1, Cubic1z2, Cubic1z3 });
            Cubic1a = Calc.ReselectIfZero(1);
            Cubic1SignsAndZeroes = Calc.SignsAndZeroes(new int[] { Cubic1z1, Cubic1z2, Cubic1z3 });
            if(Cubic1a == -1)
            {
                for (int i = 0; i < 4; i++)
                {
                    Cubic1Coefficients[i] *= -1;
                }
            }
            double[] cubic1SVG = new double[] { Cubic1Coefficients[0], Cubic1Coefficients[1], Cubic1Coefficients[2], Cubic1Coefficients[3] };
            Cubic1SVGPath = SVG.SVGPolyPath(-15,15,0.1,cubic1SVG);

            //Fields for first 4th degree polynomial
            Quartic2z1 = Calc.ReselectIfZero(9);
            Quartic2z2 = Calc.ReselectIfZero(9);
            Quartic2z3 = Calc.ReselectIfZero(9);
            Quartic2z4 = Calc.ReselectIfZero(9);
            Quartic2Coefficients = Calc.ZeroesToPolyCoefficients(new int[] { Quartic2z1, Quartic2z2, Quartic2z3, Quartic2z4 });
            Quartic2a = Calc.ReselectIfZero(1);
            Quartic2SignsAndZeroes = Calc.SignsAndZeroes(new int[] { Quartic2z1, Quartic2z2, Quartic2z3, Quartic2z4 });
            if(Quartic2a == -1)
            {
                for(int i = 0; i < 5; i++)
                {
                    Quartic2Coefficients[i] *= -1;
                }
            }
            double[] quartic2SVG = new double[] { Quartic2Coefficients[0], Quartic2Coefficients[1], Quartic2Coefficients[2], Quartic2Coefficients[3], Quartic2Coefficients[4] };
            Quartic2SVGPath = SVG.SVGPolyPath(-15,15,0.1,quartic2SVG);
        }
    }
}
