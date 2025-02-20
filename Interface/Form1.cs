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
            /*string numbre = ;
            int baseCh = ;
            int changedBs = ;
            int acc = ;*/
            resultNumbre.Text = Translater.ConvertDecToOther(Translater.ConvertOtherToDec(numbre.Text, int.Parse(baseToChange.Text), 
                int.Parse(accuracy.Text)), int.Parse(changedBase.Text), int.Parse(accuracy.Text));//;
        }

       /* private void textBox1_TextChanged(object sender, EventArgs e)
        {   string numbre = textBox1.Text;
            return numbre;
        }*/
    }
}
