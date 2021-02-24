using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using WpfCoreApp1.Command;
using WpfCoreApp1.Entity;
using WpfCoreApp1.Sevices;

namespace WpfCoreApp1.ViewModel
{
    public class MvvmWindowViewModel : NotificationObject
    {
        #region Fields
        private string _searchText;
        private ObservableCollection<GridData> _resultList;
        #endregion 

        #region Properties

        public ObservableCollection<GridData> GridDataList { get; private set; }

        public ManageSevice _ManageSevice { get; set; }
        // 查询关键字
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        // 查询结果
        public ObservableCollection<GridData> ResultList
        {
            get { return _resultList; }
            set
            {
                _resultList = value;
                RaisePropertyChanged("ResultList");
            }
        }

        public ICommand QueryCommand
        {
            get { return new QueryCommand(Searching, CanSearching); }
        }

        #endregion 

        #region Construction
        public MvvmWindowViewModel()
        {

        }

        public void Init()
        {

            GridDataList = _ManageSevice.GetObservableData();
            _resultList = GridDataList;
        }

        #endregion

        #region Command Handler
        public void Searching()
        {
            ObservableCollection<GridData> personList = null;
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                ResultList = GridDataList;
            }
            else
            {
                personList = new ObservableCollection<GridData>();
                foreach (GridData p in GridDataList)
                {
                    if (p.Title.Contains(SearchText))
                    {
                        personList.Add(p);
                    }
                }
                if (personList != null)
                {
                    ResultList = personList;
                }
            }
        }

        public bool CanSearching()
        {
            return true;
        }

        #endregion 

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods 

        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion 
    }
}
