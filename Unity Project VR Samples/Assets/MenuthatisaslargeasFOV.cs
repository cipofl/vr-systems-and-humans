﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuthatisaslargeasFOV : MonoBehaviour
{

    public GameObject canvas, canvas2, targetLagging;

    // Adjust the speed for the application.
    public float speed = 1.0f;

    public int mode = 3;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Fixed Canvas");
        canvas.SetActive(false);
        canvas2 = GameObject.Find("Lagging Canvas");
        canvas2.SetActive(false);
        targetLagging = GameObject.Find("Target lagging");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (mode == 3)
            {
                mode = 1;
                print("mode 1");
                canvas.SetActive(true);
                canvas2.SetActive(false);
            }
            else if (mode == 1)
            {
                mode = 2;
                print("mode 2");
                canvas2.SetActive(true);
                canvas.SetActive(false);
            }
            else if (mode == 2)
            {
                mode = 3;
                print("mode 3");
                canvas.SetActive(false);
                canvas2.SetActive(false);
            }
        }
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    canvas.SetActive(true);
        //    canvas2.SetActive(false);
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    canvas2.SetActive(true);
        //    canvas.SetActive(false);
        //}
        //else if (Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    canvas.SetActive(false);
        //    canvas2.SetActive(false);
        //}

        // Move our position a step closer to the target.
        float step = speed * Time.deltaTime; // calculate distance to move
        canvas2.transform.position = Vector3.MoveTowards(canvas2.transform.position, targetLagging.transform.position, step);
        canvas2.transform.rotation = Quaternion.LookRotation(canvas2.transform.position - Camera.main.transform.position);
    }
}
