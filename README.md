# ArmPricing

**The Exercise**

For this exercise could you implement an MVC.NET Pricing query form in C#.     

The form should contain the following fields:
- First Name - Optional
- Last Name - Mandatory
- Email - Mandatory
- Address -Line 1, City, postcode and  Country mandatory
- Phone - Mandatory
- Products -  User should be able to select multiple products, selection of at least one product is mandatory

After form submission the following actions should happen:

1. Pricing query is registered to the database – they will also be retrieved for future reports.
2. Email sales team about the query.

A few pointers:

-  You should expect to spend no more than two or three hours on this challenge.
-  The code should be of 'production quality'. We will be looking for evidence that it's written to be flexible and maintainable.
-  Be sure to state (or comment) your assumptions.
-  This should be used as an opportunity to showcase your development approach.   

**Assumptions**

ASP.net MVC most likely with Razor as it is the most common tempting framework for asp.net
Asking for optional and mandatory fields so you expect validation, possibly implies a JS framework?
Entities would include:

* Customer
* ContactDetails
* Product
* PricingQuery, i.e., the sum query of all product prices

This entities would be saved to a DB most likely MSSQL as we are using Asp.net MVC but could easily be a document db or some other NoSql Db.

PricingQuery will consist of one or more Product (this will be a snapshot of the Product because features may change over time)
Customer will consist of one or more PricingQueries and ContactDetail

A service will be needed to handle the saving of the Customer, ContactDetails, Products and PricingQueries
A service will be needed to implement emailing

Maintainability: use cvs; Github, will also serve as a means to share the code. You are looking for Design Patterns (Gang of Four) to be employed, thinking SOLID, TDD etc., this will help to ensure the code is extensible and provides some level of security that if the code changes bugs won’t be introduced. Overall, keep it simple, ensure you only design what you need for now without prematurely optimising, which adds complexity and assumes a way forward that locks you into an approach that might not actually be correct.
