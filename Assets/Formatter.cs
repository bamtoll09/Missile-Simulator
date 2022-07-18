using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Formatter
{
    static string[] arr_xyz;
    static float x, y, z, vx, vy, vz, ax, ay,az;
    static float start;

    public static void parseLine(string line)
    {
        arr_xyz = line.Split(" ");

        start = float.Parse(arr_xyz[1]);
            x = float.Parse(arr_xyz[3]);
            y = float.Parse(arr_xyz[4]);
            z = float.Parse(arr_xyz[5]);
           vx = float.Parse(arr_xyz[6]);
           vy = float.Parse(arr_xyz[7]);
           vz = float.Parse(arr_xyz[8]);
           ax = float.Parse(arr_xyz[9]);
           ay = float.Parse(arr_xyz[10]);
           az = float.Parse(arr_xyz[11]);
    }

    public static Vector3 getLocation() { return new Vector3(x, y, z); }

    public static Vector3 getVelocity() { return new Vector3(vx, vy, vz); }

    public static Vector3 getAcceleration() { return new Vector3(ax, ay, az); }

    public static float getStart() { return start; }

    public static void logging()
    {
        Debug.Log(
            string.Format("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9}",
                start, x, y, z, vx, vy, vz, ax, ay, az)
        );
    }
}
