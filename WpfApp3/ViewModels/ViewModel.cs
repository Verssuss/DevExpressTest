using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp3.Common;
using WpfApp3.Encrypting;
using WpfApp3.Enums;
using WpfApp3.Extensions;
using WpfApp3.Models;
using WpfApp3.Views;

namespace WpfApp3.ViewModels
{
    public class ViewModel : ObservableObject
    {
        private CollectionViewSource collectionViewSource = new CollectionViewSource();

        public ICollectionView Data => collectionViewSource.View;

        public ObservableCollection<Employee> Items { get; set; }

        public IEnumerable<Position> Positions { get; set; } = new EnumerableEnum<Position>().Cast<Position>();

        public Position SelectedPosition { get; set; }
        public Employee SelectedEmployee { get; set; }

        public Position CurrentSalary { get; set; }

        public string Filter { get; set; }
        private static DispatcherTimer _timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(10) };
        private bool _isDirty = false;
        public ViewModel()
        {
            Init();
            collectionViewSource.Source = Items;
            collectionViewSource.Filter += CollectionViewSource_Filter;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private async void _timer_Tick(object? sender, EventArgs e)
        {
            if (_isDirty)
            {
                await IoC.DI.Data.Fetch(Items);
                _isDirty = false;
            }
        }

        public ICommand ApplyFilterCommand
        {
            get => new RelayCommand(() =>
            {
                isReset = false;
                collectionViewSource.View.Refresh();
            });
        }

        public ICommand ResetFilterCommand
        {
            get => new RelayCommand(() =>
            {
                isReset = true;
                collectionViewSource.View.Refresh();
            });
        }

        public ICommand AddEmployeeCommand
        {
            get => new RelayCommand(() =>
            {
                var addItem = new AddOrEditEmployee(new Employee());
                if (addItem.ShowDialog() == true)
                {
                    Employee e = addItem.Employee;
                    Items.Add(e);
                    _isDirty = true;
                }
            });
        }
        public ICommand EditEmployeeCommand
        {
            get => new RelayCommand(() =>
            {
                if (SelectedEmployee is null) return;

                Employee item = SelectedEmployee;

                var addItem = new AddOrEditEmployee(SelectedEmployee.Clone() as Employee);

                if (addItem.ShowDialog() == true)
                {
                    item = Items.FirstOrDefault(x => x.Id == addItem.Employee.Id);
                    if (item != null)
                    {
                        item.Salary = addItem.Employee.Salary;
                        item.FullName = addItem.Employee.FullName;
                        item.Position = addItem.Employee.Position;
                        item.Experience = addItem.Employee.Experience;
                        item.PhotoSource = addItem.Employee.PhotoSource;

                        _isDirty = true;
                    }
                }
            });
        }
        public ICommand DeleteEmployeeCommand
        {
            get => new RelayCommand(() =>
            {
                if (SelectedEmployee is not null)
                {
                    Items.Remove(SelectedEmployee);
                    _isDirty = true;
                }
            });
        }

        public ICrypted Crypted { get; }

        private bool isReset = false;

        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            if (Filter is null || isReset == true)
            {
                e.Accepted = true;
                return;
            }
            if (e.Item is Employee emp)
            {
                decimal.TryParse(Filter, out decimal res);
                if (emp.Salary >= res && emp.Position == SelectedPosition.GetEnumTextValue())
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }

        private async void Init()
        {
            var items = await IoC.DI.Data.GetAllAsync();
            Items = new ObservableCollection<Employee>(items.OrderByDescending(x => x.Salary));
        }

    }
}