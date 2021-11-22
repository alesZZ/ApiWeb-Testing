Feature: PostulantServiceTests
	As a Developer
	I want to add new Postulant through API
	So that it becomes available for applications.

@postulant-adding
Scenario: Add Postulant
	Given The Endpoint https://localhost:5001/api/v1/postulants is available
	When A Post Request is sent
	| Name      | LastName | Email            | Password  | MySpecialty      | MyExperience | Description | NameGithub   | ImgPostulant |
	| Alejandro | Pizarro  | sergio@gmail.com | 123456712 | Ciencia de Datos | Junior       | lorem       | sergiomg1259 | link         |
	Then A Response with Status 200 is received

Scenario: Not Add Postulant
	Given The Endpoint https://localhost:5001/api/v1/postulants is available
	When A Post Request incomplete is sent
	  | Name      | LastName | Email | Password  | MySpecialty      | MyExperience | Description | NameGithub   | ImgPostulant |
	  | Alejandro |          |       | 123456712 | Ciencia de Datos | Junior       | lorem       | sergiomg1259 | link         |
	Then A Response with Status 400 is received
	
