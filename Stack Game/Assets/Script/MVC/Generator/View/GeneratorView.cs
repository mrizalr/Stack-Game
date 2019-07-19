using Stack.Box.Model;
using Stack.Generator.Model;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Generator.View
{
    public class GeneratorView : MonoBehaviour
    {
        public GeneratorModel GeneratorModel;
        public BoxModel BoxModel;

        [HideInInspector]
        public GameObject BoxInstantiated;
        [HideInInspector]
        public GameObject PiecesInstantiated;
        private GameObject _groundInstantiated;
        private GameObject _starterBox;

        [HideInInspector]
        public Transform StarterParent;
        [HideInInspector]
        public Transform GeneratorParent;
        [HideInInspector]
        public Transform PiecesParent;

        public Action OnStoreInstantiatedBox;
        public Action OnAddHeightOfPosition;
        public Action<Transform, Transform> OnSetStarterBox;

        public void GenerateStarter()
        {
            _groundInstantiated = Instantiate(GeneratorModel.GroundPrefabs, GeneratorModel.InstantiatePosition, Quaternion.identity) as GameObject;
            OnAddHeightOfPosition();
            
            _starterBox = Instantiate(GeneratorModel.BoxPrefabs, GeneratorModel.InstantiatePosition, Quaternion.identity) as GameObject;
            OnAddHeightOfPosition();

            _groundInstantiated.transform.parent = StarterParent;
            _starterBox.transform.parent = StarterParent;

            PiecesInstantiated = Instantiate(GeneratorModel.BoxPrefabs) as GameObject;
            PiecesInstantiated.SetActive(false);
            PiecesInstantiated.transform.parent = PiecesParent;

            OnSetStarterBox(_starterBox.transform, PiecesInstantiated.transform);
        }

        public void GenerateBoxes()
        {
            for (int i = 0; i < GeneratorModel.GenerationLimit; i++)
            {
                BoxInstantiated =  Instantiate(GeneratorModel.BoxPrefabs) as GameObject;
                BoxInstantiated.SetActive(false);

                OnStoreInstantiatedBox();
                BoxInstantiated.transform.parent = GeneratorParent;
            }
        }
    }
}
