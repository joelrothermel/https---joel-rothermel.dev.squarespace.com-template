using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CNM.Tests
{
    public static class AssertionExtensions
    {
        public static void IsNull<T>(this T actual, string message = null)
        {
            Assert.IsNull(actual, message);
        }

        public static void IsNotNull<T>(this T actual, string message = null)
        {
            Assert.IsNotNull(actual, message);
        }

        public static void IsEqualTo<T>(this T actual, T expected, string message = null)
        {
            Assert.AreEqual(expected, actual, message);
        }

        public static void IsNotEqualTo<T>(this T actual, T notExpected, string message = null)
        {
            Assert.AreNotEqual(notExpected, actual, message);
        }

        public static void IsFalse(this bool actual, string message = null)
        {
            Assert.IsFalse(actual, message);
        }

        public static void IsTrue(this bool actual, string message = null)
        {
            Assert.IsTrue(actual, message);
        }

        public static TRequestedType EnsureIs<TRequestedType>(this object actual, string message = null)
        {
            Assert.IsInstanceOfType(actual, typeof(TRequestedType));

            return (TRequestedType)actual;
        }

        public static void EnsureIsNot<T>(this object actual, string message)
        {
            Assert.IsNotInstanceOfType(actual, typeof(T));
        }
    }
}
