using Microsoft.Extensions.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LibraryBLL
{
    public static class ExtenstionMethods
    {
        public static T ParseValue<T>(this XElement element)
        {
            if (element == null)
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (string.IsNullOrWhiteSpace(element.Value))
            {
                throw new ArgumentException("Element has no value", nameof(element));
            }

            try
            {
                return (T)Convert.ChangeType(element.Value, typeof(T));
            }
            catch (FormatException)
            {
                throw new ArgumentException($"Invalid {typeof(T)} format: {element.Value}", nameof(element));
            }
        }
        public static string GetIdName<T>(this T obj)
        {
            return typeof(T).BaseType.GetProperties()[0].Name;
        }
        
        public static string GetPropertyName<T, TResult>(this T obj, Expression<Func<T, TResult>> propertySelector)
        {
            var propertyName = string.Empty;
            try
            {
                propertyName = ((MemberExpression)propertySelector.Body).Member.Name;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return propertyName;
        }
        public static IEnumerable<XElement> GetElements<T>(this XDocument xmlDocument)
        {
            return xmlDocument.Descendants(typeof(T).Name);
        }
     
    }
}
