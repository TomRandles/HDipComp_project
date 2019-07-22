INSERT INTO PROGRAMMES (ProgrammeID, ProgrammeName, ProgrammeDescription,  ProgrammeCredits, ProgrammeCost, ProgrammeQQILevel, LastUpdated)
        VALUES ('BS0501', 'Business Studies', 'Business Studies', 45, 450.00, 5, '03/07/2019'),
               ('CP0502', 'Computer Programming','Computer Programming', 90, 450.00, 5, '03/07/2019'),
	           ('BM0601', 'Business Management', 'Business Management', 45, 450.00, 6, '03/07/2019'),
	           ('OA0502', 'Office Admin','Office Admin', 45, 450.00, 5, '03/07/2019'),
	           ('SS0501', 'Sports Science','Sports Science', 90, 400.00, 5, '03/07/2019');
select * from Students

INSERT INTO Students 
(StudentID, FirstName, SurName, AddressOne, AddressTwo, Town, County, MobilePhoneNumber, EmailAddress, EmergencyMobilePhoneNumber, StudentPPS, ProgrammeFeePaid, DateOfBirth, GenderType, FullOrPartTime, ProgrammeID, LastUpdated)

VALUES 
('S516978', 'Tom', 'Murphy', '11 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '1998/03/04', 0, 0, 'BS0501', '04/07/2019' ),

('S526979', 'Mike', 'Murphy', '12 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '2000/03/04', 0, 0, 'BS0501', '04/07/2019' ),

('S536980', 'Jane', 'Murphy', '13 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '1999/03/04',1,0, 'BS0501', '04/07/2019' ),

('S546981', 'Tom', 'May', '14 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '1998/10/04', 0, 0, 'BM0601', '04/07/2019' ),

('S556982', 'Mike', 'May', '15 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '2000/09/04', 0, 0, 'BM0601', '04/07/2019' ),

('S566983', 'Jane', 'May', '16 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '1999/08/04', 1, 0, 'BM0601', '04/07/2019' ),

('S575978', 'Tom', 'Murphy', '11 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '1998/03/04', 0, 0, 'CP0502', '04/07/2019' ),

('S585979', 'Mike', 'Murphy', '12 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '2000/03/04', 0,0, 'CP0502', '04/07/2019' ),

('S595980', 'Jane', 'Murphy', '13 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '1999/03/04', 1, 0,'CP0502', '04/07/2019' ),

('S504981', 'Tom', 'May', '14 Shangort', 'Knocknacarra', 'Galway', 'Galway', '00353860638475', 'student@gmail.com', '00353860276849', '1234567A', 450.00, '1998/10/04', 0, 0, 'OA0502', '04/07/2019' );
	   
INSERT INTO Modules ( ModuleID, ModuleName, ModuleDescription, ModuleCredits, LastUpdated)
VALUES ('M10501', 'Maths', 'Maths', 5, '04/07/2019'),
       ('RDB601', 'Relational DB', 'Relational DB', 5, '04/07/2019'),
       ('JAV501', 'Java 1', 'Java 1', 5, '04/07/2019'),
       ('JAV602', 'Java Advanced', 'Java Advanced', 5, '04/07/2019'),
       ('SA0601', 'Software Arch', 'Software Arch', 5, '04/07/2019'),
       ('PM0601', 'Project Management', 'Project Management', 5, '04/07/2019'),
       ('DBA501', 'DB Methods', 'DB Methods', 5, '04/07/2019'),
       ('LS0601', 'Leadership', 'Leadership', 5, '04/07/2019'),
	('EX0501', 'Excel spreadsheets', 'Excel spreadsheets', 5, '04/07/2019'),
	('EX0601', 'Advanced Excel', 'Advanced Excel', 5, '04/07/2019'),
	('AC0501', 'Accounting 1', 'Accounting 1', 5, '04/07/2019'),
	('AC0601', 'Adv Accounting', 'Adv Accounting', 5, '04/07/2019'),
	('BK0501', 'Booking 1', 'Booking 1', 5, '04/07/2019'),
	('BK0601', 'Book keeping 2', 'Book keeping 2', 5, '04/07/2019'),
	('BA0501', 'Funds of Biomechanics', 'Funds of Biomechanics', 5, '04/07/2019'),
	('A00501', 'Funds of Anatomy', 'Funds of Anatomy', 5, '04/07/2019'),
	('CH0501', 'Chemistry', 'Chemistry', 5, '04/07/2019'),
	('HP0501', 'Physiology', 'Physiology', 5,  '04/07/2019');


	 INSERT INTO Modules ( ModuleID, ModuleName, ModuleDescription, ModuleCredits, LastUpdated)
VALUES ('LS0602', 'Leadership 2', 'Leadership2', 5, '04/07/2019');
delete from ProgrammeModules

	        INSERT INTO ProgrammeModules (ModuleID, ProgrammeID, LastUpdated)
		          VALUES 
				   ('LS0601','BS0501', '04/07/2019'),
                   ('LS0602','BS0501', '04/07/2019'),
				   ('AC0501','BS0501', '04/07/2019'),
				   ('EX0501','BS0501', '04/07/2019'),
				   ('LS0601','BM0601', '04/07/2019'),
                   ('AC0601','BM0601', '04/07/2019'),
				   ('BK0601','BM0601', '04/07/2019'),
				   ('M10501','CP0502', '04/07/2019'),
				   ('JAV501','CP0502', '04/07/2019'),
				   ('DBA501','CP0502', '04/07/2019'),
				   ('EX0501','OA0502', '04/07/2019'),
				   ('AC0501','OA0502', '04/07/2019'),
				   ('BK0501','OA0502', '04/07/2019'),
				   ('BA0501','SS0501', '04/07/2019'),
				   ('A00501','SS0501', '04/07/2019'),
				   ('HP0501','SS0501', '04/07/2019');


INSERT INTO Assessments (AssessmentID, AssessmentNAME, AssessmentDescription, AssessmentType, AssessmentTotalMark, ModuleID, LastUpdated)
VALUES ('MEX501', 'Maths exam 1', 'Maths exam 1', 1, 60, 'M10501', '04/07/2019'),
('MEX502', 'Maths exam 2', 'Maths exam 2',1, 40, 'M10501',  '04/07/2019'),
('EDB601', 'RDB exam', 'RDB exam',1,40, 'RDB601',  '04/07/2019'),
('PDB601', 'RDB Project', 'RDB Project',0, 60, 'RDB601',  '04/07/2019'),
('EJA501', 'Java exam', 'Java exam',1, 50, 'JAV501',  '04/07/2019'),
('PJA501', 'Java project','Java project', 0, 50, 'JAV501',  '04/07/2019'),
('EJA601', 'Java exam', 'Java exam', 1, 50, 'JAV602',  '04/07/2019'),
('PJA601', 'Java project', 'Java project', 0, 50, 'JAV602',  '04/07/2019'),
('ESA601', 'SA exam', 'SA exam', 1, 40, 'SA0601',  '04/07/2019'),
('PSA601', 'SA project', 'SA project', 0, 60, 'SA0601',  '04/07/2019'),
('PP1601', 'Proj Management', 'Proj Management 1', 0, 30, 'PM0601',  '04/07/2019'),
('PP2601', 'Proj Management', 'Proj Management 2', 0, 70, 'PM0601',  '04/07/2019'),	
('EDB501', 'DB Methods - exam', 'DB Methods - exam', 1, 50, 'DBA501', '04/07/2019'),
('PDB501', 'DB Methods - project', 'DB Methods - project', 0, 50,'DBA501',  '04/07/2019'),
('PL1601', 'Leadership 1', 'Leadership 1', 0, 60, 'LS0601',  '04/07/2019'),
('PL2601', 'Leadership 2', 'Leadership 2', 0, 40, 'LS0601',  '04/07/2019'),
('EEX501', 'Excel spreadsheets', 'Excel spreadsheets', 1, 100,'EX0501',  '04/07/2019'),
('EEX601', 'Advanced Excel', 'Advanced Excel', 1, 100,'EX0601',  '04/07/2019'),
('EAC501', 'Accounting 1', 'Accounting 1', 1, 100, 'AC0501',  '04/07/2019'),
('EAC601', 'Adv Accounting', 'Adv Accounting', 1, 100, 'AC0601',  '04/07/2019'),
('EBK501', 'Book keeping 1', 'Book keeping 1', 1, 100, 'BK0501', '04/07/2019'),
('EBK601', 'Book keeping 2', 'Book keeping 2', 1, 100, 'BK0601', '04/07/2019'),
('EBA501', 'Fundamentals of Biomechanics', 'Fundamentals of Biomechanics', 1, 100,'BA0501',  '04/07/2019'),
('EA0501', 'Fundamentals of Anatomy', 'Fundamentals of Anatomy', 1, 100, 'A00501',  '04/07/2019'),
('ECH501', 'Chemistry', 'Chemistry', 1, 100,    'CH0501',  '04/07/2019'),
('EHP501', 'Physiology', 'Physiology', 1, 100,  'HP0501',  '04/07/2019');


INSERT INTO AssessmentResults ( AssessmentResultID, AssessmentID, AssessmentDate, AssessmentResultMark, StudentID, ModuleID, ProgrammeID, LastUpdated)
VALUES 
('G516978-PL1601-04/07/2019', 'PL1601', '04/07/2019', 30, 'S516978', 'LS0601', 'BS0501', '04/07/2019'),
('G516978-PL2601-04/07/2019', 'PL2601', '04/07/2019', 35, 'S516978', 'LS0602', 'BS0501', '04/07/2019'),
('G516978-EAC501-04/07/2019', 'EAC501', '04/07/2019', 50, 'S516978', 'AC0501', 'BS0501', '04/07/2019'),
('G516978-EEX501-04/07/2019', 'EEX501', '04/07/2019', 55, 'S516978', 'EX0501', 'BS0501', '04/07/2019'),
 ('G526979-PL1601-04/07/2019', 'PL1601', '04/07/2019', 28, 'S526979', 'LS0601', 'BS0501', '04/07/2019'),
 ('G526979-PL2601-04/07/2019', 'PL2601', '04/07/2019', 33, 'S526979', 'LS0601', 'BS0501', '04/07/2019'),
 ('G526979-EAC501-04/07/2019', 'EAC501', '04/07/2019', 49, 'S526979', 'AC0501', 'BS0501', '04/07/2019'),
 ('G526979-EEX501-04/07/2019', 'EEX501', '04/07/2019', 51, 'S526979', 'EX0501', 'BS0501', '04/07/2019');



