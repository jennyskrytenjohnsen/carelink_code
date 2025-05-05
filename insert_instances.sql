USE registrate_refugees;


INSERT INTO refugee(asylum_card_ID, first_name, last_name, nationality, 
DOB, refugee_coordinator_initials, date_arrival_DK, street_name, street_number, postal_code, image_URL, sex) 
VALUES
(50055678, 
'For', 
'Forsen', 
'Ukrain', 
'1997-12-05', 
'ROB', 
'2003-03-15', 
'Kollegievej',
 '12', 
 9000,
'/carelink_code/images/For_Forsen.jpg',
1),
(50054567, 
'New', 
'Newsen', 
'Ukrain', 
'1997-12-04', 
'ROB', 
'2003-03-14', 
'Kollegievej',
 '12', 
 9000,
'/carelink_code/images/New_Newsen.jpg',
1)
(50051234, 
'Ref', 
'Refurgeesen', 
'Ukrain', 
'1997-12-01', 
'GOB', 
'2003-01-13', 
'Jyllands Alle',
 '45', 
 8000,
'/carelink_code/images/Ref_Refurgeesen.jpg',
1),
(50052345, 
'Test', 
'Testesen', 
'Ukrain', 
'1997-12-02', 
'GOB', 
'2003-02-13',
'Jyllands Alle',
 '45', 
 8000, 
'/carelink_code/images/test_testesen.jpg',
1), 
(50053456, 
'Try', 
'Tryesen', 
'Ukrain', 
'1997-12-03', 
'ROB', 
'2003-03-13', 
'Jyllands Alle',
 '45', 
 8000,
'/carelink_code/images/Try_tryesen.jpg',
1);

UPDATE refugee
SET street_name='Jyllands Alle', street_number ='45', postal_code=8000
WHERE asylum_card_ID=50053456;


Insert into place_of_recidence(street_name, street_number, postal_code) value 
('Jyllands Alle', '45', 8000),
('Kollegievej', '12', 9000);


INSERT INTO family_relation(family_realtion_type, asylum_card_ID1, asylum_card_ID2) VALUE
('Sisters', 50054567,50055678),
('Brothers', 50051234, 50053456), 
('Parent/Child', 50052345, 50051234), 
('Parent/Child', 50052345,50053456);












