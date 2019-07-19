using Stack.Activator.Model;
using Stack.Box.Model;
using Stack.Cut.Model;
using Stack.Movement.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Cut.Pieces.View
{
    public class InstantiateBoxPiecesView : MonoBehaviour
    {
        public CutTheBoxModel CutTheBoxModel;
        public MovementModel MovementModel;
        public ActivatorModel ActivatorModel;
        public BoxModel BoxModel;

        public void InstantiateNewPieces()
        {
            CutTheBoxModel.BoxPiecesScale.y = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.localScale.y;
            CutTheBoxModel.BoxPiecesPosition.y = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position.y;

            if (MovementModel.CurrentPatrols == 0)
            {
                BoxModel.BoxPieces.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
                CutTheBoxModel.BoxPiecesScale.z = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.localScale.z;
                CutTheBoxModel.BoxPiecesPosition.z = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position.z;
            }
            else if (MovementModel.CurrentPatrols == 1)
            {
                BoxModel.BoxPieces.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
                CutTheBoxModel.BoxPiecesScale.x = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.localScale.x;
                CutTheBoxModel.BoxPiecesPosition.x = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position.x;
            }            

            BoxModel.BoxPieces.transform.localScale = CutTheBoxModel.BoxPiecesScale;
            BoxModel.BoxPieces.transform.position = CutTheBoxModel.BoxPiecesPosition;

            BoxModel.BoxPieces.GetComponent<Renderer>().material.color = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].GetComponent<Renderer>().material.color;
            BoxModel.BoxPieces.gameObject.SetActive(true);
            BoxModel.BoxPieces.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}