# Motorsport 1 ASP.NET CORE MVC Project

## About The Project - Non-technical Description

Introducing Motorsport 1 – Your prime destination for all things Formula 1. Immerse yourself in the world of high-speed races, cutting-edge technology, and unparalleled passion. Stay updated with the latest news, extensive race coverage, and exclusive insights within the realm of Formula 1. Whether a dedicated enthusiast or a curious newcomer, Motorsport 1 is your ultimate source for the heart of F1 excitement. Join us in fueling your passion for speed and competition.

This project was created by [Vasil Totev](https://github.com/Toty8) for the purposes of ASP.NET Advanced Softuni Course, July 2023.

## Not authenticated user

This part of the platform is designed for non-registered users. These users have access to the following:

* Home page -> 
A dinamic section which shows the last 5 published articles and arrows so that you can see the next or the previous one. By clicking on the article`s title you are redirected the article itself.

* Articles page -> 
A page which visualise all (non deleted) articles that have ever been published, ordered by publish date in descending order. A button with text "Details" is giving you access to read the article. The articles also can be filtered or paged by you.

* Article page-> 
A simple page visualising the article itself, full details about it and a comment section which you can read. While reading the article you are probebly going to notice two buttons "Like" and " Add Comment". They do exactly what you think they are going to do, but as soon as you click them they are going to redirect you to the login page because you are not authenticated. 

* Drivers page-> 
A page with all current drivers, a little bit of information about them and button "Details" for every single one of them, which redirects you to a page where you can see a little bit more about there statistics.

* Teams page-> 
A page with all current Teams, a little bit of information about them and button "Details" for every single one of them, which redirects you to a page where you can see a little bit more about there statistics.

* Standing page-> 
A page with the current standing of the drivers, ordered by points in descending order and a button "Team Standing". This button redirects you to a page with the current standing of the teams, ordered by points in descending order and a button "Driver Standing"(redirecting you back to the driver`s standing).

* Draft page-> 
The Draft is a little game in which you are given a 100$ budget and every team and driver have a price. You have to choose one driver and one team while staying under the budget.It is going sum the driver and the team championship points, and every dollar that is left unused it is going to add 5 points to the result. After that you are added to the standing(which is the page you are currently on) and it shows at which position you are placed. And to start playing you just have to press the "Draft" button. Which unfortunately is going to redirect you to the login page because you are not authenticated.

* Register page->
Custom made register page so that you can register yourself.

* Login page->
Custom made login page so that you can login yourself.

## User part

This part of the platform is designed for registered users. These users have access to the following:

* Home page -> 
The same as before.

* Articles page -> 
The same as before.

* Article page-> 
The same as before, but this time the "Like" and "Add Comment" buttons work. And soon as you add a comment it pops in the comment section with two buttons underneath it: "Edit" and "Delete", which allow you to edit and delete your own comments. 

* Drivers page-> 
The same as before.

* Teams page-> 
The same as before.

* Standing page-> 
The same as before.

* Draft page-> 
The same as before, but this time the "Draft" buttons works. First it redirect you to a page where you can choose a driver and after you chose one it redirect you to a page where you can choose a team. There you have two option you can either click "Reset" and start choosing your draft from the begining or you can click "Save" and finish your draft. Once you make a draft you wont be able make a new one until the next season.

* Profile page->
Profile page where you can see and edit information about your profil. Masked with a greeding.

* Log out button->
Logs you out of your profil.

## Publisher part

This part of the platform is designed for publishers. These users have access to the following:

* Home page -> 
The same as before.

* Articles page -> 
The same as before, but this time you have access to "Edit" and "Delete" buttons, which allows you to edit and delete all article published by you.

* Article page-> 
The same as the user one, but here you also have access to "Edit" and "Delete" buttons, which allows you to edit and delete all article published by you. 

* Drivers page-> 
The same as before.

* Teams page-> 
The same as before.

* Standing page-> 
The same as before.

* Draft page-> 
The same as the user one.

* My Articles page-> 
This page is the same as the all articles page but it dont have any type of filtering and pagination and it shows only articles which are published by you.   

* Add Article page-> 
This page allows you to publish an article.

* Profile page->
The same as the user one.

* Log out button->
The same as the user one.

## Admin part

This part of the platform is designed for the admin. These user have access to the following:

* Home page -> 
  This page have nothing in common with the other home page. This one is part of the admin area. It visualise four buttons. The first two of them are "Add Team" and "Add Driver". But keep in mind that you wont be able to add team If there are already 10 active teams(team is active when it have two drivers) and you wont be able add new driver there are already 20 active drivers(driver is active when he have a team and the team have two drivers).Also do not forget that a team with only one driver is not considered as an active team.
  When you click on "Add driver" you will be redirected to a page where you can add a driver who has already raced in Formula 1(this way we do not have to reset his statistics). But if you want you can also add a driver who has never raced in Formula 1 by clicking on the "Add new driver" button. On the add new driver page you are going to see a "Add old driver" button which is going to redirect you to the add old driver page(last page).
  When you click on "Add team" you will be redirected to a page where you can add a team which has never raced in Formula 1. But if you want you can also add a team who has alredy raced in Formula 1 by clicking on the "here" link(this way we do not have to reset it statistics). The link is going to redirect you to add old driver page because as you have read earlier a team is active only when it have two drivers.
  The button "Add publish" gives you an oppotunity to add an alredy existing user to a role publisher.
  "All users" button gives a table information about all the users that are registered in the site such is full name, email, information if they are agents, publishers or if they are online.

* Articles page -> 
The same as the publisher one but this time you can edit and delete any article no matter if they are your or not.

* Article page-> 
The same as the publisher one, but for all the users, no matter if you are the owner of the article. You can also edit and delete any comment you want, again no matter if they are published by you.

* Drivers page-> 
The same as before, but you will have access to "Edit" and "Unactivate" buttons, which will help you edit drivers pesonal information such as driving number and photo and unactivate driver(fire him from the team). The two buttons will also be accessible in the driver`s details.

* Teams page-> 
The same as before, but you will have access to "Edit" and "Unactivate" buttons, which will help you edit team pesonal information such as team name and photo and unactivate team(setting team to be inactive). The two buttons will also be accessible in the team`s details.

* Standing page-> 
  The same as before, but with two new buttons. One of them is "Add result".It is personal for every driver and it redirect you to add result page. Where you are supposed to enter the position which the driver finished the race and if he had achieved the pole position or the fastest lap of the race. Ones you enter the information the site is going to calculate different race statistics about the driver such as wins, pole positions, points, podiums and ect. Entering the information once the site also update information about the team which is the reason why there is no such a button for the teams.
  The other button is "Reset (End Championship)" which is going to reset both driver and team standing(seting all drivers and teams point to 0) and add one more championship to both the first driver and the first team in there championships. Also it is going to delete every draft made in the draft standing.
  
* Draft page-> 
The same as user one, but this time there two new buttons: "Edit teams price" and "Edit drivers price". These two buttons are going to redirect you to pages where you can edit both drivers and teams draft price and as you do that the difference is going to be applied to the points of the drafts.

* My Articles page-> 
The same as the publisher one.

* Add Article page-> 
The same as the publisher one.

* Profile page->
The same as the user one.

* Log out button->
The same as the user one.

## About The Project - Technical Description


### Built With

* [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-6.0)
* [Microsoft SQL Server](https://www.microsoft.com/en-us/sql-server)

## Special Thanks

* For the develepment of this project a really want to thank [Kristiyan Ivanov](https://github.com/KrIsKa7a) and [Stamo Petrov](https://github.com/Stamo).
* For the AutoMapper functionality I used a [template](https://github.com/NikolayIT/ASP.NET-Core-Template/tree/master/src/Services/AspNetCoreTemplate.Services.Mapping) from [Nikolay Kostov](https://github.com/NikolayIT)

## Pre-App Launch Setup

Before you start using your app, do a quick setup. In the "Manage user secrets" add:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server={YourServer};Database=Motorsport1;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}

. In The package manager console, type "update-datebase" so that you can add the database and seed the data. It is really important to run the package manager console in "Motorsport/Data", because thats where are the migrations folder is. 

As you start the project there will already be seeded two users with roles:

* "Admin@admin.com" - admin role

* "Publisher@publisher.com" - publisher role
  
* Both have password: 123456 

## Learn More About ASP.NET Core MVC

You can learn more in the [Create ASP.NET Core MVC App documentation](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0).
