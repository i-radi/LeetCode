/* Write your T-SQL query statement below */
with a as (select id, visit_date, people, row_number() over (order by id desc) rn, row_number() over (order by id desc) + id date_rn
from stadium 
where people >= 100
)

select id, visit_date, people from a where
date_rn in (select date_rn from a 
group by date_rn
having count(distinct id) >= 3)
order by id