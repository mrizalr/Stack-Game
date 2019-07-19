using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stack.Movement.Model
{
    public class MovementModel
    {
        public enum Condition
        {
            Moving,
            Stopped
        }

        public Condition con = Condition.Moving;

        public GameObject Patrols;

        public Transform[] Points = new Transform[4];

        public int CurrentPatrols = 0;
        public int CurrentPoint = 0;

        public float Speed = 5;
    }
}
