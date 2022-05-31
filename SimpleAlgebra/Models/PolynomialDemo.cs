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

        //Fields for repeated roots and flattening of function
        public int LinearRoot3;
        public int QuadraticRoot3;
        public int CubicRoot3;
        public int QuarticRoot3;
        public int LRCo3, QDRCo3, CRCo3, QRTCo3;
        public string LRSVG3, QDRSVG3, CRSVG3, QRTSVG3; //SVG paths for the functions
        public int[] LinCos3, QuadCos3, CubCos3, QuartCos3; //Holds the coefficients of the polynomials

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

            //Fields for repeated root example
            LinearRoot3 = Calc.ReselectIfZero(10);
            QuadraticRoot3 = Calc.ReselectIfZero(10);
            CubicRoot3 = Calc.ReselectIfZero(10);
            QuarticRoot3 = Calc.ReselectIfZero(10);
            LRCo3 = Calc.ReselectIfZero(4);
            QDRCo3 = Calc.ReselectIfZero(1);
            CRCo3 = Calc.ReselectIfZero(1);
            QRTCo3 = Calc.ReselectIfZero(1);
            //Get coefficients to use in each of the function SVG drawings
            LinCos3 = Calc.ZeroesToPolyCoefficients(new int[] { LinearRoot3 });
            QuadCos3 = Calc.ZeroesToPolyCoefficients(new int[] { QuadraticRoot3, QuadraticRoot3 });
            CubCos3 = Calc.ZeroesToPolyCoefficients(new int[] { CubicRoot3, CubicRoot3, CubicRoot3 });
            QuartCos3 = Calc.ZeroesToPolyCoefficients(new int[] { QuarticRoot3, QuarticRoot3, QuarticRoot3, QuarticRoot3 });
            for(int i = 0; i < LinCos3.Length; i++)
            {
                LinCos3[i] *= LRCo3;
            }
            for(int i = 0; i < QuadCos3.Length; i++)
            {
                QuadCos3[i] *= QDRCo3;
            }
            for(int i = 0; i < CubCos3.Length; i++)
            {
                CubCos3[i] *= CRCo3;
            }
            for(int i = 0; i < QuartCos3.Length; i++)
            {
                QuartCos3[i] *= QRTCo3;
            }
            //Transform the integer arrays into double arrays
            double[] lc3 = new double[] { LinCos3[0], LinCos3[1] };
            double[] qdc3 = new double[] { QuadCos3[0], QuadCos3[1], QuadCos3[2] };
            double[] cc3 = new double[] { CubCos3[0], CubCos3[1], CubCos3[2], CubCos3[3] };
            double[] qrc3 = new double[] { QuartCos3[0], QuartCos3[1], QuartCos3[2], QuartCos3[3], QuartCos3[4] };
            //Create SVG path d properties
            LRSVG3 = SVG.SVGPolyPath(-15, 15, 0.5, lc3);
            QDRSVG3 = SVG.SVGPolyPath(-15, 15, 0.1, qdc3);
            CRSVG3 = SVG.SVGPolyPath(-15, 15, 0.1, cc3);
            QRTSVG3 = SVG.SVGPolyPath(-15, 15, 0.1, qrc3);
        }
    }
}
