using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecflowExamples.Helpers
{
    public class LoginParameters
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    [Binding]
    public class LoginParametersConversion
    {
        [StepArgumentTransformation]
        public LoginParameters ConvertToLoginParameters(Table table)
        {
            return table.CreateInstance<LoginParameters>();
        }
    }

}
