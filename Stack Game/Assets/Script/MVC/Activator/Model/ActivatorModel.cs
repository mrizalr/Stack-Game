using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Activator.Model
{
    public class ActivatorModel
    {
        public int CurrentActiveBox = 0;
        public int IndexBoxDeactivated = 0;

        public bool isReadyForNewBox = true;
        public bool isReadytoDeactived = false;
    }
}
