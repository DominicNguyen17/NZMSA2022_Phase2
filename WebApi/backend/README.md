# Backend Notes
## Configuration
Configuration in my project is performed using settings files (appsettings.json and appsettings.Development.json). The configuration is used to make one or
more environments such as Development, Production or Testing environments and in those environments I can add your own custom configuration sections. The
difference between the appsettings.json and appsettings.Development.json is in appsettings.Development.json, there are some my custom configuration sections and I
used those in the Startup.cs but in appsettings.json I do not have that sections.

## Dependency Injection(DI):
- MiddleWare Dependency Injection(DI) make the code more readable and testable. In my project, I created the some services class which are called in
controllers to create the object and I can use in those controllers and in the future, if I want fix bug or change my code, that make me easily to do that.
For example, I have created the UserSevices which implemented the interface IUserServices, and then I called the IUserServices to create
the object and I passed that object to the UsersController class through the constructor. That is called dependency injection.

## NUnit Test:
- I have create the expected user with the same value with the actual user and I create the controller to get user by Id from database. The test case is comparing
the actual user's name and the expected user's name. If those are same, the test case is passed, otherwise, it is failed.

## Middleware Libraries:
- Middleware is components of an application that handle requests and responses. The middleware is a pipeline that will make the code more readable and easier to maintain.
Because of that, the middleware make easier to find the bugs and easily fix that.