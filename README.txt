NGO Connecting hub 

Create a database in the your MySQL server ( Name : testing ) if you want different name for the database then you need changes in the appsetting.json file of the project.

Step 1: Please move all the Model, View and Controller of aspnetusers before Migration.

Step 2: Migration 
	- Add-Migration "Message"
	- Update-Database

Step 3: After Migration put back all the files inside the folder that are removed earlier.

Step 4: Run this query in the MySQL Database 
	ALTER TABLE enrollment
	DROP CONSTRAINT FK_Enrollment_AspNetUsers_Email;

Default : Admin
	Email = "admin@gmail.com"
	Password = "Admin@123"


#Charity_DotNET;
create database testing;
show databases;
use testing;
show tables;
desc volunteer;
insert into admin values ('krishna@mail.com', '$2a$10$cXn1e0ALTqFQrXCSc.DVb.pC5J.LPGEssKPoGkg.uV7PZjRvKmony');
select * from events;


#Dummy_Data;
INSERT INTO Donor (Name, DateOfBirth, Email, Phone, Address, DonorType, Password) VALUES
('John Doe', '1990-05-15 00:00:00', 'johndoe@example.com', '1234567890', '123 Main St, Anytown, USA', 'Individual', 'password1'),
('Jane Smith', '1985-10-20 00:00:00', 'janesmith@example.com', '9876543210', '456 Oak St, Anycity, USA', 'Individual', 'password2'),
('Robert Johnson', '1978-03-08 00:00:00', 'robertjohnson@example.com', '5556667777', '789 Elm St, Anyville, USA', 'Individual', 'password3'),
('Emily Davis', '1995-12-12 00:00:00', 'emilydavis@example.com', '3332221111', '321 Maple St, Anyplace, USA', 'Individual', 'password4'),
('Michael Brown', '1980-07-25 00:00:00', 'michaelbrown@example.com', '9998887777', '654 Pine St, Anyborough, USA', 'Individual', 'password5'),
('Sarah Wilson', '1992-09-18 00:00:00', 'sarahwilson@example.com', '1112223333', '987 Cedar St, Anycity, USA', 'Individual', 'password6'),
('David Lee', '1983-01-30 00:00:00', 'davidlee@example.com', '4445556666', '741 Birch St, Anytown, USA', 'Individual', 'password7'),
('Jessica Taylor', '1976-06-28 00:00:00', 'jessicataylor@example.com', '7778889999', '852 Walnut St, Anyplace, USA', 'Individual', 'password8'),
('Christopher Martinez', '1998-04-05 00:00:00', 'christophermartinez@example.com', '6665554444', '963 Oak St, Anytown, USA', 'Individual', 'password9'),
('Amanda Rodriguez', '1989-11-10 00:00:00', 'amandarodriguez@example.com', '2223334444', '159 Pine St, Anyville, USA', 'Individual', 'password10'),
('Daniel Garcia', '1972-08-03 00:00:00', 'danielgarcia@example.com', '8889990000', '357 Elm St, Anyplace, USA', 'Individual', 'password11'),
('Lisa Hernandez', '1987-02-14 00:00:00', 'lisahernandez@example.com', '1231231234', '258 Cedar St, Anytown, USA', 'Individual', 'password12'),
('Mark Lopez', '1991-10-29 00:00:00', 'marklopez@example.com', '9990001111', '654 Birch St, Anycity, USA', 'Individual', 'password13'),
('Ashley Gonzalez', '1984-05-07 00:00:00', 'ashleygonzalez@example.com', '7770009999', '753 Maple St, Anyplace, USA', 'Individual', 'password14'),
('Kevin Perez', '1979-07-22 00:00:00', 'kevinperez@example.com', '8887776666', '852 Oak St, Anytown, USA', 'Individual', 'password15');


INSERT INTO NGO (Organization_Name, Darpan_ID, Email, Vision, Phone, Address, Website, YearOfEstablishment, KeyFocusAreas, IsApproved) VALUES
('ABC Foundation', 'DAR001', 'abc@example.com', 'To empower underprivileged communities through education and healthcare.', '1234567890', '123 Main Street, Cityville', 'www.abcfoundation.org', 2005, 'Education, Healthcare', 1),
('XYZ Charity', 'DAR002', 'xyz@example.com', 'To eradicate poverty and hunger by providing sustainable solutions.', '9876543210', '456 Elm Street, Townsville', 'www.xyzcharity.org', 2010, 'Poverty alleviation, Food security', 1),
('Hope for All', 'DAR003', 'hope@example.com', 'To provide shelter and support to homeless individuals and families.', '5554443333', '789 Oak Avenue, Villagetown', 'www.hopeforall.org', 2000, 'Homelessness, Community development', 1),
('Green Earth Society', 'DAR004', 'green@example.com', 'To promote environmental conservation and sustainability.', '1112223333', '101 Forest Road, Green City', 'www.greenearthsociety.org', 2015, 'Environmental conservation, Sustainable development', 1),
('Women Empowerment Initiative', 'DAR005', 'womenempower@example.com', 'To empower women through education, skills training, and advocacy.', '9998887777', '321 Maple Lane, Equalitytown', 'www.womenempowerment.org', 2008, 'Women empowerment, Gender equality', 1),
('Health for All', 'DAR006', 'healthforall@example.com', 'To ensure access to quality healthcare services for all.', '6667778888', '741 Pine Street, Healthyville', 'www.healthforall.org', 2012, 'Healthcare, Public health', 1),
('Youth Development Network', 'DAR007', 'youthdev@example.com', 'To provide youth with opportunities for personal and professional growth.', '2223334444', '852 Cedar Avenue, Youth City', 'www.youthdevelopment.org', 2003, 'Youth development, Education', 1),
('Community Builders Association', 'DAR008', 'communitybuilders@example.com', 'To strengthen communities through capacity-building and collaboration.', '7776665555', '963 Walnut Street, Unitytown', 'www.communitybuilders.org', 2006, 'Community development, Capacity-building', 1),
('Animal Welfare Society', 'DAR009', 'animalwelfare@example.com', 'To protect and care for animals, promoting their welfare and rights.', '3332221111', '159 Cherry Lane, Petropolis', 'www.animalwelfaresociety.org', 2017, 'Animal welfare, Conservation', 1),
('Cultural Preservation Foundation', 'DAR010', 'culturepreserve@example.com', 'To preserve and promote cultural heritage and diversity.', '8889990000', '258 Rose Street, Heritageville', 'www.culturalpreservation.org', 2002, 'Cultural preservation, Heritage', 1),
('Disaster Relief Alliance', 'DAR011', 'disasterrelief@example.com', 'To provide timely and effective assistance to communities affected by disasters.', '4445556666', '369 Vine Street, Relief City', 'www.disasterreliefalliance.org', 2019, 'Disaster relief, Emergency response', 1),
('Elderly Care Foundation', 'DAR012', 'elderlycare@example.com', 'To improve the quality of life for elderly individuals through support and care services.', '7778889999', '753 Magnolia Avenue, Seniorville', 'www.elderlycarefoundation.org', 2014, 'Elderly care, Gerontology', 1),
('Tech4Good Initiative', 'DAR013', 'tech4good@example.com', 'To harness technology for social good and address pressing global challenges.', '2221113333', '456 Pineapple Lane, Innovation City', 'www.tech4good.org', 2011, 'Technology for social good, Innovation', 1),
('Art for Change Foundation', 'DAR014', 'artforchange@example.com', 'To use art as a catalyst for social change and community empowerment.', '5556667777', '852 Sunflower Street, Creativitytown', 'www.artforchange.org', 2009, 'Art for social change, Community empowerment', 1),
('Human Rights Advocacy Group', 'DAR015', 'humanrightsadvocacy@example.com', 'To promote and protect human rights through advocacy, education, and legal support.', '9998887777', '753 Jasmine Lane, Libertytown', 'www.humanrightsadvocacy.org', 2007, 'Human rights, Advocacy', 1);

INSERT INTO Volunteer (Name, DateOfBirth, Gender, Phone, Email, Address, Occupation, Education, Interest, Language, Password)
VALUES 
('John Doe', '1990-05-15', 'Male', '1234567890', 'john.doe@example.com', '123 Main St, Cityville, USA', 'Engineer', 'Bachelor of Science in Engineering', 'Reading, Hiking', 'English', 'password123'),
('Jane Smith', '1985-10-20', 'Female', '9876543210', 'jane.smith@example.com', '456 Oak Ave, Townsville, USA', 'Teacher', 'Master of Education', 'Cooking, Painting', 'English', 'p@ssw0rd!'),
('Michael Johnson', '1995-02-28', 'Male', '5551234567', 'michael.johnson@example.com', '789 Elm Rd, Villageton, USA', 'Software Developer', 'Bachelor of Computer Science', 'Gaming, Coding', 'English', 'securepass'),
('Emily Brown', '1988-07-12', 'Female', '3339876543', 'emily.brown@example.com', '321 Pine Ln, Hamletown, USA', 'Nurse', 'Bachelor of Nursing', 'Swimming, Gardening', 'English', 'volunteer123'),
('David Lee', '1992-03-04', 'Male', '9995554321', 'david.lee@example.com', '567 Maple Blvd, Villatown, USA', 'Accountant', 'Bachelor of Commerce', 'Chess, Photography', 'English', 'd@vidPass!'),
('Sarah Williams', '1993-09-08', 'Female', '4442227890', 'sarah.williams@example.com', '654 Cedar Dr, Countyville, USA', 'Graphic Designer', 'Bachelor of Fine Arts', 'Drawing, Traveling', 'English', '123456'),
('Matthew Davis', '1991-11-30', 'Male', '8883334567', 'matthew.davis@example.com', '987 Birch St, Districtville, USA', 'Lawyer', 'Juris Doctor', 'Running, Writing', 'English', 'mattD987'),
('Olivia Martinez', '1987-12-25', 'Female', '7771113456', 'olivia.martinez@example.com', '741 Oakwood Ave, Suburbia, USA', 'Architect', 'Master of Architecture', 'Painting, Yoga', 'English', 'pass1234'),
('Daniel Rodriguez', '1994-06-17', 'Male', '6664442345', 'daniel.rodriguez@example.com', '852 Elmwood Dr, Metropolis, USA', 'Doctor', 'Doctor of Medicine', 'Singing, Soccer', 'English', 'danielR567'),
('Ava Hernandez', '1986-04-03', 'Female', '2228885678', 'ava.hernandez@example.com', '963 Willow Ln, Citytown, USA', 'Entrepreneur', 'Bachelor of Business Administration', 'Shopping, Cooking', 'English', 'ava456'),
('Christopher Taylor', '1990-08-22', 'Male', '3339996789', 'christopher.taylor@example.com', '159 Spruce Rd, Townsville, USA', 'Marketing Manager', 'Master of Business Administration', 'Traveling, Photography', 'English', 'chrisT!23'),
('Sophia Gonzalez', '1996-01-18', 'Female', '1117777890', 'sophia.gonzalez@example.com', '258 Pine St, Villageton, USA', 'Writer', 'Bachelor of Arts in English', 'Reading, Painting', 'English', 'sophia123'),
('James Wilson', '1989-05-09', 'Male', '7773335678', 'james.wilson@example.com', '357 Cedar Ave, Countyville, USA', 'Chef', 'Culinary Arts Certificate', 'Cooking, Dancing', 'English', 'wilson!23'),
('Charlotte Perez', '1997-02-14', 'Female', '5551117890', 'charlotte.perez@example.com', '654 Elm Dr, Hamletown, USA', 'Social Worker', 'Bachelor of Social Work', 'Hiking, Volunteering', 'English', 'cPerez456'),
('Ethan Nguyen', '1998-10-05', 'Male', '9993332345', 'ethan.nguyen@example.com', '852 Oak St, Villatown, USA', 'Student', 'High School Diploma', 'Gaming, Drawing', 'English', 'nguyenE!23');

