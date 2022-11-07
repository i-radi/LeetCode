/* Write your T-SQL query statement below */
select stock_name,
SUM(case when operation = 'SELL' then price else -1*price end) as capital_gain_loss
from stocks
group by stock_name