using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;

public class Scenario : MonoBehaviour
{
    public string path = "";
    public Generator generator;

    // Start is called before the first frame update
    void Start()
    {
        int counter = 0;
        foreach (string line in File.ReadLines(@path))
        {
            counter++;
            if (counter < 3) continue;
            Formatter.parseLine(line);
            Formatter.logging();
            generator.Generate(Formatter.getLocation(),
                Formatter.getVelocity(), Formatter.getAcceleration(),
                Formatter.getStart());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
