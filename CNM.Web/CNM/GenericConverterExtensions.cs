using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNM
{
    public static class GenericConverterExtensions
    {
        public static DesiredType ConvertTo<DesiredType>(this object source)
        {
            if (source == null)
            {
                if (typeof(DesiredType).IsValueType && typeof(DesiredType) != typeof(string))
                    throw new InvalidCastException("Cannot cast null object to " + typeof(DesiredType).Name);
                else
                    return default(DesiredType);
            }

            if (typeof(DesiredType) == typeof(bool))
            {
                int rawValueNumeric = 0;
                bool returnValue = false;

                if (int.TryParse(source.ToString(), out rawValueNumeric))
                {
                    if (rawValueNumeric == 0)
                        return (DesiredType)Convert.ChangeType(false, typeof(DesiredType));

                    if (rawValueNumeric == 1)
                        return (DesiredType)Convert.ChangeType(true, typeof(DesiredType));

                    throw new InvalidCastException("Could not convert source { " + source.ToString() + " } to System.Boolean.");
                }
                else
                {
                    if (!bool.TryParse(source.ToString(), out returnValue))
                    {
                        return (DesiredType)Convert.ChangeType(source.ToString() == "1", typeof(DesiredType));
                    }
                    else
                    {
                        return (DesiredType)Convert.ChangeType(returnValue, typeof(DesiredType));
                    }
                }
            }
            else if (typeof(DesiredType).IsSubclassOf(typeof(Enum)))
            {
                try
                {
                    return (DesiredType)Enum.Parse(typeof(DesiredType), source.ToString());
                }
                catch
                {
                    try
                    {
                        return (DesiredType)Enum.ToObject(typeof(DesiredType), source);
                    }
                    catch
                    {
                        foreach (string item in Enum.GetNames(typeof(DesiredType)))
                        {
                            if (item.ToLower() == source.ToString().ToLower())
                                return ConvertTo<DesiredType>(item);
                        }

                        throw new InvalidCastException("Could not cast the enum to a value.");
                    }
                }
            }
            else if (typeof(DesiredType) == typeof(Guid))
            {
                return (DesiredType)Convert.ChangeType(new Guid(source.ToString().ToUpper()), typeof(DesiredType));
            }
            else if (typeof(DesiredType).IsGenericType && typeof(DesiredType).GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                Type genericType = typeof(DesiredType).GetGenericArguments().First();

                return (DesiredType)Convert.ChangeType(source, genericType);
            }
            else if (source.GetType().IsSubclassOf(typeof(DesiredType)))
            {
                return (DesiredType)source;
            }
            else if (source.GetType().GetInterfaces().Any(interfaceType => interfaceType == typeof(DesiredType)))
            {
                return (DesiredType)source;
            }
            else if (!source.GetType().IsValueType
                && source.GetType() != typeof(string)
                && typeof(DesiredType) == typeof(string))
            {
                return (DesiredType)Convert.ChangeType(source.ToString(), typeof(DesiredType));
            }
            else
            {
                return (DesiredType)Convert.ChangeType(source, typeof(DesiredType));
            }
        }

        public static DesiredType GetValueOrDefault<DesiredType>(this object source, DesiredType defaultValue = default(DesiredType))
        {
            try
            {
                return ConvertTo<DesiredType>(source);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static object TryConvertToType(this object source, Type destinationType, object defaultValue = null)
        {
            try
            {
                if (source == null)
                    return defaultValue;

                if (destinationType == typeof(bool))
                {
                    bool returnValue = false;

                    if (!bool.TryParse(source.ToString(), out returnValue))
                    {
                        return Convert.ChangeType(source.ToString() == "1", destinationType);
                    }
                    else
                    {
                        return Convert.ChangeType(returnValue, destinationType);
                    }
                }
                else if (destinationType.IsSubclassOf(typeof(Enum)))
                {
                    try
                    {
                        return Enum.Parse(destinationType, source.ToString());
                    }
                    catch
                    {
                        return Enum.ToObject(destinationType, source);
                    }
                }
                else if (destinationType == typeof(Guid))
                {
                    return Convert.ChangeType(new Guid(source.ToString().ToUpper()), destinationType);
                }
                else if (destinationType.IsGenericType && destinationType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    Type genericType = destinationType.GetGenericArguments().First();

                    return Convert.ChangeType(source, genericType);
                }
                else if (source.GetType().IsSubclassOf(destinationType))
                {
                    return Convert.ChangeType(source, destinationType);
                }
                else if (!source.GetType().IsValueType
                    && source.GetType() != typeof(string)
                    && destinationType == typeof(string))
                {
                    return Convert.ChangeType(source.GetType().Name, destinationType);
                }
                else
                {
                    return Convert.ChangeType(source, destinationType);
                }
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}
