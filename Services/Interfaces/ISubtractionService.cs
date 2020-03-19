using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ISubtractionService
    {
        /// <summary>
        /// Returns value1 - value2
        /// </summary>
        /// <param name="value1"></param>
        /// <param name="value2"></param>
        /// <returns></returns>
        int Subtract(int value1, int value2);
    }
}