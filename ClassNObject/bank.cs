namespace ClassNObject
{
    internal class bank
    {
        private string AccHlderName;
        private double Balance;
        private static double intrestR = 0.05;

        public bank(string name, double myBalance)
        {
            AccHlderName = name;
            Balance = myBalance;
        }
        
    }
}