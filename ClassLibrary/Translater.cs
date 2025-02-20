﻿using System.Globalization;

namespace ClassLibrary
{
    public static class Translater
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

            if (int.Parse(notationFrom) < 2 || int.Parse(notationFrom) > 36)
            {
                throw new Exception(invalidNotationFromValueEx);
            }

            char notationFromUC = digits[int.Parse(notationFrom)]; //перевод изначальной системы счисления в UniCode
            if (!int.TryParse(notationTo, out result))
            {
                throw new Exception(invalidNotationToInputEx);
            }

            if (int.Parse(notationTo) < 2 || int.Parse(notationTo) > 36)
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

            for (int i = 0; i < number.Length; i++)
            {

                if (!digits.Contains(number[i]))
                    throw new Exception(invalidNumberInputEx);

                if (number[i] > notationFromUC)
                    throw new Exception(DigitOutOfNotationToEx);

            }
        }

        public static string ConvertOtherToDec(string n, int nBase, int m)
        {
            //Блок Инициализации
            string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";//Алфавит
            string result = "";//возвращаемый результат
            string[] splitNum = n.Split(',');//разделяем начальное число на целую и дробную части

            string whole = splitNum[0];//целая часть
            string frac = splitNum.Length > 1 ? splitNum[1] : "";//дробная часть, проверяем если вообще есть

            int wholeDec = 0;//переведенная целая часть
            double fracDec = 0;//переведенная дробная часть

            //переводим целую часть
            for (int i = 0; i < whole.Length; i++)
            {
                char curNum = whole[i];
                int curNumValue = digits.IndexOf(curNum);
                wholeDec += curNumValue * (int)Math.Pow(nBase, whole.Length - i - 1);
            }

            //переводим дробную часть
            for (int i = 0; i < frac.Length; i++)
            {
                char curNum = frac[i];
                int curNumValue = digits.IndexOf(curNum);
                fracDec += curNumValue * Math.Pow(nBase, -(i + 1));
            }

            //Обработка результата
            //обрабатываем округление, замен точки на запятую, проверяем наличие дробной части
            double resultPrecalc = (Math.Round(double.Parse(wholeDec + (fracDec > 0 ? "." + ((fracDec * 10).ToString("")).Replace(".", "") : "")), m));
            result = (resultPrecalc.ToString().Replace(".", ","));

            //возврат
            return result;
        }

        public static string ConvertDecToOther(string n, int newBase, int m)
        {
            string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // Алфавит
            string result = ""; // возвращаемый результат
            string[] splitNum = n.Contains(',') ? n.Split(',') : new string[] { n }; // разделяем начальное число на целую и дробную части
            double resultPrecalc = 0;

            int whole = Int32.Parse(splitNum[0]); // целая часть
            double frac = n.Contains(',') ? (double.Parse(splitNum.Length > 1 ? "0." + splitNum[1] : "0")) : 0; // дробная часть, проверяем если вообще есть

            string wholeNew = ""; // переведенная целая часть
            string fracNew = ""; // переведенная дробная часть

            // переводим целую часть
            while (whole > 0)
            {
                wholeNew = digits[whole % newBase] + wholeNew; // Взять остаток и перевести его в новую сс
                whole /= newBase; // Делим нацело
            }

            // переводим дробную часть
            while (frac > 0 && fracNew.Length < m)
            {
                frac *= newBase;
                int intPart = (int)frac;
                fracNew += digits[intPart]; // Взять целую часть и перевести её в новую сс
                frac -= intPart; // Убираем целую часть
            }

            resultPrecalc = Math.Round(double.Parse(wholeNew + (n.Contains(',') ? ("." + fracNew) : "")), m);//собираем число обратно и форматируем результат 
            result = resultPrecalc.ToString().Replace('.', ',');//конвертируем результат и форматируем
                                                                // возврат
            return result;
        }
    }
}
