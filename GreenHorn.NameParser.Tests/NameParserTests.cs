using GreenHorn.NameParser.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GreenHorn.NameParser.Tests
{

    [TestClass]
    public class NameParserTests
    {
        public const string E = "";

        [DataTestMethod]
        [DataRow("Adam", E, "Adam", E, E, E, false)]
        [DataRow("Adam Baker", E, "Adam", E, "Baker", E, false)]
        [DataRow("Adam Baker Jr", E, "Adam", E, "Baker", "Jr", false)]
        [DataRow("Adam Baker Jr.", E, "Adam", E, "Baker", "Jr.", false)]
        [DataRow("Adam P. Baker", E, "Adam", "P.", "Baker", E, false)]
        [DataRow("Mr Adam Baker", "Mr", "Adam", E, "Baker", E, false)]
        [DataRow("Mr. Adam Baker", "Mr.", "Adam", E, "Baker", E, false)]
        [DataRow("Mr Adam P. Baker III Phd.", "Mr", "Adam", "P.", "Baker", "III Phd.", false)]
        [DataRow("Mr. Adam P. Baker III Phd.", "Mr.", "Adam", "P.", "Baker", "III Phd.", false)]
        [DataRow("Mr Adam P. Baker III Phd", "Mr", "Adam", "P.", "Baker", "III Phd", false)]
        [DataRow("Mr. Adam P. Baker III Phd", "Mr.", "Adam", "P.", "Baker", "III Phd", false)]
        [DataRow("Adam della Baker", E, "Adam", E, "della Baker", E, false)]
        [DataRow("Adam della Baker", E, "Adam", E, "della Baker", E, false)]
        [DataRow("Mr Adam della Baker", "Mr", "Adam", E, "della Baker", E, false)]
        [DataRow("Mr. Adam della Baker", "Mr.", "Adam", E, "della Baker", E, false)]
        [DataRow("fr Adam Baker", "fr", "Adam", E, "Baker", E, false)]
        [DataRow("Fr Adam Baker", "Fr", "Adam", E, "Baker", E, false)]
        [DataRow("fr. Adam Baker", "fr.", "Adam", E, "Baker", E, false)]
        [DataRow("Fr. Adam Baker", "Fr.", "Adam", E, "Baker", E, false)]
        //Future Plans
        //[DataRow("Mr Baker", "Mr", E, E, "Baker", E, false)]
        //[DataRow("Mr. Baker", "Mr.", E, E, "Baker", E, false)]
        //MultiPartName
        //[DataRow("Mr. Adam and Mrs. Crystal Baker", "Mr.", E, E, "Baker", E, false)]
        public void NameParser_Parse_correctly_returns_parses_human_name(
            string fullName,
            string prefix,
            string firstName,
            string middleName,
            string lastName,
            string suffix,
            bool isBusinessName
            )
        {
            Name expectedResult = new Name() {
                Prefix = prefix, 
                First = firstName, 
                Middle = middleName, 
                Last = lastName, 
                Suffix = suffix,
                IsOrganization = isBusinessName
            };
            var parser = new NameParser();
            var results = parser.Parse(fullName);

            Assert.AreEqual(
                expected: expectedResult,
                actual: results);
        }

        [DataTestMethod]
        [DataRow("Bussiness")]
        [DataRow("BName Name Inc") ]
        [DataRow("BName Name llc")]
        [DataRow("BName Name LLC")]
        [DataRow("BName Name DBA")]
        [DataRow("BName Name dba")]
        [DataRow("BName Multi")]
        [DataRow("BName clinic")]
        [DataRow("BName counselers")]
        [DataRow("BName health")]
        [DataRow("BName service")]
        [DataRow("BName services")]
        [DataRow("BName +")]
        [DataRow("BName $")]
        public void NameParser_Parse_correctly_parses_and_returns_business_name(string fullName)
        {
            Name expectedResult = new Name()
            {
                Prefix = E,
                First = fullName,
                Middle = E,
                Last = E,
                Suffix = E,
                IsOrganization = true
            };
            var parser = new NameParser();
            var results = parser.Parse(fullName);

            Assert.AreEqual(
                expected: expectedResult,
                actual: results);
        }

        [DataTestMethod]
        [DataRow(null)]
        [DataRow(E)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NameParser_Parse_thows_exception_when_null_is_passed(string fullName)
        {
            var parser = new NameParser().Parse(fullName);
        }
    }
}
