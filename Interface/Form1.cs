using ClassLibrary;
namespace Interface
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void result_Click(object sender, EventArgs e)
        {

            try
            {
                resultNumbre.Text = Translater.MainTranslate(numbre.Text, baseToChange.Text, changedBase.Text, accuracy.Text);
            }
            catch (Exception exit)
            {
                MessageBox.Show(exit.Message);
            };
        }


    }
}
