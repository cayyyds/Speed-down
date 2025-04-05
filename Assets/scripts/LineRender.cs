using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    LineRenderer line;
    public Transform startpoint;
    public Transform endpoint;
    void Start()
    {
        line= GetComponent<LineRenderer>();

    }


    void Update()
    {
        line.SetPosition(0, startpoint.position);
        line.SetPosition(1, endpoint.position);
    }
}
