using LiteMassenger.Entity;
using LiteMassenger.Entity.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LiteMassenger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public List<Task> Tasks { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            

           /* List<Task> task;
            task = new List<Task>() {
                new Task{Id=1, Title = "Poest", Description="Obed v 12 chasov", Priority="Vusokiy", Status=0,DataSetDateTime=System.Data.DataSetDateTime.Local,UserId=1},
                    new Task{Id=2,Title = "Pospat", Description="Pospat posle obeda", Priority="Vusokiy", Status=1,DataSetDateTime=System.Data.DataSetDateTime.Local, UserId=2}
            };
*/
            LoadData();


        }
        private void LoadData()
        {
            Tasks = Constants.Context.Tasks.ToList();
            BackLog.ItemsSource = Tasks.Where(x => x.Status == 0);
            Progress.ItemsSource = Tasks.Where(x => x.Status == 1);
            Done.ItemsSource = Tasks.Where(x => x.Status == 2);
        }
        public Task obj { get; set; }
        private void Peremestit_Click(object sender, RoutedEventArgs e)
        {
            obj = BackLog.SelectedItem as Task;
            if (obj == null)
            {
                return;
            }
            var tac = Constants.Context.Tasks.Find(obj.Id);
            if (tac != null) { 
                tac.Status = 1;
                Constants.Context.SaveChanges();
                LoadData();
            }
        }

        private void PeremestitLeft_Click(object sender, RoutedEventArgs e)
        {
            obj = Progress.SelectedItem as Task;
            if (obj == null)
            {
                return;
            }
            var tac = Constants.Context.Tasks.Find(obj.Id);
            if (tac != null)
            {
                tac.Status = 0;
                Constants.Context.SaveChanges();
                LoadData();
            }
        }

        private void PeremestitRight_Click(object sender, RoutedEventArgs e)
        {
            obj = Progress.SelectedItem as Task;
            if (obj == null)
            {
                return;
            }
            var tac = Constants.Context.Tasks.Find(obj.Id);
            if (tac != null)
            {
                tac.Status = 2;
                Constants.Context.SaveChanges();
                LoadData();
            }
        }

        private void PeremestitLeftLeft_Click(object sender, RoutedEventArgs e)
        {
            obj = Done.SelectedItem as Task;
            if (obj == null)
            {
                return;
            }
            var tac = Constants.Context.Tasks.Find(obj.Id);
            if (tac != null)
            {
                tac.Status = 1;
                Constants.Context.SaveChanges();
                LoadData();
            }
        }

        private void AddCard_Click(object sender, RoutedEventArgs e)
        {
            AddCard addCard = new AddCard();

            if (addCard.ShowDialog() == true)
            {
               LoadData();
            }
        }

        private void MenuItem_Delete1_Click(object sender, RoutedEventArgs e)
        {
            if (BackLog.SelectedIndex == -1) return;
            string msgtext = "Вы точно хотите удалить задачу?";
            string MessageName = "Последнее китайское предупреждение";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(msgtext, MessageName, button);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var element = BackLog.SelectedItem as Task;
                    if (element != null) { Constants.Context.Tasks.Remove(element); }
                    Constants.Context.SaveChanges();
                    LoadData();
                    break;
                case MessageBoxResult.No:
                    break;
            }
                    
           
           
        }
        private void MenuItem_Delete2_Click(object sender, RoutedEventArgs e)
        {
            if (Progress.SelectedIndex == -1) return;
            string msgtext = "Вы точно хотите удалить задачу?";
            string MessageName = "Последнее китайское предупреждение";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(msgtext, MessageName, button);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var element = Progress.SelectedItem as Task;
                    if (element != null) { Constants.Context.Tasks.Remove(element); }
                    Constants.Context.SaveChanges();
                    LoadData();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void MenuItem_Delete3_Click(object sender, RoutedEventArgs e)
        {
            if (Done.SelectedIndex == -1) return;
            string msgtext = "Вы точно хотите удалить задачу?";
            string MessageName = "Последнее китайское предупреждение";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxResult result = MessageBox.Show(msgtext, MessageName, button);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    var element = Done.SelectedItem as Task;
                    if (element != null) { Constants.Context.Tasks.Remove(element); }
                    Constants.Context.SaveChanges();
                    LoadData();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void MenuItem_Change1_Click(object sender, RoutedEventArgs e)
        {
            var element = BackLog.SelectedItem as Task;
            if (element == null) return;
            AddCard addCard = new AddCard(element);
            if (addCard.ShowDialog() == true)
            {
                LoadData();
            }
        }
        private void MenuItem_Change2_Click(object sender, RoutedEventArgs e)
        {
            var element = Progress.SelectedItem as Task;
            if (element == null) return;
            AddCard addCard = new AddCard(element);
            if (addCard.ShowDialog() == true)
            {
                LoadData();
            }
        }
        private void MenuItem_Change3_Click(object sender, RoutedEventArgs e)
        {
            var element = Done.SelectedItem as Task;
            if(element == null) return;
            AddCard addCard = new AddCard(element);
            if (addCard.ShowDialog() == true)
            {
                LoadData();
            }
        }
    }
}
