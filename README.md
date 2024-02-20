# Domain Status Checker / API

## Overview
This is a lightweight web application developed with C# and .NET, designed to provide users with a swift determination of the online status of a specified domain. Leveraging the System.Net.NetworkInformation and System.Net.Sockets namespaces, the application conducts ping operations to assess network connectivity. With future expansions planned, its initial purpose is to aid in a proxy toolbox, enabling users to check the status of their reverse proxy from outside their network, particularly useful for homelabs.

## Features
- **Domain Status Check:** Users can input a domain name and instantly receive feedback on whether the domain is online or offline.
- **Error Handling:** The application gracefully handles exceptions such as invalid domain names, network errors, or server unavailability.
- **Swagger Integration:** The project integrates with Swagger for API documentation and exploration, enhancing its usability and developer experience.

## Usage
1. **Input Domain:** Specify the domain name you wish to check the status of.
2. **Receive Status:** Instantly receive feedback indicating whether the domain is online or offline.
3. **Error Handling:** The application ensures robustness by handling various exceptions and providing clear error messages when necessary.

## API Reference
```http
@RPTB_API_HostAddress = http://localhost:5243
@CheckEndpoint = /Domain/Check
GET {{RPTB_API_HostAddress}}{{CheckEndpoint}}
Accept: application/json
```

## Installation
1. Clone the repository to your local machine.
2. Ensure you have the latest version of .NET SDK installed.
3. Navigate to the project directory and run the application using `dotnet run`.
4. Access the application through your preferred web browser.

## Dependencies
- **System.Net.NetworkInformation:** Used for performing ping operations and checking network status.
- **System.Net.Sockets:** Enables socket operations for network communication.
- **Swagger UI:** Integrated for API documentation and exploration, enhancing project usability.

## Contribution Guidelines
- Fork the repository and create a new branch for your contributions.
- Make changes or improvements as needed, ensuring adherence to coding standards and best practices.
- Submit a pull request detailing the changes implemented and the rationale behind them.

## License
This project is licensed under the [MIT License](LICENSE), granting users the freedom to use, modify, and distribute the software as per the terms outlined in the license.
