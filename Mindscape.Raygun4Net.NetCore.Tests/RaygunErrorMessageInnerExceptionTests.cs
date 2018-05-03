﻿using System;
using NUnit.Framework;

namespace Mindscape.Raygun4Net.NetCore.Tests
{
    [TestFixture]
    public class RaygunErrorMessageInnerExceptionTests
    {
        private Exception _exception;

        [SetUp]
        public void SetUp()
        {
            try
            {
                ExceptionallyCrappyMethod<string, int>("bogus");
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        private void ExceptionallyCrappyMethod<T, T2>(T bung)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                throw new InvalidOperationException("Inner Exception!", exception);
            }
        }

        [Test]
        public void ExceptionBuilds()
        {
            Assert.That(() => RaygunErrorMessageBuilder.New().Build(_exception), Throws.Nothing);
        }

        [Test]
        public void ErrorMessageHasInnerError()
        {
            var errorMessage = RaygunErrorMessageBuilder.New().Build(_exception);

            Assert.That(errorMessage.InnerError, Is.Not.Null);
        }
    }
}
