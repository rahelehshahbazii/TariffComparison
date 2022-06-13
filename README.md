# TariffComparison
The Project is an Interview Task SW Development from Verivox GMBH 
Based on the Task That I received, I Implemented Restful API (Get, Post, Put, Delete).
After execution the project, The Get Method is executed and the URL will be: 
http://localhost:21737/api/Products

After execution for the first time, as shown in above, without giving any parameters in the URL, The Output of the execution will show products (A and B) based on their properties (product id, Tariff name and Annual costs) in which we see 60 for Annual costs property for Product A and 800 for Annual costs property for Product B, which is in the Task paper. 

For observing the execution of the project, for example, when we have Consumption = 3500 For Product A and Consumption = 6000 for Product B, we can adjust the URL as below in order to see the final result. 

http://localhost:21737/api/Products?ConsumptionProductA=3500&ConsumptionProductB=6000
The Output of the execution will contain Annual costs property for both Product A and Product B based on their calculation model.

Besides the project, there is TariffComparison.Test in order to Test All of the methods which are written and all of the tasks are given comments for understanding the trend. 
