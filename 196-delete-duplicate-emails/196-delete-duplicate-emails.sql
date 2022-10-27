/* 
 Please write a DELETE statement and DO NOT write a SELECT statement.
 Write your T-SQL query statement below
 */

DELETE p1 
FROM Person p1
JOIN Person p2 ON p1.email = p2.email
WHERE p1.email = p2.email
    AND p1.id > p2.id;