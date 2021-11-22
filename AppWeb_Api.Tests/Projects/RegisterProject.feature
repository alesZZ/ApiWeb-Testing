Feature: RegisterProject
	As a Developer
	I want to add new Project through the API
	So that it complement postulant information.
	
	Background: 
		Given The Endpoint https://localhost:5001/api/v1/projects is available
		And A Postulant is already stored
		  | Id  | Name   |
		  | 100 | Sergio |
	@projects-adding
	Scenario: Register Project
		When A post request is sent 
		  | Tittle       | Description             | PostulantId | LinkToGithub | ImgProject |
		  | Landing Page | Responsive landing page | 100         | gitlink      | imgurl     |
 		Then A response with Status 200 is received
 		And A project resource is included in Response Body
          | Tittle       | Description             | PostulantId | LinkToGithub | ImgProject |
          | Landing Page | Responsive landing page | 100         | gitlink      | imgurl     |
          
	Scenario: Register Project with invalid Postulant
		When A post request is sent 
		  | Tittle       | Description             | PostulantId | LinkToGithub | ImgProject |
		  | Landing Page | Responsive landing page | 0           | gitlink      | imgurl     |
		Then A response with Status 400 is received
		And A message is included in Response Body with value "Invalid Postulant ID."
		