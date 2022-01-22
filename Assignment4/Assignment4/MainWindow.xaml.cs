using System;
using System.Collections;
using System.Collections.Generic;
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

namespace Assignment4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Enum for getting a list of appointments
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


        //We declare and initialise the variables needed.
        AppointmentList appointments = null;
        RadioButton radioChecked = null;
        int yearOfMake = int.MinValue;
        string creditCardNo = string.Empty;
        string manufacturingCompany = string.Empty;
        string vehicleModel = string.Empty;
        Appointment currentAppointment = null;
        int noOfRegistrations = 0;

        public MainWindow()
        {
            InitializeComponent();
            //create a new AppointmentsList
            appointments = new AppointmentList();

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

            //If a copy of the file already exists from the previous session. We delete it.
            if (File.Exists("BinaryFile.txt"))
            {
                File.Delete("BinaryFile.txt");
            }
        }


        //When the book appointment button is clicked
        private void BookAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            bool result = true;

            //We check if all the input fields are filled and relevant data is given.
            if (YearOfMakeTextBox.Text == string.Empty || CreditCardTextBox.Text == string.Empty || ManufacturingCompanyTextBox.Text == string.Empty || VehicleModelTextBox.Text == string.Empty || radioChecked == null || AppointmentsListComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please input all the data");
                result = false;
            }

            //We denote error if invalid input is given. And we signal the user to give the right input.
            if(VehicleModelTextBox.Text == string.Empty)
            {
                VehicleModelTextBox.Foreground = Brushes.Red;
            }

            if(ManufacturingCompanyTextBox.Text == string.Empty)
            {
                ManufacturingCompanyTextBox.Foreground = Brushes.Red;
            }

            if (!CheckYearOfMake(YearOfMakeTextBox.Text))
            {
                YearOfMakeTextBox.Foreground = Brushes.Red;
                MessageBox.Show("Enter a valid year between 1900 and 2023. ");
                result = false;
            }

            if (!CheckCreditCardNo(CreditCardTextBox.Text))
            {
                CreditCardTextBox.Foreground = Brushes.Red;
                MessageBox.Show("Enter a valid 16 digit credit card number.");
                result = false;
            }

            //If relevant input is given we proceed further.
            if (result)
            {
                yearOfMake = int.Parse(YearOfMakeTextBox.Text);
                creditCardNo = CreditCardTextBox.Text;
                manufacturingCompany = ManufacturingCompanyTextBox.Text;
                vehicleModel = VehicleModelTextBox.Text;
                var selectedSlot = AppointmentsListComboBox.SelectedItem;
                int slotNo = int.Parse(selectedSlot.ToString().Substring(0, 2).Trim());
                string time = selectedSlot.ToString().Substring(4);
                string typeOfVehicle = radioChecked.Content.ToString();
                
                //We remove the selected appointment from ComboBox
                AppointmentsListComboBox.Items.Remove(selectedSlot);
                noOfRegistrations++;


                //We write the data into a binary file.
                FileStream fileStream = null;
                try
                {
                    if(File.Exists("BinaryFile.txt"))
                    {
                        fileStream = new FileStream("BinaryFile.txt", FileMode.Append, FileAccess.Write);
                    } else
                    {
                        fileStream = new FileStream("BinaryFile.txt", FileMode.OpenOrCreate, FileAccess.Write);
                    }
                    BinaryWriter binaryWriter = new BinaryWriter(fileStream);
                    binaryWriter.Write(slotNo);
                    binaryWriter.Write(time);
                    binaryWriter.Write(yearOfMake);
                    binaryWriter.Write(manufacturingCompany);
                    binaryWriter.Write(vehicleModel);
                    binaryWriter.Write(creditCardNo);
                    binaryWriter.Write(typeOfVehicle);
                    binaryWriter.Close();
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                catch (Exception exp)
                {
                    Console.WriteLine(exp.ToString());
                    Console.WriteLine(exp.Message);
                }

                finally
                {
                    fileStream.Close();
                    //We clear all the forms and make the interface ready for the next registration.
                    ClearForm();
                }
            }
        }

        private void ProcessAppointmentButton_Click(object sender, RoutedEventArgs e)
        {
            //We clear the TextBlock proceed again.
            DisplayProcessedInfoTextBlock.Text = "";
            appointments.Clear();

            //We do this to prevent exception if Process button is clicked without any registration or appintment being done.
            if(!File.Exists("BinaryFile.txt"))
            {
                return;
            }

            //We read the data from the binary file and create appointment object and add it to appoinment list
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream("BinaryFile.txt", FileMode.Open, FileAccess.Read);
                BinaryReader binaryReader = new BinaryReader(fileStream);

                for (int i = 1; i <= noOfRegistrations; i++)
                {
                    int slotNo = binaryReader.ReadInt32();
                    string time = binaryReader.ReadString();
                    yearOfMake = binaryReader.ReadInt32();
                    manufacturingCompany = binaryReader.ReadString();
                    vehicleModel = binaryReader.ReadString();
                    creditCardNo = binaryReader.ReadString();
                    string typeOfVehicle = binaryReader.ReadString();

                    //Depending on the type of vehicle we create respective objects.
                    switch(typeOfVehicle)
                    {
                        case "Car":
                            currentAppointment = new Appointment(slotNo, time, new Car(yearOfMake, manufacturingCompany, vehicleModel, creditCardNo));
                            break;
                        case "Pick Up Truck":
                            currentAppointment = new Appointment(slotNo, time, new PickUpTruck(yearOfMake, manufacturingCompany, vehicleModel, creditCardNo));
                            break;
                        case "School Bus":
                            currentAppointment = new Appointment(slotNo, time, new SchoolBus(yearOfMake, manufacturingCompany, vehicleModel, creditCardNo));
                            break;
                        case "Tractor":
                            currentAppointment = new Appointment(slotNo, time, new Tractor(yearOfMake, manufacturingCompany, vehicleModel, creditCardNo));
                            break;
                    }

                    appointments.Add(currentAppointment);
                }

                binaryReader.Close();
            }

            catch (IOException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                Console.WriteLine(exp.Message);
            }
            finally
            {
                fileStream.Close();
            }

            string textToDisplay = string.Empty;

            //Sorting the appoinment list by slotNo
            appointments.Sort();

            //We iterate over the appointments and add the relevant information to the text variable we want to display in the TextBlock
            foreach (Appointment ap in appointments)
            {
                textToDisplay += $"Slot No: {ap.SlotNo} - {ap.AppointmentTime} \n{ap.CustomerVehicle}\n\n";
            }
            DisplayProcessedInfoTextBlock.Text = textToDisplay;
        }

        //We call this method to clear the input fields and make the interface ready for the next registration.
        private void ClearForm()
        {
            YearOfMakeTextBox.Text = "";
            CreditCardTextBox.Text = "";
            ManufacturingCompanyTextBox.Text = "";
            VehicleModelTextBox.Text = "";
            if (radioChecked != null)
            {
                radioChecked.IsChecked = false;
            }
            //radioChecked = null;
        }

        //to check if valid year of make is entered
        private bool CheckYearOfMake(string yearOfMake)
        {
            int year = 0;
            if (int.TryParse(yearOfMake, out year) && year > 1900 && year < 2023)
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


        //We do this to keep track of the radio button that is selected by the user. We use it to get Vehicle type.
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            radioChecked = radioButton;
        }

        //We use this to reset the style of text boxes. The red error state is changed back to black.
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Foreground = Brushes.Black;
        }

    }
}
