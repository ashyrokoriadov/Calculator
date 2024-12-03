namespace Calculator.Core
{
    public class DefaultIntCalculator : ICalculator<int>
    {
        public int Add(int a, int b) => a + b;

        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException($"Value {nameof(b)} cannot be 0.");

            return a / b;
        }

        public int Multiply(int a, int b) => a * b;

        public int Subtract(int a, int b) => a - b;
    }
}