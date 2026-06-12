# Fleet Vehicle Maintenance Management API

ASP.NET Core Web API for managing fleet vehicles, drivers, and maintenance records.

## Tech Stack
- ASP.NET Core 8.0
- Entity Framework Core
- SQL Server
- Swagger

---

## Repository and Service Pattern

**Repository Pattern** 

The Repository Pattern is used to separate database access logic from business logic. Repository classes handle all communication with the database using Entity Framework Core.

Benefits: Keeps controllers clean, makes code easier to maintain, improves testability by isolating data access.

**Service Pattern** 

The Service Pattern is used to contain business logic such as validation, filtering, sorting, and pagination. Services act as a middle layer between controllers and repositories.

Benefits: Centralizes business rules, prevents duplication of logic, makes the application more scalable and organized.

**Flow:** Controller → Service → Repository → Database

---

## API Endpoints Tested

### Vehicles
- GET /api/vehicles - get all vehicles
- GET /api/vehicles/{id} - get vehicle by id
- POST /api/vehicles - add new vehicle

### Drivers
- GET /api/drivers - get all drivers
- GET /api/drivers/{id} - get driver by id
- POST /api/drivers - add new driver

### Maintenance Records
- GET /api/maintenanceRecords - get records with pagination, filtering, sorting
- POST /api/maintenanceRecords - add new maintenance record

---

## Screenshots

### Vehicle Endpoints

| GET /api/vehicles | GET /api/vehicles/1 | POST /api/vehicles |
|:---:|:---:|:---:|
| ![Get All Vehicles](Screenshots/01_GET_All_Vehicles.png) | ![Get Vehicle By Id](Screenshots/02_GET_Vehicle_By_Id.png) | ![POST Vehicle](Screenshots/03_POST_Vehicle_Response.png) |

### Driver Endpoints

| GET /api/drivers | GET /api/drivers/1 | POST /api/drivers |
|:---:|:---:|:---:|
| ![Get All Drivers](Screenshots/04_GET_All_Drivers.png) | ![Get Driver By Id](Screenshots/05_GET_Driver_By_Id.png) | ![POST Driver](Screenshots/06_POST_Driver_Response.png) |

### Maintenance Endpoints

| POST /api/maintenanceRecords | GET Pagination | Filter by Status |
|:---:|:---:|:---:|
| ![POST Maintenance](Screenshots/07_POST_Maintenance.png) | ![Pagination](Screenshots/08_GET_Maintenance_Pagination.png) | ![Filter Status](Screenshots/09_GET_Maintenance_Filter_Status.png) |

| Filter by Vehicle | Filter by Driver | Filter by Date Range |
|:---:|:---:|:---:|
| ![Filter Vehicle](Screenshots/10_GET_Maintenance_Filter_Vehicle.png) | ![Filter Driver](Screenshots/11_GET_Maintenance_Filter_Driver.png) | ![Filter Date](Screenshots/12_GET_Maintenance_Filter_DateRange.png) |

| Sort by Cost | Error Validation |
|:---:|:---:|
| ![Sort Cost](Screenshots/13_GET_Maintenance_Sort.png) | ![Error](Screenshots/14_Error_Validation.png) |

---

## Sample Data

- 10 vehicles
- 10 drivers
- 31 maintenance records

---

## How to Run

1. Run the FleetMaintainnence.sql script in SQL Server Management Studio
2. Update the connection string in appsettings.json to match your SQL Server
3. Open the project in Visual Studio and press F5
4. Swagger UI will open at http://localhost:XXXX/swagger