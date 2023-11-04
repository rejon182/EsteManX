using System.Collections;
using UnityEngine;


public class PortraitController : MonoBehaviour
{
    public int activatedCandle = 0;
    public int requiredCandles = 3; // Adjust as needed
    public GameObject portrait;
    private SpriteRenderer portraitSprite;
    public InGameScreensController inGameScreensController;


    private void Start()
    {
        portrait.SetActive(false);
    }

    private void Update()
    {
        // CheckPortraitState();
    }

    public void CheckPortraitState()
    {
        if (activatedCandle >= requiredCandles)
        {
            portrait.SetActive(true);
            portraitSprite = GetComponent<SpriteRenderer>();
            StartCoroutine(showWinFuntion());
        }
    }

    public void ActivatePortrait()
    {
        portrait.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Mostrando al niño");
        // portraitSprite.color = Color.green;
        CheckPortraitState();
        col.gameObject.SetActive(false);
    }

    IEnumerator showWinFuntion()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        inGameScreensController.ShowWinScreen();

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        // yield return new WaitForSeconds(5);

    }
}