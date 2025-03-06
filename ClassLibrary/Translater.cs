using System.Globalization;

namespace ClassLibrary
{
    public static class Translater
    {
        private static readonly string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";//Алфавит

        /// <summary>
        /// Метод связывающий методы перевода в десятичную из иной и из иной в десятичную
        /// Создан для более удобной связи с интерфейсом
        /// </summary>
        /// <param name="n">  начальное число с которым производим операцию, строка  </param>
        /// <param name="notationFrom">  начальное основание из которой переводим, цел. число  </param>
        /// <param name="notationTo">  конечная система счисления, в которую переводим, цел. число  </param>
        /// <param name="accuracy">  точность, количество знаков после запятой, цел. число  </param>
        /// <returns>  возвращает число в конечной системе счисления, тип данных - строка  </returns>
        public static string MainTranslate(string n, int notationFrom, int notationTo, int accuracy) 
        {
            bool isNegative = false;

            if (n.Contains('-'))
            {
                isNegative = true;
                n = n.Replace("-", "");
            }

            (string whole, string frac) = GetWholeAndFrac(n);

            string outWhole = ConvertWhole(whole, notationFrom, notationTo);
            string outFrac = ConvertFrac(frac, notationFrom, notationTo, accuracy);
            string result = ResultJoin(isNegative, outWhole, outFrac);

            return result;
        }
       
        /// <summary>
        /// Метод для разделения числа на дробную и целую части
        /// Создан для упрощения переводов в MainTranslate
        /// </summary>
        /// <param name="n">  Число для разделения, строка  </param>
        /// <returns>  Возвращает две строки - целую и дробную части  </returns>
        private static (string, string) GetWholeAndFrac(string n)
        {
            n = n.Replace('.', ',');
            string[] splitNum = n.Contains(',') ? n.Split(',') : [n];//разделяем начальное число на целую и дробную части

            string whole = splitNum[0];//целая часть
            string frac = splitNum.Length > 1 ? splitNum[1] : ""; //дробная часть, проверяем если вообще есть
            return (whole, frac);
        }

        /// <summary>
        /// Метод для связи перевода целой части числа в десятичную и конечную систему счисления
        /// Создан для упрощения переводов в MainTranslate
        /// </summary>
        /// <param name="whole">  Целая часть числа, строка  </param>
        /// <param name="notationFrom">  Исходная система счисления, цел. число  </param>
        /// <param name="notationTo">  Иная система счисления, цел. число  </param>
        /// <returns>  Возвращает целую часть числа в конечной системе счисления, строка  </returns>
        private static string ConvertWhole(string whole, int notationFrom, int notationTo)
        {
            string decWhole = ConvertWholeOtherToDec(whole, notationFrom);
            string resWhole = ConvertDecToOther(decWhole, notationTo);
            return resWhole;
        }

        /// <summary>
        /// Метод для перевода целой части числа в десятичную систему счисления
        /// </summary>
        /// <param name="whole">  Целая часть числа, строка  </param>
        /// <param name="notationFrom">  Исходная система счисления, цел. число  </param>
        /// <returns>  Возвращает целую часть числа в десятичной системе счисления, цел. число  </returns>
        private static string ConvertWholeOtherToDec(string whole, int notationFrom)
        {
            int decWhole = 0;
            for (int i = 0; i < whole.Length; i++)
            {
                char curNum = whole[i];
                int curNumValue = digits.IndexOf(curNum);
                decWhole += curNumValue * (int)Math.Pow(notationFrom, whole.Length - i - 1);
            }
            return decWhole.ToString();
        }
        /// <summary>
        /// Метод для перевода целой части числа в конечную систему счисления
        /// </summary>
        /// <param name="n">  Целая часть числа в десятичной системе. счисл., строка  </param>
        /// <param name="notationTo">  Основание конечной системы счисления, цел. число  </param>
        /// <returns>  Возвращает цел. часть числа в конечной сис. счисл, строка  </returns>
        private static string ConvertDecToOther(string n, int notationTo)
        {
            string otherN = "";
            int digit = int.Parse(n);

            while (digit > 0)
            {
                int remainder = digit % notationTo;
                otherN = digits[remainder] + otherN;
                digit /= notationTo;
            }

            return otherN;
        }

        /// <summary>
        /// Метод для связи перевода дробной части числа в десятичную и конечную систему счисления
        /// Создан для упрощения переводов в MainTranslate
        /// </summary>
        /// <param name="frac">  Дробная часть числа, строка  </param>
        /// <param name="notationFrom">  Исходная система счисления, цел. число  </param>
        /// <param name="notationTo">  Основание конечной системы счисления  </param>
        /// <param name="accuracy">  Параметр для точности вычислений, число  </param>
        /// <returns>  Возвращает дробную часть числа в конечной системе счисления  </returns>
        private static string ConvertFrac(string frac, int notationFrom, int notationTo, int accuracy)
        {
            string decFrac = ConvertFracOtherToDec(frac, notationFrom);
            string resFrac = ConvertFracDecToOther(decFrac, notationTo, accuracy);
            return resFrac;
        }
        /// <summary>
        /// Метод для перевода дробной части числа в десятичную систему счисления.
        /// </summary>
        /// <param name="frac">Дробная часть числа, строка.</param>
        /// <param name="notationFrom">Исходная система счисления, целое число.</param>
        /// <returns>Возвращает дробную часть числа в десятичной системе счисления, строка.</returns>
        private static string ConvertFracOtherToDec(string frac, int notationFrom)
        {
            double decFrac = 0;
            for (int i = 0; i < frac.Length; i++)
            {
                char curNum = frac[i];
                int curNumValue = digits.IndexOf(curNum);
                decFrac += curNumValue * Math.Pow(notationFrom, -(i + 1));
            }

            return decFrac.ToString();
        }

        /// <summary>
        /// Метод для перевода дробной части числа из десятичной системы в конечную систему счисления.
        /// </summary>
        /// <param name="fract">Дробная часть числа в десятичной системе счисления, строка.</param>
        /// <param name="notationTo">Основание конечной системы счисления, целое число.</param>
        /// <param name="m">Точность вычислений, количество знаков после запятой, целое число.</param>
        /// <returns>Возвращает дробную часть числа в конечной системе счисления, строка.</returns>
        private static string ConvertFracDecToOther(string fract, int notationTo, int m)
        {
            string fracNew = "";
            double frac = double.Parse(fract);

            while (frac > 0)
            {
                frac *= notationTo; // Домножаем на новое основание системы счисления
                int intPart = (int)frac; // Берем целую часть
                fracNew += digits[intPart]; // Переводим целую часть в новую систему счисления
                frac -= intPart; // Убираем целую часть
            }

            fracNew = FracRoundOther(fracNew, notationTo, m);

            return fracNew;
        }

        /// <summary>
        /// Метод для округления дробной части числа в конечной системе счисления.
        /// </summary>
        /// <param name="fracNew">Дробная часть числа, строка.</param>
        /// <param name="newBase">Основание конечной системы счисления, целое число.</param>
        /// <param name="m">Точность вычислений, количество знаков после запятой, целое число.</param>
        /// <returns>Возвращает округленную дробную часть числа, строка.</returns>
        private static string FracRoundOther(string fracNew, int newBase, int m)
        {
            if (fracNew.Length > m) // Проверяем, нужно ли округлять
            {
                char lastDigit = fracNew[m]; // Находим цифру после той, до которой округляем
                fracNew = fracNew[..m]; // Отрезаем незначащую часть
                char roundDigit = fracNew[^1]; // Находим последнюю цифру
                if (digits.IndexOf(lastDigit) >= newBase / 2) // Если цифра после округляемой больше или равна половине основания
                {
                    roundDigit = digits[Math.Clamp(digits.IndexOf(roundDigit) + 1, 0, newBase - 1)]; // Округляем в большую сторону
                }
                fracNew = fracNew[..^1] + roundDigit; // Собираем дробную часть обратно
            }
            return fracNew;
        }

        /// <summary>
        /// Метод для объединения целой и дробной частей числа в конечный результат.
        /// </summary>
        /// <param name="isNeg">Флаг, указывающий на отрицательность числа, булевое значение.</param>
        /// <param name="whole">Целая часть числа, строка.</param>
        /// <param name="frac">Дробная часть числа, строка.</param>
        /// <returns>Возвращает число в конечной системе счисления, строка.</returns>
        private static string ResultJoin(bool isNeg, string whole, string frac)
        {
            if (frac != "")
            {
                return $"{(isNeg ? "-" : "")}" + whole + "," + frac;
            }
            else
            {
                return $"{(isNeg ? "-" : "")}" + whole;
            }
        }

    }
}
