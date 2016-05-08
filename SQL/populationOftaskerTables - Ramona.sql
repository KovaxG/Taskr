/*
	Name: Tables Creation
	For:  Taskr
	Date: 2016-03-23
	By:   Kovacs Gyorgy & Bolboaca Ramona
	
	Notes: La mine baza de date se numea `database`, deci daca
	la tine difera numele, nu uita sa il schimbi.
	
	Nimic nu poate fi NULL!!!
	
	DEFAULT_TEXT = '-'
	DEFAULT_ID   = 0
	DEFAULT_DATE = 1970/1/1
	
*/

-- Seamana foarte mult cu users, oare nu le unim?
-- Si secretara poate sa plece, poate ar trebui sa pun
-- si DateLeft etc... cum spui tu.
CREATE TABLE `database`.`secretary` (
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
CREATE TABLE `database`.`users` (
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

CREATE TABLE `database`.`projectSuggestions` (
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
	`ImageURL` TEXT NOT NULL,
	PRIMARY KEY (`Id`)
);

-- Am unit asta cu archived projects
CREATE TABLE `database`.`projects` (
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
	`ImageURL` TEXT NOT NULL,
	PRIMARY KEY (`Id`)
);

CREATE TABLE `database`.`tasks` (
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
	`Notes` TEXT NOT NULL,
	`ImageURL` TEXT NOT NULL,
	PRIMARY KEY (`Id`)
);

-- These two tables will store the requests from users to join a project
-- or accept a task.
CREATE TABLE `database`.`projectrequests` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `project_id` INT NOT NULL,
  PRIMARY KEY (`Id`)
);

CREATE TABLE `database`.`taskrequests` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `task_id` INT NOT NULL,
  PRIMARY KEY (`Id`)
);
  
-- Insert Secretaries
INSERT INTO `database`.`secretary` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`Status`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (1,'Ramona','Bolboaca','Ramona','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','ramona.bolboaca@gmail.com','Z,£º¯ @+â§P@','0746666666','2007-05-02','Day off','Tell Diana about the new employee.','1970-01-01','-','-','-');
INSERT INTO `database`.`secretary` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`Status`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (2,'Pop','Diana','Diana','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','pop.diana@gmail.com','à ¬ÜÀ`$`ÌÐ¼@À','0741221148','2012-06-06','Working','-','1970-01-01','-','-','-');
INSERT INTO `database`.`secretary` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`Status`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (3,'Mihailescu','Irina','Irina','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','mihailescu.irina@gmail.com','Ä¤Hô$VrôDÔ4@','0723365852','2012-03-04','Not Available','-','2016-05-06','Retired','Low','Good employee and good SQL  trainer');
INSERT INTO `database`.`secretary` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`Status`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (4,'Zelea','Anamaria','Anamaria','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','zelea.anamaria@gmail.com','¼ 6ðÙ¾`Îø¡','0758885423','2012-05-20','Not Available','-','2016-05-07','Found another job','Low','Good employee');
INSERT INTO `database`.`secretary` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`Status`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (5,'Tusca','Florin','Florin','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','tusca.florin@gmail.com','Ä\Zpfç¾Z0¦Æç~','0723665478','2011-05-04','Available','Fire Popescu Andrei.','1970-01-01','-','-','-');

  
-- Insert Users
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (1,'Kovacs','Gyorgy','Gyuri','http://static.comicvine.com/uploads/original/11116/111161618/4098751-6726721977-621px.png','georgesmth202@gmail.com','b°.À­z´Ü0ò`','0742773469','2016-04-22',2,0,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (2,'Ardeleanu','Mircea','Mircea','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','ardeleanu.mircea@gmail.com','çÀçççç@çÀçççç@','0745692145','2013-05-15',3,1,0,'Day off','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (3,'Badea','Nicolae','Nicu','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','badea.nicolae@gmail.com',':jD@0ìÊÚÔ °','0741258745','2012-07-14',5,1,0,'Not Available','-','2016-04-08','Medical problems','Medium','Went abroad to get treatment for his illness.');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (4,'Baltag ','Octavian','Tavi','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','baltag.octavian@gmail.com','TøxàgD*8P8p','0741857457','2012-03-13',4,2,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (5,'Coanda','George','George','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','coandageorge@gmail.com','p`à`8ç¸°` Øàøçx','0748978521','2012-08-15',5,2,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (6,'Darie','Emanuel','Manu','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','darie.emanuel@gmail.com','ççççÀç@ççççÀç@','0741288793','2012-09-14',1,2,4,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (7,'Enache','Sorin','Soso','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','enache.sorin@gmail.com','þLåüÀæÄl4`','0721473698','2015-03-16',2,3,0,'Working','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (8,'Gheorghe ','Daniel','Dani','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','gheorghe.daniel@gmail.com','ìî4X< ü0¸s','0723698741','2015-07-13',3,3,9,'Holiday','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (9,'Jurca','Avram','Avram','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','jurca.traian@gmail.com','ÔØÐä¦ ¼ÄØPôÖ','0752142365','2014-09-15',4,2,6,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (10,'Lascu','Dan','Dan','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','lascu.dan@gmail.com','Ø2ðþÚÀÆøPNøªàö','0721212585','2013-04-13',2,1,2,'Working','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (11,'Lunca','Eduard','Edi','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','lunca.eduard@gmail.com','6|ôxÀ¬>Ü¬ÔX-à','0758787414','2011-07-15',5,1,0,'Day off','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (12,'Morariu','Simona','Simona','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','morariu.simona@gmail.com','àNçôÄÀ`ò`þçÔTÀp','0758463881','2013-07-14',3,5,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (13,'Munteanu','Teodora','Teo','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','munteanu.teodora@gmail.com','&>\"\ZV nn,ÒÂ','0723469712','2010-04-15',1,5,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (14,'Oltean','Maria','Maria','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','oltean.maria@gmail.com','ç#H1Ü¥ïçÛÌMÀg','0721469734','2012-10-14',5,2,0,'Not Available','-','2016-05-08','Got married and moved to another country','Low','Good exmployee.');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (15,'Pop','Dorina','Dorina','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','pop.dorina@gmail.com','hðØÀ`è¨P,8là`','0745312711','2013-03-15',4,3,0,'Day off','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (16,'Popa','Cristina','Cristina','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','popa.cristina@gmail.com','@<ØP@ô@üÜ8Ð ','0754221378','2014-08-14',2,5,0,'Sick','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (17,'Popescu ','Elena','Elena','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','popescu.elena@gmail.com','8ð0XìØp¸L@<','0754333121','2012-03-16',5,0,0,'Day off','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (18,'Rab','Laura','Laura','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','rab.laura@gmail.com',' l`¤°TP L pôÀÐ','0724667273','2014-08-14',3,1,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (19,'Salceanu','Alexandra','Alexandra','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','salceanu.alexandra@gmail.com','N¡Ü·(O°uvôÈG','0724671131','2012-01-02',5,3,0,'Holiday','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (20,'Stanescu','Ioana','Ioana','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','stanesc.ioana@gmail.com','ä°AÐW0NX¾','0753336724','2011-10-12',1,0,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (21,'Ursea','Mirela','Mirela','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','ursea.mirela@gmail.com','ò¸ë¨ÏpZÊx3HÇ¸*','0745747641','2016-01-01',4,2,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (22,'Abrudan','Emilia','Emi','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','abrudan.emilia@gmail.com','êäb nèz°tò0^','0725836144','2007-05-02',1,3,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (23,'Morar','Elizabeta','Liza','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','morar.elizabeta@gmail.com','!Ü#ðØN	ôé®»x','0752221436','2011-11-22',1,0,0,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (24,'Popescu','Andrei','Andrei','http://www.finearttips.com/wp-content/uploads/2010/05/avatar.jpg','popescu.andrei@gmail.com','¨ ´T ôb`$ À','0752551435','2016-04-01',2,5,17,'Available','-','1970-01-01','-','-','-');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (25,'Maris','Denisa','Deni','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','maris.denisa@gmail.com','passworddenisa24','0725699696','2011-04-22',1,0,0,'Not Available','-','2016-03-20','Found another job','Low','Good employee');
INSERT INTO `database`.`users` (`Id`,`FirstName`,`LastName`,`DisplayName`,`AvatarLink`,`Email`,`PasswordHash`,`PhoneNumber`,`JoinDate`,`AddedBy`,`ActiveProject`,`ActiveTask`,`WorkStatus`,`PersonalNotes`,`LeaveDate`,`ReasonForLeaving`,`RejoinDesirability`,`Observations`) VALUES (26,'Oltean','Adina','Adina','http://www.telekyoto.web.auth.gr/images/Avatar_woman.gif','oltean.adina@gmail.com','passwordadina25','0754412474','2013-04-22',3,0,0,'Not Available','-','2016-02-25','Found another job','Low','Smart and good employee');

-- Insert Projects
INSERT INTO `database`.`projects` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`ProjectLead`,`DateCreated`,`ModificationLogLink`,`Notes`,`AvailableFunds`,`CurrentYield`,`DateTerminated`,`TerminationReason`,`TerminatedBy`,`CollectedFunds`,`ConsumedFunds`,`ImageURL`) VALUES (1,'Vehicle Tracking','Vehicle Tracking Using Driver Mobile Gps Tracking','This system will track location of the vehicle and will send details about the location to the admin. This system helps admin to find out the location of the driver driving the vehicle. Admin will know which driver is in which location. ',2,2,'2013-05-20','http://nevonprojects.com/vehicle-tracking-using-driver-mobile-gps-tracking/','-','20000','2.3%','1970-01-01','-',0,'-','-','http://www.solutionsunlimited.co.ke/wp-content/uploads/2016/04/vehicle-tracking1.jpg');
INSERT INTO `database`.`projects` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`ProjectLead`,`DateCreated`,`ModificationLogLink`,`Notes`,`AvailableFunds`,`CurrentYield`,`DateTerminated`,`TerminationReason`,`TerminatedBy`,`CollectedFunds`,`ConsumedFunds`,`ImageURL`) VALUES (2,'Smart ATM','Fingerprint Based ATM System','Fingerprint Based ATM is a desktop application where fingerprint of the user is used as a authentication. The finger print minutiae features are different for each human being so the user can be identified uniquely.',4,4,'2012-08-20','http://nevonprojects.com/fingerprint-based-atm-system/','-','30000','2.4%','1970-01-01','-',0,'-','-','https://i.ytimg.com/vi/QN6bbLiA6Io/maxresdefault.jpg');
INSERT INTO `database`.`projects` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`ProjectLead`,`DateCreated`,`ModificationLogLink`,`Notes`,`AvailableFunds`,`CurrentYield`,`DateTerminated`,`TerminationReason`,`TerminatedBy`,`CollectedFunds`,`ConsumedFunds`,`ImageURL`) VALUES (3,'Employee Tracker','Android Employee Tracker','This system is a combination of web as well as android application where the user will be using the android application and admin as well as HR will work with web application. This application is meant for field work Employers.',19,19,'2012-03-20','http://nevonprojects.com/android-employee-tracker/','-','18000','2.1%','1970-01-01','-',0,'-','-','http://www.phonesheriff.com/images/lndg/employee-mobile-tracking.png');
INSERT INTO `database`.`projects` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`ProjectLead`,`DateCreated`,`ModificationLogLink`,`Notes`,`AvailableFunds`,`CurrentYield`,`DateTerminated`,`TerminationReason`,`TerminatedBy`,`CollectedFunds`,`ConsumedFunds`,`ImageURL`) VALUES (4,'Product Rating','Sentiment Analysis for Product Rating','Here we propose an advanced Sentiment Analysis for Product Rating system that detects hidden sentiments in comments and rates the product accordingly. The system uses sentiment analysis methodology in order to achieve desired functionality.',17,17,'2014-04-15','http://nevonprojects.com/sentiment-analysis-for-product-rating/','If more funds are received, project can be finished.','12000','1.9%','2016-05-01','Not enough funds',17,'0','12000','http://www.smashstack.com/articles/wp-content/uploads/2015/07/star-rating-676x507.jpg');
INSERT INTO `database`.`projects` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`ProjectLead`,`DateCreated`,`ModificationLogLink`,`Notes`,`AvailableFunds`,`CurrentYield`,`DateTerminated`,`TerminationReason`,`TerminatedBy`,`CollectedFunds`,`ConsumedFunds`,`ImageURL`) VALUES (5,'Customer Relationship Management','Android Customer Relationship Management System','Customer relationship management (CRM) is a system for managing a company’s interactions with current and future customers. It often involves using technology to organize, automate, and synchronize sales.',12,12,'2014-07-13','http://nevonprojects.com/android-customer-relationship-management-system/','-','18000','3%','1970-01-01','-',0,'-','-','http://infoglobaltech.com/wp-content/uploads/2013/08/shutterstock_CRM.jpg');
INSERT INTO `database`.`projects` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`ProjectLead`,`DateCreated`,`ModificationLogLink`,`Notes`,`AvailableFunds`,`CurrentYield`,`DateTerminated`,`TerminationReason`,`TerminatedBy`,`CollectedFunds`,`ConsumedFunds`,`ImageURL`) VALUES (6,'Find Real Estate','Real Estate Search Based On Data Mining','This project helps the users to make good decisions regarding buying or selling of valuable property. Prior to this online system this process involved a lot of travelling costs and searching time.',20,20,'2015-08-08','http://nevonprojects.com/real-estate-search-based-on-data-mining/','-','22000','2.2%','2016-03-03','Finished Project',20,'44000','21000','http://propertyuk.com/wp-content/uploads/2013/06/Find-A-Property-UK.jpg');

-- Insert ProjectSuggestions
INSERT INTO `database`.`projectsuggestions` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`DateCreated`,`InvestmentRequired`,`EstimatedReturn`,`Priority`,`Notes`,`ImageURL`) VALUES (1,'Online Herbs Shopping','This project helps the users in curing its disease by giving the list of fruits and herbs that the user should consume in order to get rid of its disease.','http://nevonprojects.com/online-herbs-shopping/',15,'2016-03-03','5000','7500','1','-','http://blog.deewal.com/wp-content/uploads/2015/09/Deewal-1.jpg');
INSERT INTO `database`.`projectsuggestions` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`DateCreated`,`InvestmentRequired`,`EstimatedReturn`,`Priority`,`Notes`,`ImageURL`) VALUES (2,'Hotel Management Android Project','The regular hotel management system project entirely in an android app. This android application allows the hotel manager to handle all hotel activities in his android phone.','http://nevonprojects.com/hotel-management-android/',21,'2016-03-01','8000','1000','1','-','https://0.s3.envato.com/files/85489040/CC_FEATURED_IMAGE_590x300.png');
INSERT INTO `database`.`projectsuggestions` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`DateCreated`,`InvestmentRequired`,`EstimatedReturn`,`Priority`,`Notes`,`ImageURL`) VALUES (3,'Efficient Doctor Patient Portal','We here propose a doctor patient handling, managing system that helps doctors in their work and also patients to book doctor appointments and view medical progress. The system allows doctors to manage their booking slots online.','http://nevonprojects.com/efficient-doctor-patient-portal/',22,'2016-03-16','10000','13000','1','-','http://cc-carecloudsitefinal.s3-website-us-east-1.amazonaws.com/wp-content/uploads/2014/07/secure-patient-portal1.png');
INSERT INTO `database`.`projectsuggestions` (`Id`,`Title`,`ShortDescription`,`DetailedDescription`,`CreatedBy`,`DateCreated`,`InvestmentRequired`,`EstimatedReturn`,`Priority`,`Notes`,`ImageURL`) VALUES (4,'Android Local Train Ticketing Project','A local train ticketing system project for local trains that allows users to book local train tickets and get ticket receipt online. This local train project provides login rights for normal users and admin. ','http://nevonprojects.com/android-local-train-ticketing-project/',23,'2016-03-17','11000','14000','1','-','https://tctechcrunch2011.files.wordpress.com/2014/03/1-welcome.png?w=400');

-- Insert Tasks
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (1,0,'Login','Make the login user interface and the connection to the database','-',1,'2015-05-02',2,'2015-06-03',11,'2015-06-08','Completed','-','http://www.itdapaderucoffee.com/images/login_img.gif');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (2,0,'Track the user’s location','Track the user’s location with the help of GPS and send this detail to admin.','-',1,'2015-07-03',2,'1970-01-01',0,'2016-07-03','Worked on','-','3.bp.blogspot.com/-v0uyr9Nw1cw/VRpjC1EGd_I/AAAAAAAAA84/CdC3369R8cI/s1600/Graphic1.png');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (3,0,'View the location of the driver','Make and graphical interface in order to view the location of the driver driving the vehicle','-',1,'2016-02-01',2,'1970-01-01',0,'2016-09-01','Available','-','3.bp.blogspot.com/-v0uyr9Nw1cw/VRpjC1EGd_I/AAAAAAAAA84/CdC3369R8cI/s1600/Graphic1.png');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (4,0,'Login','User will login to the system using his fingerprint.','-',2,'2016-01-21',4,'1970-01-01',0,'2016-08-21','Worked on','-','http://www.itdapaderucoffee.com/images/login_img.gif');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (5,0,'Add Pin Code','User has to scan finger and add pin code in order to do transactions','-',2,'2016-01-22',4,'1970-01-01',0,'2016-07-01','Available','-','http://static1.businessinsider.com/image/51fa59096bb3f7ff1100000a/study-finds-that-a-shocking-number-of-people-still-use-stupidly-easy-pin-codes-like-1234.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (6,0,'Withdrawal of cash','User can withdraw cash by entering the amount he want to withdraw.','-',2,'2016-01-23',4,'1970-01-01',0,'2016-06-01','Worked on','-','http://www.pesapoint.co.ke/images/cash_withdrawal.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (7,0,'Transfer of Money','User can transfer cash to other accounts by entering the account number he wants to transfer.','-',2,'2016-01-23',4,'2016-01-29',5,'2016-02-01','Completed','-','http://www.checksmartstores.com/wp-content/uploads/2012/12/Money-Transfer_33807311.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (8,0,'Login','Make the login user interface and the connection to the database.','-',3,'2016-03-20',19,'2016-03-25',7,'2016-04-20','Completed','-','http://www.itdapaderucoffee.com/images/login_img.gif');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (9,0,'Track the user’s location','Track the user’s location with the help of GPS and send this detail to admin.','-',3,'2016-03-20',19,'1970-01-01',0,'2016-06-20','Worked on','-','3.bp.blogspot.com/-v0uyr9Nw1cw/VRpjC1EGd_I/AAAAAAAAA84/CdC3369R8cI/s1600/Graphic1.png');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (10,0,'View the location of the employee','Make and graphical interface in order to view the location of the employee.','-',3,'2016-03-20',19,'1970-01-01',0,'2016-06-20','Available','-','3.bp.blogspot.com/-v0uyr9Nw1cw/VRpjC1EGd_I/AAAAAAAAA84/CdC3369R8cI/s1600/Graphic1.png');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (11,0,'Rank user comment','Based on the sentiment keywords from the database the user comment needs to be ranked.','-',4,'2016-01-15',17,'1970-01-01',0,'2016-08-15','Available','-','http://blog.performics.com/wp-content/uploads/2013/04/Comments.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (12,0,'Create database','Create a database of sentiment based keywords along with positivity or negativity weight in database','-',4,'2015-08-15',17,'2016-04-15',17,'2016-04-15','Completed','-','http://www.altran.ch/uploads/tx_templavoila/Database-System_03.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (13,0,'Rate the product','Rate the product based on the data recieved from the users comments.','-',4,'2016-01-15',17,'1970-01-01',0,'2016-08-15','Available','-','http://www.shoemoney.com/wp-content/uploads/2014/05/rate_products.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (14,0,'Employee database','Create employee database and add new employees\'','Create the database with the specific tablles and fields. Add new employees by filling employee details and will provide identity number and password to the employee to access the system.',5,'2015-08-13',12,'2015-09-13',12,'2015-09-13','Completed','-','http://www.altran.ch/uploads/tx_templavoila/Database-System_03.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (15,0,'Login','Login actions + interface + database handler','Make the login user interface and the connection to the database.When employee login to the system he will get email about the meetings that is going to be held on next day with the lead',5,'2015-09-13',12,'2015-10-13',13,'2015-10-18','Completed','-','http://www.itdapaderucoffee.com/images/login_img.gif');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (16,0,'Create the estate database','Create the database with all the tables required and populate tabled with accurate fields.','Property details like Address, space measurement(sq ft), number of BHKs, Floor, Property Seller name and its contact number plus email-id',6,'2015-08-10',20,'2015-09-08',15,'2015-09-20','Completed','-','http://www.altran.ch/uploads/tx_templavoila/Database-System_03.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (17,0,'Dashboard','The user actions: he can see number of leads, profit and loss amount','User will be redirected to dashboard where he will get to know about number of leads he had converted and number of leads he had not converted.User will also get to know about profit and loss amount in the dashboard, based on number of leads he had converted',5,'2016-02-13',12,'1970-01-01',0,'2016-05-13','Worked on','-','http://www.ppc-essentials.com/wp-content/uploads/2014/03/Analytics-Dashboard.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (18,0,'Meetings options','The user actions: view meetings, meeting topics, send/ receive SMS,Email','Employee can fix meeting with customer by specifying the meeting topic and description about the meeting. User can view meeting that is going to be held. User can also view the topic and description about the meeting. User can send SMS and E-mail to the customers.',5,'2016-03-13',12,'1970-01-01',0,'2016-06-13','Available','-','http://b.fastcompany.net/multisite_files/fastcompany/imagecache/1280/poster/2016/02/3057102-poster-p-1-encryption-app-telegram-hits-100-million-users.jpg');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (19,0,'Search option','What can the user do, create a search function.','The user can search property depending on the area that it wants in, number of wash rooms, bedrooms, halls and kitchen.',6,'2015-09-08',20,'2015-11-10',13,'2015-11-11','Completed','-','http://www.yolink.com/yolink/wordpress/images/BlueOrbSearch.png');
INSERT INTO `database`.`tasks` (`Id`,`ParentId`,`Title`,`ShortDescription`,`DetailedDescription`,`ParentProject`,`DateCreated`,`CreatedBy`,`DateCompleted`,`CompletedBy`,`DeadLine`,`Status`,`Notes`,`ImageURL`) VALUES (20,0,'Loan algorithm','An algorithm that calculates loan that the user can take plus 20%-30% cash that the user has to pay.','-',6,'2016-02-10',20,'2016-02-10',20,'2016-02-10','Completed','-','http://4.bp.blogspot.com/-Tz4tZ_e9IwU/VilExwxSLzI/AAAAAAAADck/RuBHdfbLmx8/s1600/algorithms-and-algorithmic-notations.png');

-- taskrequests
INSERT INTO `database`.`taskrequests` (`Id`,`user_id`,`task_id`) VALUES (1,13,18);
INSERT INTO `database`.`taskrequests` (`Id`,`user_id`,`task_id`) VALUES (2,7,10);
INSERT INTO `database`.`taskrequests` (`Id`,`user_id`,`task_id`) VALUES (3,15,10);
INSERT INTO `database`.`taskrequests` (`Id`,`user_id`,`task_id`) VALUES (4,22,10);
INSERT INTO `database`.`taskrequests` (`Id`,`user_id`,`task_id`) VALUES (5,14,5);
INSERT INTO `database`.`taskrequests` (`Id`,`user_id`,`task_id`) VALUES (6,3,3);
INSERT INTO `database`.`taskrequests` (`Id`,`user_id`,`task_id`) VALUES (7,11,3);
INSERT INTO `database`.`taskrequests` (`Id`,`user_id`,`task_id`) VALUES (8,18,3);

-- projectrequests
INSERT INTO `database`.`projectrequests` (`Id`,`user_id`,`project_id`) VALUES (1,23,1);
INSERT INTO `database`.`projectrequests` (`Id`,`user_id`,`project_id`) VALUES (2,20,2);
INSERT INTO `database`.`projectrequests` (`Id`,`user_id`,`project_id`) VALUES (3,17,3);
INSERT INTO `database`.`projectrequests` (`Id`,`user_id`,`project_id`) VALUES (4,1,5);
INSERT INTO `database`.`projectrequests` (`Id`,`user_id`,`project_id`) VALUES (5,23,2);
INSERT INTO `database`.`projectrequests` (`Id`,`user_id`,`project_id`) VALUES (6,17,1);
--