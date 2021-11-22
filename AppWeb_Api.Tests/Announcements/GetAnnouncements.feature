Feature: GetAnnouncements
	As a Developer
	I want to get announcements information through the API
	So that it can publish in the application
	
	Background: 
		Given The Endpoint https://localhost:5001/api/v1/announcements is available
		And Announcements is already stored 
		  | ID | Tittle                    | Description | RequiredSpecialty | RequiredExperience | Salary | TypeMoney | Visible | Date       | CompanyID |
		  | 1  | Developer for android app | Lorem Ipsus | Mobile Developer  | Senior             | 3000   | Dollar    | True    | 17/11/2021 | 1         |
    
	@announcements-getting
	Scenario: Get Announcement
		When A get request with id 1 is sent
		Then A response with Status 200 is received
		And A Announcement resource is included in Response Body
		  | ID | Tittle                    | Description | RequiredSpecialty | RequiredExperience | Salary | TypeMoney | Visible | Date       | CompanyID |
		  | 1  | Developer for android app | Lorem Ipsus | Mobile Developer  | Senior             | 3000   | Dollar    | True    | 17/11/2021 | 1         |
		
	Scenario: Get non-existent Announcement
		When A get request with id 400 is sent
		Then A response with Status 404 is received
		And A message is included in Response Body with value "Announcement not found"