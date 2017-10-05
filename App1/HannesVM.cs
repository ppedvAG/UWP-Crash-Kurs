using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace App1
{
   public class HannesVM:INotifyPropertyChanged
    {
        public Person MyPerson { get; set; } = new Person();
        public ObservableCollection<Customer> CustListe { get; set; } = new ObservableCollection<Customer>();

        public event PropertyChangedEventHandler PropertyChanged;

        public void Lade()
        {
               MyPerson.ID = 1;
            MyPerson.Text = "Hannes";

        }
        public async Task ladeKundenAsync()
        {
            var f = await KnownFolders.MusicLibrary.GetFileAsync("northwind.json");
            var str=await FileIO.ReadTextAsync(f);
            var items = JsonConvert.DeserializeObject<List<Customer>>(str);
            foreach (var item in items)
            {
                CustListe.Add(item);
            }
        }


    }
}
