/* Write your T-SQL query statement below */
SELECT 
    a.name, ISNULL(b.travelled_distance,0) AS travelled_distance
FROM Users a
LEFT OUTER JOIN   
(
SELECT 
    user_id, SUM(distance) AS travelled_distance 
FROM 
    Rides
GROUP BY 
    user_id
) 
b ON a.id = b.user_id

ORDER BY 
    b.travelled_distance DESC, a.name ASC