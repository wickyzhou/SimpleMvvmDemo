using SimpleMvvmDemo.Common;
using SimpleMvvmDemo.Entity;
using System;
using System.Windows;

namespace SimpleMvvmDemo.ViewModels
{
    public class EditViewModel : ViewModelBase
    {
        private Action<int, Employee> CallBack;

        public EditViewModel()
        {
            SaveCommand = new RelayCommand(Save);
            ExitCommand = new RelayCommand(Exit);
        }

        private Employee _data;
        public Employee Data
        {
            get => _data;
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }


        public void WithParam(Employee employee, Action<int, Employee> callBack)
        {
            Data = employee ?? new Employee();
            CallBack = callBack;
        }

        public RelayCommand SaveCommand { get; set; }
        public RelayCommand ExitCommand { get; set; }


        private void Save(object obj)
        {
            CallBack?.Invoke(1, Data);
        }

        private void Exit(object obj)
        {
            CallBack?.Invoke(0, null);
        }

    }
}
