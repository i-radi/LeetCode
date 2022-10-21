/* Write your T-SQL query statement below */
select
	c.name as Customers
from dbo.Customers as c
left join dbo.Orders as o
on c.id = o.customerid
where o.customerid is null;