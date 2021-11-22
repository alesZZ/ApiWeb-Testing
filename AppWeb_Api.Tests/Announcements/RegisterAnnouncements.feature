Feature: RegisterAnnouncements
	As a Developer
	I want to register announcements trough the API
	So that it can be available for applications.

	Background: 
		Given The Endpoint https://localhost:5001/api/v1/announcements is available
		And A Company is already stored
		| Id | Name   |
		| 1  | Google |
	
	@announcements-adding
	Scenario: Add announcement
		When A post request is sent
		  | Tittle                    | Description | RequiredSpecialty | RequiredExperience | Salary | TypeMoney | Visible | Date       | CompanyID |
		  | Developer for android app | Lorem Ipsus | Mobile Developer  | Senior             | 3000   | Dollar    | True    | 17/11/2021 | 1         |
		Then A response with Status 200 is received
		And A announcment resource is included in Response Body
		  | Tittle                    | Description | RequiredSpecialty | RequiredExperience | Salary | TypeMoney | Visible | Date       | CompanyID |
		  | Developer for android app | Lorem Ipsus | Mobile Developer  | Senior             | 3000   | Dollar    | True    | 17/11/2021 | 1         |
		
	Scenario: Add announcement with invalid companyID
		When A post request is sent
		  | Tittle                    | Description | RequiredSpecialty | RequiredExperience | Salary | TypeMoney | Visible | Date       | CompanyID |
		  | Developer for android app | Lorem Ipsus | Mobile Developer  | Junior             | 1200   | Dollar    | True    | 17/11/2021 | 2         |
		Then A response with Status 400 is received
		And A message is included in Response Body with value "Invalid Company ID"