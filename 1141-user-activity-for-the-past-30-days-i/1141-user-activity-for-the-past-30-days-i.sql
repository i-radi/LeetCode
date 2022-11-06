/* Write your T-SQL query statement below */
select activity_date as day, count(user_id) as active_users
from (select distinct user_id,activity_date from activity)a
where activity_date between dateadd(day, -29, '2019-07-27') and '2019-07-27'
group by activity_date