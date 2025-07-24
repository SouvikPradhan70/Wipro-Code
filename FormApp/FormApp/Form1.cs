namespace FormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //step 1:Add a button to the form
            //step 2 :Adda click event handler for the button
            //step 3:In the click event handler, change the text of the button
            //step 4:Run the application and click the button to see the change
            //stepp 5: use your browser control to navigate to a URL entered in the text

            webBrowser1.Navigate(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
