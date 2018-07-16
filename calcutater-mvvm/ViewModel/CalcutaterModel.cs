using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace calcutater_mvvm.ViewModel
{
    public class CalcutaterModel : INotifyPropertyChanged
    {
        private string _number;
        public string Number
        {
            get { return _number; }
            set
            {
                _number = _number+ value;
                OnPropertyChanged();
            }
        }

        private int _operation;
        public int Operation
        {
            get { return _operation; }
            set
            {
                _operation=Int32.Parse(_number);
            }
        }
          


    //нажатие на цифры
    private RelayCommand numberButton;
        public RelayCommand NumberButton
        {
            get
            {
                return numberButton ??
                  (numberButton = new RelayCommand(obj =>
                  {
                      Number = obj as string;
                  }));
            }
        }

        // нажатие на С
        private RelayCommand press_с;
        public RelayCommand Press_с
        {
            get
            {
                return numberButton ??
                  (numberButton = new RelayCommand(obj =>
                  {
                      Number = "";
                  }));
            }
        }








        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



    }
}
