/* Write your T-SQL query statement below */
with cte As (

    select * from Patients 
    cross apply string_split(conditions,' ')

)

select patient_id, patient_name , conditions from cte
where value 
like 'DIAB1%'