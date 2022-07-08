# ModelTrainWebApp

Developed by Chris Broughton  
Code Louisvile  
Software Development 2 (C# .NET MVC)  
May 2022 Cohort  

## C# MVC Web App for Model Railroad Clubs and Events

The Model Train Web App is an app for model railroad enthusiasts interested in local clubs and events. The app utilizes MVC, Entity Framework, C#, .NET, and SQL, as well as some basic HTML and CSS. It also utilizes a Cloudinary .NET package to allow adding/deleting/viewing photos associated with each club or event. 

The app allows a user to add, view, edit, and delete information on model train-related clubs and events. For clubs, a user can provide club name, description, address, email address, website, the type of club, and an image/logo. For events, a user can provide the event name, description, start date and time, the location (address) of the event, the organizer's email address, and an image/logo for the event. 

## Required Features:

- A Readme file (this file)
- You must create at least one class, then create at least one object of that class and populate it with data. You must use or display the data in your application
- Create and call at least 3 functions or methods, at least one of which must return a value that is used in your application

## Feature List:

- Create an additional class which inherits one or more properties from its parent
- Implement a regular expression (regex) to ensure a field (email address) is always stored and displayed in the same format
- Read data from an external file, such as text, JSON, CSV, etc (*in this case, a SQL Database*) and use that data in your application
- Visualize data in a graph, chart, or other visual representation of data (*database data is displayed in rows & columns and on pages*)

## Ideas For Future Enhancement:

- Add Identity Framework to allow creating individual user and admin accounts  
- Add a geo-location feature to allow searching for clubs and events by a user's location, distance, or radius  
- Different security levels for accounts, such as basic user (read only) and editor / admin access for adding, editing, and deleting information  
- Auto-delete feature for events after some period of time after the event date. 

    