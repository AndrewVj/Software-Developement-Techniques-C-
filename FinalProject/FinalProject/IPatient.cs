using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{
    //An Interface to force behaviour of the Patient Class
    public delegate String DentalServicesDelegate();
    public interface IPatient
    {
        string Name { get; set; }

        uint Age { get; set; }

        string ContactNumber { get; set; }

        string CreditCardNumber { get; set; }

        public DentalServicesDelegate DentalServices { get; set; }

        public string RoutineCheckUp();

        public string Cleaning();

        public string CavityFilling();

        public string ToothExtraction();

        public string OtherService();

    }
}
