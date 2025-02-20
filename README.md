# EMP_CRM

## 📌 Project Overview
**EMP_CRM** (Employee CRM) is a .NET Core MVC-based employee management system designed to streamline employee-related operations. This project integrates authentication, authorization, role-based access control, and a dashboard for managing employee records efficiently.

## 🏗️ Tech Stack
- **Frontend**: AdminLTE v3 (for UI design)
- **Backend**: ASP.NET Core 8 (MVC)
- **Database**: Entity Framework Core with SQL Server
- **Authentication**: Identity-based authentication and authorization
- **Middleware**: Custom middleware for handling requests and responses
- **Logging & Monitoring**: Serilog, Health Checks, and Application Insights

## ⚡ Features
- ✅ User Authentication (Login, Registration, Forgot Password)
- ✅ Role-Based Access Control (RBAC)
- ✅ Employee Management (CRUD operations using EF Core)
- ✅ Dashboard with Employee Details
- ✅ Custom Middleware Implementation
- ✅ Logging & Monitoring with Serilog
- ✅ Health Checks for system monitoring

## 📸 Screenshots

### Employee Login
![Dashboard](https://github.com/pawan856/EMP_CRM/blob/master/EMP_CRM/wwwroot/Images/Emp_CRM1.jpeg)

### New Employee Register
![Employee List](https://github.com/pawan856/EMP_CRM/blob/master/EMP_CRM/wwwroot/Images/EMP_CRM2.jpeg)

### Forgot password
![Employee Details](https://github.com/pawan856/EMP_CRM/blob/master/EMP_CRM/wwwroot/Images/Emp_CRM3.jpeg)

### Employee Dashboard
![Employee Creation](https://github.com/pawan856/EMP_CRM/blob/master/EMP_CRM/wwwroot/Images/Emp_CRM4.jpeg)

### Employee Creation
![Employee Edit](https://github.com/pawan856/EMP_CRM/blob/master/EMP_CRM/wwwroot/Images/Emp_CRM5.jpeg)

### Employee Details
![Employee Deletion](https://github.com/pawan856/EMP_CRM/blob/master/EMP_CRM/wwwroot/Images/Emp_CRM6.jpeg)

### Employee updations
![Role Management](https://github.com/pawan856/EMP_CRM/blob/master/EMP_CRM/wwwroot/Images/Emp_CRM7.jpeg)

### Employee Delete
![User Permissions](https://github.com/pawan856/EMP_CRM/blob/master/EMP_CRM/wwwroot/Images/Emp_CRM8.jpeg)

###  Employee Report
![Reports & Analytics](https://github.com/pawan856/EMP_CRM/blob/master/EMP_CRM/wwwroot/Images/Emp_CRM9.jpeg)

## 🚀 Setup & Installation
1. **Clone the Repository**
   ```sh
   git clone https://github.com/pawan856/EMP_CRM.git
   cd EMP_CRM
   ```
2. **Set Up Database**
   - Update `appsettings.json` with your SQL Server connection string.
   - Apply migrations:
     ```sh
     dotnet ef database update
     ```
3. **Run the Application**
   ```sh
   dotnet run
   ```
4. **Access the Web App**
   - Open `http://localhost:5000` (or the specified port) in your browser.

## 🔗 API Endpoints
| Endpoint              | Method | Description                 |
|----------------------|--------|-----------------------------|
| `/Account/Login`     | POST   | User login                  |
| `/Account/Register`  | POST   | User registration           |
| `/Employee`          | GET    | Fetch all employees         |
| `/Employee/{id}`     | GET    | Fetch employee by ID        |
| `/Employee/Create`   | POST   | Create a new employee       |
| `/Employee/Edit/{id}`| PUT    | Update employee details     |
| `/Employee/Delete/{id}` | DELETE | Remove an employee     |

## 📂 Project Structure
```
EMP_CRM/
│-- Controllers/
│-- Models/
│-- Views/
│-- Middleware/
│-- Services/
│-- wwwroot/
│-- appsettings.json
│-- Program.cs
│-- Startup.cs
```

## 🛠️ Future Enhancements
- 📌 Employee Performance Tracking
- 📌 Email Notifications for HR Actions
- 📌 Advanced Reporting & Analytics
- 📌 Mobile-Friendly UI Enhancements

## 📜 License
This project is open-source and available under the MIT License.

---
**Author:** Pawan856

Feel free to contribute or raise issues! 🚀

