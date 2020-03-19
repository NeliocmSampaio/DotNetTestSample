using Services.Interfaces;
using System;

namespace Services
{
    public class SumService : ISumService
    {
        public int Sum(int value1, int value2)
        {
            return value1 + value2;
        }
    }
}
