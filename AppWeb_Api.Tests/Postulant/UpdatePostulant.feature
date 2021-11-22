Feature: Update Postulant
	As a Developer
	I want to update Postulant information through API
	So that it to be validate
	
	Background: 
		Given The Endpoint https://localhost:5001/api/v1/postulants/id is available
		And the Postulant is already stored
		  | id | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description |
		  | 1  | Alex | Liza     | developer-97@gmail.com | 12345678 | Ciencia de Datos | Junior       | descripcion |
	@pustulant-updating
	Scenario: Update Postulant information
		When A Put request is sent
		  | id | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description     |
		  | 1  | Alex | Liza     | developer-97@gmail.com | newpass  | Ciencia de Datos | Junior       | new description |
		Then A response with Status 200 is received
		And A postulant resource is included in Response Body
		  | id | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description     |
		  | 1  | Alex | Liza     | developer-97@gmail.com | newpass  | Ciencia de Datos | Junior       | new description |
	
	Scenario: Update Postulant with invalid information
		When A Put request is sent
		  | id | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description     |
		  | 1  | Alex |          | developer-97@gmail.com | newpass  | Ciencia de Datos | Junior       | new description |
    Then A response with Status 400 is received
    And A message is included in Response Body with value "Invalid Information"

	Scenario: Postulant is not exist
		When A Put request is sent
		  | id | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description |
		  | 69 | John | Doe      | developer-69@gmail.com | newpass  | Ciencia de Datos | Junior       | description |
    	Then A response with Status 404 is received
    	And A message is included in Response Body with value "Postulant not found"
		
		