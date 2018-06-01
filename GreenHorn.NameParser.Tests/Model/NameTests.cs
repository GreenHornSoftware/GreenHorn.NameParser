using GreenHorn.NameParser.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreenHorn.NameParser.Tests.Model
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void NameTest_Name_model_two_different_Name_models_are_equal()
        {

            var one = new Name()
            {
                First = "Foo",
                Last = "Bar",
                Middle = "B",
                Prefix = "",
                Suffix = "III"
            };
            var two = new Name()
            {
                First = "Foo",
                Last = "Bar",
                Middle = "B",
                Prefix = "",
                Suffix = "III"
            };

            Assert.AreEqual(one, two);
        }

        [TestMethod]
        public void NameTest_Name_model_set_to_different_Name_model_are_equal()
        {

            var one = new Name()
            {
                First = "Foo",
                Last = "Bar",
                Middle = "B",
                Prefix = "Mr.",
                Suffix = "III"
            };
            var two = one;

            Assert.AreEqual(one, two);
        }

        [TestMethod]
        public void NameTest_Name_model_equal_method_call_are_equal()
        {
            var one = new Name()
            {
                First = "Foo",
                Last = "Bar",
                Middle = "B",
                Prefix = "Mr.",
                Suffix = "III"
            };
            var two = new Name()
            {
                First = "Foo",
                Last = "Bar",
                Middle = "B",
                Prefix = "Mr.",
                Suffix = "III"
            };

            Assert.IsTrue(one.Equals(two));
        }
    }
}
