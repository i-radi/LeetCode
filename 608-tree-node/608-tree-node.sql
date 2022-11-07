/* Write your T-SQL query statement below */
select id ,
(Case
WHEN p_id is null then 'Root'
WHEN id in (select p_id from Tree) then 'Inner'
ELSE 'Leaf'
END) type
From Tree