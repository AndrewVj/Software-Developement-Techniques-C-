using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FinalProject
{
    [XmlRoot("AppointmentList")]
    [XmlInclude(typeof(Appointment))]

    //AppointmentList class to store list of appointments
    //We use IDisposable and IEnumerable Interfaces.
    //We use Indexer to make this class usuable like it is an Array or List.
    public class AppointmentList : IEnumerable<Appointment>, IDisposable
    {
        List<Appointment> appointments = null;
        [XmlArray("Appointments")]
        [XmlArrayItem("Appointment", typeof(Appointment))]
        public List<Appointment> Appointments { get => appointments; set => appointments = value; }

        public AppointmentList()
        {
            Appointments = new List<Appointment>();
        }
        public Appointment this[int i]
        {
            get => Appointments[i];
            set => Appointments[i] = value;
        }

        public void Add(Appointment appointment)
        {
            Appointments.Add(appointment);
        }
        public void Remove(Appointment appointment)
        {
            Appointments.Remove(appointment);
        }

        public int Count()
        {
            return Appointments.Count();
        }
        public void Sort()
        {
            Appointments.Sort();
        }

        public IEnumerator<Appointment> GetEnumerator()
        {
            return ((IEnumerable<Appointment>)Appointments).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Appointments).GetEnumerator();
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public void Clear()
        {
            Appointments.Clear();
        }
    }
}
