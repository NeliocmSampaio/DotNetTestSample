using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CalculatorService : ICalculatorService
    {
        private ISumService _sumService;
        private ISubtractionService _subtractionService;

        public CalculatorService(ISumService sumService, ISubtractionService subtractionService)
        {
            _sumService = sumService;
            _subtractionService = subtractionService;
        }

        public int ProcessOperation(int value1, int value2, Operation operation)
        {
            switch (operation)
            {
                case Operation.Sum:
                    return _sumService.Sum(value1, value2);
                case Operation.Subtract:
                    return _subtractionService.Subtract(value1, value2);
            }

            throw new InvalidOperationException();
        }

        public bool ReturnTrue()
        {
            return true;
        }
    }
}
