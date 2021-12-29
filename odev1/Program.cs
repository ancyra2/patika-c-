using System;
using System.Collections.Generic;
namespace odev1
{
    class Program
    {
        public static void firstQuestion()
        {
            List<int> numbers = new List<int>();
            
            Console.WriteLine("Kaç tane pozitif sayı girmek istiyorsunuz?");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sayıları giriniz");

            for (int i=0; i<n; i++){
                int number = Convert.ToInt32(Console.ReadLine());
                numbers.Add(number);
            }
            
            foreach(int number in numbers){
                if(number % 2 == 0){
                    Console.Write(number + " ");
                }
               
            }
        }
        public static void secondQuestion(){
            List<int> numbers = new List<int>();
            List<int> numbers2 = new List<int>();

            Console.WriteLine("Pozitif iki sayı giriniz...");

            for (int i=0; i<=1; i++){
                int number = Convert.ToInt32(Console.ReadLine());
                numbers.Add(number);
            }
             
            Console.WriteLine("Ayrıca kaç tane pozitif sayı girmek istiyorsunuz?");

            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Sayıları giriniz");

            for (int i=0; i<n; i++){
                int number = Convert.ToInt32(Console.ReadLine());
                numbers2.Add(number);
            }

            Console.WriteLine("Aşağıdaki sayılar {0} ile tam bölünür", numbers[1]);

            foreach(int number in numbers2){
                if(number == numbers[1] || number % numbers[1] == 0){
                    Console.Write(" " + number);
                }
            }
        }

        public static void thirdQuestion(){
            List<string> words = new List<string>();
            
            Console.WriteLine("Pozitif bir sayı giriniz...");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Lütfen {0} tane kelime öbeği giriniz...", n);

            for (int i=0; i<n; i++){
                string word = Console.ReadLine();
                words.Add(word);
            }
             Console.WriteLine("Girmiş olduğunuz kelimeler sondan başa doğru aşağıdaki şekildedir...");
             for (int i=n; i>0; i--){
                Console.WriteLine(words[i-1]);
            }
        }

        public static void fourthQuestion(){

                Console.WriteLine("Lütfen bir cümle giriniz... ");
                string phrase = Console.ReadLine();

                int wordSum = 0;
                int charSum = 0;

                String[] words = phrase.Split(' ');
                foreach (string word in words)
                {
                    wordSum +=1; 
                    foreach(char c in word){
                        charSum += 1;
                    }
                }

                Console.WriteLine("Kelime sayisi {0}", wordSum);
                Console.WriteLine("Harf sayisi {0}", charSum);
        } 
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hangi soruyu cevaplamak istiyorsaniz o sorunun numarasini giriniz(1-4)...");
            int question = Convert.ToInt32(Console.ReadLine());

            switch (question){
                case 1: 
                    firstQuestion();
                break;
                case 2: 
                    secondQuestion();
                break;
                case 3: 
                    thirdQuestion();
                break;
                case 4: 
                    fourthQuestion();
                break;
                default:
                    Console.WriteLine("Böyle bir soru sistemde yok!");
                break;
                
            }
            
        }
    }
}
