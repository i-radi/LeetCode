/* Write your T-SQL query statement below */
SELECT TOP 1 customer_number 
FROM Orders
GROUP BY customer_number
ORDER BY count(order_number) DESC;