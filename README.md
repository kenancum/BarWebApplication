# Bar WebApp

This is a sample project that demonstrates how to build a web application using ASP.NET Core, MongoDB, and AngularJS.
## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [MongoDB](https://www.mongodb.com/download-center/community)
- [Node.js](https://nodejs.org/en/download/)

### Installing

1. Clone the repository to your local machine:
``` Console
git clone https://github.com/<username>/<repository>.git
```

2. Install the npm packages for the AngularJS application:
``` Console
cd <path-to-angular-project>
npm install
```

3. Start the MongoDB server:
```Console
mongod --dbpath <path-to-data-directory> --port 27017
```

4. Build and run the ASP.NET Core web application:
```Console
cd <path-to-aspnet-project>
dotnet run
```

5. Start the AngularJS application:
```Console
cd <path-to-angular-project>
ng serve
```

6. Open your browser and navigate to http://localhost:4200 to see the application running.

## API Endpoints
*GET /api/Bars: Retrieve a list of all bar items
*GET /api/Bars/{id}: Retrieve a specific bar item by id
*POST /api/Bars: Create a new bar item
*PUT /api/Bars: Update a specific bar item by id
*DELETE /api/Bars/{id}: Delete a specific bar item by id

### Running the tests

To run the tests for the ASP.NET Core web application, navigate to the project directory and run the following command:
```Console
dotnet test
```

## Deployment

To deploy the application, you can use the [dotnet publish](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-publish?tabs=netcore21) command to create a self-contained deployment package.

## Built With

- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1) - The web framework used
- [MongoDB](https://www.mongodb.com/) - The database used
- [AngularJS](https://angularjs.org/) - The JavaScript framework used for the front-end

## Author
[Kenan Cum](https://linkedin.com/in/kenancum)
