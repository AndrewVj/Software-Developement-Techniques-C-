using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Appointment
    {
        private int slotNo;
        private string appointmentDate;
        private Vehicle customerVehicle;

        public int SlotNo { get => slotNo; set => slotNo = value; }
        public string AppointmentDate { get => appointmentDate; set => appointmentDate = value; }
        internal Vehicle CustomerVehicle { get => customerVehicle; set => customerVehicle = value; }
    }
}
