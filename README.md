## Car-Rental-System

**Program for renting cars.**

The program uses a Five-Layer Architecture consisting of:
* Persistence Layer: Uses [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2016) database. The layer uses prepared statements for communicating with the database. [Create](https://github.com/Batev/Car-Rental-System/blob/master/CarRentalSystemServer/CarRentalSystemServer/Server/Database/Create.sql) and [Insert](https://github.com/Batev/Car-Rental-System/blob/master/CarRentalSystemServer/CarRentalSystemServer/Server/Database/Insert.sql) scripts could be found unter the links.
* Service Layer: Varifies data input and makes complicated computations.
* Controller Layer: Uses [ASP.NET](https://www.asp.net/). Sends and receives HTTP request and JSON objects on the server side.
* Client Layer: Sends and receives HTTP request and JSON objects on the client side.
* Presentation Layer: Uses [WPF](https://msdn.microsoft.com/en-us/library/ms754130(v=vs.110).aspx). Simple interface for the users.
