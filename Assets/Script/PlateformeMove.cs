using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateformeMove : MonoBehaviour
{
    private float maxLeft = -25f;
    private float maxRight = 25f;
    private int randomDirection;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        randomDirection = Random.Range(0,2) * 2 -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.transform.position.x <= maxLeft)
        {
            randomDirection = 1;
        } else if(gameObject.transform.position.x >= maxRight)
        {
            randomDirection = -1;
        }
        Vector3 newposition = new Vector3(gameObject.transform.position.x + randomDirection * speed * Time.deltaTime,
                                            gameObject.transform.position.y,
                                            gameObject.transform.position.z);
        gameObject.transform.position = newposition;
    }
}
