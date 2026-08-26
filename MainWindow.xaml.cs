using ACF_APP.Controls;
using ACF_APP.Models;
using Microsoft.Win32;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace ACF_APP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        // создание .json 
        private readonly string applicationsFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "ACF_log",
                    "applicationsAA1.json");
        // создание .json 

        private List<ApplicationInfo> applications = new();

        public MainWindow()
        {
            InitializeComponent();

            LoadApplications();
        }

        //загрузка .json
        private void LoadApplications()
        {
            if (!File.Exists(applicationsFile))
                return;

            try
            {
                string json = File.ReadAllText(applicationsFile);

                applications = JsonSerializer.Deserialize<List<ApplicationInfo>>(json) ?? new List<ApplicationInfo>();

                foreach (ApplicationInfo app in applications)
                {
                    AddApplicationCard(app);
                }
            }
            catch
            {
                applications = new List<ApplicationInfo>();
            }
        }

        private void AddApplicationCard(ApplicationInfo app)
        {
            ApplicationCard card = new ApplicationCard();

            card.ApplicationPath = app.Path;
            card.Text = app.Name;

            ContextMenu menu = new ContextMenu();

            MenuItem deleteItem = new MenuItem
            {
                Header = "Удалить"
            };

            deleteItem.Click += (sender, e) =>
            {
                DeleteApplication(app, card);
            };

            menu.Items.Add(deleteItem);

            card.ContextMenu = menu;

            ApplicationsPanel.Children.Add(card);
        }

        // загрузка .json

        // сохранение .json
        private void SaveApplications()
        {
            string? directory = System.IO.Path.GetDirectoryName(applicationsFile);

            if (directory != null) Directory.CreateDirectory(directory);

            string json = JsonSerializer.Serialize(
                applications, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

            File.WriteAllText(applicationsFile, json);
        }
        // сохранение .json



        // перетпскивония окна за любою область
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject source = e.OriginalSource as DependencyObject;

            while (source != null)
            {
                if (source is FrameworkElement element && element.Tag?.ToString() == "NoDrag")
                {
                    return;
                }
                // если у кнопки есть строка Tag="NoDrag" то она будет работать иначе анимации будут а функций нет

                source = VisualTreeHelper.GetParent(source);
            }

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }// перетпскивония окна за любою область

        private void CMD_Click(object sender, RoutedEventArgs e)
        {
            try // открытие проверки
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "cmd.exe",
                    UseShellExecute = true,
                    Verb = "runas"
                });// открывает cmd сразу от имени админа 
            }
            catch (Win32Exception ex) when (ex.NativeErrorCode == 1223)
            {
                // Пользователь отказался от запуска от имени администратора.
            }
        }

        private void GitHub_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/ACF137",
                UseShellExecute = true
            });
        }

        private void ADD_Click(object sender, RoutedEventArgs e)
        {// открытие проводника
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Select application", //поиск конкретных форматов
                Filter = "Executable files (*.exe)|*.exe",
                Multiselect = false
            };

            if (dialog.ShowDialog() != true)
                return;

            string applicationPath = dialog.FileName;

            string applicationName =
                System.IO.Path.GetFileNameWithoutExtension(applicationPath);

            ApplicationInfo application = new ApplicationInfo
            {
                Name = applicationName,
                Path = applicationPath
            };

            // Добавляем в список
            applications.Add(application);

            // Сохраняем JSON
            SaveApplications();

            // Создаём карточку
            AddApplicationCard(application);
        }

        private void DeleteApplication(ApplicationInfo app, ApplicationCard card)
        {
            MessageBoxResult result = MessageBox.Show(
                $"Удалить приложение из ACF APP ORGANIZER?\n\n{app.Name}",
                "ACF APP ORGANIZER",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes)
                return;

            applications.Remove(app);
            ApplicationsPanel.Children.Remove(card);

            SaveApplications();
        }

        private const string StartupName = "ACF APP Organizer";

        private bool IsAutoStartEnabled()
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Run");

            return key?.GetValue(StartupName) != null;
        }

        private void EnableAutoStart()
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Run",
                true);

            key?.SetValue(
                StartupName,
                $"\"{Environment.ProcessPath}\"");
        }

        private void DisableAutoStart()
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(
                @"Software\Microsoft\Windows\CurrentVersion\Run",
                true);

            key?.DeleteValue(StartupName, false);
        }

        private void AutoStart_Click(object sender, RoutedEventArgs e)
        {
            if (IsAutoStartEnabled())
            {
                DisableAutoStart();
                MessageBox.Show("AUTOSTART OFF");
            }
            else
            {
                EnableAutoStart();
                MessageBox.Show("AUTOSTART ON");
            }
        }
    }
}