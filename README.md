This is C# (4.7.2) Web API project, it uses https://api.exchangeratesapi.io API to generate Min,Max,Avg currency rate for provided dates
and currencies.

Requirements: Visual Studio 2019

Request example:
https://localhost:44392/api/Values?dates=2018-02-01, 2018-02-15, 2018-03-01&currency=SEK->NOK

Expected result:
A min rate of 0.9546869595 on 2018-03-01, A max rate of 0.9815486993, on 2018-02-15, An average rate of 0.970839476466667
