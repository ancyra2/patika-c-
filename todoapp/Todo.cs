using System;
using System.Collections.Generic;
using System.Linq;
namespace todoapp{
    public enum TodoProgress 
        {
            Todo ,
            InProgress,
            Done
        };
        public enum Size 
        {
            XS , 
            S, 
            M, 
            L, 
            XL
        };
    public class Todo{
        public string header;
        public string content;
        public string appointedPerson;
        public string size;

        public List<string[]> todoList = new List<string[]>();
        public List<string[]> inProgressList = new List<string[]>();
        public List<string[]> doneList = new List<string[]>();

        
        public Todo(){
            string[] todo = {"1","Todo","Baslik","Content","Anonym1","XL"};
            string[] todo2 = {"2","Todo","Default","Content","Anonym2","XL"};
            string[] inProgress = {"3","InProgress","Baslik","Content","Anonym1","L"};
            string[] done = {"4", "Done","Baslik","Content","Anonym3","XS"};
            
            this.todoList.Add(todo);
            this.todoList.Add(todo2);
            this.inProgressList.Add(inProgress);
            this.doneList.Add(done);
        }
        public void menu(){

            Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz...");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");

            int islem = Convert.ToInt32(Console.ReadLine());

            switch (islem)
            {
                case 1:
                    this.listBoard();
                    this.menu();
                    break;
                case 2:
                    Console.WriteLine("Lütfen bir id numarası giriniz       : ");
                    string id = Console.ReadLine();
                    Console.WriteLine("Lütfen kartın tipini giriniz (Todo), (InProgress), (Done)      : ");
                    string type = Console.ReadLine();
                    Console.WriteLine("Lütfen bir başlık giriniz       : ");
                    string header = Console.ReadLine();
                    Console.WriteLine("Lütfen içeriği giriniz       : ");
                    string content = Console.ReadLine();
                    Console.WriteLine("Lütfen atanacak kişiyi giriniz       : ");
                    string appointedPerson = Console.ReadLine();
                    Console.WriteLine("Lütfen önem derecesini giriniz (XS), (S), (M), (L), (XL)      : ");
                    string size = Console.ReadLine();
                    this.addCard(id, type, header, content, appointedPerson, size);
                    this.menu();
                    break;
                case 3:
                    Console.WriteLine("Lütfen silinecek kartın id değerini giriniz       : ");
                    int idToRemove = Convert.ToInt32(Console.ReadLine());
                    this.removeCard(idToRemove);
                    this.menu();
                    break;
                case 4:
                    Console.WriteLine("Lütfen güncellenecek kartın id değerini giriniz      : ");
                    int idToMove = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Lütfen güncellenecek kartın yeni tipini giriniz (Todo), (InProgress), (Done)      : ");
                    string typeToMove = Console.ReadLine();
                    this.moveCard(idToMove, typeToMove);
                    this.menu();
                    break;
            }
        }
        public void addCard(string id ,string type, string header, string content, string appointedPerson, string size){
            string[] card = {id, type, header, content, appointedPerson, size};
            if(type == "Todo"){
                this.todoList.Add(card);
            }else if(type == "InProgress"){
               this.inProgressList.Add(card);
            }else if(type == "Done"){
              this.doneList.Add(card);
            }
        }
        public void updateCard(int id, string type, string header, string content, string appointedPerson, string size){
            foreach(string[] todo in this.todoList ){
                int todoId = Convert.ToInt32(todo[0]);
                if(todoId == id){
                    todo[1] = type;
                    todo[2] = header;
                    todo[3] = content;
                    todo[4] = appointedPerson;
                    todo[5] = size;
                    return;
                }
            }
             foreach(string[] todo in this.inProgressList ){
                int todoId = Convert.ToInt32(todo[0]);
                if(todoId == id){
                    todo[1] = type;
                    todo[2] = header;
                    todo[3] = content;
                    todo[4] = appointedPerson;
                    todo[5] = size;
                    return;
                }
            }
             foreach(string[] todo in this.doneList ){
                int todoId = Convert.ToInt32(todo[0]);
                if(todoId == id){
                    todo[1] = type;
                    todo[2] = header;
                    todo[3] = content;
                    todo[4] = appointedPerson;
                    todo[5] = size;
                    return;
                }
            }
        }
        
        public void removeCard(int id){
        
             foreach(string[] todo in this.todoList ){
                
                int todoId = Convert.ToInt32(todo[0]);
                if(todoId == id){
                   this.todoList.Remove(todo);
                    return;
                }
            }
             foreach(string[] todo in this.inProgressList ){
                
                int todoId = Convert.ToInt32(todo[0]);
                if(todoId == id){
                   this.inProgressList.Remove(todo);
                    return;
                }
            }
             foreach(string[] todo in this.doneList ){
                
                 int todoId = Convert.ToInt32(todo[0]);
                if(todoId == id){
                   this.doneList.Remove(todo);
                    return;
                }
            }

        }
        public void moveCard(int id, string type){
             foreach(string[] todo in this.todoList ){
                
                int todoId = Convert.ToInt32(todo[0]);
                if(todoId == id){
                    todo[1] = type;
                    return;
                }
            }
             foreach(string[] todo in this.inProgressList ){
                
                int todoId = Convert.ToInt32(todo[0]);
                if(todoId == id){
                    todo[1] = type;
                    return;
                }
            }
             foreach(string[] todo in this.doneList ){
                
                 int todoId = Convert.ToInt32(todo[0]);
                if(todoId == id){
                    todo[1] = type;
                    return;
                }
            }
        }
        public void listBoard(){
            Console.WriteLine("TODO Line");
            Console.WriteLine("************************");
            foreach(string[] todo in this.todoList){
                Console.WriteLine("id   :"+ " " + todo[0]);
                Console.WriteLine("Başlık   :" + " " + todo[2]);
                Console.WriteLine("İçerik   :" + " " + todo[3]);
                Console.WriteLine("Atanan Kişi   :" + " " + todo[4]);
                Console.WriteLine("Büyüklük   :" + " " + todo[5]);
                Console.WriteLine("----------------------------");
            }
            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("************************");
            foreach(string[] progress in this.inProgressList){
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("id   :"+ " " + progress[0]);
                Console.WriteLine("Başlık   :" + " " + progress[2]);
                Console.WriteLine("İçerik   :" + " " + progress[3]);
                Console.WriteLine("Atanan Kişi   :" + " " + progress[4]);
                Console.WriteLine("Büyüklük   :" + " " + progress[5]);
                Console.WriteLine("----------------------------");
            }
            Console.WriteLine("DONE Line");
            Console.WriteLine("************************");
            foreach(string[] done in this.doneList){

                if(this.doneList.Count > 0){
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("id   :"+ " " + done[0]);
                    Console.WriteLine("Başlık   :" + " " + done[2]);
                    Console.WriteLine("İçerik   :" + " " + done[3]);
                    Console.WriteLine("Atanan Kişi   :" + " " + done[4]);
                    Console.WriteLine("Büyüklük   :" + " " + done[5]);
                    Console.WriteLine("----------------------------");
                }else{
                    Console.WriteLine("~ BOŞ ~");
                }
               
            }
        }
    }
    
}

