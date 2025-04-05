using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upmove : MonoBehaviour
{
    Vector3 movement;
    public float speed;
    GameObject topline;
    // Start is called before the first frame update
    void Start()
    {
        movement.y=speed;
        topline=GameObject.Find("topline");
    }

    // Update is called once per frame
    void Update()
    {
        moveplatform();
    }
    void moveplatform()
    {
        transform.position += movement*Time.deltaTime;
        if (transform.position.y >= topline.transform.position.y)
        {
            Destroy(gameObject);
        }
    }
}
