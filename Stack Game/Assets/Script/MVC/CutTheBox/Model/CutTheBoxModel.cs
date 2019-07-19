using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Cut.Model
{
    public class CutTheBoxModel
    {
        public GameObject BoxPieces;

        public Vector3 NewBoxScale;
        public Vector3 NewBoxPosition;
        public Vector3 BoxPiecesScale;
        public Vector3 BoxPiecesPosition;

        public void SetNewBoxScale(Vector3 newScale)
        {
            NewBoxScale = newScale;
        }

        public void SetNewBoxPosition(Vector3 newPosition)
        {
            NewBoxPosition = newPosition;
        }

        public void SetPieceScale(Vector3 newScale)
        {
            BoxPiecesScale = newScale;
        }

        public void SetPiecesPosition(Vector3 newPosition)
        {
            BoxPiecesPosition = newPosition;
        }
    }

}