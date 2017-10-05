using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace App1
{
   public class HannesVM:INotifyPropertyChanged
    {
        public Person MyPerson { get; set; } = new Person();

        public event PropertyChangedEventHandler PropertyChanged;

        public void Lade()
        {
               MyPerson.ID = 1;
            MyPerson.Text = "Hannes";

        }
        

    }
}
