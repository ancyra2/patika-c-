using System;
using System.Collections.Generic;
namespace odev2
{
    class Program
    {
        public static void firstQuestion()
        {
            List<int> numbers = new List<int>();
            List<int> primeNums = new List<int>();
            List<int> notPrimeNums = new List<int>();

            int n = 20;
            Console.WriteLine("{0} adet pozitif sayı giriniz...", n);
            
            for (int i=0; i<n; i++){
                int number = Convert.ToInt32(Console.ReadLine());
                if(number < 0){
                    Console.WriteLine("Lütfen pozitif bir sayı giriniz...");
                    number = Convert.ToInt32(Console.ReadLine());
                }
                numbers.Add(number);
            }
            
            foreach (int number in numbers){
                int flag = 0;
                for (int i=2; i<number; i++){
                    if(number == 2){
                        primeNums.Add(number);
                        break;
                    }
                    if(number % i == 0){
                        notPrimeNums.Add(number);
                        flag = 1; 
                    }
                    if(flag == 1) break;
                }
               if (flag == 0){
                   primeNums.Add(number);
               } 
            }
            primeNums.Sort();
            notPrimeNums.Sort();
            

            int primeSum = 0;
            int notPrimeSum = 0;

            foreach (int p in primeNums){
                primeSum += p;
            }
            foreach (int np in notPrimeNums){
                notPrimeSum += np;
            }

            Console.WriteLine("{0} tane asal sayi var.", primeNums.Count);
            Console.WriteLine("{0} tane asal olmayan sayi var.", notPrimeNums.Count);
            Console.WriteLine("Asal sayilarin ortalamasi {0}",primeSum/primeNums.Count);
            Console.WriteLine("Asal olmayan sayilarin ortalamasi {0}",notPrimeSum/notPrimeNums.Count);
            Console.WriteLine("Prime Numbers ---------------------------------------------");
            foreach (int p in primeNums){
                Console.WriteLine(p);
            }
            Console.WriteLine("Not Prime Numbers ---------------------------------------------");
            foreach (int np in notPrimeNums){
                Console.WriteLine(np);
            }
            
        }

        public static void secondQuestion(){
            int n = 6;
            int[] numbers = new int[n];
            int[] max3 = new int[3];
            int[] min3 = new int[3];

            Console.WriteLine("{0} adet sayı giriniz...", n);
            
            for (int i=0; i<n; i++){
                int number = Convert.ToInt32(Console.ReadLine());
                numbers[i] = number;
            }
            Array.Sort(numbers);

            for(int i = 0; i < 3; i++){
                min3[i] = numbers[i];
            }
            for(int i = 1; i < 4; i++){
                max3[i-1] = numbers[n-i]; 
            }

            Console.WriteLine("-----------------");
            Console.WriteLine("Maximum değerleri");
            foreach (int max in max3){
                Console.WriteLine(max);
            }
            Console.WriteLine("-----------------");
            Console.WriteLine("Minumum değerleri");
            foreach (int min in min3){
                Console.WriteLine(min);
            }
            Console.WriteLine("-----------------");
            Console.WriteLine("Min ve Maks ortalama Toplamları");
            Console.WriteLine(meanSumOfTwoArrays(min3,max3));
            Console.WriteLine("-----------------");
            Console.WriteLine("Min ortalama ");
            Console.WriteLine(mean(min3));
            Console.WriteLine("-----------------");
            Console.WriteLine("Maks ortalama ");
            Console.WriteLine(mean(max3));
            
        }
        public static double mean(Array arr){
            int sum = 0;
            foreach(int val in arr){
                sum += val;
            }
            return (sum/arr.Length);
        }
         public static int meanSumOfTwoArrays(Array arr, Array arr2){
            int sum = 0;
            int sum2 = 0;
            foreach(int val in arr){
                sum += val;
            }
            foreach(int val2 in arr2){
                sum += val2;
            }
            return sum+sum2;
        }

        public static void thirdQuestion(){
            Console.WriteLine("Bir cümle giriniz...");
            string phrase = Console.ReadLine();
            
            char[] vowels = {'a','e','ı','i','o','ö','u','ü','A','E','I','İ','O','Ö','U','Ü'};
            string vows = "";
            foreach(char c in phrase){
               for(int i = 0; i<vowels.Length; i++){
                   if(c == vowels[i]){
                      vows += vowels[i]; 
                   }
               }
            }
            char[] sortedVowels = new char[vows.Length];

            for(int i = 0; i <vows.Length; i++ ){
                sortedVowels[i] = vows[i];
            }
            Array.Sort(sortedVowels);
            
            foreach(char sc in sortedVowels){
                Console.WriteLine(sc);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hangi soruyu cevaplamak istiyorsaniz o sorunun numarasini giriniz(1-3)...");
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
                default:
                    Console.WriteLine("Böyle bir soru sistemde yok!");
                break;
                
            }
        }
    }
}
