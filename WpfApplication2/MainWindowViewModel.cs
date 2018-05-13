using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication2
{
    class MainWindowViewModel
    {
        public Command NewOrder { get; set; } = new Command();
        public Command CheckOrder { get; set; } = new Command();
        public MainWindowViewModel()
        {
            NewOrder.Method = OpenNewWindow;
            CheckOrder.Method = OpenCheckWindow;
        }

        private void OpenCheckWindow(object obj)
        {
            Window w = new CheckOrderWindow();
            w.Show();
        }

        private void OpenNewWindow(object obj)
        {
            Window w = new CarsWindow();
            w.Show();
        }
    }
}
