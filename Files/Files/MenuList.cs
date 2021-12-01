using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files
{
    class MenuList
    {
        private IList Items;

        private int selectedIndex;

        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                value = Math.Abs(value % Items.Count);
                selectedIndex = value;
                Draw();
            }
        }

        public object SelectedItem { get { return Items[SelectedIndex]; } }

        public MenuList(IList items)
        {
            this.Items = items;
            SelectedIndex = 0;
        }
        private void Draw()
        {
            Console.Clear();
            for (int i = 0; i < Items.Count; i++)
            {
                if (i == selectedIndex)
                {
                    var tmp = Console.BackgroundColor;
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = tmp;
                    Console.WriteLine(Items[i]);
                    Console.ForegroundColor = Console.BackgroundColor;
                    Console.BackgroundColor = tmp;
                }
                else
                {
                    Console.WriteLine(Items[i]);
                }
            }
        }
       

        public static void Choise(object obj)
        {
            Console.WriteLine(obj);
        }
    }

}

