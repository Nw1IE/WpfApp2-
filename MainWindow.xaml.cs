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
            InputPanel.Visibility = Visibility.Visible; // Показываем панель ввода
        }

        private void AddNewTaskCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            InputPanel.Visibility = Visibility.Collapsed; // Скрываем панель ввода
        }

        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            string taskName = TaskTextBox.Text;
            DateTime? taskDate = TaskDatePicker.SelectedDate;

            if (!string.IsNullOrEmpty(taskName) && taskDate.HasValue)
            {
                TaskItem newTask = new TaskItem { Name = taskName, DueDate = taskDate.Value };
                taskList.Add(newTask); // Добавляем задачу в список

                // Обновляем ListBox
                TasksListBox.ItemsSource = null; // Очищаем источник данных
                TasksListBox.ItemsSource = taskList; // Присваиваем новый источник

                // Очищаем поля ввода
                TaskTextBox.Text= null; // Очищаем текстовое поле
                TaskDatePicker.SelectedDate = null; // Очищаем дату
            }
            else
            {
                MessageBox.Show("Пожалуйста, введите название и выберите дату.");
            }
        }

        private void DeleteTaskButton_Click(object sender, RoutedEventArgs e)
        {
            // Получаем выбранный элемент из списка задач
            var selectedTask = TasksListBox.SelectedItem as TaskItem;

            // Проверяем, что задача выбрана
            if (selectedTask != null)
            {
                // Удаляем выбранную задачу из списка
                taskList.Remove(selectedTask);

                // Обновляем отображение списка
                TasksListBox.ItemsSource = null; // Сбрасываем источник данных
                TasksListBox.ItemsSource = taskList; // Присваиваем обновленный список 

                MessageBox.Show("Задача успешно удалена.");
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
        public DateTime DueDate { get; set; }

        public override string ToString()
        {
            return $"{Name} - срок: {DueDate.ToShortDateString()}";
        }
    }
}