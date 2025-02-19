namespace ClassLibrary
{
    public class Translater
    {
        public static readonly string invalid_p_ex = "InvalidPValueException";
        public static readonly string invalid_q_ex = "InvalidQValueException";
        public static readonly string invalid_input_n = "";
        public static readonly string digit_out_of_P` = "NegativeNullSidesValueNgonException";

        /// <summary>
        /// Метод для обработки общей ошибки длины периметра
        /// </summary>
        /// <param name="N"> Длина периметра </param>
        /// <exception cref="Exception"> Ошибка неверной длины периметра</exception>
        public static void ErrorDispatcher(string number, string notationFrom, string notationTo, string accuracy)
        {

            if (!int.TryParse(notationFrom))
            {
                throw new Exception(invalidNotationFromInput)
            }

            if (notationFrom < 2 || notationFrom>36)
            {
                throw new Exception(invalidNotationFromValueEx)
            }

            char notationFrom = digits[int.Parse(notationFrom)]
            if (!int.TryParse(notationTo))
            {
                throw new Exception(invalidNotationToInput)
            }   
            
            if (notationTo<2 || notationTo > 36)
            {
                throw new Exception(invalidNotationFromValueEx)
            }

            if (!int.TryParse(accuracy))
            {
                throw new Exception(invalidAccuracyInput)
            }

            if (accuracy<1)
            {
                throw new Exception(invalidAccuracyValueEx)
            }

            for (int = 0; int < number.Length; int++)
                {

                    if (!digits.Contains(number[i]))
                        throw new Exception(invalidNumberInput)

                    if (number[i] > notationFrom)
                        throw new Exception(DigitOutOfNotationTo)

                }
        }
    }
}
