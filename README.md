# PCBuilder

## Project Overview

### Application Description
The main goal of this project is to familiarise software development using SCRUM, and at the same time to deliver  a three-tier system.
The application should meet all the acceptance criteria listed in the project backlog and make sure the basic CRUD functionalities for both Users and Component work properly.

### KanBan Board
![Sprint 0](https://i.gyazo.com/cf17fd8a3aaeb9331c189919786b2ae1.png)

## Sprint Breakdowns

### Sprint 1: 1/12/2020

![Sprint 1](https://i.gyazo.com/2333228e70538ef22fcac5cd47ab686a.png)

**Sprint Overview**

In my first sprint, my goal was to setup my project and create the relevant database tables that will work with my business layer. I created the three-tier system and began to iteratively work through the three layers with small progress.


**Sprint Goals**
- [x] Complete User Story 0.1
- [x] Complete User Story 0.2
- [x] Complete User Story 0.3
- [x] Update README.md


**Sprint Review**

I began creating the application by using the database-first approach and set up all the relevant tables and its attributes. I also partially worked on the main entitites in my login/ register page to prepare for my User functions for Sprint 2. The last thing I worked on was the Create functions for all my tables.


**Sprint Retrospective**

I have underestimated with the workload that I gave to myself and didn't manage my time too well, and eventually I worked over-time to complete my Sprint. To improve for Sprint 2 I need to be able to manage my time better by coming up with a plan that balances with how much I work and make sure I take regular small breaks to prevent procrastination from working too much/ being stuck at a problem for too long.

### Sprint 2: 2/12/2020

![Sprint 2](https://i.gyazo.com/62453b0398f508081038f5129bf9e75e.png)

**Sprint Overview**

For my second sprint, my goal was to complete creating user and logging in, due to being stuck at a logic error for too long. I wasn't able to progress much further and able to complete 2 of my user stories, when i intended to finish 4.

**Sprint Goals**

- [x] Update README.md
- [x] Complete User story 1,1
- [x] Complete User story 1.1.1
- [ ] Complete User story 1.1.2
- [ ] Complete User story 1.2
- [x] Push code to Git


**Sprint Review**

I began to work on the front-end and the back-end of creating the user, I've designed a simple GUI for the Sign in/ up pages and created a few validation so my program queries the user registration properly. The last thing I made was the remaining CRUD functions for the User and other components (e.g. CPU, Motherboard, etc...).


**Sprint Retrospective**

Just as Sprint 1, I have underestimated my program, and eventually I was stuck at a problem for far too long. I had a simple logic error with the username validation, and I spent too long to debug the problem rather than move on to the next work and iterate through the error again. For the next sprint I now know better to move on and return to get as much work done as possible. At the same time I want to prioritize the front-end and back-end of my project and focus on Testing through the weekend.


### Sprint 3: 3/12/2020

![Sprint 3](https://i.gyazo.com/2bd6ad18b50b0cd26da72c7cfa9fad4c.png)

**Sprint Overview**
In this sprint, I mainly focused on finishing the few Goals that was left from Sprint 2, and managed to get ahead. I managed to complete my first epics which is allowing the user to sign up and sign in to their account and being redirected to the main menu. Eventually I had a few Errors with my code and invested too much time on errors that doesn't have a huge impact on the program. I should be focusing on getting the user stories done than perfecting each user story. 

**Sprint Goals**

- [x] Update README.md (Sprint 2)
- [x] Complete User story 1.1.2
- [ ] Complete User story 1.2
- [x] Start User story 4: design a basic layout of the GUI
- [x] Push code to Git


**Sprint Review**

I began my sprint by updating my README.md, after spending some time on that I focused on getting my first user story from yesterday done, which was User story 1.1.2: User's private credential. This didn't take me too long as it was just simple validation and making sure that the user enters a number and more than 6 characters for their password, in order to keep their account more safe. I then focused on my second acceptance criteria which was replacing the characters with a * to keep the password hidden. Unfortunately my password box wouldn't recognise any text, so I decided to stick with the text box. Overall I couldn't complete all the user stories, since I was ill and distracted with small issues in my program.

**Sprint Retrospective**

In order to do better and get this project done, I need to focus less on perfecting the simple things like the GUI and not overcomplicate the validation. I shouldn't have spent 2 days on the login menu and focus on testing towards the end. For tomorrow and saturday I should 100% focus on the main component classes.

### Sprint 4: 4/12/2020

![Sprint 4](https://i.gyazo.com/0403a4e3e8d8d9faaeb27fcd4dd21a26.png)

**Sprint Overview**

In this sprint I plan to complete the CRUD methods for the 4 components table. I also plan on working with my GUI and create 8 different windows for adding and updating the components. I'm mainly focusing on the main features of my program as the due date is coming closer. And if I end up not finishing my Sprint, I will make sure the GUI is designed and my back-end is done, so all I have left to do over the weekend would be to refine the GUI, connect the frontend to the backend and finish up my unit testing.

**Sprint Goals**

- [ ] Complete User Story 2.1
- [x] Complete User Story 2.1.1
- [ ] Complete User Story 2.2
- [x] Complete User Story 2.3
- [ ] Complete User Story 3.1.1
- [x] Create the basic GUI layout for every button
- [x] Update README.md
- [ ] Push Code to Git

**Sprint Review**

I began my sprint by finishing the CRUD methods and instead of using 4 different CRUD classes, I combined them as one, as it works more efficiently and it doesn't require me to instanciate 4 different objects in the code behind the GUI. Once done, I was primarily focused on getting my GUI to work and make sure the buttons function properly. And lastly I added a listbox, but I haven't populated it since I haven't connected the frontend with the backend CRUD methods.

**Sprint Retrospective**

Throughout the day it was a short sprint as we started a bit later than usual, since we had to discuss about our presentation and we had our Friday stand-up, and on top of it we finished an hour earlier for the quiz, so that gave us a total of 4 hours to work for our Sprint and unfortunately I wasn't able to get a lot done, so I worked for a couple more hours to get most of the things done besides the testing for my CRUD methods and connecting the CRUD with the frontend.

### Sprint 5: 5/12/2020

![Sprint 5](https://i.gyazo.com/3ea6cca37ed209655ff9153d81cbe8a7.png)

**Sprint Overview**

For my fifth Sprint I wanted to focus on joining my 4 tables into 1 which will output all the added core component to a PC. I plan on making all the components added together and make them viewable.

**Sprint Goals**
- [ ] Complete User Story 3
- [x] Complete User Story 3.1
- [x] Complete README.md
- [x] Push Code to GitHub

**Sprint Review**

I began this sprint by trying add a singular component (Processor) into the Components Table, instead of trying to add all of them. I needed to get one table to join instead of 4. I managed to add the Processor table to the Components Table, and copied and pasted and adapted it to the corresponding table. I also tried to refine the windows that use the CRUD function and unfortunately stumbled on a bug which breaks the code everytime the user creates an instance of that window.

**Sprint Retrospective**

I got tracked away by this bug on my code, everytime the user clicks on Add or Update after the 2nd try it breaks my build. I've been trying to fix this issue throughout most of the day.

### Sprint 6: 6/12/2020

![Sprint 6](https://i.gyazo.com/d40b9826307db1bb3d1bc54ee1212e03.png)

**Sprint Overview**

On my last sprint I want to focus on making my joint table viewable in the list box, adding a colour theme to my GUI, fix the bug I faced in my previous Sprint and I might add the total cost as a feature, depending on how much time I've got left.

**Sprint Goals**
- [x] Complete User Story 3
- [x] Complete User Story 4
- [x] Update README.md
- [x] Push Code to GitHub

**Sprint Review**

I began this sprint by fixing my bug from Sprint 5, I solved this issue by instanciating my object inside the if statements which opens up the new window. I then made sure that my joint table is viewable in the main menu by making the joint statement. This took me a total of 2 sprints as it was one of my longest methods in my CRUD. Unfortunately I couldn't get my total Price working, since my price value is nullable and after changing it to NOT NULL it wouldn't let me re-Scaffold my database, so I stopped further investigating this bug and left it.

**Sprint Retrospective**

Throughout this whole project I learned to keep your priorities as straight as possible and make sure to complete the most important tasks and to keep moving forward rather than refining and perfecting every feature. This project has opened my eyes how to utilize agile to practice.

