using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    //A delegate to hold all the methods of the Vehicle class
    //public delegate void VehicleDelegate();

    //An Interface to force behaviour of the Vehicle Class
    interface IVehicle
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
