# RSystemsWebApp
This is a Image management Web application made to perform the CRUD actions inside the image gallery. 
User can view the current list of images in gallery and can Add, Edit or Delete the images inside the gallery as per need.

# Back-End Stack And Description
API project is made using .Net 6.  
Solution consists of 5 layers.  
  Controller => ViewModels => Service => DataModels => Data Access.  
Layering is done to provide loose coupling, better maintainblity and scaleblity of the code base.  
Repository pattern is followed for loose coupling of project with database layer.  
Service layer has profiler to map ViewModels to DataModels.  
Error handling middleware has been used to handle errors and validation.  
Data is stored in data.json file located in API project.  
Fluent Validations are used for data model validation before storing them in Data file.  

# Front-End Stack And Description
UI is made using Angular 18.  
Bootstrap is used for styling and templating the HTML.  
Layering for components, models and services are done.  
