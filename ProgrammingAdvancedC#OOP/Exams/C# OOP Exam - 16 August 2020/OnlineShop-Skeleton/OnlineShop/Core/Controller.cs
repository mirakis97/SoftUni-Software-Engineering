using OnlineShop.Common.Constants;
using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IPeripheral> peripherals;
        private List<IComponent> components;

        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }
        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            if (computerType != nameof(Laptop) && computerType != nameof(DesktopComputer))
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            if (computerType == nameof(Laptop))
            {
                computers.Add(new Laptop(id, manufacturer, model, price));
            }
            else if (computerType == nameof(DesktopComputer))
            {
                computers.Add(new DesktopComputer(id, manufacturer, model, price));
            }

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price,
            double overallPerformance, string connectionType)
        {
            var computer = computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            if (peripheralType != PeripheralType.Headset.ToString() && peripheralType != PeripheralType.Keyboard.ToString() && peripheralType != PeripheralType.Monitor.ToString() && peripheralType != PeripheralType.Mouse.ToString())
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral peripheral = null;
            switch (peripheralType)
            {
                case nameof(Headset):
                    peripheral =
                        new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
                    computer.AddPeripheral(peripheral);
                    peripherals.Add(peripheral);
                    break;
                case nameof(Keyboard):
                    peripheral =
                        new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
                    computer.AddPeripheral(peripheral);
                    peripherals.Add(peripheral);
                    break;
                case nameof(Monitor):
                    peripheral =
                        new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
                    computer.AddPeripheral(peripheral);
                    peripherals.Add(peripheral);
                    break;
                case nameof(Mouse):
                    peripheral =
                        new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
                    computer.AddPeripheral(peripheral);
                    peripherals.Add(peripheral);
                    break;
            }

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);


        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            var computer = computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            var peripheral = computer.Peripherals.FirstOrDefault(c => c.GetType().Name == peripheralType);

            if (peripheral == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    computer.GetType().Name, computerId));
            }
            computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);
            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, peripheral.Id);
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price,
            double overallPerformance, int generation)
        {
            var computer = computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            if (computer.Components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            if (componentType != ComponentType.CentralProcessingUnit.ToString() && componentType != ComponentType.Motherboard.ToString() && componentType != ComponentType.PowerSupply.ToString() && componentType != ComponentType.RandomAccessMemory.ToString() && componentType != ComponentType.SolidStateDrive.ToString() && componentType != ComponentType.VideoCard.ToString())
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent newComponent;
            switch (componentType)
            {
                case nameof(CentralProcessingUnit):
                    newComponent =
                        new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
                    computer.AddComponent(newComponent);
                    components.Add(newComponent);
                    break;
                case nameof(Motherboard):
                    newComponent =
                        new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
                    computer.AddComponent(newComponent);
                    components.Add(newComponent);
                    break;
                case nameof(PowerSupply):
                    newComponent =
                        new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
                    computer.AddComponent(newComponent);
                    components.Add(newComponent);
                    break;
                case nameof(RandomAccessMemory):
                    newComponent =
                        new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
                    computer.AddComponent(newComponent);
                    components.Add(newComponent);
                    break;
                case nameof(SolidStateDrive):
                    newComponent =
                        new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
                    computer.AddComponent(newComponent);
                    components.Add(newComponent);
                    break;
                case nameof(VideoCard):
                    newComponent =
                        new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
                    computer.AddComponent(newComponent);
                    components.Add(newComponent);
                    break;
            }
            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            var computer = computers.FirstOrDefault(c => c.Id == computerId);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            var component = computer.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            if (component == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType,
                    computer.GetType().Name, computerId));
            }
            computer.RemoveComponent(componentType);
            components.Remove(component);
            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string BuyComputer(int id)
        {
            var computer = computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            computers.Remove(computer);
            return computer.ToString();

        }

        public string BuyBest(decimal budget)
        {
            var computer = computers.OrderByDescending(c => c.OverallPerformance).FirstOrDefault(c => c.Price <= budget);
            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            computers.Remove(computer);
            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            var computer = computers.FirstOrDefault(c => c.Id == id);
            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }
            return computer.ToString();

        }
        public void Close()
        {
            Environment.Exit(0);
        }
    }
}
