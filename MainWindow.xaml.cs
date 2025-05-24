using System.Globalization;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TaskItem> taskList;

        public MainWindow()
        {
            InitializeComponent();
            taskList = new List<TaskItem>();
            TasksListBox.ItemsSource = taskList;
        }

        private void AddNewTaskCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            InputPanel.Visibility = Visibility.Visible; // Показывает панель
        }

        private void AddNewTaskCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            InputPanel.Visibility = Visibility.Collapsed; // Скрывает панель
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskName = TaskTextBox.Text;
            string taskName1 = TaskTextBoxe.Text;
            DateTime? taskDate = TaskDatePicker.SelectedDate;

            if (!string.IsNullOrEmpty(taskName) && taskDate.HasValue && !string.IsNullOrEmpty(taskName1))
            {
                TaskItem newTask = new TaskItem { Name = taskName, DueDate = taskDate.Value, Descriptions = taskName1};
                taskList.Add(newTask); // Добавляет задачу в список

                
                TasksListBox.ItemsSource = null; // Очищения 
                TasksListBox.ItemsSource = taskList;

                // Очищания поля
                TaskTextBoxe.Text=null;
                TaskTextBox.Text= null; 
                TaskDatePicker.SelectedDate = null; 
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите название, выберите дату и напишите коментарий");
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный элемент из списка задач
            var selectedTask = TasksListBox.SelectedItem as TaskItem;

           
            if (selectedTask != null)
            {
                
                taskList.Remove(selectedTask);

               
                TasksListBox.ItemsSource = null; // Сбрасываем источник данных
                TasksListBox.ItemsSource = taskList; // Присваиваем обновленный список 

                MessageBox.Show("Дело успешно удалена."); // в жопу эту залупу я спать
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите задачу для удаления.");
            }
        }
    }



    public class TaskItem
    {
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public DateTime DueDate { get; set; }

        

        public override string ToString()
        {
            return $"{Name} - срок: {DueDate.ToShortDateString()}, " +
                $"\n- коментарий: {Descriptions}"; // вывод
           
        }
    }
}