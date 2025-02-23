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
        /// <param name="n">начальное число с которым производим операцию</param>
        /// <param name="nBase">начальное основание из которой переводим</param>
        /// <param name="outBase">конечная система счисления в которую переводим</param>
        /// <param name="m">точность, количество знаков после запятой</param>
        /// <returns>возвращает число в конечной системе счисления, тип данных - строка</returns>
        public static string MainTranslate(string n, string nBase, string outBase, string m)
        {
            return "1";
        }
    }
}
