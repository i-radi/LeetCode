/* Write your T-SQL query statement below */
SELECT      A.buyer_id, A.join_date, ISNULL(B.orders_in_2019,0) AS orders_in_2019
FROM (       

    SELECT user_id AS buyer_id, join_date 
    FROM   Users
)                       AS A 
LEFT JOIN   (

    SELECT buyer_id , COUNT(order_id) AS orders_in_2019
    FROM   Orders
    WHERE  order_date BETWEEN '2019-01-01' AND '2019-12-31'
    GROUP BY buyer_id

)                       AS B ON A.buyer_id=B.buyer_id
ORDER BY buyer_id ASC