
CREATE DATABASE IF NOT EXISTS registrate_refugees;
USE registrate_refugees;


CREATE TABLE place_of_recidence(
street_name varchar(255), 
street_number varchar(255), 
postal_code INT, 
PRIMARY KEY (street_name, street_number, postal_code)
);

ALTER TABLE refugee CHANGE street_name StreetName varchar(255);
ALTER TABLE refugee CHANGE street_number StreetNumber varchar(255);
ALTER TABLE refugee CHANGE postal_code PostalCode INT;

CREATE TABLE refugee (asylum_card_ID INT UNSIGNED PRIMARY KEY, 
first_name varchar(255), 
last_name varchar(255),
nationality varchar(255), 
DOB DATE, 
refugee_coordinator_initials varchar(255),
date_arrival_DK DATE, 
street_name varchar(255), 
street_number varchar(255), 
postal_code INT, 
image_URL VARCHAR(255),
sex TINYINT,
FOREIGN KEY (street_name, street_number, postal_code) 
REFERENCES place_of_recidence(street_name, street_number, postal_code)
);

ALTER TABLE refugee CHANGE asylum_card_ID AsylumCardID INT UNSIGNED;
ALTER TABLE refugee CHANGE sex Sex TINYINT;
ALTER TABLE refugee CHANGE postal_code PostalCode INT;

CREATE TABLE family_relation(
family_realtion_type varchar(255),
asylum_card_ID1 INT UNSIGNED, 
asylum_card_ID2 INT UNSIGNED, 
primary key (asylum_card_ID1, asylum_card_ID2),
FOREIGN KEY (asylum_card_ID1) REFERENCES refugee(asylum_card_ID),
FOREIGN KEY (asylum_card_ID2) REFERENCES refugee(asylum_card_ID) 
);


CREATE TABLE refugee_family (
family_id INT, 
asylum_card_ID INT UNSIGNED,
PRIMARY KEY (family_id, asylum_card_ID),
FOREIGN KEY (asylum_card_ID) REFERENCES refugee(asylum_card_ID)
);

ALTER TABLE refugee_family CHANGE family_id FamilyID INT;
ALTER TABLE refugee_family CHANGE asylum_card_ID AsylumCardID INT UNSIGNED;


ALTER TABLE refugee
DROP COLUMN image_URL;
