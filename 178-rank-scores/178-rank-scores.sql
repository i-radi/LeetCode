select Score,
Dense_RANK ( ) OVER (order by Score DESC) as Rank
From Scores;