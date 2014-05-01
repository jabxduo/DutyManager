using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duty_Manager
{
    class Duty
    {
        string description;
        int floorNumber;
        int dutyId;
        int lodgersRequired;
        int isKitchen;

        public Duty(String name)
        {
            description = name;
        }

        /// <summary>
        /// Getters and Setters
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int FloorNumber
        {
            get { return floorNumber; }
            set { floorNumber = value; }
        }
        public int DutyId
        {
            get { return dutyId; }
            set { dutyId = value; }
        }
        public int LodgersRequired
        {
            get { return lodgersRequired; }
            set { lodgersRequired = value; }
        }
        public int IsKitchen
        {
            get { return isKitchen; }
            set { isKitchen = value; }
        }

    }
}
