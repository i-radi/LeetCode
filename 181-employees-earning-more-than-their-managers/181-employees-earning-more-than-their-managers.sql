select ee.name as Employee 
from Employee as ee
inner join Employee as er
on ee.managerId = er.id
where ee.salary > er.salary