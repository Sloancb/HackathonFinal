using UnityEngine;
using UnityEngine.SceneManagement;

public class character1_linefollower : MonoBehaviour
{
    public Transform[] waypoints;   // array of waypoints that define the path
    public float speed = 5.0f;      // speed at which the object moves
    public float threshold = 0.1f;  // distance threshold to consider the object has reached a waypoint
    public bool isMoving = false;   // flag to indicate whether the object is currently moving or not

    private int currentIndex = 0;   // index of the current waypoint
    private Vector3 direction;      // direction to move towards the current waypoint

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Battle Scene")
        {
            SceneManager.UnloadSceneAsync("Battle Scene");
        }
        if (waypoints.Length < 2)
        {
            Debug.LogError("At least two waypoints are required to define a path.");
        }
        else
        {
            transform.position = waypoints[0].position;  // start at the first waypoint
            direction = (waypoints[1].position - transform.position).normalized;  // set direction towards next waypoint
            isMoving = true;  // start moving
        }
    }

    void Update()
    {
        if (isMoving)
        {
            // Move towards current waypoint
            transform.position += direction * speed * Time.deltaTime;

            // Check if we reached the current waypoint
            if (Vector3.Distance(transform.position, waypoints[currentIndex].position) < threshold)
            {
                // If there are more waypoints, move towards the next one
                if (currentIndex < waypoints.Length - 1)
                {
                    currentIndex++;
                    direction = (waypoints[currentIndex].position - transform.position).normalized;
                }
                else
                {
                    // Otherwise, we reached the end of the path, stop moving
                    isMoving = false;
                }
            }
        }

        // Check for arrow key input to move the object manually
        //if (Input.GetKeyDown(KeyCode.LeftArrow))
        /*{
            currentIndex = Mathf.Max(0, currentIndex - 1);
            direction = (waypoints[currentIndex].position - transform.position).normalized;
            isMoving = true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentIndex = Mathf.Min(waypoints.Length - 1, currentIndex + 1);
            direction = (waypoints[currentIndex].position - transform.position).normalized;
            isMoving = true;
        }
   */
     }
        
}