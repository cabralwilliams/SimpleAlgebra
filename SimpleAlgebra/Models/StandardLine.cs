using SimpleAlgebra.utils;

namespace SimpleAlgebra.Models
{
    public class StandardLine
    {
        //Fields for first question type
        public int[] standardCefficients1 = Calc.IntersectingCos(12);
        public int[] standardSolution1 = { Calc.ReselectIfZero(8), Calc.ReselectIfZero(8) };
        public string[] sLineCos1A;
        public string[] sLineCos1B;
        public string[] sLineAnswers1;
        public string messageLS1 = "";

        //Fields for second question type
        public int[] sLCos2A; //Coefficients for first line
        public int sL2Multiple; //Multiple used to generate second line
        public int[] referencePtSL2; //Reference point for first line
        public string[] sLineCos2A; //Coefficient array for first line
        public string[] sLineCos2B; //Coefficient array for second line
        public int sL2CA; //C coefficient for first line
        public int sL2CB; //C coefficient for second line
        public string questionSL2; //Question string
        public int missingSelectorSL2 = Calc.RandomPositive(4); //Sets the coefficient to be removed
        public int[] sL2solutions;
        public string messageLS2 = "";

        //Fields for third question type - perpendicular lines
        public int[] sLCos3; //The coefficients, A,B, for the lines
        public int[] referencePtSL3; //The intersection point
        public int misslingSelectorSL3 = Calc.RandomPositive(3); //Determines which coefficient to remove
        public int[] sL3solutions; //Solution array - will hold only one value
        public string questionSL3; //Question string
        public string[] sLineCos3A; //Coefficient array for first line
        public string[] sLineCos3B; //Coefficient array for second line
        public StandardLine()
        {
            Random rand = new Random();
            //Automatically create field values for first question type
            int coA1 = this.standardCefficients1[0];
            int coB1 = this.standardCefficients1[2];
            int coA2 = this.standardCefficients1[1];
            int coB2 = this.standardCefficients1[3];
            int coC1 = this.standardSolution1[0] * coA1 + this.standardSolution1[1] * coB1;
            int coC2 = this.standardSolution1[0] * coA2 + this.standardSolution1[1] * coB2;
            sLineCos1A = Calc.StandardCoefficients(new int[] { coA1, coB1, coC1 });
            sLineCos1B = Calc.StandardCoefficients(new int[] { coA2, coB2, coC2 });
            sLineAnswers1 = new string[] { $"({this.standardSolution1[0]},{this.standardSolution1[1]})", $"{this.standardSolution1[0]},{this.standardSolution1[1]}", $"({this.standardSolution1[0]}, {this.standardSolution1[1]})", $"{this.standardSolution1[0]}, {this.standardSolution1[1]}" };
            
            //Populate field values for second question type
            sLCos2A = Calc.ReducedArray(new int[] { Calc.ReselectIfZero(12), Calc.ReselectIfZero(12) });
            sL2Multiple = Calc.ReselectIfZero(4);
            referencePtSL2 = new int[] { Calc.ReselectIfZero(8), Calc.ReselectIfZero(8) };
            sL2CA = sLCos2A[0] * referencePtSL2[0] + sLCos2A[1] * referencePtSL2[1];
            sL2CB = (sLCos2A[0] * referencePtSL2[0] + sLCos2A[1] * referencePtSL2[1])*sL2Multiple + Calc.ReselectIfZero(10);
            int sl2AnswerVal;
            if(missingSelectorSL2 == 0)
            {
                sLineCos2A = Calc.StandardCoefficients(new int[] { sLCos2A[0], sLCos2A[1], sL2CA }, 0);
                sLineCos2B = Calc.StandardCoefficients(new int[] { sLCos2A[0]*sL2Multiple, sLCos2A[1]*sL2Multiple, sL2CB }, -1);
                questionSL2 = "If the system of equations above has no solution, what is the value of A?";
                sl2AnswerVal = sLCos2A[0];
            }
            else if(missingSelectorSL2 == 1)
            {
                sLineCos2A = Calc.StandardCoefficients(new int[] { sLCos2A[0], sLCos2A[1], sL2CA }, 1);
                sLineCos2B = Calc.StandardCoefficients(new int[] { sLCos2A[0] * sL2Multiple, sLCos2A[1] * sL2Multiple, sL2CB }, -1);
                questionSL2 = "If the system of equations above has no solution, what is the value of B?";
                sl2AnswerVal = sLCos2A[1];
            }
            else if(missingSelectorSL2 == 2)
            {
                sLineCos2A = Calc.StandardCoefficients(new int[] { sLCos2A[0], sLCos2A[1], sL2CA }, -1);
                sLineCos2B = Calc.StandardCoefficients(new int[] { sLCos2A[0] * sL2Multiple, sLCos2A[1] * sL2Multiple, sL2CB }, 0);
                questionSL2 = "If the system of equations above has no solution, what is the value of A?";
                sl2AnswerVal = sLCos2A[0] * sL2Multiple;
            }
            else if(missingSelectorSL2 == 3)
            {
                sLineCos2A = Calc.StandardCoefficients(new int[] { sLCos2A[0], sLCos2A[1], sL2CA }, -1);
                sLineCos2B = Calc.StandardCoefficients(new int[] { sLCos2A[0] * sL2Multiple, sLCos2A[1] * sL2Multiple, sL2CB }, 1);
                questionSL2 = "If the system of equations above has no solution, what is the value of B?";
                sl2AnswerVal = sLCos2A[1] * sL2Multiple;
            }
            else
            {
                sLineCos2A = Calc.StandardCoefficients(new int[] { sLCos2A[0], sLCos2A[1], sL2CA }, -1);
                sLineCos2B = Calc.StandardCoefficients(new int[] { sLCos2A[0] * sL2Multiple, sLCos2A[1] * sL2Multiple, sL2CB }, 2);
                questionSL2 = "If the system of equations above has no solution, what value can C NOT be?";
                sl2AnswerVal = sL2CA * sL2Multiple;
            }
            sL2solutions = new int[] { sl2AnswerVal };

            //Populate fields for third question type
            sLCos3 = Calc.PerpendicularCoefficients(12, 5);
            referencePtSL3 = new int[] { Calc.ReselectIfZero(12), Calc.ReselectIfZero(12) };
            int sL3CA = sLCos3[0] * referencePtSL3[0] + sLCos3[1] * referencePtSL3[1];
            int sL3CB = sLCos3[2] * referencePtSL3[0] + sLCos3[3] * referencePtSL3[1];
            string sL3Insert = rand.NextDouble() < 0.5 ? "intersect at a 90 degree angle" : "are perpendicular";
            if(misslingSelectorSL3 == 0)
            {
                sLineCos3A = Calc.StandardCoefficients(new int[] { sLCos3[0], sLCos3[1], sL3CA }, 0);
                sLineCos3B = Calc.StandardCoefficients(new int[] { sLCos3[2], sLCos3[3], sL3CB }, -1);
                questionSL3 = $"If the two lines above {sL3Insert}, what is the value of A?";
            } else if(misslingSelectorSL3 == 1)
            {
                sLineCos3A = Calc.StandardCoefficients(new int[] { sLCos3[0], sLCos3[1], sL3CA }, 1);
                sLineCos3B = Calc.StandardCoefficients(new int[] { sLCos3[2], sLCos3[3], sL3CB }, -1);
                questionSL3 = $"If the two lines above {sL3Insert}, what is the value of B?";
            }
            else if(misslingSelectorSL3 == 2)
            {
                sLineCos3A = Calc.StandardCoefficients(new int[] { sLCos3[0], sLCos3[1], sL3CA }, -1);
                sLineCos3B = Calc.StandardCoefficients(new int[] { sLCos3[2], sLCos3[3], sL3CB }, 0);
                questionSL3 = $"If the two lines above {sL3Insert}, what is the value of A?";
            }
            else
            {
                sLineCos3A = Calc.StandardCoefficients(new int[] { sLCos3[0], sLCos3[1], sL3CA }, -1);
                sLineCos3B = Calc.StandardCoefficients(new int[] { sLCos3[2], sLCos3[3], sL3CB }, 1);
                questionSL3 = $"If the two lines above {sL3Insert}, what is the value of B?";
            }
            sL3solutions = new int[] { sLCos3[misslingSelectorSL3] };
        }

        public void CheckSL1(string studentResponseLS1)
        {
            bool matchFound = false;
            for(int i = 0; i < sLineAnswers1.Length; i++)
            {
                if (studentResponseLS1.Equals(sLineAnswers1[i]))
                {
                    matchFound = true;
                    break;
                }
            }
            if (matchFound)
            {
                messageLS1 = $"Correct!  {studentResponseLS1} is a correct answer!";
            }
            else
            {
                messageLS1 = $"Incorrect.  {studentResponseLS1} is not correct.  One correct answer is {sLineAnswers1[0]}.";
            }
        }

        //Reset to run again
        public void ResetStandard1()
        {
            standardCefficients1 = Calc.IntersectingCos(12);
            standardSolution1 = new int[] { Calc.ReselectIfZero(8), Calc.ReselectIfZero(8) };
            int coA1 = this.standardCefficients1[0];
            int coB1 = this.standardCefficients1[2];
            int coA2 = this.standardCefficients1[1];
            int coB2 = this.standardCefficients1[3];
            int coC1 = this.standardSolution1[0] * coA1 + this.standardSolution1[1] * coB1;
            int coC2 = this.standardSolution1[0] * coA2 + this.standardSolution1[1] * coB2;
            sLineCos1A = Calc.StandardCoefficients(new int[] { coA1, coB1, coC1 });
            sLineCos1B = Calc.StandardCoefficients(new int[] { coA2, coB2, coC2 });
            sLineAnswers1 = new string[] { $"({this.standardSolution1[0]},{this.standardSolution1[1]})", $"{this.standardSolution1[0]},{this.standardSolution1[1]}", $"({this.standardSolution1[0]}, {this.standardSolution1[1]})", $"{this.standardSolution1[0]}, {this.standardSolution1[1]}" };
            messageLS1 = "";
        }

        public void CheckSL2(int studentResponse2)
        {
            bool matchFound = false;
            if(studentResponse2 == this.sL2solutions[0])
            {
                matchFound = true;
                messageLS2 = $"Correct!  Your answer of {studentResponse2} is correct!";
            }
            if(!matchFound)
            {
                messageLS2 = $"Incorrect.  Your answer {studentResponse2} is incorrect.  The correct answer is {this.sL2solutions[0]}.";
            }
        }
    }
}
