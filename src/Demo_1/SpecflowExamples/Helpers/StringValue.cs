using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowExamples.Helpers
{
    public class StringValueAttribute : Attribute
    {
        public StringValueAttribute(string stringValue)
        {
            StringValue = stringValue;
        }

        public string StringValue { get; private set; }
    }
}
