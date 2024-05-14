# 🚢 Cruise Management Application

Welcome to the Cruise Management Application! 🎉

## 📝 Overview

The Cruise Management Application is a console-based application written in C# using Spectre.Console. It allows users to manage a fleet of cruises, including adding, editing, and deleting cruises, passengers, ports, and trips available at each port.

## 🛠️ Features

### Cruise Management

- **Add Cruise:** Add a new cruise to the fleet.
- **Edit Cruise:** Modify details of an existing cruise, such as its name, duration, or departure date.
- **Delete Cruise:** Remove a cruise from the fleet.

### Passenger Management

- **Add Passenger:** Add a new passenger to a specific cruise.
- **Edit Passenger:** Modify details of an existing passenger, such as their name, age, or cabin assignment.
- **Delete Passenger:** Remove a passenger from a cruise.

### Port Management

- **Add Port:** Add a new port that a cruise can visit.
- **Edit Port:** Modify details of an existing port, such as its name or location.
- **Delete Port:** Remove a port from the list of destinations.

### Trip Management

- **Add Trip:** Add a new trip available at a specific port.
- **Edit Trip:** Modify details of an existing trip, such as its name, duration, or price.
- **Delete Trip:** Remove a trip from the list of available excursions.
- 
## 📁 Project Structure

- **CruiseManagementApp:** Contains the main application logic and user interface.
- **Models:** Defines the data models used in the application, such as Cruise, Passenger, Port, and Trip.
- **Services:** Provides services for interacting with the data, such as CRUD operations for managing cruises, passengers, ports, and trips.
- **Utils:** Contains utility classes and helper methods used across the application.
- **Database:** Contains XML files for defining the database schema and storing data.

## 🗄️ Database

The application utilizes XML for defining the database schema and storing data. The XML files include:

- **Schema.xml:** Defines the structure and constraints of the database tables.
- **Data.xml:** Stores the actual data used by the application, such as cruise details, passenger information, port details, and trip information.

