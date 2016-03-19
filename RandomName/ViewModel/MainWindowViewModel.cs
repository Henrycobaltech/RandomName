using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomName.Services;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Messaging;

namespace RandomName.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Task.Factory.StartNew(() => Title = UIConfigServices.GetWindowTitle());
            Task.Factory.StartNew(
                () =>
                {
                    var list = new List<string>();
                    var random = new Random();

                    try
                    {
                        list = new List<string>(FileServices.GetNames());
                    }
                    catch (Exception ex)
                    {

                        Messenger.Default.Send(new NotificationMessage(ex.ToString()));
                    }

                    Names = new ObservableCollection<string>();

                    while (list.Count > 0)
                    {
                        var index = random.Next(0, list.Count - 1);
                        Names.Add(list.ElementAt(index));
                        list.RemoveAt(index);
                    }
                }
                );
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                RaisePropertyChanged("Title");
            }
        }

        private ObservableCollection<string> names;

        public ObservableCollection<string> Names
        {
            get { return names; }
            set
            {
                names = value;
                RaisePropertyChanged("Names");
            }
        }


    }
}
