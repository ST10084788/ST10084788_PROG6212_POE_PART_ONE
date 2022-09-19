using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPlannerLibrary
{
    public class Module
    {
        //Variables with getters and setters
        public string ModuleCode { get; set; }
        public string ModuleName { get; set; }
        public int ModuleCredits { get; set; }
        public int ClassesPerWeek { get; set; }

        public double ModuleStudyHours { get; set; }

        public double HoursStudied { get; set; }

        public int semesterWeeks { get; set; }

        public string semesterName { get; set; }

        //default constructor
        public Module() { }

        //paramiterised constructor 
        public Module(string ModuleCode, string ModuleName, int ModuleCredits, int ClassesPerWeek, double ModuleStudyHours, double hoursStudied, int semesterWeeks, string semesterName)
        {
            this.ModuleCode = ModuleCode;
            this.ModuleName = ModuleName;
            this.ModuleCredits = ModuleCredits;
            this.ClassesPerWeek = ClassesPerWeek;
            this.ModuleStudyHours = ModuleStudyHours;
            this.HoursStudied = hoursStudied;
            this.semesterName = semesterName;
            this.semesterWeeks = semesterWeeks;
        }
    }

    public class Semester
    {
        // variables with getters and setters
        public int SemesterWeeks { get; set; }
        public DateTime StartDate { get; set; }
        public string SemesterName { get; set; }

        // default constructor 
        public Semester() { }

        public Semester(int NumWeeks, DateTime StartDate)
        {
            this.SemesterWeeks = NumWeeks;
            this.StartDate = StartDate;
        }
    }

    public class Calculations
    {
        // calculate the number of required study hours for the week 
        public double moduleStudyHours(int credits, int weeks, int classHours)
        {
            return ((credits * 10) / weeks) - classHours;
        }

        // Calculate sthe current week in the semester 
        public int currentWeek(DateTime startDate)
        {
            int CurrentWeek;
            CurrentWeek = (int)Math.Ceiling(((DateTime.Now - startDate).TotalDays + 1) / 7);
            return CurrentWeek;

        }

        // Calculates the week of the semester that work was done
        public int workweek(DateTime startDate, DateTime workDate)
        {

            int workWeeks;
            workWeeks = (int)Math.Ceiling(((workDate - startDate).TotalDays + 1) / 7);

            return workWeeks;
        }
    }

    public class PopulateDictionaries
    {
        // dictionaries to hold user's modules
        public IDictionary<string, string> moduleName = new Dictionary<string, string>();
        public IDictionary<string, double> moduleHours = new Dictionary<string, double>();
    }

    public class StudyClass
    {
        //Variables with getters and setters
        public string ModuleCode { get; set; }
        public DateTime StudyDate { get; set; }
        public double StudyHours { get; set; }
        public double RemainingHours { get; set; }

        

        //default constructor
        public StudyClass() { }

        //paramiterised constructor 
        public StudyClass(string ModuleCode, DateTime StudyDate, int StudyHours, double RemainingHours)
        {
            this.ModuleCode = ModuleCode;
            this.StudyDate = StudyDate;
            this.StudyHours = StudyHours;
            this.RemainingHours = RemainingHours;
            

            
        }

    }
}










