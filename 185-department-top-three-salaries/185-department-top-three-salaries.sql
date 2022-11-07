/* Write your T-SQL query statement below */
SELECT Department, Employee, Salary
FROM (
        SELECT     B.Name AS 'Department', A.Name AS 'Employee', A.Salary,
                   DENSE_RANK()OVER(PARTITION BY B.NAME ORDER BY A.Salary DESC) AS 'R'
        FROM        Employee   AS A 
        INNER JOIN  Department AS B ON A.DepartmentId  = B.Id
)Z
WHERE R IN (1,2,3)