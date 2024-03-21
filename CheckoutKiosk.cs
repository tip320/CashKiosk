using KioskProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class CheckoutKiosk {

        public CashInventory _cashInventory;

        //CREATE NEW CASH INVENTORY
        public CheckoutKiosk(CashInventory initialCashInventory) {
            _cashInventory = initialCashInventory;
        }//end function

        //PROCESSES CASH PAYMENTS
        public void ProcessCashPayment() {

            // STORES COST OF EACH ITEM
            Dictionary<string, decimal> items = new Dictionary<string, decimal>();

            // DEFINE VARIABLES
            string  _itemName = "";
            decimal _itemCost = 0;
            decimal _totalCost = 0;
            decimal _cashPayment = 0;
            decimal _cashPaid = 0;
            decimal _currentBalance = 0;
            int     _paymentNumber = 0;
            bool _legitCurrency = false;


            //ENTER ITEMS
            do {
                Console.Write("Enter the name of the item (or press 'ENTER' to finish): ");
                _itemName = Console.ReadLine();

                if (_itemName.ToLower() != "") {
                    Console.Write("Enter the cost of the item: $");
                    decimal.TryParse(Console.ReadLine(), out _itemCost);

                    items[_itemName] = _itemCost;
                }//end if
            } while (_itemName.ToLower() != "");
            //end dowhile

            // COST CALCULATOR
            foreach (var item in items) {
                _totalCost += item.Value;
            }//end foreach


            Console.WriteLine($"Your total is: ${_totalCost:F2}.");
            Console.Write("Enter the cash payment amount: $");

        
            decimal.TryParse(Console.ReadLine(), out _cashPayment);



            if (_cashPayment < _totalCost) {
                _paymentNumber++;
                _cashPaid += _cashPayment;
                _currentBalance = _totalCost - _cashPaid;

                while (_cashPaid < _totalCost) {

                    Console.WriteLine($"Payment #{_paymentNumber}: ${_cashPayment}");
                    Console.WriteLine($"Cash Paid: ${_cashPaid}");
                    Console.WriteLine($"Remaining: ${_currentBalance}");
                    Console.WriteLine("");
                    Console.Write("Please enter your next payment: $");
                    decimal.TryParse(Console.ReadLine(), out _cashPayment);
                    _paymentNumber++;
                    _cashPaid += _cashPayment;
                    _currentBalance = _totalCost - _cashPaid;
                }
                _cashPayment = _cashPaid;
            }  //end if

            // CALCULATE CHANGE
            decimal change = _cashPayment - _totalCost;

            // DISPLAY CHANGE

            Console.WriteLine($"Total Change: {change:C}");
            Console.WriteLine();


            int hundredDollarCount = (int)(change / 100);
            change %= 100;
            int fiftyDollarCount = (int)(change / 50);
            change %= 50;
            int twentyDollarCount = (int)(change / 20);
            change %= 20;
            int tenDollarCount = (int)(change / 10);
            change %= 10;
            int fiveDollarCount = (int)(change / 5);
            change %= 5;
            int oneDollarCount = (int)(change / 1);
            change %= 1;
            int quarterCount = (int)(change / 0.25m);
            change %= 0.25m;
            int dimeCount = (int)(change / 0.10m);
            change %= 0.10m;
            int nickelCount = (int)(change / 0.05m);
            change %= 0.05m;
            int pennyCount = (int)(change / 0.01m);

            //DISPLAY CHANGE BREAKDOWN
            Console.WriteLine($"$100: {hundredDollarCount}");
            Console.WriteLine($"$50: {fiftyDollarCount}");
            Console.WriteLine($"$20: {twentyDollarCount}");
            Console.WriteLine($"$10: {tenDollarCount}");
            Console.WriteLine($"$5: {fiveDollarCount}");
            Console.WriteLine($"$1: {oneDollarCount}");
            Console.WriteLine($"Quarters: {quarterCount}");
            Console.WriteLine($"Dimes: {dimeCount}");
            Console.WriteLine($"Nickels: {nickelCount}");
            Console.WriteLine($"Pennies: {pennyCount}");

            //UPDATE CASH INVENTORY
            _cashInventory.HundredDollar -= hundredDollarCount;
            _cashInventory.FiftyDollar -= fiftyDollarCount;
            _cashInventory.TwentyDollar -= twentyDollarCount;
            _cashInventory.TenDollar -= tenDollarCount;
            _cashInventory.FiveDollar -= fiveDollarCount;
            _cashInventory.OneDollar -= oneDollarCount;
            _cashInventory.Quarter -= quarterCount;
            _cashInventory.Dime -= dimeCount;
            _cashInventory.Nickel -= nickelCount;
            _cashInventory.Penny -= pennyCount;

        }//end function

        public void DisplayCashInventory() {
            Console.WriteLine("Current Cash Inventory:");
            Console.WriteLine($"$100: {_cashInventory.HundredDollar}");
            Console.WriteLine($"$50: {_cashInventory.FiftyDollar}");
            Console.WriteLine($"$20: {_cashInventory.TwentyDollar}");
            Console.WriteLine($"$10: {_cashInventory.TenDollar}");
            Console.WriteLine($"$5: {_cashInventory.FiveDollar}");
            Console.WriteLine($"$1: {_cashInventory.OneDollar}");
            Console.WriteLine($"Quarters: {_cashInventory.Quarter}");
            Console.WriteLine($"Dimes: {_cashInventory.Dime}");
            Console.WriteLine($"Nickels: {_cashInventory.Nickel}");
            Console.WriteLine($"Pennies: {_cashInventory.Penny}");
        }//end function

        #region HELPER FUNCTIONS

        static string Input(string message) {
            Console.Write(message);
            return Console.ReadLine();
        }//end function

        static decimal InputDecimal(string message) {
            string value = Input(message);
            return decimal.Parse(value);
        }//end function

        static double InputDouble(string message) {
            string value = Input(message);
            return double.Parse(value);
        }//end function

        static int InputInt(string message) {
            string value = Input(message);
            return int.Parse(value);
        }//end function

        static string Print(string message) {
            Console.WriteLine(message);
            return message;
        }//end function

        #endregion

    }

