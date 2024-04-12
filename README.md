NavigateApp

-	NavigateApp is a web application that allows users to navigate through different project groups and view project details.


Installation

1. Clone the repository:

>	git clone https://github.com/ayabongar/NavigateApp.git

2. Navigate to the project directory:

>  cd NavigateApp

3. Install backend dependencies:

>  dotnet restore
  
4. Start the backend server:

>  dotnet run

5. Open the frontend in your web browser:
 - Navigate to the Frontend directory.
 - Open the index.html file in your preferred web browser.


Usage

1. Upon opening the web application, you'll see a dropdown menu with options to navigate to different project groups.
2. Click on "Go to Projects" to view the projects within the selected group.
3. Use the search bar to filter projects based on keywords.


Endpoints/API Documentation

  - GET /api/projects/GetProjects
	-	Retrieves projects data from the backend.
	-	Parameters: None
	-	Returns: JSON object containing project information.
		
		
Technologies Used

-	Backend: C#, ASP.NET Core
-	Frontend: HTML, CSS, JavaScript
-	Database: JSON file


Contributing

1. Fork the repository.
2. Create a new branch (git checkout -b feature/your-feature).
3. Commit your changes (git commit -am 'Add new feature').
4. Push to the branch (git push origin feature/your-feature).
5. Create a new Pull Request.



Contact

For questions or feedback, please contact Bonga at Bongaenjoy@gmail.com