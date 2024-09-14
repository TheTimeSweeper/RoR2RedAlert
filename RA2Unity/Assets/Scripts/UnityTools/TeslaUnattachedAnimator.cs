using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaUnattachedAnimator : UnattachedAnimator {

    private bool placingCoil;

    private Animator animator;

    protected override void Update() {
        base.Update();

        Shooting();
    }

    protected override void Shooting() {
        base.Shooting();
        for (int i = 0; i < animators.Length; i++)
        {
            animator = animators[i];

            if (Input.GetMouseButtonDown(0))
            {

                animator.Play("HandOut", 2);
                animator.Play("Shock", 2);
                _combatTim = 2;
            }

            if (Input.GetMouseButtonDown(1))
            {

                animator.SetBool("isHandOut", true);
            }

            if (Input.GetMouseButtonUp(1))
            {

                animator.Play("Shock", 2);
                animator.SetBool("isHandOut", false);
                _combatTim = 2;
            }

            if (!placingCoil)
            {

                if (Input.GetKeyDown(KeyCode.R))
                {

                    animator.Play("Placing");
                    placingCoil = true;
                    _combatTim = 2;
                }
            }
            else
            {

                if (Input.GetKeyDown(KeyCode.R))
                {

                    animator.Play("DoPlace");
                    placingCoil = false;
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {

                    animator.Play("CancelPlace");
                    placingCoil = false;
                }
            }
        }
    }
}
