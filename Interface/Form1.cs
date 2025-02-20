using ClassLibrary;
namespace Interface
{
    public partial class Translater : Form
    {
        public Translater()
        {
            InitializeComponent();
        }

        //������� ������� "����" �� ������ "���������"
        private void result_Click(object sender, EventArgs e)
        {
            //���������� �������� ������� �������� �����
            try
            {
                resultNumbre.Text = ClassLibrary.Translater.MainTranslate(numbre.Text, baseToChange.Text, changedBase.Text, accuracy.Text);
            }
            catch (Exception exit) //���� �������� ������, �� �������� ���������
            {
                MessageBox.Show(exit.Message);
            };
        }


    }
}
