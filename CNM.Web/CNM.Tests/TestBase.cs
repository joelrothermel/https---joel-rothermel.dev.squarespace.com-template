using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;

namespace CNM.Tests
{
    public abstract class TestBase
    {
        protected Mock<T> Mock<T>()
            where T : class
        {
            var requestedType = typeof(T);

            if (requestedType.IsInterface)
            {
                return new Mock<T>();
            }
            else
            {
                var constructor = requestedType.GetConstructors().FirstOrDefault();

                if (constructor == null)
                {
                    return new Mock<T>();
                }
                else
                {
                    var nullArray = new object[constructor.GetParameters().Length];
                    return new Mock<T>(nullArray);
                }
            }
        }
    }
}
