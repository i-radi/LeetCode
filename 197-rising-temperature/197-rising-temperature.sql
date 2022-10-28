SELECT Today.id FROM Weather Today, Weather Yesterday
WHERE DATEDIFF(DAY, Today.recordDate, Yesterday.recordDate) = -1
AND Today.temperature > Yesterday.temperature
