# Tech Company Management Software

## Overview

This project is a comprehensive **Tech Company Management System** designed to streamline 
the operations of various departments within a company. The system provides both a 
**desktop application** for managers to manage schedules and employees, 
and a **web application** for employees to handle their shifts and availability. 
The application is built using `C#` (primarily), `JavaScript`, `CSS`, `HTML`, and `SQL`. The database is hosted on `SQL Server Management Studio`.

## Key Features

### Desktop Application
The desktop application is designed for **managers** and **CEOs** to manage their teams, schedules, and work operations.
  - Developed using **Windows Forms** in `.NET Core`.

- **Scheduling**:
  - Automated scheduling using a custom algorithm that assigns shifts based on employee availability.
  - Managers can manually assign shifts and generate schedules for various time periods (daily, weekly, monthly).
  - Notifications alert managers when a future shift lacks enough staff, allowing adjustments.
  
- **Employee Management**:
  - Department managers can view and manage employees in their department.
  - The CEO can view all employees, update wages, and handle terminations.
  
- **Clocking System**:
  - Employees clock in/out using company cards, allowing managers to track work hours.
  - Managers can view employee work hours in the form of bar charts, providing clear insights into productivity.

- **Product and Depot Management**:
  - Employees can request product restocks from the depot.
  - Depot managers manage stock and place orders with external suppliers when inventory runs low.

### Web Application
The web application offers **employees** the ability to manage their profiles, shifts, and availability.
  - Developed using `ASP.NET Core Razor Pages`.

- **Availability Management**:
  - Employees can set their availability for the upcoming month and view their assigned shifts in a calendar format.

- **Shift Requests**:
  - Employees can request shift cancellations, and if approved, other department employees can take over shifts.
  - The system ensures employees work a maximum of 2 shifts per day, following a predefined shift combination rule.

- **Profile and Account Management**:
  - Employees can update personal details, including resetting forgotten passwords.

## Technical Details

- **Scalability**: The system is designed to handle a large number of employees, shifts, and products without performance degradation. Currently, the database is loaded with more than `50,000 records` so it can recreate a real environment. The runtime is not affected by the number of records and the application loads and reacts quickly.
- **Security**: Sensitive data such as passwords is securely stored using a hash `encrypting algorithm` to ensure data integrity.
- **Shift Management Algorithm**: `Custom-built algorithms` manage the schedule generation and shift reassignment, ensuring compliance with shift rules.
- **Real-time Notifications**: Managers are alerted in real-time when shifts lack adequate staffing.
  
## Design and Architecture

- **OOP Principles**: The application is developed following `Object-Oriented Programming (OOP)` concepts to ensure a maintainable and scalable codebase.
- **Database Design**: The system’s database is structured to support multi-department operations with full relational integrity.

## Documentation & Diagrams

The project includes extensive documentation for ease of understanding and further development:

- **User Requirements Specifications (URS)**: A document that outlines all functional and non-functional requirements for the software.
- **Test Plan and Test Report**: Detailed reports of the testing process, including unit tests, and coverage for all possible scenarios.

## Testing

The project has the correcponding `Test Plan` and `Test Report` with all reasuts, after testing in a working environemnt. Both documents can be found in the attached `Documents`
## Technologies Used

- **Frontend**: 
  - `HTML`, `CSS`, `JavaScript`
- **Backend**:
  - `C#` (with `.NET Core Framework`)
  - `SQL Server Management Studio (SQL)`
- **Web Application**:
  - `ASP.NET Core Razor Pages`
- **Desktop Application**:
  - `Windows Forms (.NET Core)`
- **Database**: 
  - `SQL Server Management Studio`
- **Security**:
  - Custom `hash encrypting algorithm` for secure data storage
