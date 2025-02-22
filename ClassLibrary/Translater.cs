using System.Globalization;

namespace ClassLibrary
{
    public static class Translater
    {
        private static readonly string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";//Алфавит
        public static readonly string noNotationFromInputEx = "Значение исходной системы счисления не было введено";
        public static readonly string invalidNotationFromInputEx = "Введены недопустимые символы в исходной системе счисления. См. справку";
        public static readonly string invalidNotationFromValueEx = "Введено неверное значение в исходной системе счисления. См. справку";
        public static readonly string noNotationToInputEx = "Значение конечной системы счисления не было введено";
        public static readonly string invalidNotationToInputEx = "Введены недопустимые символы в конечной системе счисления. См. справку";
        public static readonly string invalidNotationToValueEx = "Введено неверное значение в исходной системе счисления. См. справку";
        public static readonly string invalidAccuracyInputEx = "Введены недопустимые символы в точности представления. См. справку";
        public static readonly string invalidAccuracyValueEx = "Введено недопустимое значение в точности представления. См. справку";
        public static readonly string noNumberInputEx = "Число для перевода не было введено";
        public static readonly string invalidNumberInputEx = "Введены недопустимые значения в числе для перевода. См. справку";
        public static readonly string DigitOutOfNotationToEx = "В выбранном числе присутствуют цифры вне выбранной исходной системы счисления";
        

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
            if (notationFrom== "")
                throw new Exception(noNotationFromInputEx);

            if (!int.TryParse(notationFrom, out int result))
            {
                throw new Exception(invalidNotationFromInputEx);
            }

            if (int.Parse(notationFrom) < 2 || int.Parse(notationFrom) > 36)
            {
                throw new Exception(invalidNotationFromValueEx);
            }

            char notationFromUC = digits[int.Parse(notationFrom)]; //перевод изначальной системы счисления в UniCode

            if (notationTo == "")
                throw new Exception(noNotationToInputEx);

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

            if (number == "")
                throw new Exception(noNumberInputEx);

            for (int i = 0; i < number.Length; i++)
            {

                if (!digits.Contains(number[i]) && !(number[i] == '-') && !(number[i]==','))
                    throw new Exception(invalidNumberInputEx);

                if (number[i] >= notationFromUC)
                    throw new Exception(DigitOutOfNotationToEx);

            }
        }

        
        private static int ConvertWholeOtherToDec(string whole,int nBase)
        {
            int wholeDec = 0;
            for (int i = 0; i < whole.Length; i++)
            {
                char curNum = whole[i];
                int curNumValue = digits.IndexOf(curNum);
                wholeDec += curNumValue * (int)Math.Pow(nBase, whole.Length - i - 1);
            }
            return wholeDec;
        }

        private static double ConvertFracOtherToDec(string frac,int nBase)
        {
            double fracDec = 0;
            for (int i = 0; i < frac.Length; i++)
            {
                char curNum = frac[i];
                int curNumValue = digits.IndexOf(curNum);
                fracDec += curNumValue * Math.Pow(nBase, -(i + 1));
            }
            return fracDec;

        }

        /// <summary>
        ///Метод перевода из иной системы счисления в десятичную 
        /// </summary>
        /// <param name="n">исходное число в иной системе счисления</param>
        /// <param name="nBase">основание системы счисления из которой мы переводим</param>
        /// <param name="m">точность, кол-во знаков после запятой</param>
        /// <returns>возвращает число в десятичной системе счисления, тип данных - строка</returns>
        private static string ConvertOtherToDec(string n, int nBase, int m)
        {
            //Блок Инициализации
            n = n.Replace(".", ",");

            bool isNegative = n[0] == '-';
            if (isNegative) n = n.Replace("-", "");

            string result = "";//возвращаемый результат
            string[] splitNum = n.Split(',');//разделяем начальное число на целую и дробную части

            string whole = splitNum[0];//целая часть
            string frac = splitNum.Length > 1 ? splitNum[1] : "";//дробная часть, проверяем если вообще есть

            int wholeDec = ConvertWholeOtherToDec(whole,nBase);//переведенная целая часть
            double fracDec = ConvertFracOtherToDec(frac,nBase);//переведенная дробная часть
       
            //Обработка результата
            //обрабатываем округление, замен точки на запятую, проверяем наличие дробной части
            double resultPrecalc = (Math.Round((wholeDec + fracDec), m));
            result = (isNegative ? "-" : "") + (resultPrecalc.ToString().Replace(".", ","));

            //возврат
            return result;
        }

        /// <summary>
        ///Вспомогательная функция для преобразования целой
        /// части из десятичной системы счисления в иную
        /// </summary>
        /// <param name="whole">целая часть из десятичного числа, тип данных - целое число</param>
        /// <param name="newBase"></param>
        /// <returns></returns>
        private static string ConvertWholeDecToOther(int whole, int newBase)
        {
            string wholeNew = "";
            while (whole > 0)
            {
                wholeNew = digits[whole % newBase] + wholeNew; // Взять остаток и перевести его в новую сс
                whole /= newBase; // Делим нацело
            }
            return wholeNew;
        }

        /// <summary>
        /// Вспомогательная функция для преобразования дробной
        /// части из десятичной системы счисления в иную
        /// </summary>
        /// <param name="frac">дробная часть из десятичного числа, тип данных - вещественное число</param>
        /// <param name="newBase">основание новой системы счисления, тип данных - целое число</param>
        /// <param name="m">кол-во знаков после запятой, тип данных - целое число</param>
        /// <returns>возвращает переведенную дробную часть, тип данных - строка</returns>
        private static string ConvertFracDecToOther(double frac, int newBase, int m)
        {
            string fracNew = "";


            while (frac > 0 && fracNew.Length <= m + 1)
            {
                frac *= newBase;//домножаем на новое основание сс
                int intPart = (int)frac;//берем целую часть
                fracNew += digits[intPart]; // Взять целую часть и перевести её в новую сс
                frac -= intPart; // Убираем целую часть
            }

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


        /// <summary>
        ///Метод перевода из десятичной системы счисления в иную
        /// </summary>
        /// <param name="n">исходное число в десятичной системе счисления</param>
        /// <param name="nBase">основание системы счисления в которую мы переводим</param>
        /// <param name="m">точность, кол-во знаков после запятой</param>
        /// <returns>возвращает число в иной системе счисления, тип данных - строка</returns>
        private static string ConvertDecToOther(string n, int newBase, int m)
        {
            bool isNegative = n[0] == '-';
            if (isNegative) n = n.Replace("-", "");

            string result = ""; // возвращаемый результат
            string[] splitNum = n.Contains(',') ? n.Split(',') : [n]; // разделяем начальное число на целую и дробную части

            int whole = Int32.Parse(splitNum[0]); // целая часть
            double frac = n.Contains(',') ? (double.Parse(splitNum.Length > 1 ? "0." + splitNum[1] : "0")) : 0; // дробная часть, проверяем если вообще есть

            // переводим целую часть
            string wholeNew = ConvertWholeDecToOther(whole,newBase);

            // переводим дробную часть
            string fracNew = ConvertFracDecToOther(frac, newBase, m);

            result = (isNegative ? "-" : "") + wholeNew+(fracNew != "" ? ","+ fracNew : "");//конвертируем результат и форматируем
                                                                // возврат
            return result;
        }

        private static string FormatInput(string n)
        {
            n = n.Replace(".", ",");
            return n;
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
        public static string MainTranslate(string n, string nBase, string outBase, string m)
        {
            // если точность не указана, установить стандартное знаение округления 3
            if (m == "") m = "3";

            ErrorDispatcher(n, nBase, outBase, m);

            int notationFrom = int.Parse(nBase);
            int notationTo = int.Parse(outBase);
            int accuracy = int.Parse(m);

            string nDec;//представление числа в десятеричной сс
            string nOther;//представление числа в конечной сс
            nDec = ConvertOtherToDec(n, notationFrom, accuracy);//переводим из начальной сс в десятеричную
            nOther = ConvertDecToOther(nDec, notationTo, accuracy);

            return nOther;
        }
    }
}
