/* Write your T-SQL query statement below */
with max_id as (
                select max(id) id from seat)

select case when seat.id % 2 = 1 and seat.id = max_id.id            then seat.id 
                     when seat.id % 2 = 0       then seat.id - 1 
                     else seat.id + 1                end as id, 
           student 
 from seat, max_id
 order by 1