using CrusiesConsoleAppUI.Models;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CrusiesConsoleAppUI.Services
{

    public class DataManager : IDataManager
    {
        public List<CruiseModel> DeserializeCruiseFromXml(string filePath)
        {
            List<CruiseModel> cruises = new List<CruiseModel>();

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(CruiseModel));

                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "CruiseModel")
                        {

                            CruiseModel cruise = (CruiseModel)serializer.Deserialize(reader.ReadSubtree())!;
                            cruises.Add(cruise);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null!;
            }

            return cruises;
        }

        public void AppendCruiseToXml(string filePath, CruiseModel cruise)
        {
            try
            {

                XDocument doc = XDocument.Load(filePath);

                XElement newCruiseElement =
                    new XElement("CruiseModel",
                    new XElement("CruiseName", cruise.CruiseName),
                    new XElement("CruiseIdentifier", cruise.CruiseIdentifier),
                    new XElement("Ports", cruise.Ports),
                    new XElement("Passengers", cruise.Passengers)

                ); ;

                doc.Root!.Add(newCruiseElement);

                doc.Save(filePath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void RemoveCruise(string filePath, string cruiseIdentifier)
        {
            try
            {

                XDocument doc = XDocument.Load(filePath);

                XElement cruiseToDelete = doc.Descendants("CruiseModel").FirstOrDefault(c => c.Element("CruiseIdentifier")?.Value == cruiseIdentifier)!;


                if (cruiseToDelete != null)
                {
                    cruiseToDelete.Remove();
                    doc.Save(filePath);
                }
                else
                {
                    Console.WriteLine("A Cruise With the Specified ID Could Not Be Found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }




        public void AddPassengersToCruise(string filePath, string cruiseIdentifier, PassengerModel passenger)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);

                XElement cruiseElement = doc.Root!.Elements("CruiseModel")
                    .FirstOrDefault(c => c.Element("CruiseIdentifier")!.Value == cruiseIdentifier)!;

                if (cruiseElement != null)
                {
                    XElement passengersElement = cruiseElement.Element("Passengers")!;

                    if (passengersElement == null)
                    {
                        passengersElement = new XElement("Passengers");
                        cruiseElement.Add(passengersElement);
                    }

                    XElement passengerElement = new XElement("PassengerModel",
                    new XElement("FirstName", passenger.FirstName),
                    new XElement("LastName", passenger.LastName),
                    new XElement("PassportNumber", passenger.PassportNumber));
                    passengersElement.Add(passengerElement);


                    doc.Save(filePath);
                }
                else
                {
                    Console.WriteLine("A Cruise With the Specified Identifier Not Be Found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void RemovePassengerFromCruise(string filePath, string cruiseIdentifier, string passportNumber)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);

                XElement passengerToRemove = doc.Descendants("PassengerModel").FirstOrDefault(p => p.Element("PassportNumber")?.Value == passportNumber)!;

                if (passengerToRemove != null)
                {
                    passengerToRemove.Remove();
                    doc.Save(filePath);
                }
                else
                {
                    Console.WriteLine("A Passenger With the Specified Passport Number Could Not Be Found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

        }



        public void AddTripToPort(string filePath, string cruiseIdentifier, string portId, TripModel trip)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);

                XElement cruiseElement = doc.Root!.Elements("CruiseModel")
                    .FirstOrDefault(c => c.Element("CruiseIdentifier")!.Value == cruiseIdentifier)!;

                if (cruiseElement != null)
                {
                    XElement portsElement = cruiseElement.Element("Ports")!;

                    if (portsElement != null)
                    {
                        XElement portElement = portsElement.Elements("PortModel")
                            .FirstOrDefault(p => p.Element("PortId")?.Value == portId)!;

                        if (portElement != null)
                        {
                            XElement tripsElement = portElement.Element("Trips")!;

                            if (tripsElement == null)
                            {

                                tripsElement = new XElement("Trips");
                                portElement.Add(tripsElement);
                            }

                            XElement newTripElement = new XElement("TripModel",
                                new XElement("NameOfActivity", trip.NameOfActivity),
                                new XElement("ActivityId", trip.ActivityId),
                                new XElement("Cost", trip.Cost));

                            tripsElement.Add(newTripElement);

                            doc.Save(filePath);
                        }
                        else
                        {
                            Console.WriteLine("A Port With the Specified Name Could Not Be Found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Ports Found on The Specified Cruise.");
                    }
                }
                else
                {
                    Console.WriteLine("A Cruise With the Specified Identifier Could Not Be Found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void RemoveTripFromPort(string filePath, string tripId)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);

                XElement tripToDelete = doc.Descendants("TripModel").FirstOrDefault(trip => trip.Element("ActivityId")?.Value == tripId)!;

                if (tripToDelete != null)
                {
                    tripToDelete.Remove();
                    doc.Save(filePath);
                }
                else
                {
                    Console.WriteLine("A Trip With the Specified ID Could Not Be Found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }




        public void AddPortToCruise(string filePath, CruiseModel cruise, PortModel port)
        {

            try
            {
                XDocument doc = XDocument.Load(filePath);

                XElement cruiseElement = doc.Root!.Elements("CruiseModel").FirstOrDefault(c => c.Element("CruiseIdentifier")!.Value == cruise.CruiseIdentifier)!;

                if (cruiseElement != null)
                {
                    XElement portsElement = cruiseElement.Element("Ports")!;

                    if (portsElement == null)
                    {
                        portsElement = new XElement("Ports");
                        cruiseElement.Add(portsElement);
                    }

                    XElement newPortElement = new XElement("PortModel",
                        new XElement("Name", port.Name),
                        new XElement("PortId", port.PortId),
                        new XElement("LengthOfStay", port.LengthOfStay),
                        new XElement("Trips", port.Trips));

                    portsElement.Add(newPortElement);

                    doc.Save(filePath);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void RemovePortFromCruise(string filePath, string portId)
        {
            try
            {

                XDocument doc = XDocument.Load(filePath);

                XElement portToDelete = doc.Descendants("PortModel").FirstOrDefault(p => p.Element("PortId")?.Value == portId)!;


                if (portToDelete != null)
                {
                    portToDelete.Remove();
                    doc.Save(filePath);
                }
                else
                {
                    Console.WriteLine("A Port With the Specified ID Could Not Be Found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }




        public void AddPassengerToTrip(string filePath, string cruiseIdentifier, string portId, string tripId, PassengerModel passenger)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);

                XElement cruiseElement = doc.Root!.Elements("CruiseModel")
                    .FirstOrDefault(c => c.Element("CruiseIdentifier")!.Value == cruiseIdentifier)!;

                if (cruiseElement != null)
                {
                    XElement portsElement = cruiseElement.Element("Ports")!;

                    if (portsElement != null)
                    {
                        XElement portElement = portsElement.Elements("PortModel")
                            .FirstOrDefault(p => p.Element("PortId")?.Value == portId)!;

                        if (portElement != null)
                        {
                            XElement tripsElement = portElement.Element("Trips")!;

                            if (tripsElement != null)
                            {
                                XElement tripElement = tripsElement.Elements("TripModel")
                                    .FirstOrDefault(t => t.Element("ActivityId")?.Value == tripId)!;

                                if (tripElement != null)
                                {
                                    XElement attendingPassengersElement = tripElement.Element("AttendingPassengers")!;

                                    if (attendingPassengersElement == null)
                                    {
                                        attendingPassengersElement = new XElement("AttendingPassengers");
                                        tripElement.Add(attendingPassengersElement);
                                    }

                                    XElement passengerElement = new XElement("PassengerModel",
                                    new XElement("FirstName", passenger.FirstName),
                                    new XElement("LastName", passenger.LastName),
                                    new XElement("PassportNumber", passenger.PassportNumber));

                                    attendingPassengersElement.Add(passengerElement);

                                    doc.Save(filePath);
                                }
                                else
                                {
                                    Console.WriteLine("A Trip With The Specified Name Could Not Be Found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No Trips Element Found in the Specified Port.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("A Port With the Specified Name Could Not Be Found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Ports Element Found in The Specified Cruise.");
                    }
                }
                else
                {
                    Console.WriteLine("A Cruise With the Specified Identifier Could Not Be Found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void RemovePassengerFromTrip(string filePath, string cruiseIdentifier, string portId, string tripId, string passportNumber)
        {
            try
            {
                XDocument doc = XDocument.Load(filePath);

                XElement cruiseElement = doc.Root!.Elements("CruiseModel")
                    .FirstOrDefault(c => c.Element("CruiseIdentifier")!.Value == cruiseIdentifier)!;

                if (cruiseElement != null)
                {
                    XElement portsElement = cruiseElement.Element("Ports")!;

                    if (portsElement != null)
                    {
                        XElement portElement = portsElement.Elements("PortModel")
                            .FirstOrDefault(p => p.Element("PortId")?.Value == portId)!;

                        if (portElement != null)
                        {
                            XElement tripsElement = portElement.Element("Trips")!;

                            if (tripsElement != null)
                            {
                                XElement tripElement = tripsElement.Elements("TripModel")
                                    .FirstOrDefault(t => t.Element("ActivityId")?.Value == tripId)!;

                                if (tripElement != null)
                                {
                                    XElement attendingPassengersElement = tripElement.Element("AttendingPassengers")!;

                                    if (attendingPassengersElement != null)
                                    {
                                        XElement passengerToRemove = attendingPassengersElement.Elements("PassengerModel")
                                            .FirstOrDefault(p => p.Element("PassportNumber")?.Value == passportNumber)!;

                                        if (passengerToRemove != null)
                                        {
                                            passengerToRemove.Remove();

                                            doc.Save(filePath);
                                        }
                                        else
                                        {
                                            Console.WriteLine("A Passenger With the Specified PassportNumber Could Not Be Found On The Attending Passengers.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("No AttendingPassengers Element Found On the Specified Trip.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("A Trip With the Specified Name Could Not Be Found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No Trips Element Found On the Specified Port.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("A Port With the Specified Name Could Not Be Found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Ports Element Found On the Specified Cruise.");
                    }
                }
                else
                {
                    Console.WriteLine("A Cruise With the Specified Identifier Could Not Be found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                // Handle the error as needed
            }
        }
    }
}
