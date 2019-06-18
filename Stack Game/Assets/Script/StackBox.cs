using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBox : StackElement
{
    private void Update()
    {
        if (transform.parent.name == "Generator")
        {
            if (!app.model.dropBox)
            {
                app.controller.MoveBox(this.gameObject);
            }
            else if (app.model.dropBox)
            {
                GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().AddForce(0, -50, 0, ForceMode.Force);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //app.model.boxes[app.model.boxes.Length - 1] = this.gameObject;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().isKinematic = true;
        if (transform.parent != GameObject.FindGameObjectWithTag("BoxGroup").transform)
        {
            app.model.boxList.Add(this.gameObject);
        }
        app.model.boxStacked = app.model.boxList.Count;
        transform.parent = GameObject.FindGameObjectWithTag("BoxGroup").transform;

        app.model.isReady = true;
        
        CheckingBox();

        if (app.model.boxStacked > 1)
        {
            if (collision.gameObject.CompareTag("Box"))
            {
                CutTheBox();
            }
            //float cutSize = app.model.boxList[app.model.boxStacked - 1].transform.position.x - 
            //    app.model.boxList[app.model.boxStacked - 2].transform.position.x;

            //CutTheBox(cutSize);
        }
    }

    private void CheckingBox()
    {
        if (app.model.boxStacked > 1)
        {            
            if ((Mathf.Abs(app.model.boxList[app.model.boxStacked-1].transform.position.x - app.model.boxList[app.model.boxStacked-2].transform.position.x) > 4))
            {
                app.model.isGameOver = true;
            }

            if (app.model.boxList[app.model.boxStacked - 1].transform.position.y <= app.model.boxList[app.model.boxStacked - 2].transform.position.y)
            {
                app.model.isGameOver = true;
            }
        }
    }

    //void CutTheBox(float size)
    //{
    //    float newSize = app.model.boxList[app.model.boxStacked - 2].transform.localScale.x - Mathf.Abs(size);
    //    float fallingBlockSize = app.model.boxList[app.model.boxStacked - 1].transform.localScale.x - newSize;

    //    float newPos = app.model.boxList[app.model.boxStacked - 2].transform.position.x + (size / 2);
    //    app.model.boxList[app.model.boxStacked - 1].transform.localScale = new Vector3(
    //        newSize, app.model.boxList[app.model.boxStacked - 1].transform.localScale.y,
    //        app.model.boxList[app.model.boxStacked - 1].transform.localScale.z);
    //    app.model.boxList[app.model.boxStacked - 1].transform.position = new Vector3(
    //        newPos, app.model.boxList[app.model.boxStacked - 1].transform.position.y,
    //        app.model.boxList[app.model.boxStacked - 1].transform.position.z);
    //}

    //private bool IsLeft()
    //{
    //    if (app.model.boxList[app.model.boxStacked - 1].transform.position.x - app.model.boxList[app.model.boxStacked - 2].transform.position.x < 0)
    //    {
    //        Debug.Log("left");
    //        return true;
    //    }
    //    Debug.Log("right");
    //    return false;
    //}

    public void CutTheBox()
    {
        float bottomBoxPos = app.model.boxList[app.model.boxStacked - 2].transform.position.x;
        float bottomBoxSize = app.model.boxList[app.model.boxStacked - 2].transform.localScale.x / 2;
        float topBoxPos = app.model.boxList[app.model.boxStacked - 1].transform.position.x;
        float topBoxSize = app.model.boxList[app.model.boxStacked - 1].transform.localScale.x / 2;

        //Debug.Log("bottomPos = " + bottomBoxPos);
        //Debug.Log("topPos = " + topBoxPos);
        //Debug.Log("bottomsize = " + bottomBoxSize);
        //Debug.Log("topsize = " + topBoxSize);



        if (topBoxPos < bottomBoxPos)
        {
            float bottomSideVertex = bottomBoxPos - bottomBoxSize;
            float topSideVertex = topBoxPos + topBoxSize;
            float cutValue = topSideVertex - bottomSideVertex;
            float slideValue = app.model.boxList[app.model.boxStacked - 1].transform.localScale.x / 2 - cutValue / 2;

            //Debug.Log("bottomVer = " + bottomSideVertex);
            //Debug.Log("topver = " + topSideVertex);
            //Debug.Log("slide = " + slideValue);
            //Debug.Log("cut = " + cutValue);

            app.model.boxList[app.model.boxStacked - 1].transform.localScale = new Vector3(cutValue,
                app.model.boxList[app.model.boxStacked - 1].transform.localScale.y,
                app.model.boxList[app.model.boxStacked - 1].transform.localScale.z);

            app.model.boxList[app.model.boxStacked - 1].transform.position = new Vector3(app.model.boxList[app.model.boxStacked - 1].transform.position.x + slideValue,
                app.model.boxList[app.model.boxStacked - 1].transform.position.y,
                app.model.boxList[app.model.boxStacked - 1].transform.position.z);

        }
        else if (topBoxPos > bottomBoxPos)
        {
            float bottomSideVertex = bottomBoxPos + bottomBoxSize;
            float topSideVertex = topBoxPos - topBoxSize;
            float cutValue = bottomSideVertex - topSideVertex;
            float slideValue = app.model.boxList[app.model.boxStacked - 1].transform.localScale.x / 2 - cutValue / 2;

            app.model.boxList[app.model.boxStacked - 1].transform.localScale = new Vector3(cutValue,
               app.model.boxList[app.model.boxStacked - 1].transform.localScale.y,
               app.model.boxList[app.model.boxStacked - 1].transform.localScale.z);

            app.model.boxList[app.model.boxStacked - 1].transform.position = new Vector3(app.model.boxList[app.model.boxStacked - 1].transform.position.x - slideValue,
                app.model.boxList[app.model.boxStacked - 1].transform.position.y,
                app.model.boxList[app.model.boxStacked - 1].transform.position.z);
        }
    }

}
