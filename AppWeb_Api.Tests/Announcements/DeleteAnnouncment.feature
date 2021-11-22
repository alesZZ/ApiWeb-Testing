Feature: DeleteAnnouncment
	As a Developer
	I want to delete an announcement through the API
	So that it can´t show in the app

	Background: 
		Given The Endpoint https://localhost:5001/api/v1/announcements is available
		And Announcements is already stored 
		  | ID | Tittle                    | Description | RequiredSpecialty | RequiredExperience | Salary | TypeMoney | Visible | Date       | CompanyID |
		  | 1  | Developer for android app | Lorem Ipsus | Mobile Developer  | Senior             | 3000   | Dollar    | True    | 17/11/2021 | 1         |
    
	@announcement-deleting
	Scenario: Delete Announcement by ID
		When A Delete Request with id 1 is sent
		Then A response with Status 200 is received
		
	Scenario: Delete non-existen Announcement
		When A Delete Request with id 300 is sent
		Then A response with Status 400 is received
		And A message is included in Response Body with value "Announcement not found."
	