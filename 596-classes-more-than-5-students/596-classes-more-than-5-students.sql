/* Write your T-SQL query statement below */
SELECT class
FROM Courses
GROUP BY class
HAVING count(student) > = 5;