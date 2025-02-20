using ClassLibrary;
namespace Interface
{
    public partial class Translater : Form
    {
        public Translater()
        {
            InitializeComponent();
        }

        //функция события "клик" по кнопке "результат"
        private void result_Click(object sender, EventArgs e)
        {
            //вызывается основная функция перевода числа
            try
            {
                resultNumbre.Text = ClassLibrary.Translater.MainTranslate(numbre.Text, baseToChange.Text, changedBase.Text, accuracy.Text);
            }
            catch (Exception exit) //если получена ошибка, то вывводит сообщение
            {
                MessageBox.Show(exit.Message);
            };
        }


    }
}
