namespace Interface
{
    public partial class Translater : Form
    {
        public Translater()
        {
            InitializeComponent();
        }

        private static readonly string digits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";//Алфавит

        // перечень ошибок при работе программы
        public static readonly string noNotationFromInputEx = "Значение исходной системы счисления не было введено. См. справку";
        public static readonly string invalidNotationFromInputEx = "Введены недопустимые символы в исходной системе счисления. См. справку";
        public static readonly string invalidNotationFromValueEx = "Введено неверное значение в исходной системе счисления. См. справку";
        public static readonly string noNotationToInputEx = "Значение конечной системы счисления не было введено. См. справку";
        public static readonly string invalidNotationToInputEx = "Введены недопустимые символы в конечной системе счисления. См. справку";
        public static readonly string invalidNotationToValueEx = "Введено неверное значение в исходной системе счисления. См. справку";
        public static readonly string invalidAccuracyInputEx = "Введены недопустимые символы в точности представления. См. справку";
        public static readonly string invalidAccuracyValueEx = "Введено недопустимое значение в точности представления. См. справку";
        public static readonly string noNumberInputEx = "Число для перевода не было введено. См. справку";
        public static readonly string invalidNumberInputEx = "Введены недопустимые значения в числе для перевода. См. справку";
        public static readonly string digitOutOfNotationToEx = "В выбранном числе присутствуют цифры вне выбранной исходной системы счисления. См. справку";
        public static readonly string notZero = "Число не должно начинаться с нуля. См. справку";

        /// <summary> 
        /// Проверяет корректность введённых значений оснований систем счисления.  
        /// Выбрасывает исключение, если значения отсутствуют, не являются числами или выходят за допустимый диапазон (2–36).  
        /// </summary>
        /// <param name="notationFrom">Изначальная система счисления, строка.</param>
        /// <param name="notationTo">Конечная система счисления, строка.</param>
        /// <exception cref="Exception">
        /// Выбрасывается, если:
        /// - Значение `notationFrom` или `notationTo` отсутствует.
        /// - Значение не является числом.
        /// - Число выходит за допустимые границы (2–36).
        /// </exception>
        private static void ExceptionNumberSystemBase(string notationFrom, string notationTo)
        {
            if (notationFrom == "")
                throw new Exception(noNotationFromInputEx);

            if (!int.TryParse(notationFrom, out int result))
                throw new Exception(invalidNotationFromInputEx);

            if (int.Parse(notationFrom) < 2 || int.Parse(notationFrom) > 36)
                throw new Exception(invalidNotationFromValueEx);


            if (notationTo == "")
                throw new Exception(noNotationToInputEx);

            if (!int.TryParse(notationTo, out result))
                throw new Exception(invalidNotationToInputEx);

            if (int.Parse(notationTo) < 2 || int.Parse(notationTo) > 36)
                throw new Exception(invalidNotationToValueEx);
        }


        /// <summary> 
        /// Проверяет корректность введённого значения точности и выбрасывает исключение при некорректных данных.  
        /// </summary>
        /// <param name="accuracy">Строковое представление точности для дробной части числа.</param>
        /// <exception cref="Exception">Выбрасывается, если значение точности не является числом или выходит за допустимый диапазон (1–10).</exception>
        private static void ExceptionAccuracy(string acc)
        {
            if (acc == "") return;

            if (!int.TryParse(acc, out int result))
                throw new Exception(invalidAccuracyInputEx);

            if (int.Parse(acc) < 1 || int.Parse(acc) > 10)
                throw new Exception(invalidAccuracyValueEx);
        }

        /// <summary> 
        /// Проверяет корректность введённого числа в соответствии с указанной системой счисления.  
        /// Выбрасывает исключение, если число отсутствует, содержит недопустимые символы или выходит за пределы системы счисления.  
        /// </summary>
        /// <param name="number">Вводимое для перевода число, строка.</param>
        /// <param name="notationFrom">Изначальная система счисления, строка.</param>
        /// <exception cref="Exception">
        /// Выбрасывается, если:
        /// - Число отсутствует.
        /// - Число начинается с `-0`.
        /// - Присутствуют некорректные символы (например, лишние `-` или `,`).
        /// - Число содержит цифры, выходящие за пределы допустимого диапазона для указанной системы счисления.
        /// </exception>
        private static void ExceptionNumber(string number, string notationFrom)
        {
            if (number == "")
                throw new Exception(noNumberInputEx);

            if (number[0] == '-')
                if (number[1] == '0')
                    throw new Exception(notZero);
                else if (number[0] == '0')
                    throw new Exception(notZero);

            if (number[1..].Count(c => c == '-') > 0 || number.Count(c => c == ',') > 1)
                throw new Exception(invalidNumberInputEx);

            char notationFromUC = digits[int.Parse(notationFrom)-1];
            for (int i = 0; i < number.Length; i++)
            {
                if (!digits.Contains(number[i]) && number[i] != '-' && number[i] != ',')
                    throw new Exception(invalidNumberInputEx);

                if (number[i] > notationFromUC)
                    throw new Exception(digitOutOfNotationToEx);
            }
        }


        //обработка нажатия на кнопку
        private void result_Click(object sender, EventArgs e)
        {
            try
            {
                ExceptionNumberSystemBase(baseToChange.Text, changedBase.Text);
                ExceptionNumber(numbre.Text.ToUpper(), baseToChange.Text);
                ExceptionAccuracy(accuracy.Text);

                string number = numbre.Text.ToUpper();
                int baseFrom = int.Parse(baseToChange.Text);
                int baseTo = int.Parse(changedBase.Text);
                int acc = accuracy.Text != "" ? int.Parse(accuracy.Text) : 3;

                resultNumbre.Text = ClassLibrary.Translater.MainTranslate(number, baseFrom, baseTo, acc);
            }
            catch (Exception exit) //в случае ошибки всплывает окно с информацией об ошибке
            {
                //MessageBox.Show(exit.Message);
                ShowError(exit.Message);
            }
        }

        private void OpenTermOfUse_Click(object sender, EventArgs e)
        {
            TermsOfUse f2 = new TermsOfUse();
            f2.ShowDialog();
        }
        private void ShowError(string err)
        {
            ErrorMsg f3 = new ErrorMsg(err);      
            f3.ShowDialog();
        }
    }
}
