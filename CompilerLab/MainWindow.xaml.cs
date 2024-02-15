using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace CompilerLab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Window1 helpwindow = new Window1();
        private string condition = "Ожидание";
        private string lang = "rus";
        private string filename = "";
        private void CreateFileDialog(object sender, RoutedEventArgs e)
        {
            CloseFileWindow closeFileWindow = new CloseFileWindow();
            if (filename != "")
            {
                if (closeFileWindow.ShowDialog() == true)
                {
                    using (StreamWriter writer = new StreamWriter(filename, false))
                    {
                        writer.WriteLine(Input.Text);
                    }
                }
                else if (closeFileWindow.IsCanceled) { }
                else
                {
                    return;
                }
            }

            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();




            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dialog.FileName;

                FileStream fs = File.Create(filename);

                if (!Input.IsEnabled)
                {
                    Input.IsEnabled = true;
                    Input.Text = "";
                }
                else
                {
                    Input.Text = "";
                }
                fs.Close();

            }
            SaveAsOption.IsEnabled = true;
            SaveButton.IsEnabled = true;
            SaveOption.IsEnabled = true;
            RunButton.IsEnabled = true;
            RunOption.IsEnabled = true;
            CloseFileOption.IsEnabled = true;
            EditOption.IsEnabled = true;
            CancelButton.IsEnabled = true;
            RepeatButton.IsEnabled = true;
            CopyButton.IsEnabled = true;
            CutButton.IsEnabled = true;
            PasteButton.IsEnabled = true;
            if (lang == "rus")
            {
                condition = "Редактирование";
                Condition.Content = condition;
            }
            if (lang == "eng")
            {
                condition = "Editing";
                Condition.Content = condition;
            }
            
            Input.Text = "";


        }
        private void SaveAsFileDialog(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                filename = dialog.FileName;

                FileStream fs = File.Create(filename);
                fs.Close();

                using (StreamWriter writer = new StreamWriter(filename, false))
                {
                    writer.WriteLine(Input.Text);
                }
                MessageBox.Show("Данные сохранены в " + filename);
            }
        }

        private void SaveFileDialog(object sender, RoutedEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter(filename, false))
            {
                writer.WriteLine(Input.Text);
            }

            MessageBox.Show("Данные сохранены в " + filename);
        }

        private void OpenFileDialog(object sender, RoutedEventArgs e)
        {
            CloseFileWindow closeFileWindow = new CloseFileWindow();
            if (filename != "")
            {
                if (closeFileWindow.ShowDialog() == true)
                {
                    using (StreamWriter writer = new StreamWriter(filename, false))
                    {
                        writer.WriteLine(Input.Text);
                        writer.Close();
                    }
                }
                else if (closeFileWindow.IsCanceled) {}
                else
                {
                    return;
                }
            }
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                filename = dialog.FileName;

                if (!Input.IsEnabled)
                {
                    Input.IsEnabled = true;
                    Input.Text = "";
                }

                using (StreamReader reader = new StreamReader(filename))
                {
                    string text = reader.ReadToEnd();
                    Input.Text = text;
                }

                SaveAsOption.IsEnabled = true;
                SaveButton.IsEnabled = true;
                SaveOption.IsEnabled = true;
                RunButton.IsEnabled = true;
                RunOption.IsEnabled = true;
                CloseFileOption.IsEnabled = true;
                EditOption.IsEnabled = true;
                CancelButton.IsEnabled = true;
                RepeatButton.IsEnabled = true;
                CopyButton.IsEnabled = true;
                CutButton.IsEnabled = true;
                PasteButton.IsEnabled = true;
                if (lang == "rus")
                {
                    condition = "Редактирование";
                    Condition.Content = condition;
                }
                if (lang == "eng")
                {
                    condition = "Editing";
                    Condition.Content = condition;
                }
            }
        }



        private void CloseFile(object sender, RoutedEventArgs e)
        {
            CloseFileWindow closeFileWindow = new CloseFileWindow();

            if (closeFileWindow.ShowDialog() == true)
            {
                using (StreamWriter writer = new StreamWriter(filename, false))
                {
                    writer.WriteLine(Input.Text);
                }
            }
            else if (closeFileWindow.IsCanceled) { return; }
            else
            {
                return;
            }
            Input.IsEnabled = false;
            SaveAsOption.IsEnabled = false;
            SaveButton.IsEnabled = false;
            SaveOption.IsEnabled = false;
            RunButton.IsEnabled = false;
            RunOption.IsEnabled = false;
            CloseFileOption.IsEnabled = false;
            EditOption.IsEnabled = false;
            CancelButton.IsEnabled = false;
            RepeatButton.IsEnabled = false;
            CopyButton.IsEnabled = false;
            CutButton.IsEnabled = false;
            PasteButton.IsEnabled = false;
            filename = "";
            if (lang == "rus")
            {
                condition = "Ожидание";
                Condition.Content = condition;
            }
            if (lang == "eng")
            {
                condition = "Waiting";
                Condition.Content = condition;
            }
        }
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if (filename != "")
            {
                CloseFileWindow closeFileWindow = new CloseFileWindow();

                if (closeFileWindow.ShowDialog() == true)
                {
                    using (StreamWriter writer = new StreamWriter(filename, false))
                    {
                        writer.WriteLine(Input.Text);
                    }
                }
                else if (closeFileWindow.IsCanceled) {  }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (lang == "rus")
            {
                condition = "Выход";
                Condition.Content = condition;
            }
            if (lang == "eng")
            {
                condition = "Exit";
                Condition.Content = condition;
            }
        }

        private void Undo(object sender, RoutedEventArgs e)
        {
            Input.Undo();
        }

        private void Redo(object sender, RoutedEventArgs e)
        {
            Input.Redo();
        }

        private void Copy(object sender, RoutedEventArgs e)
        {
            Input.Copy();
        }

        private void Paste(object sender, RoutedEventArgs e)
        {
            Input.Paste();
        }

        private void Cut(object sender, RoutedEventArgs e)
        {
            Input.Cut();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Input.Cut();
            Clipboard.Clear();
        }

        private void SelectAll(object sender, RoutedEventArgs e)
        {
            Input.SelectAll();
        }

        private void OutputFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OutputFont.Text == "")
            {
                Output.FontSize = 14;
            }
            else
            {
                Output.FontSize = Convert.ToInt32(OutputFont.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
            
        }
        private void InputFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (InputFont.Text == "")
            {
                Input.FontSize = 14;
            }
            else
            { 
                Input.FontSize = Convert.ToInt32(InputFont.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", ""));
            }
        }

        private void SwitchToRussian(object sender, RoutedEventArgs e)
        {
            string[] rus = {"Файл","Создать","Открыть","Сохранить","Сохранить как","Выход", "Правка","Отменить", "Повторить", 
                "Вырезать", "Копировать", "Вставить", "Удалить", "Выделить все", 
                "Текст", "Постановка задачи", "Грамматика", "Классификация грамматики",
                "Метод анализа", "Диагностика и нейтрализация ошибок", "Текстовый пример", "Список литературы", "Исходный код программы", "Справка"
                , "Вызов справки", "О программе", "Настройки", "Язык", "Пуск"};
            FileOption.Header = rus[0];
            CreateOption.Header = rus[1];
            OpenOption.Header = rus[2];
            SaveOption.Header = rus[3];
            SaveAsOption.Header = rus[4];
            CloseFileOption.Header = rus[5];
            EditOption.Header = rus[6];
            UndoOption.Header = rus[7];
            RedoOption.Header = rus[8];
            CutOption.Header = rus[9];
            CopyOption.Header = rus[10];
            PasteOption.Header = rus[11];
            DeleteOption.Header = rus[12];
            SelectAllOption.Header = rus[13];
            TextOption.Header = rus[14];
            Formulation.Header = rus[15];
            Grammatic.Header = rus[16];
            GrammaticClass.Header = rus[17];
            AnalysMethod.Header = rus[18];
            Troubleshooter.Header = rus[19];
            Example.Header = rus[20];
            Literature.Header = rus[21];
            SourceCode.Header = rus[22];
            Help.Header = rus[23];
            HelpOption.Header = rus[24];
            AboutProgram.Header = rus[25];
            Settings.Header = rus[26];
            Language.Header = rus[27];
            RunOption.Header = rus[28];
            CreateFileButton.ToolTip = "Создать файл";
            OpenFileButton.ToolTip = "Открыть файл";
            SaveButton.ToolTip = "Сохранить файл";
            CancelButton.ToolTip = "Отмена изменений";
            RepeatButton.ToolTip = "Повтор последнего изменения";
            CopyButton.ToolTip = "Копировать";
            CutButton.ToolTip = "Вырезать";
            PasteButton.ToolTip = "Вставить";
            RunButton.ToolTip = "Пуск";
            HelpButton.ToolTip = "Справка";
            AboutProgramButton.ToolTip = "О программе";
            InputFont.ToolTip = "Размер шрифта в окне редактирования";
            OutputFont.ToolTip = "Размер шрифта в окне вывода";
            helpwindow.FileLabel.Content = "Файл";
            helpwindow.CreateBlock.Text = "Создать - создает файл с указанным именем и с указанной дирректорией. Функция также доступна на панели инструментов.";
            helpwindow.OpenBlock.Text = "Открыть - открывает файл с указанным именем и с указанной дирректорией. Функция также доступна на панели инструментов.";
            helpwindow.SaveBlock.Text = "Сохранить - сохраняет изменения в открытом файле. Функция также доступна на панели инструментов.";
            helpwindow.SaveAsBlock.Text = "Сохранить как - сохраняет файл с указанным именем и с указанной дирректорией.";
            helpwindow.ExitBlock.Text = "Выход - закрывает открытый файл.";
            helpwindow.EditLabel.Content = "Правка";
            helpwindow.UndoBlock.Text = "Отменить - отменяет последнее изменение в файле. Функция также доступна на панели инструментов.";
            helpwindow.RedoBlock.Text = "Повторить - повторяет последнее отмененное изменение в файле. Функция также доступна на панели инструментов.";
            helpwindow.CutBlock.Text = "Вырезать - вырезает и сохраняет в буфере обмена выделенный текст. Функция также доступна на панели инструментов.";
            helpwindow.CopyBlock.Text = "Копировать - копирует  в буфер обмена выделенный текст. Функция также доступна на панели инструментов.";
            helpwindow.PasteBlock.Text = "Вставить - вставляет текст из буфера обмена. Функция также доступна на панели инструментов.";
            helpwindow.DeleteBlock.Text = "Удалить - удаляет выделенный выделенный текст.";
            helpwindow.SelectAllBLock.Text = "Выделить все - выделяет весь текст в документе.";
            helpwindow.SettingsLabel.Content = "Настройки";
            helpwindow.LangBlock.Text = "Язык - смена языка в программе.";
            helpwindow.InstPanel.Content = "Панель инструментов";
            helpwindow.Toolblock.Text = "Содержит функции для работы с текстом, а также кнопки запустить, вызов справки и информации о программе и окна изменения размера шрифта в программе. При наведении на элементы пользователь может увидеть подсказки описывающие действия назначенные кнопкам";
            lang = "rus";
            if (condition == "Waiting")
            {
                condition = "Ожидание";
                Condition.Content = condition;
            }
            if (condition == "Exit")
            {
                condition = "Выход";
                Condition.Content = condition;
            }
            if (condition == "Editing")
            {
                condition = "Редактирование";
                Condition.Content = condition;
            }
        }
        private void SwitchToEnglish(object sender, RoutedEventArgs e)
        {
            string[] eng = {"File","Create","Open","Save","Save as","Exit", "Edit","Undo", "Redo",
             "Cut", "Copy", "Paste", "Delete", "Select all",
             "Text", "Problem statement", "Grammar", "Grammar classification",
             "Analysis method", "Diagnosis and error neutralization", "Text example", "List of literature", "Source code of the program", "Help"
             , "Call for help", "About the program", "Settings", "Language", "Start"};
            FileOption.Header = eng[0];
            CreateOption.Header = eng[1];
            OpenOption.Header = eng[2];
            SaveOption.Header = eng[3];
            SaveAsOption.Header = eng[4];
            CloseFileOption.Header = eng[5];
            EditOption.Header = eng[6];
            UndoOption.Header = eng[7];
            RedoOption.Header = eng[8];
            CutOption.Header = eng[9];
            CopyOption.Header = eng[10];
            PasteOption.Header = eng[11];
            DeleteOption.Header = eng[12];
            SelectAllOption.Header = eng[13];
            TextOption.Header = eng[14];
            Formulation.Header = eng[15];
            Grammatic.Header = eng[16];
            GrammaticClass.Header = eng[17];
            AnalysMethod.Header = eng[18];
            Troubleshooter.Header = eng[19];
            Example.Header = eng[20];
            Literature.Header = eng[21];
            SourceCode.Header = eng[22];
            Help.Header = eng[23];
            HelpOption.Header = eng[24];
            AboutProgram.Header = eng[25];
            Settings.Header = eng[26];
            Language.Header = eng[27];
            RunOption.Header = eng[28];
            CreateFileButton.ToolTip = "Create file";
            OpenFileButton.ToolTip = "Open file";
            SaveButton.ToolTip = "Save file";
            CancelButton.ToolTip = "Undo";
            RepeatButton.ToolTip = "Redo";
            CopyButton.ToolTip = "Copy";
            CutButton.ToolTip = "Cut";
            PasteButton.ToolTip = "Paste";
            RunButton.ToolTip = "Run";
            HelpButton.ToolTip = "Help";
            AboutProgramButton.ToolTip = "About program";
            InputFont.ToolTip = "Editor font-size";
            OutputFont.ToolTip = "Output font-size";
            helpwindow.FileLabel.Content = "File";
            helpwindow.CreateBlock.Text = "Create- Creates a file with the specified name and dirrectory. The feature is also available on the toolbar.";
            helpwindow.OpenBlock.Text = "Open - opens the file with the specified name and with the specified dirrectory. The feature is also available on the toolbar.";
            helpwindow.SaveBlock.Text = "Save - Saves changes to an open file. The feature is also available on the toolbar.";
            helpwindow.SaveAsBlock.Text = "Save As - Saves the file with the specified name and with the specified dirrectory.";
            helpwindow.ExitBlock.Text = "Exit - Closes the open file.";
            helpwindow.EditLabel.Content = "Edit";
            helpwindow.UndoBlock.Text = "Undo - Undoes the last change in the file. The feature is also available on the toolbar.";
            helpwindow.RedoBlock.Text = "Redo - Redoes the last undo change in the file. The feature is also available on the toolbar.";
            helpwindow.CutBlock.Text = "Cut - Cuts and saves the selected text to the clipboard. The feature is also available on the toolbar.";
            helpwindow.CopyBlock.Text = "Copy - Copies the selected text to the clipboard. The feature is also available on the toolbar.";
            helpwindow.PasteBlock.Text = "Paste - Inserts text from the clipboard. The feature is also available on the toolbar.";
            helpwindow.DeleteBlock.Text = "Delete - Deletes the selected selected text.";
            helpwindow.SelectAllBLock.Text = "Select All - Selects all text in the document.";
            helpwindow.SettingsLabel.Content = "Settings";
            helpwindow.LangBlock.Text = "Language - change language in program";
            helpwindow.InstPanel.Content = "Toolbar";
            helpwindow.Toolblock.Text = "Contains functions for working with text, as well as buttons to start, access help and information about the program and a window for changing the font size in the program. When hovering over elements, the user can see tips describing the actions assigned to the buttons";
            lang = "eng";
            if (condition == "Ожидание")
            {
                condition = "Waiting";
                Condition.Content = condition;
            }
            if (condition == "Выход")
            {
                condition = "Exit";
                Condition.Content = condition;
            }
            if (condition == "Редактирование")
            {
                condition = "Editing";
                Condition.Content = condition;
            }
        }

        private void CallHelp(object sender, RoutedEventArgs e)
        {     
            helpwindow.Show();
            
        }

        private void DropFile(object sender, DragEventArgs e)
        {
            
        }

    }
}
