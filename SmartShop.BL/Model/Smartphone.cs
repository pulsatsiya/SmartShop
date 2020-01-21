using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.BL.Model
{
    [Serializable]
    public class Smartphone
    {  
        public int Id { get; set; }
        public string Name { get; set; }
        public string Screen { get; set; }
        public string OS { get; set; }
        public string CPU { get; set; }

        public int RAM { get; set; }

        public int Memory{ get; set; }
     // тут конструктор был реализован, но когда начал внедрять Entity, выдавал исключение при переборе foreach (он получается и не нужен был).
     /*  public Smartphone( string name, string screen, string os, string cpu, int ram, int memory)
        {
          
            
            Name = name;
            Screen = screen;
            OS = os;
            CPU = cpu;
            RAM = ram;
            Memory = memory;
        }
      */ 
   

        public override string ToString()
        {
            return Name;
        }

        
    }
}
