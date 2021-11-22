Feature: GetProjects
	As a Developer
	I want to get registered Projects through the API
	So that it can be show in Postulant profiles
	
	Background: 
		Given The Endpoint https://localhost:5001/api/v1/projects is available
		And Projects is already stored
		 | Id | Tittle       | Description             | PostulantId | LinkToGithub | ImgProject |
		 | 1  | Landing Page | Responsive landing page | 100         | gitlink      | imgurl     |
		 | 2  | Unity Game   | Shooter Multiplayer     | 200         | github Link  | imgurl     |
    
	@projects-getting
	Scenario: Get Project by Id
		When  A Get request with id 1 is sent
		Then A response with Status 200 is received
		And A project resource is included in Response Body
		  | Id | Tittle       | Description             | PostulantId | LinkToGithub | ImgProject |
		  | 1  | Landing Page | Responsive landing page | 100         | gitlink      | imgurl     |
    

	Scenario: Get non-existant Project
		When A Get request with id 100 is sent
		Then  A response with Status 400 is received
		And A message is included in Response Body with value "Project not found."