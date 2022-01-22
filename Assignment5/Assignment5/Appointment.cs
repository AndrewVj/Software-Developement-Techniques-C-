using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    //Appointment class to store Appointment data. 
    //Implements IComparable Interface and we use CompareTo on Slot No.
    public class Appointment : IComparable<Appointment>
    {
        private int slotNo;
        private string appointmentTime;
        private string vehicleType;
        private Vehicle customerVehicle;

        public Appointment()
        {
        }

        public Appointment(int slotNo, string appointmentTime, string vehicleType, Vehicle customerVehicle)
        {
            this.slotNo = slotNo;
            this.appointmentTime = appointmentTime;
            this.VehicleType = vehicleType;
            this.customerVehicle = customerVehicle;
        }

        public int SlotNo { get => slotNo; set => slotNo = value; }
        public string AppointmentTime { get => appointmentTime; set => appointmentTime = value; }
        public Vehicle CustomerVehicle { get => customerVehicle; set => customerVehicle = value; }

        public int CustVehicleYearOfMake { get => CustomerVehicle.YearOfMake; set => CustomerVehicle.YearOfMake = value; }
        public string CustVehicleCompany { get => CustomerVehicle.Company; set => CustomerVehicle.Company = value; }
        public string CustVehicleModel { get => CustomerVehicle.Model; set => CustomerVehicle.Model = value; }

        public string CustVehicleCreditCardNo { get => CustomerVehicle.AssociatedCreditCardNumber; set => CustomerVehicle.AssociatedCreditCardNumber = value; }

        public string CustVehicleSecureCreditCardNo { get => CustomerVehicle.AssociatedSecureCreditCardNumber; }
        public string VehicleType { get => vehicleType; set => vehicleType = value; }

        public string Services { get => this.ServicesDone(); }

        private string ServicesDone()
        {
            string services = CustomerVehicle.OilChange() + " || " + CustomerVehicle.EngineTuneUp() + " || " + CustomerVehicle.TransmissionCleanUp() + " || " + CustomerVehicle.AdditionalService();
            return services;
        }


        //Comparing slotNos and then returning negative or positive value.
        public int CompareTo(Appointment other)
        {
            return this.slotNo.CompareTo(other.slotNo);
        }
    }
}
