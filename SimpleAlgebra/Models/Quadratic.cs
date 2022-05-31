using SimpleAlgebra.utils;

namespace SimpleAlgebra.Models
{
    public class Quadratic
    {
        //Create standard form fields
        public int[] qSF1Coefficients; //First question coefficients
        public int qSF1z1; //First zero of quadratic
        public int qSF1z2; //Second zero of quadratic
        public string qSF1question; //String to hold first standard form question
        public string qSF1answers; //Two different ways answer can be written, separated by comma
        public bool qSF1eliminateMiddle; //Determines whether the linear coefficient was eliminated

        //Second practice problem fields
        public int[] qSF2Coefficients; //Holds the coefficients
        public int qSF2z1; //First zero
        public int qSF2z2; //second zero
        public int qSF2A; //Leading coefficient of function
        public int qSF2answer; //Answer to question
        public bool qSF2eliminateMiddle; //Determines whether linear coefficient was eliminated

        //Third practice problem fields
        public int qSF3A; //Coefficient A
        public int qSF3B; //Coefficient B
        public int qSF3C; //Coefficient C
        public int qSF3Discriminant; //Discriminant
        public int qSF3answer; //Answer to question

        //Fourth practice problem - First Factored
        public int Fact1z1; //First zero
        public int Fact1z2; //Second zero
        public int Fact1a; //Leading coefficient
        public string FactLead1; //Leading string coefficient
        public string Fact1answer; //String version of answer

        //Fifth practice problem - Second Factored
        public int Fact2z1; //First zero
        public int Fact2z2; //Second zero
        public int Fact2a; //Leading coefficient
        public string FactLead2; //Leading string coefficient
        public int Fact2answer; //String version of answer

        //Sixth practice problem - Third Factored
        public int Fact3z1; //First zero
        public int Fact3z2; //Second zero
        public int Fact3a; //Leading coefficient
        public string FactLead3; //Leading string coefficient
        public string Fact3answer; //String version of answer

        //Seventh practice problem - First Vertex
        public int Vert1H; //h coefficient of first problem
        public int Vert1K; //k coefficient of first problem
        public int Vert1A; //a coefficient of first problem
        public string Vert1Answer; //Stores the answer to the first problem

        //Eighth practice problem - Second Vertex
        public int Vert2H; //h coefficient of second problem
        public int Vert2K; //k coefficient of second problem
        public int Vert2A; //a coefficient of second problem
        public int Vert2Answer; //Stores the answer to the second problem

        //Ninth practice problem - Third Vertex
        public int Vert3H; //h coefficient of third problem
        public int Vert3K; //k coefficient of third problem
        public int Vert3A; //a coefficient of third problem
        public int Vert3AnswerA; //First root
        public int Vert3AnswerB; //Second root

        //Default constructor
        public Quadratic()
        {
            Random rand = new Random();
            //First question fields
            qSF1z1 = Calc.ReselectIfZero(12);
            qSF1z2 = Calc.ReselectIfZero(12);
            qSF1eliminateMiddle = qSF1z1 + qSF1z2 == 0;
            qSF1Coefficients = Calc.ZeroesToPolyCoefficients(new int[] {qSF1z1, qSF1z2});
            qSF1question = "Factor the above quadratic expression.";
            string qSF1f1 = Calc.LinearZeroFactor(qSF1z1);
            string qSF1f2 = Calc.LinearZeroFactor(qSF1z2);
            qSF1answers = $"({qSF1f1})({qSF1f2}),({qSF1f2})({qSF1f1})";

            //Second question fields
            qSF2z1 = Calc.ReselectIfZero(16);
            qSF2z2 = Calc.ReselectIfZero(16);
            qSF2answer = qSF2z1 + qSF2z2;
            qSF2A = Calc.ReselectIfZero(2);
            qSF2Coefficients = Calc.ZeroesToPolyCoefficients(new int[] {qSF2z1, qSF2z2});
            for(int i = 0; i < qSF2Coefficients.Length; i++)
            {
                qSF2Coefficients[i] *= qSF2A; //Scale each coefficient according to leading coefficient
            }
            qSF2eliminateMiddle = qSF2z1 + qSF2z2 == 0;

            //Third question fields
            qSF3A = Calc.ReselectIfZero(12);
            qSF3B = Calc.ReselectIfZero(12);
            qSF3C = Calc.ReselectIfZero(20);
            qSF3Discriminant = qSF3B * qSF3B - 4 * qSF3A * qSF3C;
            if(qSF3Discriminant > 0)
            {
                qSF3answer = 2;
            }
            else if(qSF3Discriminant == 0)
            {
                qSF3answer = 1;
            }
            else
            {
                qSF3answer = 0;
            }

            //First factored form question
            Fact1z1 = Calc.ReselectIfZero(12);
            Fact1z2 = Calc.ReselectIfZero(12);
            Fact1a = Calc.ReselectIfZero(9);
            if(Fact1a == 1)
            {
                FactLead1 = "";
            }
            else if(Fact1a == -1)
            {
                FactLead1 = "-";
            }
            else
            {
                FactLead1 = $"{Fact1a}";
            }
            double axisOfSymmetryFact1 = (Fact1z1 + Fact1z2) / (double)2;
            if((Fact1z1+Fact1z2)%2 == 0)
            {
                Fact1answer = $"{(Fact1z1+Fact1z2)/2}";
            }
            else
            {
                if(axisOfSymmetryFact1 > -1 && axisOfSymmetryFact1 < 0)
                {
                    Fact1answer = "-0.5";
                }
                else
                {
                    Fact1answer = $"{(Fact1z1 + Fact1z2) / 2}.5";
                }
            }

            //Second factored form question
            Fact2z1 = Calc.ReselectIfZero(12);
            Fact2z2 = Calc.ReselectIfZero(12);
            while((Fact2z1 + Fact2z2)%2 != 0)
            {
                Fact2z2 = Calc.ReselectIfZero(12);
            }
            Fact2a = Calc.ReselectIfZero(3);
            int axisOfSymmetry2 = (Fact2z1 + Fact2z2)/2;
            Fact2answer = Fact2a * (axisOfSymmetry2 - Fact2z1) * (axisOfSymmetry2 - Fact2z2);
            if (Fact2a == 1)
            {
                FactLead2 = "";
            }
            else if (Fact2a == -1)
            {
                FactLead2 = "-";
            }
            else
            {
                FactLead2 = $"{Fact2a}";
            }

            //Third factored form fields
            Fact3z1 = Calc.ReselectIfZero(12);
            Fact3z2 = Calc.ReselectIfZero(12);
            while ((Fact3z1 + Fact3z2) % 2 != 0)
            {
                Fact3z2 = Calc.ReselectIfZero(12);
            }
            Fact3a = Calc.ReselectIfZero(3);
            int axisOfSymmetry3 = (Fact3z1 + Fact3z2) / 2;
            int fact3Y = Fact3a * (axisOfSymmetry3 - Fact3z1) * (axisOfSymmetry3 - Fact3z2);
            if (Fact3a == 1)
            {
                FactLead3 = "";
            }
            else if (Fact3a == -1)
            {
                FactLead3 = "-";
            }
            else
            {
                FactLead3 = $"{Fact3a}";
            }
            Fact3answer = $"({axisOfSymmetry3},{fact3Y})|{axisOfSymmetry3},{fact3Y}";

            //First vertex form fields - ask for quadrant
            Vert1H = Calc.ReselectIfZero(9);
            Vert1K = Calc.ReselectIfZero(9);
            Vert1A = Calc.ReselectIfZero(5);
            if(Vert1H > 0 && Vert1K > 0)
            {
                Vert1Answer = "I";
            } 
            else if(Vert1H > 0)
            {
                Vert1Answer = "IV";
            } 
            else if(Vert1K > 0)
            {
                Vert1Answer = "II";
            }
            else
            {
                Vert1Answer = "III";
            }

            //Second Vertex form fields - ask for number of x-intercepts
            Vert2H = Calc.ReselectIfZero(9);
            Vert2K = (int)(-10 + Math.Floor(rand.NextDouble()*21));
            Vert2A = Calc.ReselectIfZero(5);
            if(Vert2K == 0)
            {
                Vert2Answer = 1;
            }
            else if(Vert2A*Vert2K > 0)
            {
                Vert2Answer = 0;
            }
            else
            {
                Vert2Answer = 2;
            }

            //Third Vertex form fields - ask for roots
            Vert3A = rand.NextDouble() < 0.5 ? -1 : 1;
            Vert3H = Calc.ReselectIfZero(9);
            Vert3K = Calc.RandomPositive(12);
            Vert3AnswerA = Vert3H - Vert3K;
            Vert3AnswerB = Vert3H + Vert3K;
            Vert3K *= Vert3K;
            if(Vert3A == 1)
            {
                Vert3K *= -1;
            }

        }
    }
}
