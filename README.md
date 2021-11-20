# NewsBlogProject
### In this project,I will create a NewsBlog by using Model View Controller design in .NetCore.  AppUser can add İmage and automatically ImageResizer will cropted image . 
The project have mapping operation. I combined DTO property and object property with mapping operaiton.  
<br> Before  We  moved All data  to memory in ASP.net but We only move what we need. (Eager Loading). We use expression which  can be provide flexible filter  and selector which  can be show  what we want . I made class for selector. If Requestor want to see list, selector have this property. 

# What is Asp.Netcore?
### ASP.NET Core is the open-source version of ASP.NET, that runs on macOS, Linux, and Windows. 
## The Startup class is the starting point for .NET Core projects
![image](https://user-images.githubusercontent.com/90280719/142729969-1308907e-1e6c-47c9-b967-85763567ccff.png)

# What is Depency Injection?
### Dependency Injection (DI) is a DIP confirming design pattern used to implement IoC. It allows the creation of dependent objects outside of a class and provides those objects to a class through different ways. Using DI, we move the creation and binding of the dependent objects outside of the class that depends on them.
### <br> There are 3 different lifecycles in DI;
### <br> 1-AddSingleton:It uses the same intance generated in incoming requests.
### <br> 2-AddScoped:It created an instance for each incoming  request.
### <br> 3-AddTransient:It is created new instance for each service request.


# What is IOC(Inversion Of Control)?
### It is a software development principle that aims to create loosely coupled objects.When interface is injected into the class using IoC,Interface's method can be usable.
##    What is Ioc Container? 
#### It is a framework that allows to manage dependency injection.It is the process of managing the lifecycle of objects. It provide to create object inside ConfigureServiceMethod in Start-up class


<br> ![image](https://user-images.githubusercontent.com/90280719/142729926-bcf0bac1-1080-45fb-8b40-6471443ca6d9.png)

# What is AutoMapper?
### AutoMapper is a simple C# library that transforms one object type to another object type, which means, it’s a mapper between two objects. It maps the properties of two different objects by transforming the input object of one type to the output object of another type.
