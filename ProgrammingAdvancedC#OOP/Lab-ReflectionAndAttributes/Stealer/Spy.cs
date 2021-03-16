using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Stealer
{
    public class Spy
    {

        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields(
                BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {investigatedClass}");

            foreach (FieldInfo field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type typeOfClass = Type.GetType(className);
            FieldInfo[] publicField = typeOfClass.GetFields(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] privateMethod = typeOfClass.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo[] publicMethod = typeOfClass.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            foreach (var item in publicField)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }
            foreach (var item in privateMethod.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }
            foreach (var item in publicMethod.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }
            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type typeOfClass = Type.GetType(className);
            MethodInfo[] classMethods = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {typeOfClass.BaseType.Name}");

            foreach (MethodInfo method in classMethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }
        public string CollectGettersAndSetters(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type typeOfClass = Type.GetType(className);
            MethodInfo[] classMethods = typeOfClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (MethodInfo item in classMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} will return {item.ReturnType}");
            }
            foreach (MethodInfo item in classMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} will set field of {item.GetParameters().First().ParameterType}");
            }
            return sb.ToString().Trim();
        }
    }
}
 