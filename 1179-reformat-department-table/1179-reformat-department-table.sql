/* Write your T-SQL query statement below */
SELECT *
FROM (
    SELECT id, CONCAT(month,'_Revenue') col_name, revenue
    FROM Department
) as Dpt
PIVOT (
    SUM(revenue)
    FOR col_name IN ("Jan_Revenue", "Feb_Revenue", "Mar_Revenue", "Apr_Revenue", "May_Revenue", "Jun_Revenue", "Jul_Revenue", "Aug_Revenue", "Sep_Revenue", "Oct_Revenue", "Nov_Revenue", "Dec_Revenue")
) pivot_table