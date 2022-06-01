using SimpleAlgebra.utils;

namespace SimpleAlgebra.Models
{
    public class LinearStandardWord
    {
        //Stores the first TotalSelectors value
        private static readonly int TotalSelectors = 4;
        //Fields for first linear word problem
        public int Problem1Count1;
        public int Problem1Count2;
        public int Problem1Multiple1;
        public int Problem1Multiple2;
        public bool Problem1Bool;
        public int Problem1Selector;
        public int Problem1Answer;
        public string Problem1Question;

        //Fields for second linear word problem
        public int Problem2Count1;
        public int Problem2Count2;
        public int Problem2Multiple1;
        public int Problem2Multiple2;
        public bool Problem2Bool;
        public int Problem2Selector;
        public int Problem2Answer;
        public string Problem2Question;

        //Fields for third linear word problem
        public int Problem3Count1;
        public int Problem3Count2;
        public int Problem3Multiple1;
        public int Problem3Multiple2;
        public bool Problem3Bool;
        public int Problem3Selector;
        public int Problem3Answer;
        public string Problem3Question;

        //Default Constructor
        public LinearStandardWord()
        {
            //Used to randomly choose values
            Random rand = new Random();

            //Create fields for first question
            Problem1Count1 = Calc.RandomPositiveInt(10, 40);
            Problem1Count2 = Calc.RandomPositiveInt(10, 40);
            Problem1Multiple1 = Calc.RandomPositiveInt(2, 10);
            Problem1Multiple2 = Calc.RandomPositiveInt(2, 10);
            while(Problem1Multiple2 == Problem1Multiple1)
            {
                Problem1Multiple2 = Calc.RandomPositiveInt(2, 10);
            }
            Problem1Bool = rand.NextDouble() < 0.5;
            Problem1Answer = Problem1Bool ? Problem1Count1 : Problem1Count2;
            Problem1Selector = (int)(Math.Floor(rand.NextDouble() * TotalSelectors));
            Problem1Question = WordProblems.LinearStandard(Problem1Count1, Problem1Count2, Problem1Multiple1, Problem1Multiple2, Problem1Selector, Problem1Bool);

            //Create fields for second question
            Problem2Count1 = Calc.RandomPositiveInt(10, 40);
            Problem2Count2 = Calc.RandomPositiveInt(10, 40);
            Problem2Multiple1 = Calc.RandomPositiveInt(2, 10);
            Problem2Multiple2 = Calc.RandomPositiveInt(2, 10);
            while (Problem2Multiple2 == Problem2Multiple1)
            {
                Problem2Multiple2 = Calc.RandomPositiveInt(2, 10);
            }
            Problem2Bool = rand.NextDouble() < 0.5;
            Problem2Answer = Problem2Bool ? Problem2Count1*Problem2Multiple1 : Problem2Count2*Problem2Multiple2;
            Problem2Selector = (int)(Math.Floor(rand.NextDouble() * TotalSelectors));
            Problem2Question = WordProblems.LinearStandard2(Problem2Count1, Problem2Count2, Problem2Multiple1, Problem2Multiple2, Problem2Selector, Problem2Bool);

            //Create fields for third question
            Problem3Count1 = Calc.RandomPositiveInt(10, 40);
            Problem3Count2 = Calc.RandomPositiveInt(10, 40);
            Problem3Multiple1 = Calc.RandomPositiveInt(2, 10);
            Problem3Multiple2 = Calc.RandomPositiveInt(2, 10);
            while (Problem3Multiple2 == Problem3Multiple1)
            {
                Problem3Multiple2 = Calc.RandomPositiveInt(2, 10);
            }
            Problem3Bool = rand.NextDouble() < 0.5;
            Problem3Answer = Math.Abs(Problem3Count1 * Problem3Multiple1 - Problem3Count2 * Problem3Multiple2);
            Problem3Selector = (int)(Math.Floor(rand.NextDouble() * TotalSelectors));
            Problem3Question = WordProblems.LinearStandard3(Problem3Count1, Problem3Count2, Problem3Multiple1, Problem3Multiple2, Problem3Selector, Problem3Bool);
        }
    }
}
