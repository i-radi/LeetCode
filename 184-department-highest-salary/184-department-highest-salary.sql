/* Write your T-SQL query statement below */
with cte as (
select d.name Department ,e.name Employee, salary,rank() over(partition by departmentid order by salary desc)rid from employee e inner join department d on
e.departmentid=d.id)
select Department,Employee,Salary from cte
where rid=1