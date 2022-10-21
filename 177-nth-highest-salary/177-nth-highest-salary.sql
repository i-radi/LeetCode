CREATE FUNCTION getNthHighestSalary(@N INT) RETURNS INT AS
BEGIN
RETURN (

SELECT salary = MAX(salary) FROM (
SELECT ROW_NUMBER() OVER(ORDER BY salary DESC) AS ranking, salary FROM
(
SELECT DISTINCT Salary FROM Employee) A
) B
WHERE ranking = @N

);
END