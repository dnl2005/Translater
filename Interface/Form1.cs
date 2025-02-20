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
                resultNumbre.Text = Translater.MainTranslate(numbre.Text.ToUpper(), baseToChange.Text, changedBase.Text, accuracy.Text);
            }
            catch (Exception exit) //���� �������� ������, �� �������� ���������
            {
                MessageBox.Show(exit.Message);
            };
        }


    }
}
