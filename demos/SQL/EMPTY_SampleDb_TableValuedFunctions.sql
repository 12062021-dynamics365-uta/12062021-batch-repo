-- Craig Coles
SELECT BillingCountry, count(BillingCountry) as "#ofOrders" 
FROM dbo.Invoice 
WHERE CustomerId BETWEEN '2' AND '10' 
GROUP BY  BillingCountry;

--Saida Vera (Rubi)
SELECT BillingState, Count (BillingState) AS 'Count of BillingState', SUM(Total)
FROM Invoice 
WHERE Total > 4 GROUP BY BillingState;

--Andrew Lin
SELECT UnitPrice, SUM(UnitPrice) AS "TOTAL IF ORDERED ONE OF EVERY TRACK FROM THIS PRICEPOINT" 
FROM Track 
WHERE UnitPrice >= 0.99 
GROUP BY UnitPrice 
ORDER BY SUM(UnitPrice) DESC;

-- Aldo Ramirez
Select Country, COUNT(Country) AS NumOfCustomers
FROM Customer 
WHERE Country LIKE 'Canada' GROUP BY Country;

-- Eduardo Castillo Fong
-- Show total sales per country, ordered by highest sales first, in the 2011
SELECT BillingCountry, SUM(Total) AS TotalSales 
FROM Invoice 
WHERE YEAR(InvoiceDate) = 2011 
GROUP BY BillingCountry 
ORDER BY SUM(Total) DESC;

-- Daniel Spillers (Dan)
SELECT TrackId, Name, AlbumId, Composer FROM Track
WHERE Composer BETWEEN 'A%' AND 'G%'
AND AlbumId BETWEEN 85 AND 192
AND Name BETWEEN 'Bring%' AND 'Thinking%'
Order By Name Asc;

SELECT COUNT(InvoiceId) AS 'Total Invoices', BillingCountry, SUM(Total) as 'Total' 
FROM Invoice
WHERE InvoiceId BETWEEN '20' and '90'
GROUP BY BillingCountry;

-- Robert Sharp 
SELECT c.Country, SUM(i.Total) AS SummedTotal
FROM Customer c 
LEFT JOIN Invoice i
ON c.CustomerId = i.CustomerId
WHERE Total > 5 
GROUP BY Country 
ORDER BY SummedTotal DESC, Country;

--miles.lenane
SELECT Quantity, SUM(Quantity) 
FROM InvoiceLine 
WHERE InvoiceId like '%10%' 
GROUP BY Quantity 
ORDER BY SUM(Quantity) DESC; 

--Joshua Staten (Josh)
SELECT * FROM [dbo].[Customer];
select CustomerId, LastName, Country, City from [dbo].[Customer]
where Country='Canada' or City='Prague';

SELECT count(CustomerId) as 'CustomerId' , Country
from [dbo].[Customer]
group by Country; 

--Jamie Schwartz
SELECT FirstName, LastName, email 
FROM dbo.Customer WHERE email like '%@gmail.com' ORDER BY LastName;

--Terrence Brown
Select * FROM Album
Where AlbumID > 200
ORDER BY ArtistID ASC;

-- Ahmed_Boujanoui(jimie0716)
SELECT BillingCountry, SUM(Total)
  FROM Invoice WHERE Total > 10
 GROUP BY BillingCountry
 order BY BillingCountry DESC;

-- Anthony Roy
Select State, COUNT(State) AS NumOfStates
FROM Customer
WHERE State = 'CA' GROUP BY State;

-- Kevin Lee
SELECT Country, FirstName, LastName, SUM(Total) As 'Total Spent'
FROM Customer c
Left JOIN Invoice i
ON c.CustomerId = i.CustomerId
WHERE Country = 'USA' OR Country = 'United Kingdom'
GROUP BY LastName, FirstName, Country
ORDER BY LastName ASC;

-- Greg
SELECT COUNT(EmployeeId) AS IDCount,City
FROM  Employee
WHERE Country = 'Canada'
GROUP BY City;

-- Liban
SELECT Firstname, LastName, Country FROM Customer
WHERE Company != 'null'
-- an alternate to '!=' is '<>'
ORDER BY Country ASC, Firstname DESC;

-- Shamal
SELECT TrackId, Name, AlbumId, UnitPrice 
FROM Track 
WHERE UnitPrice <=.99 AND AlbumId >= 95 AND AlbumId <=200 AND Name BETWEEN 'A%' AND 'D%' 
Order By AlbumID Asc;

-- Bishal
SELECT COUNT(CustomerId), State As TotalCustomer
FROM Customer
WHERE Country = 'USA' 
GROUP BY State
ORDER BY State;

-- Sebastian (not working)
-- Get how many customer from each country but only when there is more and 1 customer from  that country.
SELECT Country, COUNT(CustomerId) as CustomersPerCountry
FROM Customer
GROUP BY Country 
HAVING COUNT(CustomerId) > 1;






