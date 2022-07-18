using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class KeyPad : MonoBehaviour
{
    public GraphicRaycaster gr;
    public GameObject buttonLeft;
    public GameObject buttonUp;
    public GameObject buttonDown;
    public GameObject buttonRight;

    public GameObject mainCamera;

    public float speed = 5f;

    PointerEventData ped;
    List<RaycastResult> results;
    
    Vector3 vel;
    // Start is called before the first frame update
    void Start()
    {
        ped = new PointerEventData(null);
        results = new List<RaycastResult>();

        vel = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ped.position = Input.mousePosition;
            results.Clear();
            gr.Raycast(ped, results);
            if (results.Count > 0)
            {
                string test = "nothing";
                if (results[0].gameObject.name.Contains("Button"))
                {
                    string direction = results[0].gameObject.name.Substring(7);
                    switch (direction)
                    {
                        case "Left":
                        test = "left";
                        vel = Vector3.left * speed;
                        break;

                        case "Up":
                        test = "up";
                        vel = Vector3.up * speed;
                        break;

                        case "Down":
                        test = "down";
                        vel = Vector3.down * speed;
                        break;

                        case "Right":
                        test = "right";
                        vel = Vector3.right * speed;
                        break;
                    }
                } else { vel = Vector3.zero; }
                Debug.Log(test);
            } else { vel = Vector3.zero; }
        } else if (Input.GetMouseButtonUp(0)) { vel = Vector3.zero; }
        
        // mainCamera.transform.position = mainCamera.transform.position + vel * Time.deltaTime;
        Camera.main.transform.position = Camera.main.transform.position + vel * Time.deltaTime;
    }
}
