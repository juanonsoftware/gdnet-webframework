using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace GDNET.Utils
{
    public static class ReflectionAssistant
    {
        /// <summary>
        /// Read file content using BigEndianUnicode encoding
        /// </summary>
        public static string ReadFileContent(Assembly asm, string fileName)
        {
            Stream s = asm.GetManifestResourceStream(fileName);
            if (s == null)
            {
                return string.Empty;
            }

            byte[] buffer = new byte[s.Length];
            s.Read(buffer, 0, (int)s.Length);

            return Encoding.BigEndianUnicode.GetString(buffer);
        }

        public static IDictionary<string, Type> GetProperties(Type type)
        {
            Dictionary<string, Type> infos = new Dictionary<string, Type>();

            foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                infos.Add(pi.Name, pi.PropertyType);
            }

            return infos;
        }

        public static bool SetFieldValue(object objet, string fieldName, object value)
        {
            return ReflectionAssistant.SetFieldValue(objet, fieldName, value, objet.GetType());
        }

        public static bool SetFieldValue(object objet, string fieldName, object value, Type targetType)
        {
            FieldInfo fi = ReflectionAssistant.GetFieldInfo(objet, fieldName, targetType);

            if (fi == null)
            {
                return false;
            }
            else
            {
                fi.SetValue(objet, value);
                return true;
            }
        }

        /// <summary>
        /// Get value of field in given object
        /// </summary>
        public static object GetFieldValue(object objet, string fieldName)
        {
            return ReflectionAssistant.GetFieldValue(objet, fieldName, objet.GetType());
        }

        /// <summary>
        /// Get value of field in given object, on a specific type
        /// </summary>
        public static object GetFieldValue(object objet, string fieldName, Type targetType)
        {
            FieldInfo fi = ReflectionAssistant.GetFieldInfo(objet, fieldName, targetType);

            if (fi == null)
            {
                return null;
            }
            else
            {
                return fi.GetValue(objet);
            }
        }

        /// <summary>
        /// Get field info by name in given object, on a specific type
        /// </summary>
        public static FieldInfo GetFieldInfo(object objet, string fieldName, Type targetType)
        {
            Type baseType = objet.GetType();
            while (!baseType.Equals(targetType))
            {
                baseType = baseType.BaseType;
            }

            return baseType.GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
        }

        /// <summary>
        /// Get all types which implemented an interface by type of interface, on same assembly with interface
        /// </summary>
        public static IList<Type> GetTypesImplementedInterface(Type interfaceType)
        {
            return ReflectionAssistant.GetTypesImplementedInterfaceOnAssembly(interfaceType, interfaceType.Assembly);
        }

        /// <summary>
        /// Get all types which implemented an interface by type of interface, on a specific assembly
        /// </summary>
        public static IList<Type> GetTypesImplementedInterfaceOnAssembly(Type interfaceType, Assembly assembly)
        {
            List<Type> listOfTypes = new List<Type>();
            if ((interfaceType != null) && (assembly != null))
            {
                listOfTypes.AddRange(assembly.GetTypes().Where(x => x.GetInterface(interfaceType.Name) != null));
            }
            return listOfTypes;
        }

        public static object GetPropertyValue(object objet, string propertyName)
        {
            return ReflectionAssistant.GetPropertyValue(objet, propertyName, objet.GetType());
        }

        public static object GetPropertyValue(object objet, string propertyName, Type targetType)
        {
            Type baseType = objet.GetType();
            while (!baseType.Equals(targetType))
            {
                baseType = baseType.BaseType;
            }

            var propertyInfo = baseType.GetProperty(propertyName);
            return (propertyInfo == null) ? null : propertyInfo.GetValue(objet, null);
        }
    }
}
