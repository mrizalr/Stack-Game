using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackElement : MonoBehaviour
{
    public StackApplication app { get { return GameObject.FindObjectOfType<StackApplication>(); } }
}

public class StackApplication : MonoBehaviour
{
    public StackModel model;
    public StackView view;
    public StackController controller;
}
