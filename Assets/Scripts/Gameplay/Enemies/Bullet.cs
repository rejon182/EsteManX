using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public float liveTime = 5f;
    public Vector2 direccion = new Vector2(0,0);
	
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, liveTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("TakeHealth", damage);
        }
        Destroy(gameObject);
    }
}
