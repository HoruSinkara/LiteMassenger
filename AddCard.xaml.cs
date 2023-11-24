using LiteMassenger.Entity;
using LiteMassenger.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LiteMassenger
{
    /// <summary>
    /// Логика взаимодействия для AddCard.xaml
    /// </summary>
    public partial class AddCard : Window
    {
       private bool isCreated {  get; set; } 
       private Entity.Model.Task GetTask { get; set; }
        public AddCard()
        {
            InitializeComponent();
            isCreated = true;

        }
        public AddCard(Entity.Model.Task task) {
            InitializeComponent();
            isCreated = false;
            GetTask = task;
            Date.SelectedDate = GetTask.DateTime;
            Header.Text = "Изменение задачи";
            Edit.Content = "Изменить";
            DataContext = GetTask;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string title = Name.Text;
            string desc = Description.Text;
            string priority = Priority.Text;
            DateTime? date = Date.SelectedDate;
            if (title != "" && desc != "" && priority != "")
            {
                if (isCreated)
                {
                    Constants.Context.Tasks.Add(new Entity.Model.Task
                    {
                        Title = title,
                        Description = desc,
                        Priority = priority,
                        UserId = 1,
                        Status = 0,
                        DateTime = date==null ? DateTime.Now : date.Value,
                    });
                    Constants.Context.SaveChanges();
                    this.DialogResult = true;

                }
                else
                {
                    var element = Constants.Context.Tasks.Find(GetTask.Id);
                    if (element != null)
                    {
                        element.Title = title;
                        element.Description = desc;
                        element.Priority = priority;
                        element.DateTime = date == null ? DateTime.Now : date.Value;
                    }
                    
                    Constants.Context.SaveChanges();
                    this.DialogResult = true;
                }
                
            }
        }
    }
}
