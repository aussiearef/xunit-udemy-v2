using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;
using Xunit.v3;

namespace Calculations.Test
{
    public class AddDataAttribute : DataAttribute
    {
        public override ValueTask<IReadOnlyCollection<ITheoryDataRow>> GetData(MethodInfo testMethod, DisposalTracker disposalTracker)
        {
            return new ValueTask<IReadOnlyCollection<ITheoryDataRow>>(new List<ITheoryDataRow>()
            {
                new TheoryDataRow(1 , 2, 3),
                new TheoryDataRow(-3, 2, -1)
            });
        }

        public override bool SupportsDiscoveryEnumeration()
        {
            return true;
        }
    }
}
