/* Write your T-SQL query statement below */
SELECT (t.request_at) AS Day, ROUND(SUM(IIF(t.status IN('cancelled_by_driver','cancelled_by_client'), 1.0, 0.0)) /COUNT(t.id), 2) AS 'Cancellation Rate'
FROM Trips AS t
LEFT JOIN Users as u1 ON t.client_id = u1.users_id
LEFT JOIN Users as u2 ON t.driver_id = u2.users_id
WHERE t.request_at BETWEEN '2013-10-01' AND '2013-10-03'      
      AND u1.banned = 'No'
      AND u2.banned = 'No'
GROUP BY t.request_at      
ORDER BY t.request_at asc