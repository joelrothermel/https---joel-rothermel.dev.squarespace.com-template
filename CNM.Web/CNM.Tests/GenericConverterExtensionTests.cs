using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CNM.Tests
{
    [TestClass]
    public class GenericConverterExtensionTests
    {
        [TestMethod]
        public void ConvertTo_DateTimeToString_ReturnsString()
        {
            string sample = new DateTime(1900, 1, 1).ConvertTo<string>();

            sample.IsEqualTo(new DateTime(1900, 1, 1).ToString(), "Unexpected value returned.");
        }

        [TestMethod]
        public void TryConvertTo_DateTimeToString_ReturnsString()
        {
            string sample = new DateTime(1900, 1, 1).GetValueOrDefault<string>();

            sample.IsEqualTo(new DateTime(1900, 1, 1).ToString(), "Unexpected value returned.");
        }

        [TestMethod]
        public void ConvertTo_EnumToString_ReturnsString()
        {
            string sample = HttpVerb.GET.ConvertTo<string>();

            sample.IsEqualTo("GET", "Unexpected enum representation returned.");
        }

        [TestMethod]
        public void TryConvertTo_EnumToString_ReturnsString()
        {
            string sample = HttpVerb.GET.GetValueOrDefault<string>();

            sample.IsEqualTo("GET", "Unexpected enum representation returned.");
        }

        [TestMethod]
        public void ConvertTo_NullString_ReturnsNull()
        {
            string sample = ((string)(null)).ConvertTo<string>();

            sample.IsNull();
        }

        [TestMethod]
        public void TryConvertTo_NullString_ReturnsNull()
        {
            string sample = ((string)(null)).GetValueOrDefault<string>();

            sample.IsNull();
        }

        [TestMethod]
        public void ConvertTo_IntegerToString_ReturnsString()
        {
            string sample = (40).ConvertTo<string>();

            sample.IsEqualTo("40", "Unexpected integer represenation returned.");
        }

        [TestMethod]
        public void TryConvertTo_IntegerToString_ReturnsString()
        {
            string sample = (40).GetValueOrDefault<string>();

            sample.IsEqualTo("40", "Unexpected integer represenation returned.");
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void ConvertTo_InvalidConversion_ThrowsException()
        {
            int sample = "Sample".ConvertTo<int>();
        }

        [TestMethod]
        public void TryConvertTo_InvalidConversion_ReturnsDefaultValue()
        {
            int sample = "Sample".GetValueOrDefault<int>();

            sample.IsEqualTo(0, "Unexpected value returned.");
        }

        [TestMethod]
        public void ConvertTo_IntegerString_ReturnsInteger()
        {
            int sample = "40".ConvertTo<int>();

            sample.IsEqualTo(40, "Unexpected value returned.");
        }

        [TestMethod]
        public void TryConvertTo_IntegerString_ReturnsInteger()
        {
            int sample = "40".GetValueOrDefault<int>();

            sample.IsEqualTo(40, "Unexpected value returned.");
        }

        [TestMethod]
        public void ConvertTo_DateTimeString_ReturnsDateTime()
        {
            DateTime value = "12/10/2010".ConvertTo<DateTime>();

            value.IsEqualTo(new DateTime(2010, 12, 10), "Unexpected value returned.");
        }

        [TestMethod]
        public void TryConvertTo_DateTimeString_ReturnsDateTime()
        {
            DateTime value = "12/10/2010".GetValueOrDefault<DateTime>();

            value.IsEqualTo(new DateTime(2010, 12, 10), "Unexpected value returned.");
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void ConvertTo_InvalidDateTimeString_ThrowsException()
        {
            DateTime value = "12^10!2010".ConvertTo<DateTime>();
        }

        [TestMethod]
        public void TryConvertTo_InvalidDateTimeString_ReturnsBasicDateTime()
        {
            DateTime value = "12^10!2010".GetValueOrDefault<DateTime>();

            value.IsEqualTo(new DateTime(), "Unexpected value returned.");
        }

        public enum HttpVerb
        {
            GET,
            POST,
            DELETE,
            PUT
        }

        [TestMethod]
        public void ConvertTo_EnumString_ReturnsEnum()
        {
            HttpVerb verb = "GET".ConvertTo<HttpVerb>();

            verb.IsEqualTo(HttpVerb.GET, "Unexpected enum value returned.");
        }

        [TestMethod]
        public void TryConvertTo_EnumString_ReturnsEnum()
        {
            HttpVerb verb = "GET".GetValueOrDefault<HttpVerb>();

            verb.IsEqualTo(HttpVerb.GET, "Unexpected enum value returned.");
        }

        [TestMethod]
        public void ConvertTo_EnumValue_ReturnsEnum()
        {
            HttpVerb verb = (1).ConvertTo<HttpVerb>();

            verb.IsEqualTo(HttpVerb.POST, "Unexpected enum value returned.");
        }

        [TestMethod]
        public void TryConvertTo_EnumValue_ReturnsEnum()
        {
            HttpVerb verb = (1).GetValueOrDefault<HttpVerb>();

            verb.IsEqualTo(HttpVerb.POST, "Unexpected enum value returned.");
        }

        [TestMethod]
        public void ConvertTo_Enum_ReturnsInteger()
        {
            int value = HttpVerb.POST.ConvertTo<int>();

            value.IsEqualTo(1, "Unexpected value returned.");
        }

        [TestMethod]
        public void TryConvertTo_Enum_ReturnsInteger()
        {
            int value = HttpVerb.POST.GetValueOrDefault<int>();

            value.IsEqualTo(1, "Unexpected value returned.");
        }

        [TestMethod]
        public void ConvertTo_Boolean_ReturnsValue()
        {
            bool trueValue = "true".ConvertTo<bool>();
            bool falseValue = "false".ConvertTo<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();

            trueValue = "TRUE".ConvertTo<bool>();
            falseValue = "FALSE".ConvertTo<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();

            trueValue = "tRuE".ConvertTo<bool>();
            falseValue = "fAlSe".ConvertTo<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();
        }

        [TestMethod]
        public void TryConvertTo_Boolean_ReturnsValue()
        {
            bool trueValue = "true".GetValueOrDefault<bool>();
            bool falseValue = "false".GetValueOrDefault<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();

            trueValue = "TRUE".GetValueOrDefault<bool>();
            falseValue = "FALSE".GetValueOrDefault<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();

            trueValue = "tRuE".GetValueOrDefault<bool>();
            falseValue = "fAlSe".GetValueOrDefault<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();
        }

        [TestMethod]
        public void ConvertTo_IntBoolean_ReturnsValue()
        {
            bool trueValue = (1).ConvertTo<bool>();
            bool falseValue = (0).ConvertTo<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();
        }

        [TestMethod]
        public void TryConvertTo_IntBoolean_ReturnsValue()
        {
            bool trueValue = (1).GetValueOrDefault<bool>();
            bool falseValue = (0).GetValueOrDefault<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();
        }

        [TestMethod]
        public void ConvertTo_StringInteger_ReturnsValue()
        {
            bool trueValue = "1".ConvertTo<bool>();
            bool falseValue = "0".ConvertTo<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ConvertTo_LargeNumber_ThrowsException()
        {
            (24).ConvertTo<bool>();
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ConvertTo_LargeStringNumber_ThrowsException()
        {
            "24".ConvertTo<bool>();
        }

        [TestMethod]
        public void TryConvertTo_StringInteger_ReturnsValue()
        {
            bool trueValue = "1".GetValueOrDefault<bool>();
            bool falseValue = "0".GetValueOrDefault<bool>();
            bool largeFalseValue = "24".GetValueOrDefault<bool>();

            trueValue.IsTrue();
            falseValue.IsFalse();
            largeFalseValue.IsFalse();
        }

        [TestMethod]
        public void ConvertTo_NullableValueType_ReturnsValue()
        {
            int? value = 34;

            int sample = value.ConvertTo<int>();

            sample.IsEqualTo(34, "Incorrect value returned.");
        }

        [TestMethod]
        public void TryConvertTo_NullableValueType_ReturnsValue()
        {
            int? value = 34;

            int sample = value.GetValueOrDefault<int>();

            sample.IsEqualTo(34, "Incorrect value returned.");
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ConvertTo_NullableValueTypeNull_ReturnsValue()
        {
            int? value = null;

            int sample = value.ConvertTo<int>();

            sample.IsEqualTo(0, "Incorrect value returned.");
        }

        [TestMethod]
        public void TryConvertTo_NullableValueTypeNull_ReturnsValue()
        {
            int? value = null;

            int sample = value.GetValueOrDefault<int>();

            sample.IsEqualTo(0, "Incorrect value returned.");
        }

        [TestMethod]
        public void ConvertValueType_ToNullableType_ReturnsValue()
        {
            int value = 10;

            int? nullableValue = value.ConvertTo<int?>();

            nullableValue.HasValue.IsTrue();
            nullableValue.Value.IsEqualTo(10, "Incorrect value returned.");
        }

        [TestMethod]
        public void TryConvertValueType_ToNullableType_ReturnsValue()
        {
            int value = 10;

            int? nullableValue = value.GetValueOrDefault<int?>();

            nullableValue.HasValue.IsTrue();
            nullableValue.Value.IsEqualTo(10, "Incorrect value returned.");
        }

        [TestMethod, ExpectedException(typeof(FormatException))]
        public void ConvertValueType_ToNullableType_InvalidType_ThrowsException()
        {
            string value = "someValue";

            int? nullableValue = value.ConvertTo<int?>();
        }

        [TestMethod]
        public void TryConvertValueType_ToNullableType_InvalidType_ReturnsNull()
        {
            string value = "someValue";

            int? nullableValue = value.GetValueOrDefault<int?>();

            nullableValue.HasValue.IsFalse();
        }

        [TestMethod]
        public void ConvertValueType_ToNullableType_CanBeCoerced_ReturnsValue()
        {
            string value = "10";

            int? nullableValue = value.ConvertTo<int?>();

            nullableValue.HasValue.IsTrue();
            nullableValue.Value.IsEqualTo(10, "Value was not correctly parsed.");
        }

        [TestMethod]
        public void TryConvertValueType_ToNullableType_CanBeCoerced_ReturnsValue()
        {
            string value = "10";

            int? nullableValue = value.GetValueOrDefault<int?>();

            nullableValue.HasValue.IsTrue();
            nullableValue.Value.IsEqualTo(10, "Value was not correctly parsed.");
        }

        [TestMethod]
        public void TryConvertType_DefaultSpecified_ReturnsDefault()
        {
            int? someValue = null;

            int value = someValue.GetValueOrDefault<int>(20);

            value.IsEqualTo(20, "Incorrect conversion.");
        }

        [TestMethod]
        public void ConvertValueType_ToDifferentNullableType_ReturnsValue()
        {
            byte value = 4;

            int? nullableValue = value.ConvertTo<int?>();

            nullableValue.HasValue.IsTrue();
            nullableValue.Value.IsEqualTo(4, "Incorrect value returned.");
        }

        [TestMethod]
        public void TryConvertValueType_ToDifferentNullableType_ReturnsValue()
        {
            byte value = 4;

            int? nullableValue = value.GetValueOrDefault<int?>();

            nullableValue.HasValue.IsTrue();
            nullableValue.Value.IsEqualTo(4, "Incorrect value returned.");
        }

        [TestMethod]
        public void ConvertTo_NullableDateTime_ReturnsValue()
        {
            DateTime? value = new DateTime(1900, 1, 1);

            DateTime sample = value.ConvertTo<DateTime>();

            sample.IsEqualTo(new DateTime(1900, 1, 1), "Incorrect value returned.");
        }

        [TestMethod]
        public void TryConvertTo_NullableDateTime_ReturnsValue()
        {
            DateTime? value = new DateTime(1900, 1, 1);

            DateTime sample = value.GetValueOrDefault<DateTime>();

            sample.IsEqualTo(new DateTime(1900, 1, 1), "Incorrect value returned.");
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ConvertTo_NullableDateTimeNull_ThrowsException()
        {
            DateTime? value = null;

            DateTime sample = value.ConvertTo<DateTime>();

            sample.IsEqualTo(new DateTime(), "Incorrect value returned.");
        }

        [TestMethod]
        public void TryConvertTo_NullableDateTimeNull_ReturnsValue()
        {
            DateTime? value = null;

            DateTime sample = value.GetValueOrDefault<DateTime>();

            sample.IsEqualTo(new DateTime(), "Incorrect value returned.");
        }

        [TestMethod]
        public void TryConvertTo_SuppliedDefault_ReturnsDefault()
        {
            int sample = "Sample".GetValueOrDefault<int>(20);

            sample.IsEqualTo(20, "Incorrect default returned.");
        }

        [TestMethod]
        public void TryConvertTo_SuppliedDefault_ReturnsValue()
        {
            int sample = "30".GetValueOrDefault<int>(20);

            sample.IsEqualTo(30, "Incorrect value returned.");
        }

        class SampleBaseClass { }
        class SampleDerivedClass : SampleBaseClass { }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ConvertTo_ValueNull_ThrowsException()
        {
            SampleDerivedClass x = null;

            int value = x.ConvertTo<int>();

            value.IsEqualTo(0, "Unexpected value returned.");
        }

        [TestMethod]
        public void TryConvertTo_ValueNull_ReturnsDefault()
        {
            SampleDerivedClass x = null;

            int value = x.GetValueOrDefault<int>();

            value.IsEqualTo(0, "Unexpected value returned.");
        }

        [TestMethod]
        public void ConvertTo_ReferenceNull_ReturnsDefault()
        {
            SampleDerivedClass x = null;

            string value = x.ConvertTo<string>();

            value.IsEqualTo(null, "Unexpected value returned.");
        }

        [TestMethod]
        public void TryConvertTo_ReferenceNull_ReturnsDefault()
        {
            SampleDerivedClass x = null;

            string value = x.GetValueOrDefault<string>();

            value.IsEqualTo(null, "Unexpected value returned.");
        }

        public class SampleOverride
        {
            public override string ToString()
            {
                return "HelloWorld";
            }
        }

        [TestMethod]
        public void ConvertTo_ReferenceTypes_ReturnsToStringRepresentation()
        {
            string sample = new SampleOverride().GetValueOrDefault<string>();

            sample.IsEqualTo("HelloWorld", "Unexpected value returned.");
        }

        [TestMethod]
        public void TryConvertTo_ReferenceTypes_ReturnsToStringRepresentation()
        {
            string sample = new SampleOverride().GetValueOrDefault<string>();

            sample.IsEqualTo("HelloWorld", "Unexpected value returned.");
        }

        [TestMethod]
        public void ConvertTo_DerivedType_ReturnsBaseType()
        {
            SampleBaseClass baseClass = new SampleDerivedClass().ConvertTo<SampleBaseClass>();

            baseClass.IsNotNull();
        }

        [TestMethod]
        public void TryConvertTo_DerivedType_ReturnsBaseType()
        {
            SampleBaseClass baseClass = new SampleDerivedClass().GetValueOrDefault<SampleBaseClass>();

            baseClass.IsNotNull();
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ConvertTo_BaseType_ReturnsNull()
        {
            SampleDerivedClass sample = new SampleBaseClass().ConvertTo<SampleDerivedClass>();
        }

        [TestMethod]
        public void TryConvertTo_BaseType_ReturnsNull()
        {
            SampleDerivedClass sample = new SampleBaseClass().GetValueOrDefault<SampleDerivedClass>();

            sample.IsNull();
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void ConvertTo_NoRelation_ReturnsNull()
        {
            SampleDerivedClass sample = new GenericConverterExtensionTests().ConvertTo<SampleDerivedClass>();
        }

        [TestMethod]
        public void TryConvertTo_NoRelation_ReturnsNull()
        {
            SampleDerivedClass sample = new GenericConverterExtensionTests().GetValueOrDefault<SampleDerivedClass>();

            sample.IsNull();
        }

        [TestMethod]
        public void Nullable_ToNullable_ReturnsValue()
        {
            int? x = 10;

            var result = x.ConvertTo<byte?>();

            result.IsEqualTo((byte)10, "Conversion not correct.");
        }

        [TestMethod]
        public void TryNullable_ToNullable_ReturnsValue()
        {
            int? x = 10;

            var result = x.GetValueOrDefault<byte?>();

            result.IsEqualTo((byte)10, "Conversion not correct.");
        }

        [TestMethod, ExpectedException(typeof(InvalidCastException))]
        public void Null_ToNullable_ReturnsCorrectly()
        {
            int? x = null;

            var result = x.ConvertTo<byte?>();
        }

        [TestMethod]
        public void TryNull_ToNullable_ReturnsCorrectly()
        {
            int? x = null;

            var result = x.GetValueOrDefault<byte?>();

            result.IsNull();
        }

        [TestMethod]
        public void String_ToGuid_ParsesCorrectly()
        {
            Guid guid = Guid.NewGuid();

            string stringGuid = guid.ToString();

            var result = stringGuid.ConvertTo<Guid>();

            result.IsEqualTo(guid, "Conversion not correct.");
        }

        [TestMethod]
        public void TryString_ToGuid_ParsesCorrectly()
        {
            Guid guid = Guid.NewGuid();

            string stringGuid = guid.ToString();

            var result = stringGuid.GetValueOrDefault<Guid>();

            result.IsEqualTo(guid, "Conversion not correct.");
        }
    }
}
