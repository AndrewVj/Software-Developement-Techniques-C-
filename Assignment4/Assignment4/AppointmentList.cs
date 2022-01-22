using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    //AppointmentList class to store list of appointments
    //We use IDisposable and IEnumerable Interfaces.
    //We use Indexer to make this class usuable like it is an Array or List.
    class AppointmentList : IDisposable, IEnumerable<Appointment>
    {
        private List<Appointment> appointmentsList = null;

        public AppointmentList()
        {
            appointmentsList = new List<Appointment>();
        }

        public void Add(Appointment appointment)
        {
            appointmentsList.Add(appointment);
        }
        public void Remove(Appointment appointment)
        {
            appointmentsList.Remove(appointment);
        }

        public void Clear()
        {
            appointmentsList.Clear();
        }

        public int Count()
        {
            return appointmentsList.Count();
        }

        //Indexer
        public Appointment this[int i]
        {
            get => appointmentsList[i];
            set => appointmentsList[i] = value;
        }

        public void Sort()
        {
            appointmentsList.Sort();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerator<Appointment> GetEnumerator()
        {
            return ((IEnumerable<Appointment>)appointmentsList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
