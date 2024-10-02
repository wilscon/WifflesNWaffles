--Create SCHEMA WIFFLESNWAFFLES;
--go

-- DROP TABLE WIFFLESNWAFFLES.attendees;



--CREATE TABLE WIFFLESNWAFFLES.attendees(

--	name VARCHAR (255) NOT NULL,
--	email VARCHAR (255) NOT NULL PRIMARY KEY,
--	phone_number VARCHAR(25) NOT NULL,
--	topping VARCHAR(255),
--	attendance TINYINT 
 
--);

use TestDB;

-- SET IDENTITY_INSERT WIFFLESNWAFFLES.attendees ON;
-- INSERT INTO WIFFLESNWAFFLES.attendees(name, email, phone_number, topping, attendance) VALUES ('Joe','joe.white@gmail.com', '3601234567', 'syrup', 1)
-- INSERT INTO WIFFLESNWAFFLES.attendees(name, email, phone_number, topping, attendance) VALUES ('Jabe','jane.doe@gmail.com', '3601234567', 'syrup', 1)
-- SET IDENTITY_INSERT WIFFLESNWAFFLES.attendees OFF;

--ALTER TABLE WIFFLESNWAFFLES.attendees
--DROP COLUMN attendee_id;

-- Add last_name column

-- ALTER TABLE WIFFLESNWAFFLES.attendees
-- ADD last_name VARCHAR(255) NULL;

-- Rename name to first_name

-- EXEC sp_RENAME 'WIFFLESNWAFFLES.attendees.name', 'first_name', 'COLUMN'

--Delete from WIFFLESNWAFFLES.attendees;


-- ALTER TABLE WIFFLESNWAFFLES.attendees
-- ALTER COLUMN attendance INT;

--ALTER TABLE WIFFLESNWAFFLES.attendees
--ADD Year VARCHAR(50);

--UPDATE WIFFLESNWAFFLES.attendees
--SET Year = '2024';

--ALter Table WIFFLESNWAFFLES.attendees
--ADD id UNIQUEIDENTIFIER DEFAULT NEWID();

--Update WIFFLESNWAFFLES.attendees
--SET id = NEWID();

--SELECT CONSTRAINT_NAME
--FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
--WHERE TABLE_NAME = 'attendees'
--AND TABLE_SCHEMA = 'WIFFLESNWAFFLES'
--AND CONSTRAINT_TYPE = 'PRIMARY KEY';

--ALTER TABLE WIFFLESNWAFFLES.attendees
--DROP CONSTRAINT PK__attendee__AB6E6165DADF0350;

--ALTER TABLE WIFFLESNWAFFLES.attendees
--ALTER COLUMN id UNIQUEIDENTIFIER NOT NULL;

--ALTER TABLE WIFFLESNWAFFLES.attendees
--ADD CONSTRAINT PK_attendees PRIMARY KEY (id);

--ALTER TABLE WIFFLESNWAFFLES.attendees
--ALTER COLUMN email VARCHAR(255) NULL;

--ALTER TABLE WIFFLESNWAFFLES.attendees
--ALTER COLUMN phone_number VARCHAR(25) NULL;

INSERT INTO WIFFLESNWAFFLES.attendees(first_name, email, phone_number, topping, attendance, last_name, year,id) VALUES ('Connor',NULL, NULL, 'Waffles', 1,'Wilson' ,'2022', NEWID())




