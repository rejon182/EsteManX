using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public float startWaitTime;

    int currentPointIndex;
    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[0].position;
        transform.rotation = patrolPoints[0].rotation;
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            patrolPoints[currentPointIndex].position, speed * Time.deltaTime);

        if (transform.position == patrolPoints[currentPointIndex].position)
        {
            transform.rotation = patrolPoints[currentPointIndex].rotation;
            if (waitTime <= 0)
            {
                if (currentPointIndex + 1 < patrolPoints.Length)
                {
                    currentPointIndex++;
                }
                else
                {
                    currentPointIndex = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    
    
}