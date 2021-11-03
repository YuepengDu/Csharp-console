# s3698728_a1
Name: Yuepeng Du
Student ID: s3698728

I first git init in the wrong folder, I should have init it at the folder with .sln file. I just realise it when I am about to submit. my rencent commit in master may seems strange, that is because I am deleteing the files and add my folder with .sln into master. All other branches are the code that I pushed from time to time

Design Pattern:
I have implemented 2 design pattern for this assignment, MVC(Model View Controller) and Abstract Factory design pattern.
First, Let's talk about the MVC pattern, MVC separate the application object model from GUI, it can handles multiple views
using the same model, so it makes the project easier to maintain and test or even upgrade. Also the model is completely decoupled
from view, therefore, it give us as developer a lot of flexibilities to design and implement the model, the application also becomes
extensible  by implementing MVC. Secondly, the Abstract Factory pattern, it creates related or dependent objects by defining 
an interface or abstract class, it will have multiple methods for these classes to use that implements the interface.
It helps to boost consistency because these classes are crafted to work together. 

Class Library:
I used 2 classes in my Library, one is for creating connection to the database and create tables in the database everytime we 
run this program. Because in assignment 1, there are plenty places that we need to create connection to the database and interact 
with these tables for things like deposit and transfer. Creating connection is the most frequent thing that we do. Therefore,
storing this class in class library enforces data abstraction, the organization of data into small and independent pieces, 
so they can communicate with each other.

My Trello url is :https://trello.com/b/8a3fQ8jk/s3698728assignment1
