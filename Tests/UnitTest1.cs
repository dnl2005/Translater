//using Interface;  
using ClassLibrary; 

// Класс для тестирования корректной работы перевода чисел.
namespace TranslaterUnitTests
{
    [TestClass]
    public class TranslaterValueTests
    {
        /// <summary>
        /// Тест перевода отрицательного числа с буквенным значением:
        /// Перевод "-A" из шестнадцатеричной (осн. 16) в десятичную (осн. 10).
        /// Ожидаемый результат: "-10".
        /// </summary>
        [TestMethod]
        public void Test_NegativeNumber_WithLetter()
        {
            string input = "-A";
            int baseFrom = 16;
            int baseTo = 10;
            int accuracy = 3;
            string result = Translater.MainTranslate(input, baseFrom, baseTo, accuracy);
            Assert.AreEqual("-10", result);
        }

        /// <summary>
        /// Тест перевода дробного числа:
        /// Перевод "10,25" из десятичной (осн. 10) в двоичную (осн. 2).
        /// Целая часть: 10₁₀ = "1010"₂; дробная часть 0,25₁₀ ≈ "01"₂ при точности 2 знака.
        /// Ожидаемый результат: "1010,01".
        /// </summary>
        [TestMethod]
        public void Test_FractionalNumber()
        {
            string input = "10,25";
            int baseFrom = 10;
            int baseTo = 2;
            int accuracy = 2;
            string result = Translater.MainTranslate(input, baseFrom, baseTo, accuracy);
            Assert.AreEqual("1010,01", result);
        }

        /// <summary>
        /// Тест перевода целого числа:
        /// Перевод "101" из двоичной (осн. 2) в десятичную (осн. 10).
        /// Ожидаемый результат: "5".
        /// </summary>
        [TestMethod]
        public void Test_IntegerNumber()
        {
            string input = "101";
            int baseFrom = 2;
            int baseTo = 10;
            int accuracy = 3;
            string result = Translater.MainTranslate(input, baseFrom, baseTo, accuracy);
            Assert.AreEqual("5", result);
        }

        /// <summary>
        /// Тест перевода числа без букв:
        /// Перевод "123" из десятичной (осн. 10) в двоичную (осн. 2).
        /// 123₁₀ = 1111011₂.
        /// </summary>
        [TestMethod]
        public void Test_NumberWithoutLetters()
        {
            string input = "123";
            int baseFrom = 10;
            int baseTo = 2;
            int accuracy = 3;
            string result = Translater.MainTranslate(input, baseFrom, baseTo, accuracy);
            Assert.AreEqual("1111011", result);
        }

        /// <summary>
        /// Тест перевода числа с буквами:
        /// Перевод "1A3" из шестнадцатеричной (осн. 16) в десятичную (осн. 10).
        /// 1A3₁₆ = 1*256 + 10*16 + 3 = 419.
        /// </summary>
        [TestMethod]
        public void Test_NumberWithLetters()
        {
            string input = "1A3";
            int baseFrom = 16;
            int baseTo = 10;
            int accuracy = 3;
            string result = Translater.MainTranslate(input, baseFrom, baseTo, accuracy);
            Assert.AreEqual("419", result);
        }
    }
}
