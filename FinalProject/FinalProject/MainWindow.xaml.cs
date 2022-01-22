using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;
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
using System.Xml.Serialization;
using System.IO;

namespace FinalProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppointmentList appointmentListXML = new AppointmentList();
        private Appointment appointment = new Appointment();

        //Dummy Class to use in Data Binding
        private ValidatingFields validatingFields = new ValidatingFields();

        //Observable Collection that we will be binding to the data grid.
        //We will add to this collection and the changes will automatically be reflected in the bound data grid.
        private ObservableCollection<Appointment> obsAppointments = null;

        public ObservableCollection<Appointment> ObsAppointments { get => obsAppointments; set => obsAppointments = value; }


        //Properties of dummy classes
        public ValidatingFields ValidatingFields { get => validatingFields; set => validatingFields = value; }
       

        public MainWindow()
        {
            InitializeComponent();

            //Add available appointments to the Appointment Combo Box
            AppointmentTimeSlots_initialization();

            // An observable collection to bind to Data Grid
            obsAppointments = new ObservableCollection<Appointment>();
            TodayDate.Content = $"Date : {DateTime.Now.Date.ToShortDateString()}" ;
            this.DataContext = ValidatingFields;

            //Setting up the Filter Combo Box
            DataGridFilterCriteriaByPatientType.ItemsSource = AllPatientTypes();
        }

        //Private function to get PatientTypes
        private List<String> AllPatientTypes()
        {
            List<String> patientType = new List<string>();
            patientType.Add("Child");
            patientType.Add("Adult");
            patientType.Add("Senior");
            return patientType;
        }

        private void AppointmentTimeSlots_initialization()
        {
            DateTime now = DateTime.Now;
            DateTime initTime = new DateTime(now.Year, now.Month, now.Day, 9, 0, 0);

            //Total 10 appointment slots will be available in List with one hour difference 
            List<String> appointmentSlotList = new List<String>();

            //Generating Appointment time slots
            for (int i = 0; i < 10; i++)
            {
                this.appoinmentSlots.Items.Add(initTime.ToString());
                //appointmentSlotList.Add(initTime.ToString());
                initTime = initTime.AddHours(1);
            }
        }
         
        //Enum to store types of patients
        enum PatientType
        {
            Child,Adult,Senior
        }

        //Private method to get Patient Type based on Age
        private PatientType GetPatientType(uint age)
        {
          if (age >= 5 && age <= 17)
                {
                    return PatientType.Child;
                }
                else if (age >= 18 && age <= 55)
                {
                    return PatientType.Adult;
                }
                else
                {
                    return PatientType.Senior;
                }
            
        }

        //We use this to enable check box options for patients depending on their age
        private void patientAgeInput_LostFocus(object sender, RoutedEventArgs e)
        {
            uint age = 5;
           
            uint.TryParse(patientAgeInput.Text,out age);
            if(age>=5 && age <= 100)
            {
                PatientType patientType = GetPatientType(age);
                switch (patientType)
                {
                    case PatientType.Child : BabyToothExtraction.IsEnabled = true;
                        break;
                    case PatientType.Adult: CosmeticSurgery.IsEnabled = true;
                        break;
                    case PatientType.Senior: DentalImplants.IsEnabled = true;
                        break;
                    default:
                        break; 
                }
            }
            
        }

        //We use this to reset check box options for patients 
        private void patientAgeInput_GotFocus(object sender, RoutedEventArgs e)
        {
            DentalImplants.IsEnabled = false;
            DentalImplants.IsChecked = false;
            CosmeticSurgery.IsEnabled = false;
            CosmeticSurgery.IsChecked = false;
            BabyToothExtraction.IsEnabled = false;
            BabyToothExtraction.IsChecked = false;
        }

        //Appointment Booking Button is handled here
        private void BookAppointment_Click(object sender, RoutedEventArgs e)
        {
            long patientPhoneNumber = 0;
            uint age = 0;
            long ccNumber = 0;

            if (appoinmentSlots.SelectedIndex < 0)
            {
                appoinmentSlotsBorder.Background = Brushes.Red;
                appoinmentSlots.ToolTip = "Please select an appointment slot";
                return;
            }
            
            if(!(patientNameInput.Text.Length >= 2 && patientNameInput.Text.Length <= 50))
            {
                return;
            }

            if(!(long.TryParse(patientPhoneNumberInput.Text, out patientPhoneNumber) && patientPhoneNumberInput.Text.Length == 10))
            {
                return;
            }

            if(!(uint.TryParse(patientAgeInput.Text, out age) && age >= 5 && age <= 100))
            {
                return;
            }

            if(!(CCNumber.Text.Length == 16 && long.TryParse(CCNumber.Text, out ccNumber)))
            {
                return;
            }

            DateTime selectedSlot = DateTime.Parse(appoinmentSlots.SelectedItem.ToString());
            Patient patient = null;
            
            bool cleaning = (bool)Cleaning.IsChecked;
            bool cavityFilling = (bool)CavityFilling.IsChecked;
            bool toothExtraction = (bool)ToothExtraction.IsChecked;
            bool babyToothExtraction = (bool)BabyToothExtraction.IsChecked;
            bool cosmeticSurgery = (bool)CosmeticSurgery.IsChecked;
            bool dentalImpants = (bool)DentalImplants.IsChecked;

            //Getting the patient age and depending on it we create the respective objects
            PatientType patientType = GetPatientType(age);
            switch (patientType)
            {
                case PatientType.Child:
                    patient = new Child(patientNameInput.Text, age, patientPhoneNumber.ToString(), ccNumber.ToString());
                    if (babyToothExtraction)
                    {
                        ((Child)patient).BabyToothExtractionNeeded = true;
                    }
                    break;
                case PatientType.Adult:
                    patient = new Adult(patientNameInput.Text, age, patientPhoneNumber.ToString(), ccNumber.ToString());
                    if (cosmeticSurgery)
                    {
                        ((Adult)patient).CosmeticSurgeryNeeded = true;
                    }
                    break;
                case PatientType.Senior:
                    patient = new Senior(patientNameInput.Text, age, patientPhoneNumber.ToString(), ccNumber.ToString());
                    if (dentalImpants)
                    {
                        ((Senior)patient).DentalImplantsNeeded = true;
                    }
                    break;
                default:
                    break;

            }

            //Check and see what kind of services a patient needs
            if (cleaning)
            {
                patient.CleaningNeeded = true;
            }
            if (cavityFilling)
            {
                patient.CavityFillingNeeded = true;
            }
            if (toothExtraction)
            {
                patient.ToothExtractionNeeded = true;
            }


            Appointment newAppointment = new Appointment();
            newAppointment.AppointmentDateTime = selectedSlot;
            newAppointment.Patient = patient;
            newAppointment.PatientType = patientType.ToString();
            appointmentListXML.Add(newAppointment);
            //Serializing data to XML File
            WriteToFile();
            appoinmentSlots.Items.RemoveAt(appoinmentSlots.SelectedIndex);

            Message.Content = $"Successfully Booked And Saved Your Appointment Slot : {selectedSlot}";
            Message.Foreground = Brushes.Green;
            obsAppointments.Add(newAppointment);
            formReset();
            AllAppointmentsGrid.ItemsSource = obsAppointments;
        }

        //A private method that we call to serialize our AppointmentList
        private void WriteToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppointmentList));
            TextWriter tw = new StreamWriter("appointmentlist.xml");
            serializer.Serialize(tw, appointmentListXML);
            tw.Close();
        }

        //Reading the XML for displaying the recored appointment
        private void ReadFromFile()
        {
            if (!File.Exists("appointmentlist.xml"))
            {
                Message.Content = "No appointment booked yet";
                Message.Foreground = Brushes.Red;

            }
            else
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppointmentList));
                TextReader tr = new StreamReader("appointmentlist.xml");
                appointmentListXML = (AppointmentList)serializer.Deserialize(tr);
                tr.Close();
            }
        }

        //To reset the forms after button clicks
        private void formReset()
        {
           
            patientAgeInput.Text = "";
            patientNameInput.Text = "";
            CCNumber.Text = "";
            patientPhoneNumberInput.Text = "";
            CCNumber.Text = "";
            Cleaning.IsChecked = false;
            CavityFilling.IsChecked = false;
            ToothExtraction.IsChecked = false;
            BabyToothExtraction.IsChecked = false;
            CosmeticSurgery.IsChecked = false;
            DentalImplants.IsChecked = false;
        }


        private void appoinmentSlots_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            appoinmentSlotsBorder.Background = Brushes.Transparent;
            
        }


        //We read from our file and print it again to our Data Grid
        private void ShowAppointments_Click(object sender, RoutedEventArgs e)
        {
            appointmentListXML.Clear();

            ReadFromFile();
            appointmentListXML.Sort();
            obsAppointments.Clear();
            for (int i = 0; i < appointmentListXML.Count(); i++)
            {
                Appointment appointment = appointmentListXML[i];
                String patientType = appointment.PatientType;
                Patient patient = appointment.Patient;
                String patientName = patient.Name;
                uint patientAge = patient.Age;
                String patientPhoneNumber = patient.ContactNumber;
                 String ccNumber = patient.CreditCardNumber;


                Patient newPatient = null;
                switch (patientType)
                {
                    case "Child":
                        Child child = patient as Child;
                        newPatient = new Child(patientName, patientAge,patientPhoneNumber, ccNumber);
                        if (child.BabyToothExtractionNeeded)
                        {
                            ((Child)newPatient).BabyToothExtractionNeeded = true;
                        }
                        break;

                    case "Adult":
                        Adult adult = patient as Adult;
                        newPatient = new Adult(patientName, patientAge, patientPhoneNumber, ccNumber);
                        if (adult.CavityFillingNeeded)
                        {
                            ((Adult)newPatient).CavityFillingNeeded = true;
                        }
                        
                        break;

                    case "Senior":
                        Senior senior = patient as Senior;
                        newPatient = new Senior(patientName, patientAge, patientPhoneNumber, ccNumber);
                        if (senior.DentalImplantsNeeded)
                        {
                            ((Senior)newPatient).DentalImplantsNeeded = true;
                        }
                        break;

                   
                    default:

                        throw new Exception("[ERROR] It should not have happened. ");
                }
                if (patient.CleaningNeeded)
                {
                    newPatient.CleaningNeeded = true;
                }
                if (patient.CavityFillingNeeded)
                {
                    newPatient.CavityFillingNeeded = true;
                }
                if (patient.ToothExtractionNeeded)
                {
                    newPatient.ToothExtractionNeeded = true;
                }

                Appointment newAppointment = new Appointment();
                newAppointment.AppointmentDateTime = appointment.AppointmentDateTime;
                newAppointment.Patient = newPatient;
                newAppointment.PatientType = patientType;
                obsAppointments.Add(newAppointment);

            }

            AllAppointmentsGrid.ItemsSource = obsAppointments;

        }

        //We use LINQ to filter the Patients and print it on the data grid accordingly
        private void DataGridFilterCriteriaByPatientType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Message.Content = "";
            if (DataGridFilterCriteriaByPatientType.SelectedIndex != -1)
            {
                string selectedFilterType = DataGridFilterCriteriaByPatientType.SelectedItem as string;

                var query = from appointment in ObsAppointments
                            where appointment.PatientType.Equals(selectedFilterType)
                            orderby (appointment.AppointmentDateTime)
                            select appointment;
                AllAppointmentsGrid.ItemsSource = query;
            }
        }

        //We select a row on the data grid and delete it
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (AllAppointmentsGrid.SelectedItem != null && obsAppointments.Count>0)
            {
                Appointment appointmentToDelete = (Appointment)AllAppointmentsGrid.SelectedItem;
                obsAppointments.Remove(appointmentToDelete);
                appointmentListXML.Clear();
                foreach (Appointment appointment in obsAppointments)
                {
                    appointmentListXML.Add(appointment);
                }
                WriteToFile();
               
            }
        }

        //We select a row on the data grid and update specific fields in it.
        //In our case Name and PhoneNumber
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (AllAppointmentsGrid.SelectedItem != null && obsAppointments.Count > 0)
            {
                appointmentListXML.Clear();
                foreach (Appointment appointment in obsAppointments)
                {
                    appointmentListXML.Add(appointment);
                }
                WriteToFile();
                ShowAppointments_Click(sender, e);

            }
        }
    }
}
