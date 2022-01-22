using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    //An Interface to force behaviour of the Vehicle Class
    public interface IVehicle
    {
        int YearOfMake { get; set; }
        string Company { get; set; }
        string Model { get; set; }
        string AssociatedCreditCardNumber { get; set; }

        string OilChange();
        string EngineTuneUp();
        string TransmissionCleanUp();

        string AdditionalService();
    }
}
