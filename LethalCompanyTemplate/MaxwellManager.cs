using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace MaxwellBoombox
{
    public class MaxwellManager : MonoBehaviour
    {
        private int maxStates = 4;
        private int curState = -1;
        private Animator animator = null;

        /**
         * On awake, grab the animator
         */
        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
        }

        /**
         * Toggle the animation, switching to the next one if turning on
         */
        public void Toggle(bool on)
        {
            if (on)
            {
                curState = (curState + 1) % maxStates;
                animator.SetInteger("anim", curState);
            }
            else
                animator.SetInteger("anim", -1);
        }
    }
}
