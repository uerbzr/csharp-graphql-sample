using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.services.calculator
{
    public interface ICalculation
    {
        int Add(int a, int b);
        int Add(IEnumerable<int> numbers);
    }
}
