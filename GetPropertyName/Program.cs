using System;
using System.Linq.Expressions;
using Microsoft.VisualBasic.ApplicationServices;

namespace GetPropertyName
{
    class Program
    {
        static void Main(string[] args)
        {
            User aUser = new User();

            string name = GetPropertyName(() => aUser.ContactNo);
            Console.WriteLine(name);

            Console.ReadLine();
        }
        public static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            var property = propertyLambda.Body as MemberExpression;

            if (property == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }

            return property.Member.Name;
        }
    }
}
