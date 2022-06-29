using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IbelieveIdontbelieve.Service
{
    public class Reflection
    {
        object Ref;
        public Reflection(object obj)
        {
            Ref = obj;
        }
        PropertyInfo GetPropertyInfo(string str)
        {

            return Ref.GetType().GetProperty(str);
        }

        internal IEnumerable<string> read()
        {
             yield return $"CanRead: {GetPropertyInfo("DayOfWeek").CanRead}";
             yield return $"CanWrite: {GetPropertyInfo("DayOfWeek").CanWrite}";
             yield return $"Attributes: {GetPropertyInfo("DayOfWeek").Attributes}";
             yield return $"CustomAttributes: {GetPropertyInfo("DayOfWeek").CustomAttributes}";
             yield return $"DeclaringType: {GetPropertyInfo("DayOfWeek").DeclaringType}";
             yield return $"GetMethod: {GetPropertyInfo("DayOfWeek").GetMethod}";
             yield return $"IsSpecialName: {GetPropertyInfo("DayOfWeek").IsSpecialName}";
             yield return $"MemberType: {GetPropertyInfo("DayOfWeek").MemberType}";
             yield return $"MetadataToken: {GetPropertyInfo("DayOfWeek").MetadataToken}";
             yield return $"Module: {GetPropertyInfo("DayOfWeek").Module}";
             yield return $"Name: {GetPropertyInfo("DayOfWeek").Name}";
             yield return $"PropertyType: {GetPropertyInfo("DayOfWeek").PropertyType}";
             yield return $"ReflectedType: {GetPropertyInfo("DayOfWeek").ReflectedType}";
             yield return $"SetMethod: {GetPropertyInfo("DayOfWeek").SetMethod}";
        }
    }
}
