using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Vaccinedistribution
{
    public class UserChoice
    {
        public Hospital currentCapacity = new Hospital();
        public int currentNoOfDosesAvaliableInHsp = 0;
        private int totalDodesAvaliable = 50000;
        public List<Hospital> hospitals = new List<Hospital>();
        
        public void RegisterHospital()
        {
            int capacity=0;string id;
            Console.WriteLine("Enter hospitalName");
            string name = Console.ReadLine();
            Hospital hospital = new Hospital();
            hospital.Name = name;
            bool temp=true;
            while (temp)
            {
                try
                {
                    Console.WriteLine("Enter the vaccine capacity");
                    capacity = int.Parse(Console.ReadLine());
                    if (capacity > 0)
                    {
                        Console.WriteLine("Hospital= " + name);
                        Console.WriteLine($"Vaccine capacity of {name}= " + capacity);
                        DateTime date = DateTime.Today;
                        string formatedate = date.ToString("dd-MM-yyyy");
                        id = name.Substring(0, 4) + formatedate;
                        hospital.DosesCapacityHsp = capacity;
                        hospital.Id = id;
                        hospitals.Add(hospital);
                        Console.WriteLine($"ID of the hospital{name}=" + id);
                        temp = false;
                    }
                    else
                    {
                        Console.WriteLine("Enter a valid capacity");
                    }
                }
                catch (FormatException e)
                {
                     Console.WriteLine(e.Message);
                  
                }
                
            }          
        }


        /*  foreach (Hospital listofhospitals in hospitals)
          {
              Console.WriteLine("list of hospitals:" + listofhospitals.Name);
          }
          foreach (Hospital listofids in hospitals)
          {
              Console.WriteLine("list of id's=" + listofids.Id);
          }*/

        public void SupplyVaccine()
        {
            string idOfTheHospitalRequiredDoses = "";
            int noOfDosesToBeSupplied = 0;
            Console.WriteLine("Enter the Id of the hospital where vaccine must be supplied");
            idOfTheHospitalRequiredDoses = Console.ReadLine();

            foreach (var obj in hospitals)
            {
                if (obj.Id == idOfTheHospitalRequiredDoses)
                {
                    bool temp=true;
                    while (temp)
                    {
                        try
                        {
                            Console.WriteLine("No.of doses suppiled to the hospital");
                            noOfDosesToBeSupplied = Convert.ToInt32(Console.ReadLine());
                            if (noOfDosesToBeSupplied > 0)
                            {
                                totalDodesAvaliable -= noOfDosesToBeSupplied;
                                Console.WriteLine("Total no of doses avaliable at the distributer= " + totalDodesAvaliable);
                                if (noOfDosesToBeSupplied <= obj.DosesCapacityHsp && totalDodesAvaliable >= noOfDosesToBeSupplied)
                                {
                                    obj.SuppliedDoses = noOfDosesToBeSupplied;
                                    obj.CurrentDoses += noOfDosesToBeSupplied;
                                    Console.WriteLine($"Current capacity of the{idOfTheHospitalRequiredDoses}=" + obj.CurrentDoses);
                                    temp= false;
                                }
                                else
                                {
                                    Console.WriteLine("not enough capacity");
                                }
                            }
                        }
                        catch (FormatException e) { Console.WriteLine(e.Message); }
                    }                   
                }
               
            }    
        }

        public void TransferVaccines()
        {
            bool temp = true;
            int noOfDosesToBeTransfer = 0;
            Console.WriteLine("Id of the hospital sending the doses");
            string idOfTheHspSendingTheDoses = Console.ReadLine();
            Console.WriteLine("Id of the hospital receiving the doses");
            string idOfTheHspReceievingTheDoses = Console.ReadLine();
            while (temp)
            {
                try
                {
                    Hospital supplyHospital = hospitals.Find(h => h.Id == idOfTheHspSendingTheDoses);
                    Hospital reciverHospital = hospitals.Find(h => h.Id == idOfTheHspReceievingTheDoses);
                    if (hospitals.Contains(supplyHospital))
                    {
                        if (hospitals.Contains(reciverHospital))
                        {

                            Console.WriteLine("No of doses to be transfer");
                            noOfDosesToBeTransfer = Convert.ToInt32(Console.ReadLine());
                            if (noOfDosesToBeTransfer > 0)
                            {
                                if (noOfDosesToBeTransfer <= reciverHospital.DosesCapacityHsp && noOfDosesToBeTransfer + reciverHospital.CurrentDoses <= reciverHospital.DosesCapacityHsp)
                                {
                                    Console.WriteLine($"Current no of dosesavliable at {idOfTheHspReceievingTheDoses} =" + (reciverHospital.CurrentDoses += noOfDosesToBeTransfer));
                                    Console.WriteLine($"Current no of doses avaliable at {idOfTheHspSendingTheDoses}=" + (supplyHospital.CurrentDoses -= noOfDosesToBeTransfer));
                                    temp = false;
                                }
                                else
                                { Console.WriteLine("No sufficent doses at sender"); }                                                                
                            } else { Console.WriteLine("Not a correct input"); }
                        } else { Console.WriteLine("Not  found in the register"); }
                    } else{ Console.WriteLine("Not found in the register"); }
                }
                catch
                {
                    Console.WriteLine("no matches found");
                }
            }
        }
        public void RemoveHospital()
        {
            Console.WriteLine("Id of the hospital to be deleted");
            string idOfTheHospitalToBeDeleted = Console.ReadLine();

            Hospital hspToBeRemoved = hospitals.SingleOrDefault(h => h.Id == idOfTheHospitalToBeDeleted);
            if (hospitals.Contains(hspToBeRemoved))
            {
                if (hspToBeRemoved.CurrentDoses > 0)
                {
                    Console.WriteLine(totalDodesAvaliable += hspToBeRemoved.CurrentDoses);
                    Console.WriteLine("Total doses avaliable at the distributer=" + totalDodesAvaliable);
                    int i = hspToBeRemoved.CurrentDoses - hspToBeRemoved.CurrentDoses;
                    hospitals.Remove(hspToBeRemoved);
                    Console.WriteLine($"{hspToBeRemoved.Id} is removed from the hospitals");
                    Console.WriteLine(hspToBeRemoved.CurrentDoses + " are transered to the distributer");
                }
            }
            else if(hospitals!= null)
            {
                Console.WriteLine("not present in the register");
            }
        }
        public void ShowHospitals()
        {
            Console.WriteLine("list of hospitals registered");
            foreach (Hospital listofhospitals in hospitals)
            {
                Console.WriteLine($"{ listofhospitals.Name}.{ listofhospitals.DosesCapacityHsp},{ listofhospitals.CurrentDoses}");

            }
        }

        public void NumberOfVaccinesSupplied()
        {
            hospitals.ForEach(h => { Console.WriteLine($" {hospitals.IndexOf(h) + 1}. {h.Name}"); });
            
            Console.WriteLine("Select the hospital by  giving proper index:");
            int indexOfHospital = Convert.ToInt32(Console.ReadLine());
            hospitals.ForEach(h2 => {
                if (indexOfHospital == 0)
                {
                    Console.WriteLine("Enter the valid index of the hospital");
                }
                else
                {
                    if (hospitals[indexOfHospital - 1] == h2)
                    {
                        Console.WriteLine("no.of doses supplied to the " + h2.SuppliedDoses);
                    }
                }
            });

        }
    } 
}