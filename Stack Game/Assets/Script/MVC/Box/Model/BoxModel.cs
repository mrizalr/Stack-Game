using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Box.Model
{
    public class BoxModel
    {
        public List<GameObject> ListOfBox = new List<GameObject>();

        public Transform LastBox;
        public Transform StarterBox;
        public Transform BoxPieces;

        public int Score;

        public bool isGameover = false;
    }
}
