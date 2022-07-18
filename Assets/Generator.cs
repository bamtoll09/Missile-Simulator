using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject cube;
    List<float> timers;
    List<GameObject> cubes;

    float eTime = 0f;
    int i=0;
    // Start is called before the first frame update
    void Start()
    {
        timers = new List<float>();
        cubes = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        for (i=0; i<timers.Count; ++i)
        {
            if (timers[i] == 0f) continue;
            if (eTime >= timers[i])
            {
                cubes[i].SetActive(true);
                timers[i] = 0f;
            }
        }

        eTime += Time.deltaTime;
    }

    public void Generate(Vector3 pos, Vector3 vel, Vector3 acc, float timing = 0f)
    {
        if (timing < 0f) timing = 0f;
        timers.Add(timing);

        GameObject gameObject = (GameObject) Instantiate(cube, pos, Quaternion.identity);
        if (timing > 0f) gameObject.SetActive(false);
        cubes.Add(gameObject);

        Acceleration a = gameObject.GetComponent<Acceleration>();
        a.SetVelocity(vel);
        a.SetAcceleration(acc);
    }
}
