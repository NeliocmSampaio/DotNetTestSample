using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ICalculatorService
    {
        /// <summary>
        /// Process the operation using value1 and value2
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        int ProcessOperation(int value1, int value2, Operation operation);

        /// <summary>
        /// Just return true
        /// </summary>
        /// <returns></returns>
        bool ReturnTrue();
    }
}
