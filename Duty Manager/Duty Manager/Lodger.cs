using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Duty_Manager
{
    class Lodger
    {
        string name;
        Array[] favorites;
        int presetDuty;
        List<Duty> currentDuties;
        int floorNumber;
        int isKitchen;

        public Lodger(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Begin Getters and Setters
        /// </summary>
        /// 
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int IsKitchen
        {
            get { return isKitchen; }
            set { isKitchen = value; }
        }
        public int FloorNumber
        {
            get { return floorNumber; }
            set { floorNumber = value; }
        }

        internal List<Duty> CurrentDuties
        {
            get { return currentDuties; }
            set { currentDuties = value; }
        }
        public int PresetDuty
        {
            get { return presetDuty; }
            set { presetDuty = value; }
        }

    }
}
