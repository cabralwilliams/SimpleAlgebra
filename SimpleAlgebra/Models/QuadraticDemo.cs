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

        //Vertex Instances
        //On Axis
        public int VACo0;
        public int VHCo0;
        public string VPath0;
        public int[] VInt0;
        public double[] VDouble0;

        //First Quadrant
        public int VACo1;
        public int VHCo1;
        public int VKCo1;
        public string VPath1;
        public int[] VInt1;
        public double[] VDouble1;

        //Second Quadrant
        public int VACo2;
        public int VHCo2;
        public int VKCo2;
        public string VPath2;
        public int[] VInt2;
        public double[] VDouble2;

        //Third Quadrant
        public int VACo3;
        public int VHCo3;
        public int VKCo3;
        public string VPath3;
        public int[] VInt3;
        public double[] VDouble3;

        //Fourth Quadrant
        public int VACo4;
        public int VHCo4;
        public int VKCo4;
        public string VPath4;
        public int[] VInt4;
        public double[] VDouble4;

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

            //Vertex 0
            VACo0 = Calc.ReselectIfZero(2);
            VHCo0 = Calc.ReselectIfZero(8);
            VInt0 = Calc.ZeroesToPolyCoefficients(new int[] { VHCo0, VHCo0 });
            for(int i = 0; i < 3; i++)
            {
                VInt0[i] *= VACo0;
            }
            VDouble0 = new double[] { VInt0[0], VInt0[1], VInt0[2] };
            VPath0 = SVG.SVGPolyPath(-15,15,0.1, VDouble0);

            //Vertex 1
            VACo1 = Calc.ReselectIfZero(2);
            VHCo1 = Calc.RandomPositiveInt();
            VKCo1 = Calc.RandomPositiveInt(1, 8);
            VInt1 = Calc.ZeroesToPolyCoefficients(new int[] { VHCo1, VHCo1 });
            for(int i = 0; i < 3; i++)
            {
                VInt1[i] *= VACo1;
            }
            VInt1[2] += VKCo1;
            VDouble1 = new double[] { VInt1[0], VInt1[1], VInt1[2] };
            VPath1 = SVG.SVGPolyPath(-15, 15, 0.1, VDouble1);

            //Vertex 2
            VACo2 = Calc.ReselectIfZero(2);
            VHCo2 = -Calc.RandomPositiveInt();
            VKCo2 = Calc.RandomPositiveInt(1, 8);
            VInt2 = Calc.ZeroesToPolyCoefficients(new int[] { VHCo2, VHCo2 });
            for (int i = 0; i < 3; i++)
            {
                VInt2[i] *= VACo2;
            }
            VInt2[2] += VKCo2;
            VDouble2 = new double[] { VInt2[0], VInt2[1], VInt2[2] };
            VPath2 = SVG.SVGPolyPath(-15, 15, 0.1, VDouble2);

            //Vertex 3
            VACo3 = Calc.ReselectIfZero(2);
            VHCo3 = -Calc.RandomPositiveInt();
            VKCo3 = -Calc.RandomPositiveInt(1, 8);
            VInt3 = Calc.ZeroesToPolyCoefficients(new int[] { VHCo3, VHCo3 });
            for (int i = 0; i < 3; i++)
            {
                VInt3[i] *= VACo3;
            }
            VInt3[2] += VKCo3;
            VDouble3 = new double[] { VInt3[0], VInt3[1], VInt3[2] };
            VPath3 = SVG.SVGPolyPath(-15, 15, 0.1, VDouble3);

            //Vertex 4
            VACo4 = Calc.ReselectIfZero(2);
            VHCo4 = Calc.RandomPositiveInt();
            VKCo4 = -Calc.RandomPositiveInt(1, 8);
            VInt4 = Calc.ZeroesToPolyCoefficients(new int[] { VHCo4, VHCo4 });
            for (int i = 0; i < 3; i++)
            {
                VInt4[i] *= VACo4;
            }
            VInt4[2] += VKCo4;
            VDouble4 = new double[] { VInt4[0], VInt4[1], VInt4[2] };
            VPath4 = SVG.SVGPolyPath(-15, 15, 0.1, VDouble4);
        }
    }
}
