using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Condition { moving, stopped }

public class StackModel : StackElement
{
    public Condition con = Condition.stopped;
    public float speed = 1;
    public GameObject[] point;
    public int currentPoint;
    public bool dropBox = false;
    public bool isReady = false;
    public GameObject boxPrefabs;
    public bool isGameOver = false;
    public int counter=0;

    //public GameObject[] boxes;
    public List<GameObject> boxList = new List<GameObject>();
    public int boxStacked;

    //private void Start()
    //{
    //    boxes = new GameObject[1];
    //}

}
