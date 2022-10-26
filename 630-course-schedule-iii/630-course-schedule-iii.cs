public class Solution {
public int ScheduleCourse(int[][] courses) {
        var priorityQueue = new PriorityQueue<int, int>();
        var totalTime = 0;
        courses = courses.OrderBy(x => x[1]).ToArray();
        for(var i = 0; i < courses.Length; i++)
        {
            priorityQueue.Enqueue(courses[i][0], int.MaxValue - courses[i][0]);
            totalTime += courses[i][0];
            if(courses[i][1] < totalTime)
            {
                var dequeue = priorityQueue.Dequeue();
                totalTime -= dequeue;
            }
        }

        return priorityQueue.Count;
    }
}