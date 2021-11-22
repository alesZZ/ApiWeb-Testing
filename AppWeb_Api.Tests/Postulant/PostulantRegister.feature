Feature: PostulantRegister
	As a Developer
	I want to add new Postulant User through API
	So that it becomes available for applications.	
		
	@postulant-adding
	Scenario: Add postulant
		Given The Endpoint https://localhost:5001/api/v1/postulants is available
		When A post request is sent
		  | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description | NameGithub | ImgPostulant |
		  | Alex | Liza     | developer-97@gmail.com | 12345678 | Ciencia de Datos | Junior       | descripcion | gitname    | xd           |
		Then A response with Status 200 is received
		And A postulant resource is included in Response Body
		  | Id | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description | NameGithub | ImgPostulant |
		  | 1  | Alex | Liza     | developer-97@gmail.com | 12345678 | Ciencia de Datos | Junior       | descripcion | gitname    | xd           |
    
	Scenario: Invalid postulant
		Given The Endpoint https://localhost:5001/api/v1/postulants is available
		When A post request is sent
		  | Name | LastName | Email                  | Password | MySpecialty      | MyExperience | Description | NameGithub | ImgPostulant |
		  |      |          | developer-97@gmail.com | 12345678 | Ciencia de Datos | Junior       | descripcion | gitname    | xd           |
    	Then A response with Status 400 is received
    	And A message is included in Response Body with value "{"type":"https://tools.ietf.org/html/rfc7231#section-6.5.1","
		
	Scenario: Add postulant with existing email
		Given A Email is already stored
		  | Name | LastName | Email                  | Password | MySpecialty    | MyExperience | Description | NameGithub | ImgPostulant |
		  | Alex | Liza     | developer-97@gmail.com | 12345678 | CienciadeDatos | Junior       | descripcion | gitname    | xd           |
		When A post request is sent
		  | Name  | LastName | Email                  | Password | MySpecialty      | MyExperience | Description | NameGithub | ImgPostulant |
		  | Diego | Perez    | developer-97@gmail.com | 1234abcd | Ciencia de Datos | Senior       | descripcion | gitname    | xd           |
		Then A response with Status 400 is received
		And A message is included in Response Body with value "Email is already exist."
		