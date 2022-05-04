using SimpleAlgebra.utils;

namespace SimpleAlgebra.Models
{
    public class QuadraticDemo
    {
        public string DoubleUniqueReal1;
        public int Zero1A;
        public int Zero1B;
        public int[] QuadCos1;
        public double[] DoubleQuadCos1;

        public QuadraticDemo()
        {
            Zero1A = Calc.ReselectIfZero(6);
            Zero1B = Calc.ReselectIfZero(6);
            while(Zero1A == Zero1B)
            {
                Zero1B = Calc.ReselectIfZero(6);
            }
            QuadCos1 = Calc.ZeroesToPolyCoefficients(new int[] { Zero1A, Zero1B });
            DoubleQuadCos1 = new double[] { (double)QuadCos1[0], (double)QuadCos1[1], (double)QuadCos1[2] };
            DoubleUniqueReal1 = SVG.SVGPolyPath(-12.0, 12.0, 0.1, DoubleQuadCos1);
        }
    }
}
