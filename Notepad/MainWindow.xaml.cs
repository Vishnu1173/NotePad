using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
using System.IO;
using System.Windows.Xps;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NewWindowPage newWindowPage;
        public MainWindow()
        {
            InitializeComponent();
            newWindowPage = new NewWindowPage();
            framemain.Content = newWindowPage;
        }

        private void menunewwin_Click(object sender, RoutedEventArgs e)
        {
            if(newWindowPage.txtdetails.Text !="")
            {
                MessageBoxResult msg = MessageBox.Show("Do you want to save this?","Info",MessageBoxButton.YesNo);
                if (msg == MessageBoxResult.Yes)
                {
                    SaveFileDialog osave = new SaveFileDialog();
                    osave.Filter = "text files|*.txt|document file|*.doc|any files|*.*";
                    osave.Title = "Sathish";
                    osave.ShowDialog();
                    File.WriteAllText(osave.FileName, newWindowPage.txtdetails.Text);
                    newWindowPage.txtdetails.Clear();
                }
                else
                {
                    newWindowPage.txtdetails.Clear();
                }
            }
            framemain.Content = newWindowPage;
        }

            private void menusave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog osave=new SaveFileDialog();
            osave.Filter = "text files|*.txt|document file|*.doc|any files|*.*";
            osave.Title ="Sathish";
            osave.ShowDialog();
            File.WriteAllText(osave.FileName, newWindowPage.txtdetails.Text);
        }

        private void menuopen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oopen=new OpenFileDialog();
            oopen.Filter = "text files|*.txt|document file|*.doc|any files|*.*";
            oopen.Title = "Sathish";
            oopen.ShowDialog();
            newWindowPage.txtdetails.Text=File.ReadAllText(oopen.FileName);
        }

        private void menufile_Click(object sender, RoutedEventArgs e)
        {
            FileInfo finfo=new FileInfo("C:\\Users\\vijay\\sathish\\me.txt");
            MessageBox.Show(finfo.FullName.ToString());
            MessageBox.Show(finfo.Exists.ToString());
            MessageBox.Show(finfo.Length.ToString());
            MessageBox.Show(finfo.Name.ToString());
            MessageBox.Show(finfo.Directory.ToString());

        }

        private void menuDir_Click(object sender, RoutedEventArgs e)
        {
            DirectoryInfo odir = new DirectoryInfo("C:\\Users\\vijay\\sathish");
            FileInfo[] ofile = odir.GetFiles();
            MessageBox.Show(ofile.Length.ToString());
            foreach( FileInfo file in odir.GetFiles() )
            {
                MessageBox.Show(file.FullName.ToString());
            }
        }

        private void menuexit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();    
        }
    }
}
