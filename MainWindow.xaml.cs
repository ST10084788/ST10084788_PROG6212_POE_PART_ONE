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

namespace ST10084788_PROG6212_PROG_POE_PART_ONE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // objects of pages that need to be call
        SemesterPage sp = new SemesterPage();
        HomePage homePage = new HomePage();
        Display display = new Display();
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // calls SemesterPage
            FrameMain.Content = sp;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // calls HomePage
            FrameMain.Content = homePage;
        }

        
        private void FrameMain_Loaded_1(object sender, RoutedEventArgs e)
        {
            // set default page on frame
            FrameMain.Content = display;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
