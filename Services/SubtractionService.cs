using Services.Interfaces;

namespace Services
{
    public class SubtractionService : ISubtractionService
    {
        public int Subtract(int value1, int value2)
        {
            return value1 - value2;
        }
    }
}
