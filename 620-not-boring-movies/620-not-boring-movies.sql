/* Write your T-SQL query statement below */
select * from cinema
where id % 2 = 1 and description != 'boring'
order by rating desc