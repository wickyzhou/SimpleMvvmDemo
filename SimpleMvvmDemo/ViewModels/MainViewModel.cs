using SimpleMvvmDemo.Common;
using SimpleMvvmDemo.Entity;
using SimpleMvvmDemo.Service;
using SimpleMvvmDemo.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;

namespace SimpleMvvmDemo.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private EmpolyeeService _service;

        public MainViewModel()
        {
            _service = new EmpolyeeService();
            DataList = new ObservableCollection<Employee>();

            AddCommand = new RelayCommand(Add);
            EditCommand = new RelayCommand(Edit);
            DeleteCommand = new RelayCommand(Delete);

            GetAll();
        }


        private string _displayName { get; set; }
        public string DisplayName
        {
            get => _displayName;
            set
            {
                _displayName = value;
                OnPropertyChanged(nameof(DisplayName));
            }
        }

        private ObservableCollection<Employee> _dataList;
        public ObservableCollection<Employee> DataList
        {
            get => _dataList;
            set
            {
                _dataList = value;
                OnPropertyChanged(nameof(DataList));
            }
        }

        private Employee _selectedItem;
        public Employee SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public RelayCommand AddCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }


        private void Add(object obj)
        {
            EditView edit = new EditView();

            (edit.DataContext as EditViewModel).WithParam(null, (type, val) =>
            {
                edit.Close();
                if (type == 1)
                {
                    // DataList.Add(val);
                    _service.Insert(val);
                    GetAll();
                }
            });
            var flag = edit.ShowDialog() ?? false;
        }

        private void Edit(object obj)
        {
            if (SelectedItem == null) return;

            EditView edit = new EditView();

            (edit.DataContext as EditViewModel).WithParam(SelectedItem, (type, val) =>
            {
                edit.Close();
                if (type == 1)
                {
                    // DataList.Add(val);
                    _service.Update(val);
                    GetAll();
                }
            });
            edit.ShowDialog();
        }

        private void Delete(object obj)
        {
            if (SelectedItem == null) return;

            //DataList.Remove(SelectedItem);
            _service.Delete(SelectedItem.Id);
            GetAll();
        }

        private void GetAll()
        {
            DataList.Clear();
            _service.GetAll().ToList().ForEach(x =>
            {
                DataList.Add(x);
            });
        }
    }
}
