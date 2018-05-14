using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace WpfApplication2
{
    class CarsWindowViewModel : INotifyPropertyChanged
    {
        private List<Car> _cars;
        public List<Car> Cars
        {
            get { return _cars; }
            set
            {
                _cars = value;
                OnPropertyChanged("Cars");
            }
        }
        private string _name;
        private string _carid;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string CarID
        {
            get { return _carid; }
            set
            {
                _carid = value;
                OnPropertyChanged("CarID");
            }
        }
        SQL db = new SQL();
        public Command Create { get; set; } = new Command();
        public CarsWindowViewModel()
        {
            List<Car> l = db.SelectAllCars();
            if (l != null) Cars = new List<Car>(l);
            else Cars = new List<Car>();
            Create.Method = CreateOrder;
        }

        private void CreateOrder(object obj)
        {
            try
            {
                db.CreateOrder(int.Parse(CarID), Name);
            }
            catch
            {
                Logger log = LogManager.GetCurrentClassLogger();


                log.Trace("trace message");
                log.Debug("debug message");
                log.Info("info message");
                log.Warn("warn message");
                log.Error("error message");
                log.Fatal("fatal message");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string a)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a));
        }
    }
}
