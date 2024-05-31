# ST10023767_PROG (Agri-Energy Connect Web Application)

We were given a poe to create a Agri-Energy Connect web application prototype to bridge the gap between the agricultural sector and green energy technology providers in South Africa. This initiative aims to create a digital ecosystem where farmers, green energy experts, and enthusiasts can collaborate, share resources, and innovate in the realms of sustainable agriculture and renewable energy.

This was created to be marked by a lecturer IN 2024, but can be used by anyone who wants to access the Agri-Energy website. 

## Author 

#### Mikayle Devpnique Coetzee
##### ST10023767

## Objective

The primary goal of Agri-Energy Connect is to promote sustainable agricultural practices and the integration of green energy solutions. The platform serves as a hub for knowledge sharing, and resource collaboration.

## Key Features for both an employee and farmer

### 1. Sustainable Farming Hub

Users are able to share best practices in the farming hub...They will be able to select a category, including organic farming techniques, water conservation methods, and health maintenance.

Users will be able to view all the posts made by any other user who has a profile.

### 2. Sustainable Farming Hub Chat

Throughout the entire application, users can click on the 'Chat' button in the bottom reight corner of the page to access the messager. They can send messages and ask questions to anyone who has a profile. Similar to a group chat.

### 3. Project Collaboration 
Users can upload projects and comment on any of them to share their input and collaborate.

## Key Features for an employee

### 1. Green Energy Marketplace
Employees can not upload products but they can view all the farmers products and filter/compare it accordingley. 

### 2. Educational and Training Resources
Employees can upload webinars, courses and workshops, view and filter all the avaliable resources accordingley.

### 3. Add Farmers
Employees can add farmers and view all the farmers who has a profile or who requested to sign up. When farmers use the sign up, they will not be able to log in until the employee approves them.

### 4. Sign up
Employees are able to sign up themselves.

## Key Features for a farmer

### 1. Green Energy Marketplace
Farmers can upload products to the Marketplace and view all their products. They can also delete products.

### 2. Educational and Training Resources
Farmers can not upload webinars, courses and workshops, but they can view and filter all the avaliable resources accordingley

### 3. Sign up 
If a farmer dosent want to go through an employee with registering they can register themselves but they have to wait for an employee to aprove them, before they can have access to the website. 

## Prototype Web Application

The prototype web application demonstrates the core functionalities of the Agri-Energy Connect platform. It is built using ASP.NET, Visual Studio, and C#. The application focuses on user roles, database integration, and essential features for farmers and employees.

### 1. Database development and integration

I made use of a service based database, and implemented my version of entity framework. Because of the poe only asking for a prototype, I decided not to implement foreign keys. 

#### Sample Data: 
Employee: Username = Mikayle01 ... Password = Password@01
Farmer: Username = Juvane01 ... Password = Password@01
Farmer: Username = Dev01 ... Password = Password@01

### 2.  User Role Definition and Authentication System

#### Farmer Role:
Can add products to their profile and view their own product listings.

#### Employee Role:
Can add new farmer profiles, view all products, and use filters for product searching.

#### Secure Login: 
Authentication mechanisms to protect user data and ensure role-specific access.

### 3.  Functional Features

#### Farmers: 
Add new products with details like name, category, and production date.

#### Employees: 
Add new farmer profiles and view/filter products based on criteria such as date range and product type.

### 4. User Interface Design and Usability

#### User-Friendly Interface: 
Intuitive navigation and clear layout.

#### Responsive Design: 
The website is scalable.

### 5. Data Accuracy and Validation

#### Validation Checks: 
Maintain accuracy and consistency of information.
#### Error Handling: 
Prevent system crashes and data corruption.

## 3. Setup and Running the Prototype

### Prerequisites
Visual Studio: Ensure Visual Studio is installed on your development environment.
.NET Framework: Install the required .NET framework version.

### Step-by-Step Setup Instructions

1. Clone the Repository or download the folder and unzip it onto your device
2. Open in Visual Studio: Open the project solution file (.sln) in Visual Studio.
3. Restore Packages: Restore the NuGet packages used in the project.
4. Build the Solution: Build the project to ensure all dependencies are resolved.
5. Database Setup: Run the provided SQL scripts to set up the database schema and populate it with sample data.
6. Configure Connection Strings: Update the database connection strings in the appsettings.json file.
7. Run the Application: Start the application using Visual Studio's built-in server.

### Running the Prototype

- Login: Access the login page and authenticate using the sample credentials provided or sign up by clicking on the sign up button.

- Navigation: Use the navigation bar to access different sections of the platform or use the dashboard.

- Testing Functionalities: Test the functionalities available to different user roles (Farmer and Employee)

## Conclusion

The Agri-Energy Connect web application prototype we were requested to create demonstrates the potential of a digital platform to enhance sustainable agriculture and green energy integration.
