# Contoso BadBank Hackathon


## Narrative/Story:
Imagine this situation: One of your developers left the company but he left source code for your stock depot web application he was working on. It’s on you now to take the existing code, make it work and extend it!
Below you find a list of challenges which guide you from running the app to extending features to thinking about advanced cloud usage.

## Core Principles:
While there are many ways to get something done in Azure, try to follow these core principles:
-	use existing building blocks and services available in Azure and avoid to re-invent the wheel
-	avoid writing code where it’s not necessary – there might be a way to configure stuff 
-	be cost efficient – only use what you need
-	avoid fixed cost if possible and hunt for a consumption-based model

## Disclaimer:
>While the application provided targets a scenario from the financial industry, this clearly is only a starting point. For production use several adjustments must be made. This is only meant to be used for demo purposes.


### 1	Get it running
Get the app code running on Azure. You can find the application code here (TODO LINK)

1.	Familiarize yourself with the code
2.	Find a hosting solution in Azure
3.	Run the code in Azure and access the website

> Success criteria: The application is running and you can visit the start page from a browser. 

### 2	Working with identities
The application is already prepared to work with an identity management solution. However, you will find that you cannot log into it. 

4.	Find a way to manage identities for your customers. 
5.	Connect your application with the identity management solution
6.	Ask for name, email address and phone number for every user who signs up

> Success criteria: Users can sign up for the application and can provide the required attributes.

### 3	Working with application data
Users want to place stock trade orders for their depot. Make sure you can store orders. (For demo purposes you can skip stock price, limits, validity, stock exchange location etc. which typically would be considered in the real world)
Success criteria: Users can place orders, e.g. “Buy 10 MSFT stocks” and the orders will be listed on a users “Orders” page.

7.	Find a way to store trade order data. The data to be stored should provide (at least) this information:
    *	Stock Symbol (e.g. MSFT)
    *	Number of ordered items
    *	Date and time of order
    *	State of the order (open, processing, executing)


### 4	Working asyncronously
Placed Orders shall be executed. (For demo purposes you can skip all considerations of pricing, limits, validity, stock exchange location etc.)

> Success criteria: Orders are executed and change their state from “open” to “executed” after a while. 

12.	Implement a service which will execute orders and update the state of an order to “executed”. You can use any technology and language you want but think about the Core Principles when choosing your weapons.
13.	Persist the bought or sold stock information for every user. As a minimum store 
    *	Number of items
    *	Stock Symbol
14.	The execution of an order must be handled asynchronously! 

### 5	Integration
You want to extend your business model by offering APIs to approved 3rd party companies and business partners for consumption. Create a web service which allows to access the underlying database. The API shall return the total amounts of stock orders per day for further processing. 
> Success criterias: 

    •	As a 3rd party developer I can call an API which returns the required value but only do within the limits of the quota. 
    •	As a new 3rd party developer I can request a subscription. 
    •	As a 3rd party developer I can find guidance on how to use the API somewhere.

15.	Implement a service which can access the data. You can use any technology and language but think about the Core Principles when choosing your weapons.
16.	Provide an API for your service which can be called only with a valid key which only will be given to subscribed developers.
17.	Limit the number of calls to 5 times per minute.
18.	Provide a good developer experience for 3rd party developers which helps them understand which kind of application you offer and which API calls are possible.

### 6	Communication via SMS
Over the time several cases of fraud have been detected where Hackers initiated orders for hacked accounts. As a first step your CISO demands you send out an SMS to customers which confirms a completed trade order to detect fraud early. 
> Success criteria: Whenever I place an order I will get a SMS confirmation after it has been executed.

19.	Implement or extend a service which sends an SMS confirmation to a customer whenever an order has been executed.

### 7	Social Media & Recommendation
You want to pilot a new feature to give recommendations to buy or sell stock. This feature shall indicate the sentiment of recent social media posts on Twitter and help to find if a brand is considered as positive or negative. The result shall be translated into a recommendation to buy or sell stock for customers who already have the stock in their portfolio. 
> Success criteria: As a customer I will see a small icon indicating the current sentiment for a specific stock in my depot.

20.	Implement a service which monitors social media (Twitter) and looks for tweets related to a specific company (for demo purposes it’s good enough if you just pick a single company)
21.	Perform a sentiment analyses on the tweet content.
22.	Show the results to the users in their depot.
23.	Update the analysis results regularly.

### 8	Continuous Improvements
Now that you have everything up and running you want to create a new version of the app. 

24.	Make sure you have a dedicated instance of your app for testing. Make sure you don’t overwrite the data in the production DB!
25.	Make sure that you can deploy the new version without downtime for users. 
26.	Make sure you can show the new version of the application to 10% of the users while keeping the old version in place for the rest to allow validation.

### 9	Configuration for Security and Availablity
27.	Your CISO demands you enable Multifactor authentication on your app. Make sure that every user signing into the app will be asked for a second factor.
28.	Your application is very successful. Set up your depot app so you can scale out automatically on demand if load is too high. 

1.	Ensure you have a replication of your data so that data loss can be avoided, even if the datacenter goes down.

1.	Bonus: In which could a potential data inconsistency appear? How could you solve this issue?

### 10	Disaster Recovery 
You realize it was a lot of work to get everything set up correctly and you are afraid that you might spoil everything you created on Azure by accident. 

29.	Find a way to automate the creation of all your Azure resources following the Infrastructure as Code pattern and describe the infrastructure for your web app.
30.	Put the description of your app into source control and try to set up another instance of your app.

### 11	CI/CD
If you haven’t done it already, automate the deployment.

31.	Create a pipeline which allows you to push a new version of the depot app with every committed change in source code.

### 12	Insights

32. TODO:
	App Insights?	Ladezeiten! Deployment Marker 
Sleep einbauen

### 13 Extend 

32. Add your own ideas based on real customer needs. (eg add stock prices etc...)



