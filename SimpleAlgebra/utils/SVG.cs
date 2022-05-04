namespace SimpleAlgebra.utils
{
    public static class SVG
    {
        public static double PolyCalc(double xVal, double[] coefficients)
        {
            if(coefficients.Length == 0)
            {
                return -1.0;
            }
            double output = 0.0;
            for(int i = 0; i < coefficients.Length; i++)
            {
                int power = coefficients.Length - i - 1;
                output += coefficients[i] * Math.Pow(xVal, power);
            }
            return output;
        }
        public static string SVGPolyPath(double xStart, double xEnd, double xIncrement, double[] coefficients)
        {
            string output = "M";
            double xPos = xStart;
            double yVal;
            while(xPos < xEnd)
            {
                yVal = PolyCalc(xPos, coefficients);
                //Prevents yVal from being converted to scientific notation
                yVal = Math.Abs(yVal) < 0.00001 ? 0.0 : yVal;
                output += $"{xPos} {-yVal} L ";
                xPos += xIncrement;
            }
            yVal = PolyCalc(xEnd, coefficients);
            yVal = Math.Abs(yVal) < 0.00001 ? 0.0 : yVal;
            output += $"{xEnd} {-yVal}";
            return output;
        }
        public static bool IsAsymptotic(double numY, double denY, double limitHigh, double limitLow)
        {
            if(Math.Abs(numY/limitHigh) > Math.Abs(denY) || -Math.Abs(numY/limitLow) < -Math.Abs(denY))
            {
                return true;
            }
            return false;
        }
        public static List<string> SVGRationalPaths(double xStart, double xEnd, double xIncrement, double[] numCos, double[] denCos, double limitHigh, double limitLow)
        {
            List<string> paths = new List<string>();
            //Tracks the x position
            double xPos = xStart;
            //Tracks the y values created by numerator and denominator based on x
            double numY = PolyCalc(xPos, numCos);
            double denY = PolyCalc(xPos, denCos);
            while(Math.Abs(numY/limitHigh) > Math.Abs(denY) || -Math.Abs(numY / limitLow) < -Math.Abs(denY))
            {
                xPos += xIncrement;
                numY = PolyCalc(xPos, numCos);
                denY = PolyCalc(xPos, denCos);
            }
            double yVal = Math.Abs(numY / denY) < 0.00001 ? 0.0 : numY / denY;
            string currentPath = $"M{xPos} {-yVal}";
            while(xPos < xEnd)
            {
                //Increment x
                xPos += xIncrement;
                //Calculate numerator and denominator values
                numY = PolyCalc(xPos, numCos);
                denY = PolyCalc(xPos, denCos);
                //Check to see if value is asymptotic
                if(IsAsymptotic(numY, denY, limitHigh, limitLow))
                {
                    paths.Add(currentPath);
                    while(IsAsymptotic(numY, denY, limitHigh, limitLow))
                    {
                        xPos += xIncrement;
                        numY = PolyCalc(xPos, numCos);
                        denY = PolyCalc(xPos, denCos);
                    }
                    yVal = Math.Abs(numY / denY) < 0.00001 ? 0.0 : numY / denY;
                    currentPath = $"M{xPos} {-yVal}";
                }
                else
                {
                    yVal = Math.Abs(numY / denY) < 0.00001 ? 0.0 : numY / denY;
                    currentPath += $" L {xPos} {-yVal}";
                }
            }
            xPos = xEnd;
            numY = PolyCalc(xPos, numCos);
            denY = PolyCalc(xPos, denCos);
            if(!IsAsymptotic(numY, denY, limitHigh, limitLow))
            {
                yVal = Math.Abs(numY / denY) < 0.00001 ? 0.0 : numY / denY;
                currentPath += $" L {xPos} {-yVal}";
            }
            paths.Add(currentPath);
            return paths;
        }
    }
}
