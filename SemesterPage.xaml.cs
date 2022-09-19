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
using StudyPlannerLibrary;

namespace ST10084788_PROG6212_PROG_POE_PART_ONE
{

    public partial class SemesterPage : Page
    {

        // object of semester class found in class library
        Semester semester = new Semester();

        // object of module class found in class library
        Module modules = new Module();

        // object of VariableBinding class
        VariableBinding binding = new VariableBinding();

        // object of PopulateDictionaries class found in class library
        PopulateDictionaries pd = new PopulateDictionaries();

        // object of Calculations class found in class library
        Calculations calculations = new Calculations();

        // object of studyClass class found in class library
        StudyClass studyClass = new StudyClass(); 


        public SemesterPage()
        {
            InitializeComponent();

            // Data context is set to binding class for binding the TextBlocks
            this.DataContext = binding;
        }

        private void SemesterButton_Click(object sender, RoutedEventArgs e)
        {
            //Validate semester name entered by user
            if (string.IsNullOrEmpty(binding.SemesterNameVB)) 
            {
                //Notify user if they have not entered a semester name
                Notify1.Visibility = Visibility.Visible;
                Notify1.Foreground = Brushes.Red;
                Notify1.Text = "Error. Please Enter A Valid Semester Name.";
            }
            else
            {
                //Save semester name to class
                semester.SemesterName = binding.SemesterNameVB;
                Notify1.Visibility = Visibility.Visible;
                Notify1.Foreground = Brushes.Green;
                Notify1.Text = "Saved Successfully!";
            }

            //Validate amount of semester weeks entered by user
            int sWeeks = 0;
            if (!int.TryParse(binding.SemesterWeeksVB, out sWeeks))
            {
                //Notify user if they have not entered an amount of semester weeks
                Notify2.Visibility = Visibility.Visible;
                Notify2.Foreground = Brushes.Red;
                Notify2.Text = "Error. Please Enter A Valid Amount Of Weeks.";
            }
            else
            {
                //Save semester weeks to class
                semester.SemesterWeeks = sWeeks;
                Notify2.Visibility = Visibility.Visible;
                Notify2.Foreground = Brushes.Green;
                Notify2.Text = "Saved Successfully!";
            }

            // Validate semester start date
            DatePicker1.SelectedDate = DateTime.Today; // date is automatically set to the current system's date
            string startTime = DatePicker1.Text;
            string timeReplace = startTime.Replace("/", "");
            string[] format = { "yyyyMMdd" };
            DateTime semesterDate;

            // convert time 
            if (DateTime.TryParseExact(timeReplace, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out semesterDate))
            {
                //Save semester StartDate to class
               semester.StartDate = semesterDate;
               Notify3.Visibility = Visibility.Visible;
               Notify3.Foreground = Brushes.Green;
               Notify3.Text = "Saved Successfully!";
            }
            else
            {
                // alert user if they have not entered a valid value
                Notify3.Visibility = Visibility.Visible;
                Notify3.Foreground = Brushes.Red;
                Notify3.Text = "Error. Please Select A Valid Date.";
            }


            //Validate if all fields have been entered correctly
            if (Notify1.Text == "Saved Successfully!"
               && Notify2.Text == "Saved Successfully!"
               && Notify3.Text == "Saved Successfully!")

            {
                // show message to alert user that all info has been saved 
                MessageBox.Show("All Semester Details Have Been Saved Sucessfully!");
                SemesterButton.Visibility = Visibility.Hidden;
                
                // Hide semester fields once details have been saved

                //Hide Notification boxes
                Notify1.Visibility = Visibility.Hidden;
                Notify2.Visibility = Visibility.Hidden;
                Notify3.Visibility = Visibility.Hidden;
                StackPanel3.Visibility = Visibility.Hidden;

                // Hide lables
                Label2.Visibility = Visibility.Hidden;
                Label3.Visibility = Visibility.Hidden;
                Label4.Visibility = Visibility.Hidden;

                // clear textboxes
                sWeeksTextBox.Text = "";
                sNameTextBox.Text = "";

                sWeeksTextBox.Visibility = Visibility.Hidden;
                sNameTextBox.Visibility= Visibility.Hidden;
                DatePicker1.Visibility = Visibility.Hidden;

                // Make module details visible 
                StackPanel1.Visibility = Visibility.Visible;
                Label5.Visibility = Visibility.Visible;
                Label6.Visibility = Visibility.Visible;
                Label7.Visibility = Visibility.Visible;
                Label8.Visibility = Visibility.Visible;
                ModuleButton.Visibility= Visibility.Visible;
                mCodeTextBox.Visibility= Visibility.Visible;
                mNameTextBox.Visibility= Visibility.Visible;
                mCreditsTextBox.Visibility= Visibility.Visible;
                mClassesTextBox.Visibility= Visibility.Visible;

            }

            else
            {
                //Notify user if the fields have not been filled
                MessageBox.Show("Error. Please Ensure That All Semester Fields Have Been Filled Correctly", "Warning!", MessageBoxButton.OKCancel);
            }

        }

        private void ModuleButton_Click(object sender, RoutedEventArgs e)
        {
            
            //Validate module code
            if (string.IsNullOrEmpty(binding.ModuleCodeVB))
            {
                //Notify user if they have not entered a module code
                Notify4.Visibility = Visibility.Visible;
                Notify4.Foreground = Brushes.Red;
                Notify4.Text = "Error. Please Enter A Valid Module Code.";

            }
            else
            {
                // save module code
                modules.ModuleCode = binding.ModuleCodeVB;
                Notify4.Visibility = Visibility.Visible;
                Notify4.Foreground = Brushes.Green;
                Notify4.Text = "Saved Successfully!";
            }

            //Validate module name
            if (string.IsNullOrEmpty(binding.ModuleNameVB))
            {
                //Notify user if they have not entered a valid module name
                Notify5.Visibility = Visibility.Visible;
                Notify5.Foreground = Brushes.Red;
                Notify5.Text = "Error. Please Enter A Valid Module Name.";

            }
            else
            {
                //save module name to class
                modules.ModuleName = binding.ModuleNameVB;
                Notify5.Visibility = Visibility.Visible;
                Notify5.Foreground = Brushes.Green;
                Notify5.Text = "Saved Successfully!";
            }

            //Validate module credits
            int credits = 0;
            if (!int.TryParse(binding.CreditsVB, out credits))
            {
                //notify user if they have not entered a valid amount module credits
                Notify6.Visibility = Visibility.Visible;
                Notify6.Foreground = Brushes.Red;
                Notify6.Text = "Error. Please Enter A Valid Amount Of Credits.";

            }
            else
            {
                //save module credits to class
                modules.ModuleCredits = credits;
                Notify6.Visibility = Visibility.Visible;
                Notify6.Foreground = Brushes.Green;
                Notify6.Text = "Saved Successfully!";
            }

            //Validate class hours per week
            int classHours = 0;
            if (!int.TryParse(binding.ClassHoursVB, out classHours))
            {
                //Notify user if they have not entered a valid amount of class hours per week
                Notify7.Visibility = Visibility.Visible;
                Notify7.Foreground = Brushes.Red;
                Notify7.Text = "Error. Please Enter A Valid Amount Of Class Hours Per Week.";

            }
            else
            {
                // Save amount of classes per week to class
                modules.ClassesPerWeek = classHours;
                Notify7.Visibility = Visibility.Visible;
                Notify7.Foreground = Brushes.Green;
                Notify7.Text = "Saved Successfully!";
            }

            // Validate if all fieds have been entered correctly
            if (Notify4.Text == "Saved Successfully!"
               && Notify5.Text == "Saved Successfully!"
               && Notify6.Text == "Saved Successfully!"
               && Notify7.Text == "Saved Successfully!" 
               && (!pd.moduleName.ContainsKey(modules.ModuleCode))) // if the user has already entered 
               // this module code, the program will not save it

            {

                // clear fields, so that the user can enter a new module
                mCodeTextBox.Text = "";
                mNameTextBox.Text = "";
                mCreditsTextBox.Text = "";
                mClassesTextBox.Text = "";

                Notify4.Visibility = Visibility.Hidden;
                Notify5.Visibility = Visibility.Hidden;
                Notify6.Visibility = Visibility.Hidden;
                Notify7.Visibility = Visibility.Hidden;


                // save module name and code to dictionary
                pd.moduleName.Add(modules.ModuleCode, modules.ModuleName);
                
                // use linq to then populate the combo box from the module codes in the dictionary
                var display = from x in pd.moduleName
                              where x.Key == modules.ModuleCode
                              select x;
                
                foreach (var result in display)
                {
                    // adds module code to combo box
                    ComboBox1.Items.Add(result.Key);
                }

                //calculates the amount of hours that the person would need to study for PW
                modules.ModuleStudyHours = calculations.moduleStudyHours(modules.ModuleCredits, semester.SemesterWeeks, modules.ClassesPerWeek);
               
                // adds the module code and study hours to dictionary
                pd.moduleHours.Add(modules.ModuleCode, modules.ModuleStudyHours);

                modules.semesterName = semester.SemesterName;
                modules.semesterWeeks = semester.SemesterWeeks;
                
                // displays all information in the modules datagrid
                DataGrid1.Items.Add(modules);

                // Make Module data grid visible
                DataGrid1.Visibility = Visibility.Visible;
                dMessage1.Visibility = Visibility.Visible;


                //Make study session fields visible
                Label9.Visibility = Visibility.Visible;
                Label10.Visibility = Visibility.Visible;
                Label11.Visibility = Visibility.Visible;
                ComboBox1.Visibility = Visibility.Visible;
                StudyHoursTextBox.Visibility = Visibility.Visible;  
                DatePicker2.Visibility = Visibility.Visible;    
                StudyButton.Visibility = Visibility.Visible;    
                StackPanel2.Visibility = Visibility.Visible; 
                
                //Noticy user that all module details have been saved

                MessageBox.Show("All Module Details Have Been Saved Sucessfully!", "Details Saved.", MessageBoxButton.OKCancel);

            }

            else
            {
                // Notify user that module details have not been saved and they need to be entered correctly
                MessageBox.Show("Error. Please Ensure That All Module Fields Have Been Filled Correctly.", "Warning!", MessageBoxButton.OKCancel);
            }
        }

        
        private void StudyButton_Click(object sender, RoutedEventArgs e)
        {
            //Holds the amount of hours that user needs to study for
            double studyHoursRemaining = 0;
            

            //Validate amount of hours studied that are entered by the user
            int studyHours = 0;
            if (!int.TryParse(binding.StudyHoursVB, out studyHours))
            {
                //Notify the user if they ahve not entered a valid amount of study hours
                Notify9.Visibility = Visibility.Visible;
                Notify9.Foreground = Brushes.Red;
                Notify8.Text = "Error. Please Enter A Valid Amount Of Hours Studied.";

            }
            else
            {
                // save study hours to class
                studyClass.StudyHours = studyHours;
                Notify9.Visibility = Visibility.Visible;
                Notify9.Foreground = Brushes.Green;
                Notify9.Text = "Saved Successfully!";
            }

            // get selected module from combobox
            string moduleCmb = ComboBox1.SelectedItem.ToString();
            
            
            if (ComboBox1.SelectedItem == null)
            {
                // displays error message if the user has not chosen a module from the comboBox
                Notify8.Visibility = Visibility.Visible;
                Notify8.Foreground = Brushes.Red;
                Notify8.Text = "Error. Please Choose A Module.";
            }

            else

            {
                //acknowledges that the user has selected a module from the combo box
                Notify8.Visibility = Visibility.Visible;
                Notify8.Foreground = Brushes.Green;
                Notify8.Text = "Saved Successfully!";
            }

            // get date 
            DatePicker2.SelectedDate = DateTime.Today; // set to system's current date as default
            string studyTime = DatePicker1.Text;
            string studytimeReplace = studyTime.Replace("/", "");
            string[] format = { "yyyyMMdd" };
            DateTime studyDate;

            //convert time
            if (DateTime.TryParseExact(studytimeReplace, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out studyDate))
            {
               
                Notify10.Visibility = Visibility.Visible;
                Notify10.Foreground = Brushes.Green;
                Notify10.Text = "Saved Successfully!";
            }

            else
            {
                //displays error message if user has not selected a date
                Notify10.Visibility = Visibility.Visible;
                Notify10.Foreground = Brushes.Red;
                Notify10.Text = "Error. Please Select A Valid Date.";

            }

            //Validate if all fields have been entered correctly



            if (Notify8.Text == "Saved Successfully!"
               && Notify9.Text == "Saved Successfully!"
               && Notify10.Text == "Saved Successfully!")

            {
                // checks if current week matches to the week in the current semester
                if (calculations.currentWeek(semester.StartDate) == calculations.workweek(semester.StartDate, studyDate))
                { 
                    // Calculate the remaining study hours for the current week

                    // looks for module in dictionary and subtracts the amount of hours that the user has studied for
                    if (pd.moduleHours.ContainsKey(moduleCmb))
                    {

                        pd.moduleHours[moduleCmb] = pd.moduleHours[moduleCmb] - studyHours;
                    }

                    // sets the reaming hours to the current value in the dictionary
                    if (pd.moduleHours.ContainsKey(moduleCmb))
                    {

                        studyHoursRemaining = pd.moduleHours[moduleCmb];
                    }


                    //saves all information to the study class
                    studyClass.ModuleCode = moduleCmb;
                    studyClass.RemainingHours = studyHoursRemaining;
                    studyClass.StudyDate = studyDate;

                    //populates the datagrid with study session data
                    DataGrid2.Items.Add(studyClass);

                    // Clear fields so that user add another study session
                    Notify8.Visibility = Visibility.Hidden;
                    Notify9.Visibility = Visibility.Hidden;
                    Notify10.Visibility = Visibility.Hidden;

                    StudyHoursTextBox.Text = "";
                    ComboBox1.SelectedIndex = -1;

                   //Make study data grid visible
                   dMessage2.Visibility = Visibility.Visible;
                   DataGrid2.Visibility = Visibility.Visible;

                    //Notify user that all information has been saved
                    MessageBox.Show("Self-Study Session Has Been Saved Successfully!", "Details Saved", MessageBoxButton.OKCancel);
                }

            }


            else
            {
                // Notify user that information has not been saved
                MessageBox.Show("Error. Please Ensure That All Semester Fields Have Been Filled Correctly", "Warning", MessageBoxButton.OKCancel);
            }

        }
    }
}
