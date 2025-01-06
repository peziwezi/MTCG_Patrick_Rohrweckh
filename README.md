# PersonDB

A demo project to show how to access a PostgreSQL database via ADO.Net.
The CRUD operations are implemented using the Repository pattern.

## Pre-Requisites

* Docker installed
* Npgsql Extension installed in Visual Studio

## To run the project

1. Start the container with the PostgreSQL database server: ```database.bat```			
2. In the psql shell create the mydb database with the following command: ```CREATE DATABASE mydb;```	
3. To create the database tables conntect to mydb and then run all the SQL commands in the [database.sql](database.sql) file
4. Run the solution.

 
