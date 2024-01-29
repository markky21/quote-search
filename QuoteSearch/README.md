## About this project

The Quote Search application is a C# project that allows users to search for quotes. It uses the .NET framework and is
structured following the principles of Object-Oriented Programming (OOP). The application is designed with a focus on
separation of concerns, as evidenced by the distinct layers for user interaction, business logic, and data access.

## Technologies and patterns

The application uses the following technologies and patterns:

1. C#: The primary programming language used in the application.
2. .NET Framework: The application is built on the .NET framework, which provides a comprehensive and consistent
   programming model for building applications.
3. Moq: This is a popular mocking framework for .NET. It's used in the application for creating mock objects in unit
   tests, which helps isolate the code under test.
4. NUnit: This is the unit testing framework used in the application. It's a widely-used tool in the .NET ecosystem for
   writing and running tests.
5. Facade Pattern: The application uses the Facade pattern to provide a simplified interface to a complex subsystem. An
   example of this is the IConsole interface and its implementation ConsoleFacade, which abstracts the console
   operations.
6. Dependency Injection (DI): The application uses DI to manage dependencies between objects, which promotes loose
   coupling and enhances testability. This is evident in how dependencies are passed into constructors, such as in the
   ConsoleUserInteractor class.
7. Test-Driven Development (TDD): The application appears to follow the TDD approach, as indicated by the comprehensive
   suite of tests. This includes tests for validating user input and ensuring correct application behavior.
