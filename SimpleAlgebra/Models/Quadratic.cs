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


        //Default constructor
        public Quadratic()
        {
            //First question fields
            qSF1z1 = Calc.ReselectIfZero(12);
            qSF1z2 = Calc.ReselectIfZero(12);
            qSF1eliminateMiddle = qSF1z1 + qSF1z2 == 0;
            qSF1Coefficients = Calc.ZeroesToPolyCoefficients(new int[] {qSF1z1, qSF1z2});
            qSF1question = "Factor the above quadratic expression.";
            string qSF1f1 = Calc.LinearZeroFactor(qSF1z1);
            string qSF1f2 = Calc.LinearZeroFactor(qSF1z2);
            qSF1answers = $"({qSF1f1})({qSF1f2}),({qSF1f2})({qSF1f1})";
        }
    }
}
