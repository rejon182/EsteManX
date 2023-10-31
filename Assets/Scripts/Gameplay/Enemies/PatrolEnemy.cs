using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    public float startWaitTime;
    private Animator animator;

    int currentPointIndex;
    float waitTime;

    private bool isFacingRight;

    void Start()
    {
        transform.position = patrolPoints[0].position;
        transform.rotation = patrolPoints[0].rotation;
        waitTime = startWaitTime;
        animator = GetComponent<Animator>();
        isFacingRight = true;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position,
            patrolPoints[currentPointIndex].position, speed * Time.deltaTime);

        if (transform.position == patrolPoints[currentPointIndex].position)
        {
            transform.rotation = patrolPoints[currentPointIndex].rotation;
            animator.SetBool("Devil_IsWalking", true);
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
                animator.SetBool("Devil_IsWalking", false);
            }
        }
    }

    void x()
    {
        Vector2 localScale = transform.localScale;
        if (isFacingRight)
        {
            localScale.x *= 1f;
        }
        else
        {
            localScale.x *= -1f;
        }
        transform.localScale = localScale;
        isFacingRight = !isFacingRight;
    }
}