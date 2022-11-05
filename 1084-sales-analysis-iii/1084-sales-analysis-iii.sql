/* Write your T-SQL query statement below */
select s.product_id, p.product_name
  from sales s
  left outer join product p on s.product_id = p.product_id
 where s.sale_date between '2019-01-01' and '2019-04-01'
   and s.product_id not in (select product_id
                            from sales 
                            where sale_date not between '2019-01-01' and '2019-04-01' )
 group by s.product_id, p.product_name