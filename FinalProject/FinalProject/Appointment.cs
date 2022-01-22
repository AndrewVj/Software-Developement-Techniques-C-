using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalProject
{
    [XmlInclude(typeof(Child))]
    [XmlInclude(typeof(Adult))]
    [XmlInclude(typeof(Senior))]

    //Appointment class to store Appointment data. 
    //Implements IComparable Interface and we use CompareTo on AppointmentDateTime.
    public class Appointment : IComparable<Appointment>
    {
        private DateTime appointmentDateTime;
        private String patientType;
        private Patient patient;

        public DateTime AppointmentDateTime { get => appointmentDateTime; set => appointmentDateTime = value; }
        public Patient Patient { get => patient; set => patient = value; }
        public string PatientType { get => patientType; set => patientType = value; }

        public Appointment()
        {

        }
        public int CompareTo(Appointment other)
        {
            return AppointmentDateTime.CompareTo(other.AppointmentDateTime);
        }

        public override string ToString()
        {
            return string.Format($"Appointment Date and Time : {AppointmentDateTime} \n{Patient} ");
        }
    }
}
