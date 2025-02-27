using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Interface;  // Для доступа к классу Translater (UI)
using ClassLibrary; // Для доступа к методу MainTranslate

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

    // Класс для тестирования обработки ошибок (исключений) в методах проверки входных данных.
    [TestClass]
    public class TranslaterErrorTests
    {
        private Type uiTranslaterType;
        private MethodInfo exceptionNumberSystemBaseMethod;
        private MethodInfo exceptionAccuracyMethod;
        private MethodInfo exceptionNumberMethod;

        /// <summary>
        /// Метод инициализации для получения доступа к приватным методам через reflection.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            uiTranslaterType = typeof(Interface.Translater);
            exceptionNumberSystemBaseMethod = uiTranslaterType.GetMethod("ExceptionNumberSystemBase", BindingFlags.NonPublic | BindingFlags.Static);
            exceptionAccuracyMethod = uiTranslaterType.GetMethod("ExceptionAccuracy", BindingFlags.NonPublic | BindingFlags.Static);
            exceptionNumberMethod = uiTranslaterType.GetMethod("ExceptionNumber", BindingFlags.NonPublic | BindingFlags.Static);
        }

        /// <summary>
        /// Вспомогательный метод для вызова тестируемого метода с заданными параметрами
        /// и проверки выбрасывания исключения с ожидаемым сообщением.
        /// </summary>
        private void InvokeAndAssertException(MethodInfo method, object[] parameters, string expectedMessage)
        {
            try
            {
                method.Invoke(null, parameters);
                Assert.Fail("Ожидаемое исключение не было выброшено.");
            }
            catch (TargetInvocationException tie)
            {
                Assert.AreEqual(expectedMessage, tie.InnerException.Message);
            }
        }

        // Тесты для ExceptionNumberSystemBase
        // Проверка ошибок, связанных с некорректными значениями систем счисления (основания)

        /// <summary>
        /// Проверка: если исходное основание системы счисления не введено (пустая строка).
        /// Ожидается выбрасывание исключения с сообщением noNotationFromInputEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumberSystemBase_EmptyNotationFrom()
        {
            InvokeAndAssertException(exceptionNumberSystemBaseMethod, new object[] { "", "10" },
                Interface.Translater.noNotationFromInputEx);
        }

        /// <summary>
        /// Проверка: если исходное основание системы счисления содержит недопустимые символы (не является числом).
        /// Ожидается выбрасывание исключения с сообщением invalidNotationFromInputEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumberSystemBase_NonNumericNotationFrom()
        {
            InvokeAndAssertException(exceptionNumberSystemBaseMethod, new object[] { "ABC", "10" },
                Interface.Translater.invalidNotationFromInputEx);
        }

        /// <summary>
        /// Проверка: если исходное основание системы счисления выходит за допустимый диапазон (меньше 2).
        /// Ожидается выбрасывание исключения с сообщением invalidNotationFromValueEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumberSystemBase_OutOfRangeNotationFrom()
        {
            InvokeAndAssertException(exceptionNumberSystemBaseMethod, new object[] { "1", "10" },
                Interface.Translater.invalidNotationFromValueEx);
        }

        /// <summary>
        /// Проверка: если конечное основание системы счисления не введено (пустая строка).
        /// Ожидается выбрасывание исключения с сообщением noNotationToInputEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumberSystemBase_EmptyNotationTo()
        {
            InvokeAndAssertException(exceptionNumberSystemBaseMethod, new object[] { "10", "" },
                Interface.Translater.noNotationToInputEx);
        }

        /// <summary>
        /// Проверка: если конечное основание системы счисления содержит недопустимые символы (не является числом).
        /// Ожидается выбрасывание исключения с сообщением invalidNotationToInputEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumberSystemBase_NonNumericNotationTo()
        {
            InvokeAndAssertException(exceptionNumberSystemBaseMethod, new object[] { "10", "XYZ" },
                Interface.Translater.invalidNotationToInputEx);
        }

        /// <summary>
        /// Проверка: если конечное основание системы счисления выходит за допустимый диапазон (больше 36).
        /// Ожидается выбрасывание исключения с сообщением invalidNotationToValueEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumberSystemBase_OutOfRangeNotationTo()
        {
            InvokeAndAssertException(exceptionNumberSystemBaseMethod, new object[] { "10", "37" },
                Interface.Translater.invalidNotationToValueEx);
        }

        // Тесты для ExceptionAccuracy
        // Проверка ошибок, связанных с некорректным значением точности представления дробной части

        /// <summary>
        /// Проверка: если значение точности содержит недопустимые символы (не является числом).
        /// Ожидается выбрасывание исключения с сообщением invalidAccuracyInputEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionAccuracy_NonNumeric()
        {
            InvokeAndAssertException(exceptionAccuracyMethod, new object[] { "XYZ" },
                Interface.Translater.invalidAccuracyInputEx);
        }

        /// <summary>
        /// Проверка: если значение точности меньше допустимого диапазона (меньше 1).
        /// Ожидается выбрасывание исключения с сообщением invalidAccuracyValueEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionAccuracy_OutOfRangeLow()
        {
            InvokeAndAssertException(exceptionAccuracyMethod, new object[] { "0" },
                Interface.Translater.invalidAccuracyValueEx);
        }

        /// <summary>
        /// Проверка: если значение точности больше допустимого диапазона (больше 10).
        /// Ожидается выбрасывание исключения с сообщением invalidAccuracyValueEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionAccuracy_OutOfRangeHigh()
        {
            InvokeAndAssertException(exceptionAccuracyMethod, new object[] { "11" },
                Interface.Translater.invalidAccuracyValueEx);
        }

        // Тесты для ExceptionNumber
        // Проверка ошибок, связанных с некорректным вводом числа для перевода

        /// <summary>
        /// Проверка: если число для перевода не введено (пустая строка).
        /// Ожидается выбрасывание исключения с сообщением noNumberInputEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumber_EmptyNumber()
        {
            InvokeAndAssertException(exceptionNumberMethod, new object[] { "", "10" },
                Interface.Translater.noNumberInputEx);
        }

        /// <summary>
        /// Проверка: если число начинается с "-0", что недопустимо.
        /// Ожидается выбрасывание исключения с сообщением notZero.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumber_NegativeZeroStart()
        {
            InvokeAndAssertException(exceptionNumberMethod, new object[] { "-0", "10" },
                Interface.Translater.notZero);
        }

        /// <summary>
        /// Проверка: если число начинается с "0", что недопустимо (число не должно начинаться с нуля).
        /// Ожидается выбрасывание исключения с сообщением notZero.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumber_ZeroStart()
        {
            InvokeAndAssertException(exceptionNumberMethod, new object[] { "0", "10" },
                Interface.Translater.notZero);
        }

        /// <summary>
        /// Проверка: если в числе присутствует лишний символ '-' внутри числа.
        /// Ожидается выбрасывание исключения с сообщением invalidNumberInputEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumber_ExtraMinus()
        {
            InvokeAndAssertException(exceptionNumberMethod, new object[] { "1-2", "10" },
                Interface.Translater.invalidNumberInputEx);
        }

        /// <summary>
        /// Проверка: если в числе присутствует более одной запятой, что недопустимо.
        /// Ожидается выбрасывание исключения с сообщением invalidNumberInputEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumber_MultipleCommas()
        {
            InvokeAndAssertException(exceptionNumberMethod, new object[] { "1,2,3", "10" },
                Interface.Translater.invalidNumberInputEx);
        }

        /// <summary>
        /// Проверка: если в числе присутствует символ, не являющийся допустимым (например, '#').
        /// Ожидается выбрасывание исключения с сообщением invalidNumberInputEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumber_InvalidCharacter()
        {
            InvokeAndAssertException(exceptionNumberMethod, new object[] { "1#2", "10" },
                Interface.Translater.invalidNumberInputEx);
        }

        /// <summary>
        /// Проверка: если в числе присутствует цифра, выходящая за пределы допустимого диапазона для заданной системы счисления.
        /// Для системы с основанием 2 допустимы только цифры '0' и '1'. Передаем "2", что должно вызвать исключение.
        /// Ожидается выбрасывание исключения с сообщением digitOutOfNotationToEx.
        /// </summary>
        [TestMethod]
        public void Test_ExceptionNumber_DigitOutOfRange()
        {
            InvokeAndAssertException(exceptionNumberMethod, new object[] { "2", "2" },
                Interface.Translater.digitOutOfNotationToEx);
        }
    }
}
