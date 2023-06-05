using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoX6
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var contactos = new List<Contactos>
            {
                new Contactos { LastName = "Huayta", FirstName = "Jheferson"},
                new Contactos { LastName = "Charlote", FirstName = "alex"},
                new Contactos { LastName = "Marin", FirstName = "Jaime"},
                new Contactos { LastName = "Vazquez", FirstName = "Raul" },
                new Contactos { LastName = "Najarro", FirstName = "Aldair" },
                new Contactos { LastName = "Alanya", FirstName = "Zoe" },
                new Contactos { LastName = "Quispe", FirstName = "Ashe" },
                new Contactos { LastName = "Rosas", FirstName = "Andy" },
                new Contactos { LastName = "Mamani", FirstName = "Alex" },
                new Contactos { LastName = "Chan", FirstName = "Marta" },
                new Contactos { LastName = "Torres", FirstName = "Lenard" },
                new Contactos { LastName = "German", FirstName = "nancy" },
                new Contactos { LastName = "Baldez", FirstName = "Lucia"}
            };

            var contactsGrouped = new ObservableCollection<Grouping<string, Contactos>>(
                contactos.OrderBy(c => c.LastName)
                        .ThenBy(c => c.FirstName)
                        .GroupBy(c => c.LastName?.Substring(0, 1).ToUpper())
                        .Select(g => new Grouping<string, Contactos>(g.Key, g)));

            listView.ItemsSource = contactsGrouped;
        }
    }
    public class Contactos
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
    }
}
