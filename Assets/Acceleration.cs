using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acceleration : MonoBehaviour
{
    Vector3 vel, acc;
    Vector3 init;

    bool isRunning = false;

    float eTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        init = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            transform.position = init + vel * eTime
                                + 0.5f * acc
                                * eTime * eTime;

            eTime += Time.deltaTime;
        }

        if (isRunning && eTime > 1f && transform.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            eTime = 0f;

            isRunning = false;
        }
    }

    public void SetPosition(Vector3 v)
    {
        this.transform.position = v;
    }

    public void SetVelocity(Vector3 v)
    {
        this.vel = v;
    }

    public void SetAcceleration(Vector3 v)
    {
        this.acc = v;
    }
}
