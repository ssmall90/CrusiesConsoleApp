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

                            CruiseModel cruise = (CruiseModel)serializer.Deserialize(reader.ReadSubtree());
                            cruises.Add(cruise);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; 
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

                doc.Root.Add(newCruiseElement);

                doc.Save(filePath);

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
                    XElement passengersElement = cruiseElement.Element("Passengers");

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
                    Console.WriteLine("Cruise with the specified identifier not found.");
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
                            Console.WriteLine("Port with the specified name not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Ports element found in the specified cruise.");
                    }
                }
                else
                {
                    Console.WriteLine("Cruise with the specified identifier not found.");
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
                    Console.WriteLine("Trip with the specified ID not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                // Handle the error as needed
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


    }
}
