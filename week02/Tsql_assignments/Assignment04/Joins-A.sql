-- Healthcare System Schema
-- Create database 
CREATE DATABASE joinsdb;
GO
USE joinsdb;
GO

CREATE TABLE Patients (
    PatientID INT PRIMARY KEY,
    PatientName VARCHAR(100),
    DateOfBirth DATE,
    Gender VARCHAR(10)
);
GO
INSERT INTO Patients (PatientID, PatientName, DateOfBirth, Gender) VALUES
(1, 'John Doe', '1960-05-10', 'Male'),
(2, 'Jane Smith', '1985-09-23', 'Female'),
(3, 'Michael Brown', '1972-11-15', 'Male'),
(4, 'Emily Johnson', '1995-02-18', 'Female'),
(5, 'Robert Davis', '1955-07-02', 'Male'),
(6, 'Olivia Wilson', '2001-12-30', 'Female'),
(7, 'David Miller', '1968-03-22', 'Male'),
(8, 'Sophia Garcia', '1979-10-08', 'Female'),
(9, 'James Anderson', '1948-04-11', 'Male'),
(10, 'Linda Martinez', '1988-06-25', 'Female'),
(11, 'Noah Thomas', '1990-07-14', 'Male'), 
(12, 'Ava Thompson', '1982-03-09', 'Female');  

GO

CREATE TABLE Doctors (
    DoctorID INT PRIMARY KEY,
    DoctorName VARCHAR(100),
    Specialty VARCHAR(100)
);
go
INSERT INTO Doctors (DoctorID, DoctorName, Specialty) VALUES
(1, 'Dr. Alice Carter', 'Cardiology'),
(2, 'Dr. Brian Lee', 'Neurology'),
(3, 'Dr. Catherine Adams', 'Pediatrics'),
(4, 'Dr. Daniel Harris', 'Orthopedics'),
(5, 'Dr. Emma Scott', 'General Medicine'),
(6, 'Dr. Frank Turner', 'Dermatology'),
(7, 'Dr. Grace Evans', 'Psychiatry'),
(8, 'Dr. Henry White', 'Radiology'),
(9, 'Dr. Isabella King', 'Endocrinology');

go


CREATE TABLE Appointments (
    AppointmentID INT PRIMARY KEY,
    PatientID INT,
    DoctorID INT,
    AppointmentDate DATE,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (DoctorID) REFERENCES Doctors(DoctorID)
);
go
INSERT INTO Appointments (AppointmentID, PatientID, DoctorID, AppointmentDate) VALUES
(1, 1, 1, '2024-12-15'),
(2, 2, 3, '2025-01-10'),
(3, 3, 5, '2025-03-05'),
(4, 4, 2, '2025-03-12'),
(5, 5, 1, '2025-03-20'),
(6, 6, 4, '2025-04-10'),
(7, 7, 5, '2025-05-05'),
(8, 8, 6, '2025-05-22'),
(9, 9, 1, '2025-06-01'),
(10, 10, 7, '2025-06-18'),
(11, 1, 5, '2025-10-22'),
(12, 3, 4, '2025-10-25'),
(13, 4, 3, '2025-10-28'),
(14, 2, 9, '2025-11-05'),
(15, 11, 3, '2025-11-10'); 

go

CREATE TABLE Medications (
    MedicationID INT PRIMARY KEY,
    MedicationName VARCHAR(200),
    DosageForm VARCHAR(50)
);
go
INSERT INTO Medications (MedicationID, MedicationName, DosageForm) VALUES
(1, 'Atorvastatin', 'Tablet'),
(2, 'Metformin', 'Tablet'),
(3, 'Amoxicillin', 'Capsule'),
(4, 'Lisinopril', 'Tablet'),
(5, 'Omeprazole', 'Capsule'),
(6, 'Ibuprofen', 'Tablet'),
(7, 'Cough Syrup', 'Liquid'),
(8, 'Insulin Glargine', 'Injection'),
(9, 'Hydrocortisone Cream', 'Cream'),
(10, 'Aspirin', 'Tablet'),
(11, 'Vitamin D3', 'Tablet'),
(12, 'Paracetamol', 'Syrup'),
(13, 'Zinc Supplement', 'Tablet');

go

CREATE TABLE Prescriptions (
    PrescriptionID INT PRIMARY KEY,
    PatientID INT,
    MedicationID INT,
    PrescriptionDate DATE,
    FOREIGN KEY (PatientID) REFERENCES Patients(PatientID),
    FOREIGN KEY (MedicationID) REFERENCES Medications(MedicationID)
);
go
INSERT INTO Prescriptions (PrescriptionID, PatientID, MedicationID, PrescriptionDate) VALUES
(1, 1, 1, '2024-12-15'),
(2, 2, 3, '2025-01-10'),
(3, 3, 2, '2025-03-05'),
(4, 4, 5, '2025-03-12'),
(5, 5, 4, '2025-03-20'),
(6, 6, 7, '2025-04-10'),
(7, 7, 6, '2025-05-05'),
(8, 8, 9, '2025-05-22'),
(9, 9, 8, '2025-06-01'),
(10, 10, 10, '2025-06-18'),
(11, 1, 2, '2025-10-22'),
(12, 3, 1, '2025-10-25'),
(13, NULL, 3, '2025-10-01'),
(14, 4, NULL, '2025-10-05'),
(15, NULL, NULL, '2025-10-10');

go


-- Questions

-- 1. List all patients and their appointments, including patients who have never had an appointment.
select 
	p.patientid,
	p.patientname,
	a.appointmentid,
	a.appointmentdate,
	a.doctorid
from patients as p
left join appointments as a 
on p.patientid=a.patientid;

-- 2. Display all doctors and their scheduled appointments, including doctors without any appointments.
select 
	d.*,
	a.appointmentid,
	a.appointmentdate
from doctors as d 
left join appointments as a
on d.doctorid=a.doctorid

-- 3. Show all medications and the patients they've been prescribed to, including medications that haven't been prescribed.
select
	m.medicationid,
	m.medicationname,
	pr.prescriptionid,
	pr.prescriptiondate,
	p.patientid,
	p.patientname
from medications as m
left join prescriptions as pr 
on m.medicationid=pr.medicationid
left join patients as p 
on pr.patientid=p.patientid

-- 4. List all possible patient-doctor combinations, regardless of whether an appointment has occurred.
select 
	p.patientname,
	d.doctorname
from patients as p
cross join doctors as d

-- 5. Display all prescriptions with patient and medication information, including prescriptions where either the patient or medication information is missing.
select 
	pr.prescriptionid,
	pr.prescriptiondate,
	p.patientid,
	p.patientname,
	m.medicationid,
	m.medicationname

from prescriptions as pr
left join patients as p on pr.patientid=p.patientid
left join medications as m on pr.medicationid=m.medicationid

-- 6. Show all patients who have never been prescribed any medication, along with their appointment history.
select  
	p.patientid,
	p.patientname,
	a.appointmentid,
	a.appointmentdate
from patients p
left join prescriptions pr on p.patientid = pr.patientid
left join appointments a on p.patientid = a.patientid
where pr.prescriptionid is null
    

-- 7. List all doctors who have appointments in the next week, along with the patients they're scheduled to see.
select 
d.doctorid,
d.doctorname,
d.specialty,
p.patientname,
a.appointmentdate
from appointments a
join doctors d on d.doctorid=a.doctorid
join patients p on p.patientid=a.patientid 
where a.appointmentdate between getdate() and dateadd(week,1,getdate())

-- 8. Display all medications prescribed to patients over 60 years old, including medications not prescribed to this age group.
select 
	m.medicationname,
	m.dosageform,
	p.patientname,
	datediff(year,p.dateofbirth,getdate()) as age
from medications m 
left join prescriptions pr on pr.medicationid=m.medicationid
left join patients p on pr.patientid=p.patientid
where datediff(year,p.dateofbirth,getdate())>60  or p.patientid is null;

-- 9. Show all appointments from last year and any associated prescription information.
select 
	a.appointmentid,
	a.appointmentdate,
	p.patientname,
	d.doctorname,
	pr.prescriptionid,
	pr.prescriptiondate

from appointments a
join patients p on a.patientid=p.patientid
join doctors d on a.doctorid=d.doctorid
left join prescriptions pr on a.patientid=pr.patientid
where year(a.appointmentdate)=year(getdate())-1

-- 10. List all possible specialty-medication combinations, regardless of whether a doctor of that specialty has prescribed that medication.
select 
d.specialty,
m.medicationname
from doctors d
cross join medications m

