using SimpleAlgebra.utils;

namespace SimpleAlgebra.Models
{
    public class QuadraticDemo
    {
        //Two real roots
        public string DoubleUniqueReal1; //String that contains the SVG path
        public int Zero1A; //Zero 1 of function
        public int Zero1B; //Zero 2 of function
        public int[] QuadCos1; //Integer coefficients of the function
        public double[] DoubleQuadCos1; //Double coefficients of the function

        //One double root
        public string SingleUniqueReal2;
        public int ACo2; //This will be -1 or 1
        public int Zero2;
        public int[] QuadCos2;
        public double[] SingleQuadCos2;

        //No real roots
        public string ZeroReal3;
        public int ACo3;
        public int BCo3;
        public int CCo3;
        public double[] ZeroQuadCos3;

        //Factored Instances
        //Two Unique Real
        public int Zero4A;
        public int Zero4B;
        public int ACo4;
        public string AOS4;
        public string VY4;
        public int[] QuadCos4;
        public double[] DoubleQuadCos4;
        public string DoubleUniqueReal4;

        //Double Real
        public int Zero5; //Double zero
        public int ACo5; //Leading coefficient
        public int[] QuadCos5; //Holds integer coefficients of the function
        public double[] DoubleQuadCos5; //The double versions of the coefficients
        public string SingleUniqueReal5; //Path string for 5th function

        public QuadraticDemo()
        {
            //2 Unique real roots
            Zero1A = Calc.ReselectIfZero(6);
            Zero1B = Calc.ReselectIfZero(6);
            while(Zero1A == Zero1B)
            {
                Zero1B = Calc.ReselectIfZero(6);
            }
            QuadCos1 = Calc.ZeroesToPolyCoefficients(new int[] { Zero1A, Zero1B });
            DoubleQuadCos1 = new double[] { (double)QuadCos1[0], (double)QuadCos1[1], (double)QuadCos1[2] };
            DoubleUniqueReal1 = SVG.SVGPolyPath(-12.0, 12.0, 0.1, DoubleQuadCos1);

            //1 Unique real root (double)
            Zero2 = Calc.ReselectIfZero(8);
            ACo2 = Calc.ReselectIfZero(1);
            QuadCos2 = Calc.ZeroesToPolyCoefficients(new int[] { Zero2, Zero2 });
            //Multiply by -1 or 1 depending on ACo2
            for(int i = 0; i < 3; i++)
            {
                QuadCos2[i] *= ACo2;
            }
            SingleQuadCos2 = new double[] { (double)QuadCos2[0], (double)QuadCos2[1], (double)QuadCos2[2] };
            SingleUniqueReal2 = SVG.SVGPolyPath(-15, 15, 0.1, SingleQuadCos2);

            //0 real roots
            ACo3 = Calc.ReselectIfZero(2);
            CCo3 = ACo3 < 0 ? -Math.Abs(Calc.ReselectIfZero(8)) : Math.Abs(Calc.ReselectIfZero(8));
            BCo3 = Calc.ReselectIfZero(6);
            while(BCo3*BCo3 >= 4 * ACo3 * CCo3)
            {
                BCo3 = Calc.ReselectIfZero(6);
            }
            ZeroQuadCos3 = new double[] { (double)ACo3, (double)BCo3, (double)CCo3 };
            ZeroReal3 = SVG.SVGPolyPath(-15, 15, 0.1, ZeroQuadCos3);

            //Factored 2 unique roots
            ACo4 = Calc.ReselectIfZero(2);
            Zero4A = Calc.ReselectIfZero(6);
            Zero4B = Calc.ReselectIfZero(6);
            while(Zero4B == Zero4A)
            {
                Zero4B = Calc.ReselectIfZero(6);
            }
            int rootSum4 = Zero4A + Zero4B;
            AOS4 = rootSum4 % 2 == 0 ? $"{rootSum4 / 2}" : $"{rootSum4 / 2}.5";
            double h4 = rootSum4/(double)2;
            QuadCos4 = Calc.ZeroesToPolyCoefficients(new int[] { Zero4A, Zero4B });
            for(int i = 0; i < QuadCos4.Length; i++)
            {
                QuadCos4[i] *= ACo4;
            }
            DoubleQuadCos4 = new double[] { QuadCos4[0], QuadCos4[1], QuadCos4[2] };
            DoubleUniqueReal4 = SVG.SVGPolyPath(-15, 15, 0.1, DoubleQuadCos4);
            //Console.WriteLine($"h4: {h4}");
            double vk4 = SVG.PolyCalc(h4, DoubleQuadCos4); //double value of vertex y-coefficient
            //string s = String.Format("Computed vk4: {0}", vk4.ToString());
            //Console.WriteLine(s);
            //Get the y-coordinate of vertex with no extraneous decimals
            if(rootSum4%2 == 0)
            {
                VY4 = $"{Math.Round(vk4)}";
            }
            else if(Math.Abs(ACo4) == 2)
            {
                //Console.WriteLine($"vk4: {vk4}");
                if(vk4 > -1 && vk4 < 0)
                {
                    VY4 = "-0.5";
                }
                else
                {
                    VY4 = $"{Math.Round(vk4)}.5";
                }
            }
            else
            {
                //Console.WriteLine($"vk4: {vk4}");
                if (vk4 > -1 && vk4 < 0)
                {
                    VY4 = "-0.25";
                }
                else
                {
                    VY4 = $"{Math.Round(vk4)}.25";
                }
            }

            //Factored single root but doubled
            Zero5 = Calc.ReselectIfZero(8);
            ACo5 = Calc.ReselectIfZero(2);
            QuadCos5 = Calc.ZeroesToPolyCoefficients(new int[] { Zero5, Zero5 });
            for(int i = 0; i < 3; i++)
            {
                QuadCos5[i] *= ACo5;
            }
            DoubleQuadCos5 = new double[] { QuadCos5[0], QuadCos5[1], QuadCos5[2] };
            SingleUniqueReal5 = SVG.SVGPolyPath(-15, 15, 0.1, DoubleQuadCos5);
        }
    }
}
