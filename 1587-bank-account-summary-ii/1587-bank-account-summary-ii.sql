/* Write your T-SQL query statement below */
SELECT name, SUM(amount)balance
FROM Users U 
JOIN Transactions T ON T.account = U.account
GROUP BY name
HAVING SUM(AMOUNT) > 10000