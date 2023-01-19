using Vaccinedistribution;

namespace myapplication
{
    class MainMenu
    {
      //  public int CurrentNoOfDoses()
     //   {
      //      return this.totalDodesAvaliable;

     //   }
        public int totalDodesAvaliable = 500000;
        public static void Main(string[] args)
        {

            UserChoice obj = new UserChoice();
            Console.WriteLine("enter your option");
            while (true)
            {
                Console.WriteLine("MAIN MENU FOR VACCINE DISTRIBUTION");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1.Register hospital");
                Console.WriteLine("2.Suplly vaccines");
                Console.WriteLine("3.Transfer vaccines");
                Console.WriteLine("4.Remove hospital");
                Console.WriteLine("5.Show hospital");
                Console.WriteLine("6.No.of vaccines supplied");
                Console.WriteLine("7.Exit");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("enter your option");
                int option = Convert.ToInt32(Console.ReadLine());



                if (option == 1)
                {
                    obj.RegisterHospital();
                }
                else if (option == 2)
                {
                    obj.SupplyVaccine();
                }
                else if (option == 3)
                {
                    obj.TransferVaccines();
                }
                else if (option == 4)
                {
                    obj.RemoveHospital();
                }
                else if (option == 5)
                {
                    obj.ShowHospitals();
                }
                else if (option == 6)
                {
                    obj.NumberOfVaccinesSupplied();
                }
                else if (option == 7)
                { 
                    Console.WriteLine("---------- EXIT----------");
                    break;
                }
                
                    
               
               

            }
        }
    }
    
}