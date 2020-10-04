using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp7
{
    interface Ipart
    {
          void toDo();
    }
    class House: Ipart
    {
      public Stack<Ipart> hous=new Stack<Ipart>(11);


        public void toDo()
        {
            if(hous.Count==11)
            Console.WriteLine("дом построен");
            else
                Console.WriteLine("дом еще не построен");
        }
    }
    class Basememt :Ipart
    {
        public void toDo()
        {
            Console.WriteLine("фундамент построен");
        }
    }
    class Roof : Ipart
    {
        public void toDo()
        {
            Console.WriteLine("крыша построена");
        }
    }
    class Walls :Ipart
    {
        public void toDo()
        {
            Console.WriteLine("построенна новая стена");
        }
    }
    class Window: Ipart
    {
        public void toDo()
        {
            Console.WriteLine("построенно новое окно");
        }
    }
    class Door : Ipart
    {
        public void toDo()
        {
            Console.WriteLine("построенна новая дверь");
        }
    }
   
    
    
    interface IWorker
    {
        void Work();
    }
   
  
    class Team:IWorker
    {
        
        protected House h = new House();   
        public List<IWorker> team = new List<IWorker>(5) ;
        public void Work()
        {
            menu();
        }   
        private void menu()
        {
            int ch;
            do
            {
                Console.Clear();
                foreach (var item in team)
                {
                    if(team[0] is Worker || team[1] is Worker)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("в команде нет рабочих");
                        Thread.Sleep(600);
                        Environment.Exit(0);
                    }
                }
                Console.WriteLine("что строить?\n1.Фундамент\n2.Окно\n3.Дверь\n4.Стена\n5.Крыша\n6.Готов ли дом\n7.Отчет Бригадира");
                ch = 0;
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        foreach (var item in h.hous)
                        {
                            if (item is Basememt)
                            {
                                Console.WriteLine("фундамент уже есть");
                                Thread.Sleep(500);
                                menu();
                            }
                        }
                        Basememt BM = new Basememt();
                        h.hous.Push(BM);
                        BM.toDo();
                        Thread.Sleep(500);
                        break;
                    case 2:
                        int w_count = 0;
                        foreach (var item in h.hous)
                        {
                            if (item is Window)
                                w_count++;
                            if (w_count == 4)
                            {
                                Console.WriteLine("уже есть 4 окна");
                                Thread.Sleep(500);
                                
                                menu();
                            }
                        }
                        Window w = new Window();
                        h.hous.Push(w);
                        w.toDo();
                        Thread.Sleep(500);
                        break;
                    case 3:
                        foreach (var item in h.hous)
                        {
                            if (item is Door)
                            {
                                Console.WriteLine("уже есть дерь");
                                Thread.Sleep(500);
                                menu();
                            }                             
                        }
                        Door d=new Door();
                        h.hous.Push(d);
                        d.toDo();
                        Thread.Sleep(500);
                        break;
                    case 4:
                        int walls_count = 0;
                        foreach (var item in h.hous)
                        {
                            if (item is Walls)
                                walls_count++;
                            if (walls_count == 4)
                            {
                                Console.WriteLine("уже есть 4 стены");
                                Thread.Sleep(500);

                                menu();
                            }
                        }
                        Walls wall = new Walls();
                        h.hous.Push(wall);
                        wall.toDo();
                        Thread.Sleep(500);
                        break;
                    case 5:
                        foreach (var item in h.hous)
                        {
                            if(item is Roof )
                            {
                                Console.WriteLine("уже есть крыша");
                                Thread.Sleep(500);
                                menu();
                            }
                        }
                        Roof r = new Roof();
                        h.hous.Push(r);
                        r.toDo();
                        Thread.Sleep(500);
                        break;
                    case 6:
                        h.toDo();
                        Thread.Sleep(500);
                        break;
                    case 7:
                        foreach (var item in team)
                        {
                            if (item is Brigadir)
                            {
                                Brigadir br = new Brigadir();

                                br.Calculate(h);
                            }
                            else
                            {
                                Console.WriteLine("в команде нет бригадира");
                                
                            }
                        }
                       
                        Thread.Sleep(1500);
                        break;
                    default:
                        break;
                }

            } while (true);
          

        }
    }
    class Worker: IWorker
    {
        public void Work()
        {
            Console.WriteLine("Рабочий работает");
        }
    }
    class Brigadir: Team , IWorker
    {

        public new void Calculate(House h )
        {
            bool door_chek = false;
            bool roof_chek = false;
            bool bm_chek = false;
            int window_chek = 0;
            int walls_chek = 0;
            foreach (var item in h.hous)
            {
                if (item is Door)
                    door_chek = true;
                if (item is Roof)
                    roof_chek = true;
                if (item is Basememt)
                    bm_chek = true;
                if (item is Window)
                    window_chek++;
                if (item is Walls)
                    walls_chek++;
            }
            if (bm_chek == true)
                Console.WriteLine("основание есть");
            else
                Console.WriteLine("основания нет");
            Console.WriteLine($"стен:{ walls_chek }");
            if (door_chek == true)
                Console.WriteLine("дверь есть");
            else
                Console.WriteLine("двери нет");
            if (roof_chek == true)
                Console.WriteLine("крыша есть");
            else
                Console.WriteLine("крыши нет");
            Console.WriteLine($"окон:{ window_chek }");
           
        }
    }

}
