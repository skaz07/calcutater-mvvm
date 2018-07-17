using System.ComponentModel;
using System.Runtime.CompilerServices;
using System;

namespace calcutater_mvvm.ViewModel
{
    public class CalcutaterModel : INotifyPropertyChanged
    {



        public bool Operation { get; set;}
        bool _needClear;

        // свойство обрабатывающее нажатие на кнопки с данными
        private string _date;
        public string Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        private double _temp;
        private string _rez;

        //нажатие на цифры ←
        private RelayCommand _back;
        public RelayCommand Back
        {
            get
            {
                return _back ??
                  (_back = new RelayCommand(obj =>
                  {
                      Date = _date.Substring(0, _date.Length - 1);
                  }));
            }
        }


        //нажатие на цифры
        private RelayCommand _numberButton;
        public RelayCommand NumberButton
        {
            get
            {
                return _numberButton ??
                  (_numberButton = new RelayCommand(obj =>
                  {
                      if (_needClear == true) _date = "";
                      Date = _date+ obj as string;
                      _needClear = false;
                  }));
            }
        }

        // нажатие на С
        private RelayCommand _press_с;
        public RelayCommand Press_с
        {
            get
            {
                return _press_с ??
                  (_press_с = new RelayCommand(obj =>
                  {
                      Date = "";
                  }));
            }
        }


        // нажатие на +
        private RelayCommand _plus;
        public RelayCommand Press_plus
        {
            get
            {
                return _plus ??
                  (_plus = new RelayCommand(obj =>
                  {
                      if (_rez == null)
                      {
                          _temp =  double.Parse(_date);
                          Date = "";
                          _rez = _temp.ToString();
                          Operation = true;
                      }
                      else
                      {
                          Date= (_temp+ double.Parse(_date)).ToString();
                          _needClear = true;
                      }
                  }));
            }
        }



        private RelayCommand _minus;
        public RelayCommand Press_minus
        {
            get
            {
                return _minus ??
                  (_minus = new RelayCommand(obj =>
                  {
                      if (_rez == null)
                      {
                          _temp = double.Parse(_date);
                          Date = "";
                          _rez = _temp.ToString();
                          Operation = false;
                      }
                      else
                      {
                          Date = (_temp - double.Parse(_date)).ToString();
                          _needClear = true;
                      }
                  }));
            }
        }

        private RelayCommand _equally;
        public RelayCommand Press_equally
        {
            get
            {
                return _equally ??
                  (_equally = new RelayCommand(obj =>
                  {
                      if (_rez != null)
                          if (Operation == true)
                          {
                              Date = (_temp + double.Parse(_date)).ToString();
                              _needClear = true;
                              _rez = null;
                          }
                          else
                          {
                              Date = (_temp - double.Parse(_date)).ToString();
                              _needClear = true;
                              _rez = null;
                          }
                  }));
            }
        }







        // Вспомогательные функции 
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }



    }
}
