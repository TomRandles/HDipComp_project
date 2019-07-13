
INSERT INTO PROGRAMMES (ProgrammeID, ProgrammeName, ProgrammeDescription,  ProgrammeCredits, ProgrammeCost, ProgrammeQQILevel, LastUpdated)
        VALUES ('BS0501', 'Business Studies', 'Business Studies', 45, 450.00, 5, '03/07/2019'),
               ('CP0502', 'Computer Programming','Computer Programming', 90, 450.00, 5, '03/07/2019'),
	           ('BM0601', 'Business Management', 'Business Management', 45, 450.00, 6, '03/07/2019'),
	           ('OA0502', 'Office Admin','Office Admin', 45, 450.00, 5, '03/07/2019'),
	           ('SS0501', 'Sports Science','Sports Science', 90, 400.00, 5, '03/07/2019');

			   
INSERT INTO Students 
(StudentID, FirstName, SurName, AddressOne, AddressTwo, Town, County, MobilePhoneNumber, EmailAddress, EmergencyMobilePhoneNumber, StudentPPS, ProgrammeFeePaid, DateOfBirth, GenderType, FullOrPartTime, ProgrammeID, LastUpdated)

VALUES 
('G516978', 'Tom', 'Murphy', '11 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1998/03/04', 0, 0, 'BS0501', '04/07/2019' ),

('G526979', 'Mike', 'Murphy', '12 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '2000/03/04', 0, 0, 'BS0501', '04/07/2019' ),

('G536980', 'Jane', 'Murphy', '13 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1999/03/04',1,0, 'BS0501', '04/07/2019' ),

('G546981', 'Tom', 'May', '14 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1998/10/04', 0, 0, 'BM0601', '04/07/2019' ),

('G556982', 'Mike', 'May', '15 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '2000/09/04', 0, 0, 'BM0601', '04/07/2019' ),

('G566983', 'Jane', 'May', '16 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1999/08/04', 1, 0, 'BM0601', '04/07/2019' ),

('G575978', 'Tom', 'Murphy', '11 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1998/03/04', 0, 0, 'CP0502', '04/07/2019' ),

('G585979', 'Mike', 'Murphy', '12 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '2000/03/04', 0,0, 'CP0502', '04/07/2019' ),

('G595980', 'Jane', 'Murphy', '13 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1999/03/04', 1, 0,'CP0502', '04/07/2019' ),

('G504981', 'Tom', 'May', '14 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1998/10/04', 0, 0, 'OA0502', '04/07/2019' ),

('G514982', 'Mike', 'May', '15 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '2000/09/04', 0, 0, 'OA0502', '04/07/2019' ),

('G524983', 'Jane', 'May', '16 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1999/08/04', 1, 0, 'OA0502', '04/07/2019' ),

('G539378', 'Felicity', 'Kilduff', '11 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1998/03/04', 1, 0, 'SS0501', '04/07/2019' ),

('G548979', 'Jane', 'Mara', '12 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '2000/03/04', 1, 0, 'SS0501', '04/07/2019' ),

('G558980', 'Una', 'McGuire', '13 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1999/03/04', 1, 0, 'SS0501', '04/07/2019' ),

('G366981', 'Triona', 'May', '14 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1998/10/04', 1, 0, 'BM0601', '04/07/2019' ),

('G376982', 'Gertrude', 'May', '15 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '2000/09/04', 1, 0, 'BM0601', '04/07/2019' ),

('G386983', 'Maeve', 'Horan', '16 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1999/08/04', 1, 0, 'BM0601', '04/07/2019' ),

('G596978', 'Cloda', 'Murphy', '11 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1998/03/04', 1, 0, 'BS0501', '04/07/2019' ),

('G506979', 'Chloe', 'Murphy', '12 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '2000/03/04', 1, 0, 'BS0501', '04/07/2019' ),

('G516980', 'Ann', 'Murphy', '13 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1999/03/04', 1, 0, 'BS0501', '04/07/2019' ),

('G426981', 'Harry', 'May', '14 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1998/10/04', 0, 0, 'BM0601', '04/07/2019' ),

('G436982', 'Jack', 'May', '15 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '2000/09/04', 0, 0, 'BM0601', '04/07/2019' ),

('G446983', 'Peter', 'May', '16 Shangort', 'Knocknacarra', 'Galway', 'Galway', 0860638475, 'student@gmail.com', 0860276849, '1234567A', 450.00, '1999/08/04', 0, 0, 'BM0601', '04/07/2019' );

