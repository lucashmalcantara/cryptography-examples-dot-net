using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CryptographyExamples.Helpers
{
    /// <summary>
    /// Reference: https://stackoverflow.com/questions/1415140/can-my-enums-have-friendly-names
    /// </summary>
    public static class EnumerationsHelper
    {

        public static IEnumerable<T> GetValues<T>() where T : Enum =>
            Enum.GetValues(typeof(T)).Cast<T>();

        public static string GetDescription(this Enum value)
        {
            var type = value.GetType();
            var name = Enum.GetName(type, value);

            if (name == null)
                return null;

            var fieldInfo = type.GetField(name);

            if (fieldInfo == null)
                return null;

            var descriptionAttribute =
                   Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute)) 
                   as DescriptionAttribute;

            if (descriptionAttribute == null)
                return null;

            return descriptionAttribute.Description;
        }

    }
}
