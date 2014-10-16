using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowExamples.Helpers
{
    /// <summary>
    /// Helper class to get enum value from string. It'll either use a StringValue attribute, or not.
    /// Proper credit goes to 'max', who answered this stackoverflow question:
    /// http://stackoverflow.com/questions/4367723/get-enum-from-description-attribute
    /// </summary>
    public class EnumHelper
    {
        public static T GetField<T>(string value)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(StringValueAttribute)) as StringValueAttribute;
                if (attribute != null)
                {
                    if (attribute.StringValue == value)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == value)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "string value");
        }
    }
}
