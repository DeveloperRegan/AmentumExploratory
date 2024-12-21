# Purpose

This is a test application used to help measure applicant skill and knowledge when working in a .NET environment.

Your job as the applicant is to add the requested features and resolve the bugs. 
While we are looking at the submitted project, we are also interested in your thought process.
Submitted feedback should include why you chose to implement the features and bugs in the methods you chose, along with any potential issues or improvements you might have noticed could be made within the codebase.

## Setup: 

This project uses a `MSSQL` database. If you do not have access to a `MSSQL` database, you can get a local version [here](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb).

We have used Entity Framework to setup migrations to get the database in a workable spot for you with some seed data to start this assessment. 

To initialize the database...
- Make sure the connection string in the appsettings.json is pointing to the database server you would prefer to work with (the current connection string should be set to a generic LocalDB instance).
- Open a Terminal and run the command `dotnet ef database update` from within the project directory.

## Submission

To submit your work, you need to create and upload your work to a public repository on Github. 
Feel free to make as many or few commits as necessary.

### Feature: Notification Service

Our users have shown a more positive reaction in the past when the sites we build have a way to notify them that an action taken was completed (successfully or not). 
In a rush to get this app completed, we forgot to implement UI notifications to alert our users in a manner that is consistent with the result of the action taken.
While we are working on implementing this feature we thought it would be a great time to use this implementation to also save text log files on our application server to refer to incase there is an error.

Task:
- Create and Implement a Notification Service that can send messages to the UI or a TextFile.
- Notifications need to be sent on success/failures when the /ContactForm form is submitted.
- Service needs to be easily extensible so we can add additional medium (API Endpoints, Email, etc...) through which the notifications can be sent in the future.
- Service needs to be written in a way that is testable, however we are not asking for you to implement your own tests in this instance. (Feel free to expand on how you would go about testing this in our discussions though!)
- Notification medium is decided when code is written, but can easily be swapped out should business requirements change.

### Feature: Lost CSS

Unfortunately after you just finished styling a wonderful page on Ed White and the Gemini 4 mission, all your changes for styling were lost due to a computer malfunction.

Task:
- Style the LostCSS page in a manner that mimics the following files:
	- requested_full.png
		- Default Layout
	- requested_mobile.png
		- Anything 440PX or Smaller
- All CSS must be hand coded. (No bootstrap or other css frameworks allowed!)
- Desired results can be created without altering the html.

### Bug: Faulty Logic

Our nifty contact list has a bug when attempting to filter the people in the list.
The contact list should be filtered via the reason and search text.
The search text needs to be a contains filter and searches both the name and email fields simultaneously.

### Bug: Failure To Load

Someone accidently merged their branch into yours and you received a new feature that hasn't been fully tested. 
Unfortunately your features and your coworker's feature have to be deployed for testing by the end of the day and your coworker is unavailable. (We will have a talk with them when they get back!)
Pages may or may not load initially and some navigation remains, but functionality has halted and fatal errors are being thrown. Find and solve the problem that is preventing the app from functioning properly.