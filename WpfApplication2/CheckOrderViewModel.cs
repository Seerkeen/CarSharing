using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace WpfApplication2
{
    class CheckOrderViewModel : INotifyPropertyChanged
    {
        private Order _currorder;
        public Order currOrder
        {
            get { return _currorder; }
            set
            {
                _currorder = value;
                OnPropertyChanged("currOrder");
            }
        }
        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged("Search");
            }
        }
        SQL sql = new SQL();
        public Command Check { get; set; } = new Command();
        public CheckOrderViewModel()
        {
            Check.Method = GetInfo;
        }

        private void GetInfo(object obj)
        {
            try
            {
                currOrder = sql.CheckOrder(int.Parse(Search));
                //throw new System.ArgumentException("Parameter cannot be null", "original");
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
