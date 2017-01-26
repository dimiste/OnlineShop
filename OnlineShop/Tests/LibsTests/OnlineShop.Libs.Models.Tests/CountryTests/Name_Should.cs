﻿using NUnit.Framework;
using OnlineShop.Libs.Models.Constants;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace OnlineShop.Libs.Models.Tests.CountryTests
{
    [TestFixture]
    public class Name_Should
    {
        [Test]
        public void Have_RightValueFor_MinLength_Attribute()
        {
            var propertyName = "Name";

            var result = typeof(Country)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MinLengthAttribute))
                            .Select(x => (MinLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(Validation.Country.NameMinLenght, result.Length);
        }

        [Test]
        public void Have_RightValueFor_MaxLength_Attribute()
        {
            var propertyName = "Name";

            var result = typeof(Country)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(MaxLengthAttribute))
                            .Select(x => (MaxLengthAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(Validation.Country.NameMaxLenght, result.Length);
        }

        [Test]
        public void Have_RightValueFor_RegularExpression_Attribute()
        {
            var propertyName = "Name";

            var result = typeof(Country)
                            .GetProperty(propertyName)
                            .GetCustomAttributes(false)
                            .Where(x => x.GetType() == typeof(RegularExpressionAttribute))
                            .Select(x => (RegularExpressionAttribute)x)
                            .SingleOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(Validation.Regexs.EnBgNumSpaceMinus, result.Pattern);
        }
    }
}
