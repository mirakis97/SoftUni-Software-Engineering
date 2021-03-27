using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IDriver> drivers;
        public Race(string name,int laps)
        {
            this.name = name;
            this.laps = laps;
            this.drivers = new List<IDriver>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                this.name = value;
            } 
        }

        public int Laps
        { 
            get => this.laps; 
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RaceInvalid);
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IDriver> Drivers => this.drivers;
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);

            }
            else if (driver.CanParticipate != false)
            {
                throw new ArgumentException(ExceptionMessages.DriverNotParticipate);
            }
            else if (drivers.Contains(driver))
            {
                throw new ArgumentException(ExceptionMessages.DriverAlreadyAdded);
            }
            this.drivers.Add(driver);
        }
    }
}
