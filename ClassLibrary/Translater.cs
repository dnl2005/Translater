using System.Globalization;

namespace ClassLibrary
{
    public static class Translater
    {
        private static readonly string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";//Алфавит

        private static string FracRoundOther(string fracNew, int newBase, int m)
        {
            if (fracNew.Length > m)//Округленике в любой сс. Смотрим, чтобы вообще надо было округлять
            {
                char lastDigit = fracNew[m];//Находим цифру после той, до которой мы округляем
                fracNew = fracNew[..m];//Отрезаем незначащую часть
                char roundDigit = fracNew[^1];//находи последнюю цифру
                if (digits.IndexOf(lastDigit) >= newBase / 2)//Если значение цифры после той, до которой мы округляем
                                                             //больше половины основания системы счисления,
                                                             //мы округляем в большую сторону
                {
                    roundDigit = digits[Math.Clamp(digits.IndexOf(roundDigit) + 1, 0, newBase - 1)];
                }
                fracNew = fracNew[..^1] + roundDigit;//собираем дробную часть обратно
            }
            return fracNew;
        }

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

        private static string ConvertFracDecToOther(string fract, int notationTo, int m)
        {
            string fracNew = "";
            double frac = double.Parse(fract);

            for (int i = 0; i < m + 1 && frac > 0; i++)
            {
                frac *= notationTo;//домножаем на новое основание сс
                int intPart = (int)frac;//берем целую часть
                fracNew += digits[intPart]; // Взять целую часть и перевести её в новую сс
                frac -= intPart; // Убираем целую часть
            }

            fracNew = FracRoundOther(fracNew, notationTo, m);

            return fracNew;
        }

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

        private static string ConvertWhole(string whole, int notationFrom, int notationTo)
        {
            string decWhole = ConvertWholeOtherToDec(whole, notationFrom);
            string resWhole = ConvertDecToOther(decWhole, notationTo);
            return resWhole;
        }

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

        private static string ConvertFrac(string frac, int notationFrom, int notationTo, int m)
        {
            string decFrac = ConvertFracOtherToDec(frac, notationFrom);
            string resFrac = ConvertFracDecToOther(decFrac, notationTo, m);
            return resFrac;
        }

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

        private static (string, string) GetWholeAndFrac(string n)
        {
            n = n.Replace('.', ',');
            string[] splitNum = n.Contains(',') ? n.Split(',') : [n];//разделяем начальное число на целую и дробную части

            string whole = splitNum[0];//целая часть
            string frac = splitNum.Length > 1 ? splitNum[1] : ""; //дробная часть, проверяем если вообще есть

            return (whole, frac);
        }

        /// <summary>
        /// Метод связывающий методы перевода в десятичную из иной и из иной в десятичную
        /// Создан для более удобной связи с интерфейсом
        /// </summary>
        /// <param name="n">начальное число с которым производим операцию</param>
        /// <param name="nBase">начальное основание из которой переводим</param>
        /// <param name="outBase">конечная система счисления в которую переводим</param>
        /// <param name="m">точность, количество знаков после запятой</param>
        /// <returns>возвращает число в конечной системе счисления, тип данных - строка</returns>
        public static string MainTranslate(string n, int notationFrom, int notationTo, int accuracy = 3)
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
    }
}
