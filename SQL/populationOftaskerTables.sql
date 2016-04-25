/*
	Name: Tables Creation
	For:  Taskr
	Date: 2016-03-23
	By:   Kovacs Gyorgy & Bolboaca Ramona
	
	Notes: La mine baza de date se numea `test`, deci daca
	la tine difera numele, nu uita sa il schimbi.
	
	
	DEFAULT_TEXT = ...
	DEFAULT_ID   = 0
	DEFAULT_DATE = 1970/1/1
	
*/

-- Seamana foarte mult cu users, oare nu le unim?
-- Si secretara poate sa plece, poate ar trebui sa pun
-- si DateLeft etc... cum spui tu.
CREATE TABLE `test`.`secretary` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`FirstName` TEXT NOT NULL,
	`LastName` TEXT NOT NULL,
	`DisplayName` TEXT NOT NULL,
	`AvatarLink` TEXT NOT NULL, 
	`Email` TEXT NOT NULL,
	`PasswordHash` TEXT NOT NULL,
	`PhoneNumber` TEXT NOT NULL,
	`JoinDate` DATE NOT NULL,
	`Status` TEXT NOT NULL,
	`PersonalNotes` TEXT NOT NULL,
	`LeaveDate` DATE NOT NULL,
 	`ReasonForLeaving` TEXT NOT NULL,
 	`RejoinDesirability` TEXT NOT NULL,
 	`Observations` TEXT NOT NULL,
	PRIMARY KEY (`Id`)
);

-- Am unit former users cu users, ca nu difera prea mult
CREATE TABLE `test`.`users` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`FirstName` TEXT NOT NULL,
	`LastName` TEXT NOT NULL,
	`DisplayName` TEXT NOT NULL,
	`AvatarLink` TEXT NOT NULL,
	`Email` TEXT NOT NULL,
	`PasswordHash` TEXT NOT NULL,
	`PhoneNumber` TEXT NOT NULL,
	`JoinDate` DATE NOT NULL,
	`AddedBy` INT NOT NULL,
	`ActiveProject` INT NOT NULL,
	`ActiveTask` INT NOT NULL,
	`WorkStatus` TEXT NOT NULL,
	`PersonalNotes` TEXT NOT NULL,
	`LeaveDate` DATE NOT NULL,
	`ReasonForLeaving` TEXT NOT NULL,
	`RejoinDesirability` TEXT NOT NULL,
	`Observations` TEXT NOT NULL,
	PRIMARY KEY (`Id`)
);

CREATE TABLE `test`.`projectSuggestions` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Title` TEXT NOT NULL,
	`ShortDescription` TEXT NOT NULL,
	`DetailedDescription` TEXT NOT NULL,	
	`CreatedBy` INT NOT NULL,
	`DateCreated` DATE NOT NULL,
	`InvestmentRequired` TEXT NOT NULL,
	`EstimatedReturn` TEXT NOT NULL,
	`Priority` TEXT NOT NULL,
	`Notes` TEXT NOT NULL,
	PRIMARY KEY (`Id`)
);

-- Am unit asta cu archived projects
CREATE TABLE `test`.`projects` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`Title` TEXT NOT NULL,
	`ShortDescription` TEXT NOT NULL,
	`DetailedDescription` TEXT NOT NULL,
	`CreatedBy` INT NOT NULL,
	`ProjectLead` INT NOT NULL,
	`DateCreated` DATE NOT NULL,
	`ModificationLogLink` TEXT NOT NULL,
	`Notes` TEXT NOT NULL,
	`AvailableFunds` TEXT NOT NULL,
	`CurrentYield` TEXT NOT NULL,
	`DateTerminated` DATE NOT NULL,
	`TerminationReason` TEXT NOT NULL,
	`TerminatedBy` INT NOT NULL,
	`CollectedFunds` TEXT NOT NULL,
	`ConsumedFunds` TEXT NOT NULL,
	PRIMARY KEY (`Id`)
);

CREATE TABLE `test`.`tasks` (
	`Id` INT NOT NULL AUTO_INCREMENT,
	`ParentId` INT NOT NULL,
	`Title` TEXT NOT NULL,
	`ShortDescription` TEXT NOT NULL,
	`DetailedDescription` TEXT NOT NULL,
	`ParentProject` INT NOT NULL,
	`DateCreated` DATE NOT NULL,
	`CreatedBy` INT NOT NULL,
	`DateCompleted` DATE NOT NULL,
	`CompletedBy` INT NOT NULL,
	`DeadLine` DATE NOT NULL,
	`Status` TEXT NOT NULL,
	PRIMARY KEY (`Id`)
);

-- These two tables will store the requests from users to join a project
-- or accept a task.
CREATE TABLE `test`.`projectrequests` (
  `user_id` INT NOT NULL,
  `project_id` INT NOT NULL
);

CREATE TABLE `test`.`taskrequests` (
  `user_id` INT NOT NULL,
  `task_id` INT NOT NULL
);

-- Insert Users
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Kovacs', 'Gyorgy', 'Gyuri', 'http://static.comicvine.com/uploads/original/11116/111161618/4098751-6726721977-621px.png', 'georgesmth202@gmail.com', 'password', '0742773469', '2016-04-22', '1', '0', '0', 'On Vacation', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Ardeleanu', 'Mircea', 'Mircea', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'ardeleanu.mircea@gmail.com', 'passwordmircea1', '0745692145', '2013-05-15', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Badea', 'Nicolae', 'Nicu', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'badea.nicolae@gmail.com', 'passwordnicolae2', '0741258745', '2012-07-14', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Baltag ', 'Octavian', 'Tavi', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'baltag.octavian@gmail.com', 'passwordoctavion3', '0741857457', '2014-09-13', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Coanda', 'George', 'George', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'coandageorge@gmail.com', 'passwordgeorge4', '0748978521', '2012-08-15', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Darie', 'Emanuel', 'Manu', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'darie.emanuel@gmail.com', 'passwordemanuel5', '0741288793', '2012-09-14', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Enache', 'Sorin', 'Soso', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'enache.sorin@gmail.com', 'passwordsorin6', '0721473698', '2015-03-16', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Gheorghe ', 'Daniel', 'Dani', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'gheorghe.daniel@gmail.com', 'passworddaniel7', '0723698741', '2015-07-13', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Jurca', 'Traian', 'Traian', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'jurca.traian@gmail.com', 'passwordtraian8', '0752142365', '2014-09-15', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Lascu', 'Dan', 'Dan', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'lascu.dan@gmail.com', 'passworddan9', '0721212585', '2013-04-13', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Lunca', 'Eduard', 'Edi', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'lunca.eduard@gmail.com', 'passwordlunca10', '0758787414', '2011-07-15', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Morariu', 'Simona', 'Simona', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'morariu.simona@gmail.com', 'passwordsimona11', '0758463881', '2013-07-14', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Munteanu', 'Teodora', 'Teo', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'munteanu.teodora@gmail.com', 'passwordteodora12', '0723469712', '2010-04-15', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Oltean', 'Maria', 'Maria', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'oltean.maria@gmail.com', 'passwordmaria13', '0721469734', '2012-10-14', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Pop', 'Dorina', 'Dorina', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'pop.dorina@gmail.com', 'passworddorina14', '0745312711', '2013-03-15', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Popa', 'Cristina', 'Cristina', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'popa.cristina@gmail.com', 'passwordcristina15', '0754221378', '2014-08-14', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Popescu ', 'Elena', 'Elena', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'popescu.elena@gmail.com', 'passwordelena16', '0754333121', '2012-03-16', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Rab', 'Laura', 'Laura', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'rab.laura@gmail.com', 'passwordlaura17', '0724667273', '2014-08-14', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Salceanu', 'Alexandra', 'Alexandra', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'salceanu.alexandra@gmail.com', 'passwordalexandra18', '0724671131', '2012-01-02', '1', '0', '0', 'On Vacation', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Stanescu', 'Ioana', 'Ioana', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'stanesc.ioana@gmail.com', 'passwordioana19', '0753336724', '2011-10-12', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Ursea', 'Mirela', 'Mirela', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'ursea.mirela@gmail.com', 'passwordmirela20', '0745747641', '2016-01-01', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Abrudan', 'Emilia', 'Emi', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'abrudan.emilia@gmail.com', 'passwordemilia21', '0725836144', '2007-05-02', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Morar', 'Elizabeta', 'Liza', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'morar.elizabeta@gmail.com', 'passwordelizabeta22', '0752221436', '2011-11-22', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Popescu', 'Andrei', 'Andrei', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'popescu.andrei@gmail.com', 'passwordandrei23', '0752551435', '2016-04-01', '1', '0', '0', 'Available', '-', '1970/01/01', '-', '-', '-');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Maris', 'Denisa', 'Deni', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'maris.denisa@gmail.com', 'passworddenisa24', '0725699696', '2011-04-22', '1', '0', '0', 'Not Available', '-', '2016/03/20', 'Found another job', 'Low', 'Good employee');
INSERT INTO `test`.`users` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `AddedBy`, `ActiveProject`, `ActiveTask`, `WorkStatus`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Oltean', 'Adina', 'Adina', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'oltean.adina@gmail.com', 'passwordadina25', '0754412474', '2013-04-22', '1', '0', '0', 'Not Available', '-', '2016/02/25', 'Found another job', 'Low', 'Smart and good employee');

-- Insert Projects
INSERT INTO `test`.`projects` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`, `Notes`, `AvailableFunds`, `CurrentYield`, `DateTerminated`, `TerminationReason`, `TerminatedBy`, `CollectedFunds`, `ConsumedFunds`) VALUES ('Taskr', 'A Project Management Application', 'Too tired to write something here.', '1', '1', '2016/04/22', 'Link Goes Here', 'Fun...', '-', '-', '1970/01/01', '-', '0', '-', '-');
INSERT INTO `test`.`projects` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`, `Notes`, `AvailableFunds`, `CurrentYield`, `DateTerminated`, `TerminationReason`, `TerminatedBy`, `CollectedFunds`, `ConsumedFunds`) VALUES ('Trakr', 'Vehicle Tracking Using Driver Mobile Gps Tracking', 'This system will track location of the vehicle and will send details about the location to the admin. This system helps admin to find out the location of the driver driving the vehicle. Admin will know which driver is in which location. ', '2', '2', '2013/05/20', 'http://nevonprojects.com/vehicle-tracking-using-driver-mobile-gps-tracking/', 'Fun...', '-', '-', '1970/01/01', '-', '0', '-', '-');
INSERT INTO `test`.`projects` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`, `Notes`, `AvailableFunds`, `CurrentYield`, `DateTerminated`, `TerminationReason`, `TerminatedBy`, `CollectedFunds`, `ConsumedFunds`) VALUES ('Fingerprintr', 'Fingerprint Based ATM System', 'Fingerprint Based ATM is a desktop application where fingerprint of the user is used as a authentication. The finger print minutiae features are different for each human being so the user can be identified uniquely.', '4', '4', '2012/08/20', 'http://nevonprojects.com/fingerprint-based-atm-system/', 'Fun...', '-', '-', '1970/01/01', '-', '0', '-', '-');
INSERT INTO `test`.`projects` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`, `Notes`, `AvailableFunds`, `CurrentYield`, `DateTerminated`, `TerminationReason`, `TerminatedBy`, `CollectedFunds`, `ConsumedFunds`) VALUES ('Trakr', 'Android Employee Tracker', 'This system is a combination of web as well as android application where the user will be using the android application and admin as well as HR will work with web application. This application is meant for field work Employers.', '19', '19', '2012-03-20', 'http://nevonprojects.com/android-employee-tracker/', 'Fun...', '-', '-', '1970/01/01', '-', '0', '-', '-');
INSERT INTO `test`.`projects` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`, `Notes`, `AvailableFunds`, `CurrentYield`, `DateTerminated`, `TerminationReason`, `TerminatedBy`, `CollectedFunds`, `ConsumedFunds`) VALUES ('ProductRatr', 'Sentiment Analysis for Product Rating', 'Here we propose an advanced Sentiment Analysis for Product Rating system that detects hidden sentiments in comments and rates the product accordingly. The system uses sentiment analysis methodology in order to achieve desired functionality.', '17', '17', '2014-04-15', 'http://nevonprojects.com/sentiment-analysis-for-product-rating/', 'Fun...', '-', '-', '1970/01/01', '-', '0', '-', '-');
INSERT INTO `test`.`projects` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`, `Notes`, `AvailableFunds`, `CurrentYield`, `DateTerminated`, `TerminationReason`, `TerminatedBy`, `CollectedFunds`, `ConsumedFunds`) VALUES ('Managementr', 'Android Customer Relationship Management System', 'Customer relationship management (CRM) is a system for managing a company’s interactions with current and future customers. It often involves using technology to organize, automate, and synchronize sales.', '12', '12', '2014-07-13', 'http://nevonprojects.com/android-customer-relationship-management-system/', 'Fun...', '-', '-', '1970/01/01', '-', '0', '-', '-');
INSERT INTO `test`.`projects` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `ProjectLead`, `DateCreated`, `ModificationLogLink`, `Notes`, `AvailableFunds`, `CurrentYield`, `DateTerminated`, `TerminationReason`, `TerminatedBy`, `CollectedFunds`, `ConsumedFunds`) VALUES ('DataMinr', 'Real Estate Search Based On Data Mining', 'This project helps the users to make good decisions regarding buying or selling of valuable property. Prior to this online system this process involved a lot of travelling costs and searching time.', '20', '20', '2015-08-08', 'http://nevonprojects.com/real-estate-search-based-on-data-mining/', 'Fun...', '-', '-', '1970/01/01', '-', '0', '-', '-');

-- Insert ProjectSuggestions
INSERT INTO `test`.`projectsuggestions` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `DateCreated`, `InvestmentRequired`, `EstimatedReturn`, `Priority`, `Notes`) VALUES ('Online Herbs Shopping', 'This project helps the users in curing its disease by giving the list of fruits and herbs that the user should consume in order to get rid of its disease.', 'http://nevonprojects.com/online-herbs-shopping/', '15', '16-03-03', '5000', '7500', '1', '-');
INSERT INTO `test`.`projectsuggestions` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `DateCreated`, `InvestmentRequired`, `EstimatedReturn`, `Priority`, `Notes`) VALUES ('Hotel Management Android Project', 'The regular hotel management system project entirely in an android app. This android application allows the hotel manager to handle all hotel activities in his android phone.', 'http://nevonprojects.com/hotel-management-android/', '21', '16-03-01', '8000', '1000', '1','-');
INSERT INTO `test`.`projectsuggestions` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `DateCreated`, `InvestmentRequired`, `EstimatedReturn`, `Priority`, `Notes`) VALUES ('Efficient Doctor Patient Portal', 'We here propose a doctor patient handling, managing system that helps doctors in their work and also patients to book doctor appointments and view medical progress. The system allows doctors to manage their booking slots online.', 'http://nevonprojects.com/efficient-doctor-patient-portal/', '22', '16-03-16', '10000', '13000', '1', '-');
INSERT INTO `test`.`projectsuggestions` (`Title`, `ShortDescription`, `DetailedDescription`, `CreatedBy`, `DateCreated`, `InvestmentRequired`, `EstimatedReturn`, `Priority`, `Notes`) VALUES ('Android Local Train Ticketing Project', 'A local train ticketing system project for local trains that allows users to book local train tickets and get ticket receipt online. This local train project provides login rights for normal users and admin. ', 'http://nevonprojects.com/android-local-train-ticketing-project/', '23', '16-03-17', '11000', '14000', '1', '-');

-- Insert Secretaries
INSERT INTO `test`.`secretary` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `Status`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Ramona', 'Bolboaca', 'Ramona', 'http://weknowyourdreamz.com/image.php?pic=/images/beet/beet-21.jpg', 'ramona@gmail.com', 'I Love Github', '074666666', '2016-04-22', 'Available', '-', '1970/1/1', '-', '-', '-');
INSERT INTO `test`.`secretary` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `Status`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Pop', 'Diana', 'Diana', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'pop.diana@gmail.com', 'passworddiana1', '0741221148', '2012-06-06', 'Available', '-', '1970/1/1', '-', '-', '-');
INSERT INTO `test`.`secretary` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `Status`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Mihailescu', 'Irina', 'Irina', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'mihailescu.irina@gmail.com', 'passwordirina2', '0723365852', '2012-03-04', 'Available', '-', '1970/1/1', '-', '-', '-');
INSERT INTO `test`.`secretary` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `Status`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Zelea', 'Ana-Maria', 'Ana-Maria', 'http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif', 'zelea.anamaria@gmail.com', 'passwordanamaria3', '0758885423', '2012-05-20', 'Available', '-', '1970/1/1', '-', '-', '-');
INSERT INTO `test`.`secretary` (`FirstName`, `LastName`, `DisplayName`, `AvatarLink`, `Email`, `PasswordHash`, `PhoneNumber`, `JoinDate`, `Status`, `PersonalNotes`, `LeaveDate`, `ReasonForLeaving`, `RejoinDesirability`, `Observations`) VALUES ('Tusca', 'Florin', 'Florin', 'http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg', 'tusca.florin@gmail.com', 'passwordflorin4', '0723665478', '2011-05-04', 'Available', '-', '1970/1/1', '-', '-', '-');

-- Insert Tasks
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Make Inserts Work', 'Make Inserts Work', '...', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title1', 'Make the login user interface and the connection to the database.', '...', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title2', 'Track the user’s location', 'Track the user’s location with the help of GPS and send this detail to admin.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title3', 'Make and graphical interface in order to view the location of the driver driving the vehicle.', 'Make and graphical interface in order to view the location of the driver driving the vehicle','1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title4', 'Login', 'User will login to the system using his fingerprint.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title5', 'Add Pin Code', ' User has to scan finger and add pin code in order to do transactions.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title6', 'Withdrawal of cash', 'User can withdraw cash by entering the amount he want to withdraw.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title7', 'Transfer of Money', 'User can transfer cash to other accounts by entering the account number he wants to transfer.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title8', 'Login', 'Make the login user interface and the connection to the database.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title9', 'Track the user’s location', 'Track the user’s location with the help of GPS and send this detail to admin.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title10', 'View the location of the employee', 'Make and graphical interface in order to view the location of the employee.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title11', 'Create database', ' Create a database of sentiment based keywords along with positivity or negativity weight in database', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title12', 'Rank user comment', 'Based on the sentiment keywords from the database the user comment needs to be ranked. ', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title13', 'Rate the product', 'Rate the product based on the data recieved from the users comments.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title14', 'Create employee database and add new employees', 'Create the database with the specific tablles and fields. Add new employees by filling employee details and will provide identity number and password to the employee to access the system.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title15', 'Login', 'Make the login user interface and the connection to the database.When employee login to the system he will get email about the meetings that is going to be held on next day with the lead.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title16', 'Dashboard', 'User will be redirected to dashboard where he will get to know about number of leads he had converted and number of leads he had not converted.User will also get to know about profit and loss amount in the dashboard, based on number of leads he had converted.',  '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title17', 'Meetings options', 'Employee can fix meeting with customer by specifying the meeting topic and description about the meeting. User can view meeting that is going to be held. User can also view the topic and description about the meeting. User can send SMS and E-mail to the customers.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title18', 'Create the estate database', 'Property details like Address, space measurement(sq ft), number of BHKs, Floor, Property Seller name and its contact number plus email-id. ', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title19', 'Search option', 'The user can search property depending on the area that it wants in, number of wash rooms, bedrooms, halls and kitchen.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');
INSERT INTO `test`.`tasks` (`ParentId`, `Title`, `ShortDescription`, `DetailedDescription`, `ParentProject`, `DateCreated`, `CreatedBy`, `DateCompleted`, `CompletedBy`, `DeadLine`, `Status`) VALUES ('0', 'Title20', 'Loan algorithm', 'An algorithm that calculates loan that the user can take plus 20%-30% cash that the user has to pay.', '1', '2016/04/22', '1', '2016/04/22', '1', '2016/04/24', 'Completed');



