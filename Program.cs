namespace KioskProject {

    public class Program {
        public static void Main() {
            Console.WriteLine("Thank you for using NHS Self-Checkout, where DNA is a no-go!");
            Console.WriteLine();

            // CREATE ARRAY FOR CASH INVENTORY
            CashInventory initialCashInventory = new CashInventory {
                OneDollar = 10,
                FiveDollar = 10,
                TenDollar = 10,
                TwentyDollar = 10,
                FiftyDollar = 10,
                HundredDollar = 10,
                Penny = 100,
                Nickel = 100,
                Dime = 100,
                Quarter = 100
            };

            // CREATE KIOSK TO PUT CASH IN
            CheckoutKiosk kiosk = new CheckoutKiosk(initialCashInventory);

            kiosk.ProcessCashPayment();

            kiosk.DisplayCashInventory();
        }//end main
    }//end class
    public struct CashInventory {

        //TRACKS COINS AND DOLLARS
        public int OneDollar { get; set; }
        public int FiveDollar { get; set; }
        public int TenDollar { get; set; }
        public int TwentyDollar { get; set; }
        public int FiftyDollar { get; set; }
        public int HundredDollar { get; set; }
        public int Penny { get; set; }
        public int Nickel { get; set; }
        public int Dime { get; set; }
        public int Quarter { get; set; }


       
    }//end struct


}//end namespace