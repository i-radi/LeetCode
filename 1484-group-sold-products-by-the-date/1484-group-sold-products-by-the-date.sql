/* Write your T-SQL query statement below */
with cte_activities as 
(
select
	a.sell_date
	,a.product
	,count(a.product)as num_sold
from dbo.Activities as a
group by
	a.sell_date
	,a.product
)
select
	a.sell_date
	,COUNT(a.product) as num_sold
	,STRING_AGG(a.product,',') within group(order by a.product) as products
from cte_activities as a
group by
	a.sell_date;