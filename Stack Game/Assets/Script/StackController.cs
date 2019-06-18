﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : StackElement
{
    GameObject cam;
    public Vector3 cameraPoint;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        cameraPoint = GameObject.FindGameObjectWithTag("CameraPoint").transform.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !ReadyToNewBox())
        {
            Transform box = GameObject.FindGameObjectWithTag("Generator").transform.GetChild(0);
            app.model.dropBox = true;
            app.model.counter++;
        }

        GenerateNewBox();

        cam.transform.position = Vector3.Lerp(cam.transform.position, cameraPoint, .2f);
    }

    public void MoveBox(GameObject box)
    {
        if (box.transform.position == app.model.point[app.model.currentPoint].transform.position)
        {
            
            app.model.currentPoint = 0;
        
        }

        box.transform.position = Vector3.MoveTowards(box.transform.position, app.model.point[app.model.currentPoint].transform.position,
            app.model.speed * Time.deltaTime);

        if (box.transform.position == app.model.point[app.model.currentPoint].transform.position)
        {
           
            app.model.currentPoint = 1;
            
        }
    }

    public bool ReadyToNewBox()
    {
        if (GameObject.FindGameObjectWithTag("Generator").transform.childCount == 0 && app.model.isReady)
        {
            return true;
        }
        return false;
    }

    public void GenerateNewBox()
    {
        if (ReadyToNewBox())
        {
            if (!app.model.isGameOver)
            {
                GameObject patrol = GameObject.FindGameObjectWithTag("Patrol");
                patrol.transform.position = new Vector3(patrol.transform.position.x, patrol.transform.position.y + .5f, patrol.transform.position.z);
                cameraPoint = GameObject.FindGameObjectWithTag("CameraPoint").transform.position;
                //cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 4.5f, cam.transform.position.z);

                GameObject newBox = Instantiate(app.model.boxPrefabs, new Vector3(app.model.point[app.model.currentPoint].transform.position.x, patrol.transform.position.y, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("Generator").transform) as GameObject;

                app.model.isReady = false;
                app.model.dropBox = false;
            }
        }
    }
}
