namespace ClassLibrary
{
    public static class Translater
    {
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
