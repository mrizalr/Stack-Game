using Stack.Activator.Model;
using Stack.Box.Model;
using Stack.Cut.Model;
using Stack.Movement.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Cut.View
{
    public class CutTheBoxView : MonoBehaviour
    {
        public CutTheBoxModel CutTheBoxModel;
        public BoxModel BoxModel;
        public ActivatorModel ActivatorModel;
        public MovementModel MovementModel;
        
        public void RescaleTheBox()
        {
            CutTheBoxModel.NewBoxScale.y = BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.localScale.y;
            BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.localScale = CutTheBoxModel.NewBoxScale;
        }

        public void CenterUpTheBox()
        {
            CutTheBoxModel.NewBoxPosition.y = BoxModel.LastBox.position.y + BoxModel.LastBox.localScale.y;
            BoxModel.ListOfBox[ActivatorModel.CurrentActiveBox].transform.position = CutTheBoxModel.NewBoxPosition;
        }

        
    }

}