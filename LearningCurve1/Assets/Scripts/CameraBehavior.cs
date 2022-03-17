using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camoffset = new Vector3(0f, 1.5f, -2.6f);

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        // TranformPoint returns the relative position
        this.transform.position = target.TransformPoint(camoffset);
        this.transform.LookAt(target);
    }

}
