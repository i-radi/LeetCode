/* Write your T-SQL query statement below */
select product_id,'store1' as store,store1 as price from products where store1>0
union
select product_id,'store2' as store,store2 as price from products where store2>0
union
select product_id,'store3' as store,store3 as price from products where store3>0
order by product_id