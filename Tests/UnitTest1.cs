using ClassLibrary;
namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ErrorDispatcher_102_errorReturn()
        {
            string testNUMBER1 = "102";
            string p = "2";
            string q = "10";
            string m = "4";
            var result = Assert.ThrowsException<Exception>(() =>Translater.ErrorDispatcher(testNUMBER1,p,q,m));
            Assert.AreEqual(Translater.invalidNotationFromValueEx, result.Message);
        }
    }
}