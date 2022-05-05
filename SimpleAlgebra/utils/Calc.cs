using System;

namespace SimpleAlgebra.utils
{
    public static class Calc
    {

        public static int ReselectIfZero(int limit = 12)
        {
            int newLimit = limit == 0 ? 12 : (limit < 0 ? -limit : limit);
            var rand = new Random();
            int output = -newLimit + (int) Math.Floor(rand.NextDouble() * (2*newLimit + 1));
            while(output == 0)
            {
                output = -newLimit + (int)Math.Floor(rand.NextDouble() * (2 * newLimit + 1));
            }
            return output;
        }

        public static int[] IntersectingCos(int limit = 12)
        {
            int newLimit = limit == 0 ? 12 : (limit < 0 ? -limit : limit);
            int a1, a2, b1, b2;
            a1 = ReselectIfZero(newLimit);
            a2 = ReselectIfZero(newLimit);
            b1 = ReselectIfZero(newLimit);
            b2 = ReselectIfZero(newLimit);
            while(a1*b2 == a2*b1)
            {
                a1 = ReselectIfZero(newLimit);
                a2 = ReselectIfZero(newLimit);
                b1 = ReselectIfZero(newLimit);
                b2 = ReselectIfZero(newLimit);
            }
            return new int[] { a1, a2, b1, b2 };
        }

        public static int[] ReducedArray(int[] inputArray)
        {
            int[] positives = new int[inputArray.Length];
            int min = int.MaxValue;
            for(int i = 0; i < inputArray.Length; i++)
            {
                if(inputArray[i] < 0)
                {
                    positives[i] = -inputArray[i];
                    if(positives[i] < min)
                    {
                        min = positives[i];
                    }
                } 
                else
                {
                    positives[i] = inputArray[i];
                    if(positives[i] < min)
                    {
                        min = positives[i];
                    }
                }
            }
            if(min <= 1)
            {
                return inputArray;
            }
            int current = 1;
            while(current < min)
            {
                current++;
                int count = 0;
                for(int i = 0; i < positives.Length; i++)
                {
                    if(positives[i]%current == 0)
                    {
                        count++;
                    }
                }
                if(count == positives.Length)
                {
                    for(int i = 0; i < positives.Length; i++)
                    {
                        positives[i] = positives[i] / current;
                    }
                    current--;
                }
            }
            for(int i = 0; i < positives.Length; i++)
            {
                if(inputArray[i] < 0)
                {
                    positives[i] = -positives[i];
                }
            }
            return positives;
        }

        public static string[] StandardCoefficients(int[] coefficients)
        {
            string coA, coB, sign;
            if(coefficients[0] == 1)
            {
                coA = "";
            }
            else if(coefficients[0] == -1)
            {
                coA = "-";
            }
            else
            {
                coA = $"{coefficients[0]}";
            }

            if(coefficients[1] == 1)
            {
                coB = "";
                sign = " + ";
            }
            else if(coefficients[1] == -1)
            {
                coB= "";
                sign = " - ";
            }
            else if(coefficients[1] < 0)
            {
                coB = $"{-coefficients[1]}";
                sign = " - ";
            }
            else
            {
                coB = $"{coefficients[1]}";
                sign = " + ";
            }
            return new string[] { coA, coB, sign, $"{coefficients[2]}" };
        }

        public static int GreatestCommonFactor(int[] inputArray)
        {
            if(inputArray.Length == 0)
            {
                return -1;
            }
            int[] reduced = ReducedArray(inputArray);
            return inputArray[0] / reduced[0];
        }

        public static int RandomPositive(int limit)
        {
            int newLimit = limit <= 0 ? 11 : limit + 1;
            Random rand = new Random();
            return (int)(Math.Floor(rand.NextDouble() * newLimit));
        }

        public static string[] StandardCoefficients(int[] coefficients, int replaceIndex)
        {
            string coA, coB, sign, coC;
            if(replaceIndex == 0)
            {
                coA = "A";
            }
            else if (coefficients[0] == 1)
            {
                coA = "";
            }
            else if (coefficients[0] == -1)
            {
                coA = "-";
            }
            else
            {
                coA = $"{coefficients[0]}";
            }

            if(replaceIndex == 1)
            {
                coB = "B";
                sign = " + ";
            }
            else if (coefficients[1] == 1)
            {
                coB = "";
                sign = " + ";
            }
            else if (coefficients[1] == -1)
            {
                coB = "";
                sign = " - ";
            }
            else if (coefficients[1] < 0)
            {
                coB = $"{-coefficients[1]}";
                sign = " - ";
            }
            else
            {
                coB = $"{coefficients[1]}";
                sign = " + ";
            }

            if(replaceIndex == 2)
            {
                coC = "C";
            } else
            {
                coC = $"{coefficients[2]}";
            }
            return new string[] { coA, sign, coB, coC };
        }

        public static int[] PerpendicularCoefficients(int limit, int multLimit = 5)
        {
            //Returns coefficients A,B for perpendicular lines based on input limits
            int[] reducedCos1 = ReducedArray(new int[] { ReselectIfZero(limit), ReselectIfZero(limit) });
            //Ensure that multiple has sufficient range
            int newMult = Math.Abs(multLimit) < 2 ? 5 : Math.Abs(multLimit);
            int useMult = ReselectIfZero(newMult);
            //Ensure that mutliple is not -1 or 1
            while (Math.Abs(useMult) == 1)
            {
                useMult = ReselectIfZero(newMult);
            }
            Random rand = new Random();
            int swap = rand.NextDouble() < 0.5 ? 0 : 1;
            int coA, coB;
            if (swap == 0)
            {
                coA = -useMult * reducedCos1[1];
                coB = useMult * reducedCos1[0];
            }
            else
            {
                coA = useMult * reducedCos1[1];
                coB = -useMult * reducedCos1[0];
            }
            return new int[] { reducedCos1[0], reducedCos1[1], coA, coB };
        }

        public static int[] ZeroesToPolyCoefficients(int[] zeroes)
        {
            if(zeroes.Length == 0)
            {
                return new int[] { 1, 1 };
            }
            else if(zeroes.Length == 1)
            {
                return new int[] { 1, -zeroes[0] };
            }
            //Set the index of the zero array
            int index = 1;
            //Set the current state of the coefficients array
            int[] current = new int[] { 1, -zeroes[0] };
            //Loop through the zeroes
            while(index < zeroes.Length)
            {
                int[] nextArr = new int[current.Length + 1];
                //Populate the nextArr with zeroes
                for(int i = 0; i < nextArr.Length; i++)
                {
                    nextArr[i] = 0;
                }
                int[] currentZero = new int[] { 1, -zeroes[index] };
                for(int i = 0; i < current.Length; i++)
                {
                    for(int j = 0; j < currentZero.Length; j++)
                    {
                        nextArr[i + j] += current[i] * currentZero[j];
                    }
                }
                current = nextArr;
                index++;
            }
            return current;
        }
        public static string LinearZeroFactor(int zero)
        {
            if(zero == 0)
            {
                return "x";
            }
            else if(zero < 0)
            {
                return $"x+{-zero}";
            }
            else
            {
                return $"x-{zero}";
            }
        }
        public static string EliminateSpaces(string str)
        {
            if(str.Length == 0)
            {
                return str;
            }
            return str.Replace(" ", "");
        }

        public static int RandomPositiveInt(int lower = 1, int upper = 12)
        {
            Random rand = new Random();
            return rand.Next(lower, upper + 1);
        }
    }
}
