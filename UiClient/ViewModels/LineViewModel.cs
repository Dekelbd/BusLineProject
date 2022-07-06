using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using Model.Interfaces;

namespace UiClient.ViewModels
{
    public class LineViewModel : ViewModelBase
    {
        private ObservableCollection<Line> _lines;
        private List<Line> CurrentLines;

        public void GetLines()
        {
            CurrentLines = BusService.Instance.GetLines();
            ObservableCollection<Line> obsCollection = new ObservableCollection<Line>(CurrentLines);
            _lines = obsCollection;

        }

        public LineViewModel()  
        {
            GetLines();
        }
        public ObservableCollection<Line> Lines
        {

            get
            {
                return _lines;
            }
            set
            {
                _lines = value;
                OnPropertyChanged("Lines");
            }
        }


    }
}
