﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenMagic.DataAnnotations;

namespace OpenMagic.Tests.DataAnnotations
{
    public class ValidationTests
    {
        [TestClass]
        public class Validate
        {
            [TestMethod]
            public void ShouldThrowValidationExceptionWhenValueIsNotValid()
            {
                // Given
                var invalidObject = new TestClass();

                // When
                Action action = () => Validation.Validate(invalidObject);

                // Then
                action.ShouldThrow<ValidationException>();
            }

            [TestMethod]
            public void ShouldBeSameAsValueWhenValueIsValid()
            {
                // Given
                var validObject = new TestClass() { Required = "required property" };

                // When
                var result = validObject.Validate();

                // Then
                result.Should().BeSameAs(validObject);
            }
        }

        public class TestClass
        {
            [Required]
            public string Required { get; set; }
        }
    }
}
