using ClassLibrary;
namespace Interface
{
    public partial class Translator : Form
    {
        public Translator()
        {
            InitializeComponent();
        }

        //обработка нажатия на кнопку
        private void result_Click(object sender, EventArgs e)
        {
            try
            {
                resultNumbre.Text = ClassLibrary.Translater.MainTranslate(numbre.Text.ToUpper(), baseToChange.Text, changedBase.Text, accuracy.Text);
            }
            catch (Exception exit) //в случае ошибки всплывает окно с информацией об ошибке
            {
                MessageBox.Show(exit.Message);
            };
        }
    }
}
