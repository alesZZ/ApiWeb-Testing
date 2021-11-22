Feature: Get Postulants
	As a developer
	I want to get postulant information through the API
	So that it can be use for show in their profiles
	
	Background: 
		Given The Endpoint https://localhost:5001/api/v1/postulants is available
		And the Postulant is already stored
		  | id | Name | LastName | Email                  | Password | MySpecialty            | MyExperience | Description |
		  | 1  | Alex | Liza     | developer-97@gmail.com | 12345678 | Ciencia de Datos       | Junior       | descripcion |
		  | 2  | John | Doe      | developer-21@gmail.com | abcdefgh | Inteligencia Artifcial | Senior       | descripcion |
	@postulant-getting
	Scenario: Get postulant
		Given The Endpoint https://localhost:5001/api/v1/postulants/id is available
		When A Get request is sent
		Then A response with Status 200 is received
		And A postulant resource is included in Response Body
		  | id | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description |
		  | 1  | Alex | Liza     | developer-97@gmail.com | 12345678 | Ciencia de Datos | Junior       | descripcion |
    
	Scenario: Get all postulants
		Given The Endpoint https://localhost:5001/api/v1/postulants is available
		When A Get request is sent
		Then A response with Status 200 is received
		And A postulant resource is included in Response Body
		  | id | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description |
		  | 1  | Alex | Liza     | developer-97@gmail.com | 12345678 | Ciencia de Datos | Junior       | descripcion |
		  | 1  | Alex | Liza     | developer-97@gmail.com | 12345678 | Ciencia de Datos | Junior       | descripcion |