using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Serialization;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    enum Vehicles
    {
        //The values will now start from 1 instead of 0
        Car = 1,
        SchoolBus,
        PickUpTruck,
        Tractor
    }
    enum AppointmentSlots
    {
        //The values will now start from 1 instead of 0
        am8 = 1,
        am9,
        am10,
        am11,
        am12,
        pm1,
        pm2,
        pm3,
        pm4,
        pm5
    }
    public partial class MainWindow : Window
    {
        AppointmentList appointments = new AppointmentList();
        ObservableCollection<Appointment> displayAppointments = null;
        
        //Dummy Classes to use in Data Binding
        Appointment anAppointment = new Appointment();
        Vehicle aVehicle = new Car();

        //Observable Collection that we will be binding to the data grid.
        //We will add to this collection and the changes will automatically be reflected in the bound data grid.
        public ObservableCollection<Appointment> DisplayAppointments { get => displayAppointments; set => displayAppointments = value; }

        //Properties of dummy classes
        public Appointment AnAppointment { get => anAppointment; set => anAppointment = value; }
        public Vehicle AVehicle { get => aVehicle; set => aVehicle = value; }

        public MainWindow()
        {
            InitializeComponent();

            //To add Vehicle Types to the combo box
            var vehicleStrings = Enum.GetNames(typeof(Vehicles));
            foreach(var vehicle in vehicleStrings)
            {
                VehicleListComboBox.Items.Add(vehicle);
            }

            //To add Slots to the combo box
            var slotValues = Enum.GetValues(typeof(AppointmentSlots));
            Hashtable availableSlots = new();
            foreach (AppointmentSlots value in slotValues)
            {
                string time = value.ToString();
                string hours = time.Substring(2);
                string amOrPm = time.Substring(0, 2).ToUpper();
                string finalTime = $"{hours}:00 {amOrPm}";
                availableSlots.Add((int)value, finalTime);
            }

            //We add the available appointments to the ComboBox in the interface.
            for (int i = 1; i <= availableSlots.Count; i++)
            {
                AppointmentsListComboBox.Items.Add($"{i} - {availableSlots[i]}");
            }

            DisplayAppointments = new ObservableCollection<Appointment>();
            anAppointment.CustomerVehicle = new Car();
            
            //Setting up the data context
            DataContext = this;
            
        }

        //To reset the text box after error handling.
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Foreground = Brushes.Black;
        }



        //Here we will check the fields, create an appointment and add it to the datagrid.
        private void BookAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = true;

            if (YearOfMakeTextBox.Text == string.Empty || CreditCardTextBox.Text == string.Empty || ManufacturingCompanyTextBox.Text == string.Empty || VehicleModelTextBox.Text == string.Empty || VehicleListComboBox.SelectedIndex < 0 || AppointmentsListComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please input all the data");
                result = false;
            }

            if(!CheckCreditCardNo(CreditCardTextBox.Text))
            {
                result = false;
            }

            if(!CheckYearOfMake(YearOfMakeTextBox.Text))
            {
                result = false;
            }

            if(result)
            {
                int yearOfMake = int.Parse(YearOfMakeTextBox.Text);
                string creditCardNo = CreditCardTextBox.Text;
                string manufacturingCompany = ManufacturingCompanyTextBox.Text;
                string vehicleModel = VehicleModelTextBox.Text;
                var selectedSlot = AppointmentsListComboBox.SelectedItem;
                int slotNo = int.Parse(selectedSlot.ToString().Substring(0, 2).Trim());
                string time = selectedSlot.ToString().Substring(4);
                string typeOfVehicle = VehicleListComboBox.SelectedItem.ToString();

                //We remove the selected appointment from ComboBox
                AppointmentsListComboBox.Items.Remove(selectedSlot);


                //Creating a new appointment depending on the vehicle type
                Appointment currentAppointment = new Appointment();
                switch (typeOfVehicle)
                {
                    case "Car":
                        currentAppointment = new Appointment(slotNo, time, typeOfVehicle, new Car(yearOfMake, manufacturingCompany, vehicleModel, creditCardNo));
                        break;
                    case "PickUpTruck":
                        currentAppointment = new Appointment(slotNo, time, typeOfVehicle, new PickUpTruck(yearOfMake, manufacturingCompany, vehicleModel, creditCardNo));
                        break;
                    case "SchoolBus":
                        currentAppointment = new Appointment(slotNo, time, typeOfVehicle, new SchoolBus(yearOfMake, manufacturingCompany, vehicleModel, creditCardNo));
                        break;
                    case "Tractor":
                        currentAppointment = new Appointment(slotNo, time, typeOfVehicle, new Tractor(yearOfMake, manufacturingCompany, vehicleModel, creditCardNo));
                        break;
                }

                //Adding the appointment to the observable collection and hence also the data grid.
                displayAppointments.Add(currentAppointment);
                ClearForm();

            } else
            {
                MessageBox.Show("Please input the correct data! And then book the appointment");
            }
        }


        //We will read from the XML file and then display the sorted appointments in the data grid.
        private void ProcessAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            appointments.Clear();
            ReadFromFile();
            appointments.Sort();
            DisplayAppointments.Clear();
            foreach(Appointment appointment in appointments)
            {
                DisplayAppointments.Add(appointment);
            }
        }


        //We are searching the ObservableCollection and displaying it in the data grid.
        //Here we are searching for Vehicles that have the year of make mentioned in the search box.
        private void SearchByYearButton_Click(object sender, RoutedEventArgs e)
        {
            //Using LINQ we filter the data.
            var query = from appointment in DisplayAppointments
                        where appointment.CustVehicleYearOfMake.ToString() == SearchByYearTextBox.Text.Trim()
                        select appointment;
            MyDataGrid.ItemsSource = query;
        }


        //Function to Write the Appointments into an XML file.
        private void WriteToFile()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppointmentList));
            TextWriter tw = new StreamWriter("Appointments.xml");
            serializer.Serialize(tw, appointments);
            tw.Close();
        }

        //Function to Read from an XML file and add it to the appointments List
        private void ReadFromFile()
        {
            if(!File.Exists("Appointments.xml"))
            {
                return;
            }
            XmlSerializer serializer = new XmlSerializer(typeof(AppointmentList));
            TextReader tr = new StreamReader("Appointments.xml");
            appointments = (AppointmentList)serializer.Deserialize(tr);
            tr.Close();
        }


        //Here we save the appointments in the observable collection to an XML file
        private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            appointments.Clear();
            foreach(Appointment appointment in DisplayAppointments)
            {
                appointments.Add(appointment);
            }
            WriteToFile();
            DisplayAppointments.Clear();
        }

        //Function to reset the form after each appointment booking
        private void ClearForm()
        {
            YearOfMakeTextBox.Text = "";
            CreditCardTextBox.Text = "";
            ManufacturingCompanyTextBox.Text = "";
            VehicleModelTextBox.Text = "";
            VehicleListComboBox.SelectedIndex = -1;
            AppointmentsListComboBox.SelectedIndex = -1;
            SearchByYearTextBox.Text = "";
        }

        //to check if valid year of make is given
        private bool CheckYearOfMake(string yearOfMake)
        {
            int year = 0;
            if (int.TryParse(yearOfMake, out year) && year >= 1950 && year <= 2021)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //to check if valid credit card information is given.
        private bool CheckCreditCardNo(string creditCardNo)
        {
            long credit = 0;
            if (long.TryParse(creditCardNo, out credit) && credit.ToString().Length == 16)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
