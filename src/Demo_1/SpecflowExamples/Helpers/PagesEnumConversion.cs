using SpecflowExamples.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecflowExamples
{
    public enum Pages
    {
        Home,
        [StringValue("Article list")]
        ArticleList,
        Article,
        Checkout,
        Confirmation
    }

    [Binding]
    public class PagesEnumConversion
    {
        [StepArgumentTransformation]
        public Pages ConvertToPagesEnum(string pageText)
        {
            return EnumHelper.GetField<Pages>(pageText);
        }
    }

}
