using System.Globalization;

namespace ClassLibrary
{
    public class Translater
    {
        public static readonly string invalidNotationFromInputEx = "Ошибка: введены недопустимые символы в исходной системе счисления. См. справку";
        public static readonly string invalidNotationFromValueEx = "Ошибка: введено неверное значение в исходной системе счисления. См. справку";
        public static readonly string invalidNotationToInputEx = "Ошибка: введены недопустимые символы в конечной системе счисления. См. справку";
        public static readonly string invalidNotationToValueEx = "Ошибка: введено неверное значение в исходной системе счисления. См. справку";
        public static readonly string invalidAccuracyInputEx = "Ошибка: введены недопустимые символы в точности представления. См. справку";
        public static readonly string invalidAccuracyValueEx = "Ошибка: введено недопустимое значение в точности представления. См. справку";
        public static readonly string invalidNumberInputEx = "Ошибка: введены недопустимые значения в числе для перевода. См. справку";
        public static readonly string DigitOutOfNotationToEx = "Ошибка: в выбранном числе присутствуют цифры вне выбранной исходной системы счисления";


        /// <summary>
        /// Метод для обработки ошибок входных данных.
        /// Для проверки чисел на соответствие системе счисления и словарю используется сравнение по UniCode.
        /// </summary>
        /// <param name="number">Вводимое для перевода число, строка</param>
        /// <param name="notationFrom">Изначальная система счисления, строка</param>
        /// <param name="notationTo">Конечная система счисления, строка</param>
        /// <param name="accuracy">Точность представления для знаков после запятой, строка</param>
        /// <exception cref="Exception">Возвращает ошибку, строка </exception>
        public static void ErrorDispatcher(string number, string notationFrom, string notationTo, string accuracy)
        {
            if (!int.TryParse(notationFrom, out int result))
            {
                throw new Exception(invalidNotationFromInputEx);
            }
            
            if (int.Parse(notationFrom) < 2 || int.Parse(notationFrom)>36)
            {
                throw new Exception(invalidNotationFromValueEx);
            }

            char notationFromUC = digits[int.Parse(notationFrom)]; //перевод изначальной системы счисления в UniCode
            if (!int.TryParse(notationTo, out result))
            {
                throw new Exception(invalidNotationToInputEx);
            }
            
            if (int.Parse(notationTo) <2 || int.Parse(notationTo) > 36)
            {
                throw new Exception(invalidNotationToValueEx);
            }

            if (!int.TryParse(accuracy, out result))
            {
                throw new Exception(invalidAccuracyInputEx);
            }

            if (int.Parse(accuracy) < 1)
            {
                throw new Exception(invalidAccuracyValueEx);
            }

            for (int i= 0;i < number.Length; i++)
                {

                if (!digits.Contains(number[i]))
                    throw new Exception(invalidNumberInputEx);

                    if (number[i] > notationFromUC)
                    throw new Exception(DigitOutOfNotationToEx);

                }
        }
    }
}
