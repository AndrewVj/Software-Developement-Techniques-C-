using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    //Appointment class to store Appointment data. 
    //Implements IComparable Interface and we use CompareTo on Slot No.
    class Appointment : IComparable<Appointment>
    {
        private int slotNo;
        private string appointmentTime;
        private Vehicle customerVehicle;

        public Appointment()
        {
        }

        public Appointment(int slotNo, string appointmentTime, Vehicle customerVehicle)
        {
            this.slotNo = slotNo;
            this.appointmentTime = appointmentTime;
            this.customerVehicle = customerVehicle;
        }

        public int SlotNo { get => slotNo; set => slotNo = value; }
        public string AppointmentTime { get => appointmentTime; set => appointmentTime = value; }
        internal Vehicle CustomerVehicle { get => customerVehicle; set => customerVehicle = value; }

        //Comparing slotNos and then returning negative or positive value.
        public int CompareTo(Appointment other)
        {
            return this.slotNo.CompareTo(other.slotNo);
        }
    }
}
