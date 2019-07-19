using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Generator.Model
{
    public class GeneratorModel
    {
        public GameObject GroundPrefabs;
        public GameObject BoxPrefabs;
        public GameObject BoxPiecesPrefabs;

        public Transform StarterBox;

        public Vector3 InstantiatePosition = new Vector3(0, 0, 0);

        public int GenerationLimit = 50;

        public void SetPrefabs()
        {
            GroundPrefabs = Resources.Load<GameObject>("Prefabs/Ground");
            BoxPrefabs = Resources.Load<GameObject>("Prefabs/Box");
            BoxPiecesPrefabs = Resources.Load<GameObject>("Prefabs/BoxPieces");
        }
    }

}