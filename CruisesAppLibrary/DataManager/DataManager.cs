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
                // Create an instance of the XmlSerializer for the CruiseModel
                XmlSerializer serializer = new XmlSerializer(typeof(CruiseModel));

                // Create an XmlReader to read the XML file
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "CruiseModel")
                        {
                            // Deserialize the first CruiseModel element encountered in the XML
                            CruiseModel cruise = (CruiseModel)serializer.Deserialize(reader.ReadSubtree());
                            cruises.Add(cruise);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; // Handle the error as needed
            }

            return cruises;
        }

        public void AppendCruiseToXml(string filePath, CruiseModel cruise)
        {
            try
            {
                // Load the existing XML document
                XDocument doc = XDocument.Load(filePath);


                XElement newCruiseElement =
                    new XElement("CruiseModel",
                    new XElement("CruiseName", cruise.CruiseName),
                    new XElement("CruiseIdentifier", cruise.CruiseIdentifier),
                    new XElement("Trips", cruise.Ports),
                    new XElement("Passengers", cruise.Passengers)

                ); ;


                doc.Root.Add(newCruiseElement);

                doc.Save(filePath);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                // Handle the error as needed
            }
        }

        public PortModel DeserializePortFromXml(string filePath)
        {
            try
            {
                // Create an instance of the XmlSerializer for the CruiseModel
                XmlSerializer serializer = new XmlSerializer(typeof(PortModel));

                // Create an XmlReader to read the XML file
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "PortModel")
                        {
                            // Deserialize the first CruiseModel element encountered in the XML
                            PortModel port = (PortModel)serializer.Deserialize(reader.ReadSubtree());
                            return port;
                        }
                    }
                }

                // If no Port element is found, return null
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; // Handle the error as needed
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
                        new XElement("PortName", port.Name),
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
                // Handle the error as needed
            }
        }

        public TripModel DeserializeTripFromXml(string filePath)
        {
            try
            {
                // Create an instance of the XmlSerializer for the CruiseModel
                XmlSerializer serializer = new XmlSerializer(typeof(TripModel));

                // Create an XmlReader to read the XML file
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "TripModel")
                        {
                            // Deserialize the first CruiseModel element encountered in the XML
                            TripModel trip = (TripModel)serializer.Deserialize(reader.ReadSubtree());
                            return trip;
                        }
                    }
                }

                // If no Port element is found, return null
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; // Handle the error as needed
            }
        }

        public PassengerModel DeserializePassengerFromXml(string filePath)
        {
            try
            {
                // Create an instance of the XmlSerializer for the CruiseModel
                XmlSerializer serializer = new XmlSerializer(typeof(PassengerModel));

                // Create an XmlReader to read the XML file
                using (XmlReader reader = XmlReader.Create(filePath))
                {
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "PassengerModel")
                        {
                            // Deserialize the first CruiseModel element encountered in the XML
                            PassengerModel passenger = (PassengerModel)serializer.Deserialize(reader.ReadSubtree());
                            return passenger;
                        }
                    }
                }

                // If no Port element is found, return null
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null; // Handle the error as needed
            }
        }
    }
}
