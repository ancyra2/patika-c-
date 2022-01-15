using System;
using System.Collections.Generic;
namespace project1
{
    public class Phone
    {
        public string phoneNumber;
        public string personName;
        public Dictionary<string, string> contacts;

        public Phone(string phoneNumber, string personName)
        {
            this.phoneNumber = phoneNumber;
            this.personName = personName;
            this.contacts = new Dictionary<string, string>(){
                {personName, phoneNumber},
                {"A1", "03123353535"},
                {"B1", "03123353535"},
                {"C1", "03123353535"},
                {"D1", "03123353535"},
                {"E1", "03123353535"},
            };
        }

        public void menu()
        {
            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz...");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("(1) Yeni Numara Kaydetmek");
            Console.WriteLine("(2) Varolan Numarayı Silmek");
            Console.WriteLine("(3) Varolan Numarayı Güncellemek");
            Console.WriteLine("(4) Rehberi Listelemek");
            Console.WriteLine("(5) Rehberde Arama Yapmak");

            int islem = Convert.ToInt32(Console.ReadLine());

            switch (islem)
            {
                case 1:
                    Console.WriteLine("Lütfen isim giriniz: ");
                    string contactName = Console.ReadLine();
                    Console.WriteLine("Lütfen soyisim giriniz: ");
                    string contactLastName = Console.ReadLine();
                    Console.WriteLine("Lütfen telefon numarasını ");
                    string contactPhoneNumber = Console.ReadLine();

                    this.saveContact(contactName + " " + contactLastName, contactPhoneNumber);
                    this.menu();
                    break;
                case 2:
                    Console.WriteLine("Lütfen silmek istediğiniz kişinin isim veya soyismini giriniz: ");
                    string contactInfo = Console.ReadLine();
                    Console.WriteLine(contactInfo + " adlı kişiyi silmek istiyor musunuz? (y/n)");
                    string answer = Console.ReadLine();

                    if (answer == "y" || answer == "Y")
                    {
                        bool state = this.deleteContact(contactInfo);
                        if (state == false)
                        {
                            Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                            Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
                            Console.WriteLine("* Yeniden denemek için      : (2)");
                            int subIslem = Convert.ToInt32(Console.ReadLine());

                            switch (subIslem)
                            {
                                case 1:
                                    Console.WriteLine("Çıkılıyor...");
                                    break;
                                case 2:
                                    Console.WriteLine("Lütfen silmek istediğiniz kişinin isim veya soyismini giriniz: ");
                                    string contactSubInfo = Console.ReadLine();
                                    bool subState = this.deleteContact(contactSubInfo);
                                    if (subState == false)
                                    {
                                        Console.WriteLine("Silme işlemi gerçekleştirilemedi. Çıkılıyor...");
                                    }
                                    break;
                            }
                        }
                        this.menu();
                    }
                    else
                    {
                        Console.WriteLine("Silme işlemi iptal edildi.");
                        this.menu();
                    }

                    break;
                case 3:
                    Console.WriteLine("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz:");
                    string personName = Console.ReadLine();
                    Console.WriteLine("Lütfen numarayı giriniz:");
                    string phoneNumber = Console.ReadLine();
                    try
                    {
                        this.contacts[personName] = phoneNumber;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
                        Console.WriteLine("* Güncellemeyi sonlandırmak için    : (1)");
                        Console.WriteLine("* Yeniden denemek için    : (2)");
                        int subIslem2 = Convert.ToInt32(Console.ReadLine());

                        if (subIslem2== 1)
                        {
                            Console.WriteLine("Çıkılıyor...");
                            this.menu();
                        }
                        else
                        {
                            this.menu();
                        }
                    }
                    break;
                case 4:
                    this.showContacts();
                    Console.WriteLine("Menüye dönmek için bir Enter tuşuna basın");
                    Console.ReadLine();
                    this.menu();
                    break;
                case 5:
                    Console.WriteLine("Arama yapmak istediğiniz tipi seçiniz.");
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine("İsim veya soyisime göre arama yapmak için: (1)");
                    Console.WriteLine("Telefon numarasına göre arama yapmak için: (2)");
                    int subIslem3 = Convert.ToInt32(Console.ReadLine());
                    if(subIslem3 == 1){
                        Console.WriteLine("Lütfen aramak istediğiniz kişinin adını ya da soyadını giriniz:");
                        string searchingName = Console.ReadLine();
                        bool state = this.contacts.ContainsKey(searchingName);
                        if (state == true){
                            Console.WriteLine(searchingName+ "=>" + this.contacts[searchingName]);
                            this.menu();
                        }else{
                           Console.WriteLine("Kişi bulunamadı"); 
                           this.menu();
                        }
                       
                    }else{
                        Console.WriteLine("Lütfen aramak istediğiniz kişinin telefon numarasını giriniz:");
                        string searchingNumber = Console.ReadLine();
                        bool numberState = this.contacts.ContainsValue(searchingNumber);
                        if(numberState == true){
                            foreach(var p in this.contacts){
                                if(p.Value == searchingNumber){
                                     Console.WriteLine(searchingNumber+ " => " + p.Key);
                                    break;
                                }
                            }
                            this.menu();
                           
                        }else{
                           Console.WriteLine("Kişi bulunamadı");
                           this.menu();   
                        }

                    }
                    break;
            }

        }

        public bool saveContact(string personName, string phoneNumber)
        {
            try
            {
                this.contacts.Add(personName, phoneNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        public bool deleteContact(string personName)
        {
            try
            {
                this.contacts.Remove(personName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
        public bool updateContact(string personName, string phoneNumber)
        {
            try
            {
                this.contacts[personName] = phoneNumber;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public void showContacts()
        {
            Console.WriteLine("Kişiler");
            Console.WriteLine("--------------------------------");
            foreach (var contact in this.contacts)
            {
                Console.WriteLine("{0} => {1}", contact.Key, contact.Value);
                Console.WriteLine("--------------------------------");
            }
            Console.WriteLine("*********************************");
        }

        public string searchContact(string personName)
        {
            return this.contacts[personName];
        }

    }

}
