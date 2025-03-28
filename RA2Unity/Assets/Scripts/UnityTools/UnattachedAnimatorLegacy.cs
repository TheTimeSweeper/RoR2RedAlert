﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnattachedAnimatorLegacy : MonoBehaviour
{
    [System.Serializable]
    public class UnattachedAnimation
    {
        public string animationState;
        public int layer;
    }

    [System.Serializable]
    public class UnattachedAnimations
    {
        public List<UnattachedAnimation> animations;
    }

    [System.Serializable]
    public class UnattachedAnimationCombo
    {
        public string name;
        public KeyCode keyCode;
        public List<UnattachedAnimations> comboAnimations;
        [HideInInspector]
        public float comboTimer;
        [HideInInspector]
        public int comboStep;
    }

    [SerializeField]
    protected Animator[] animators;

    [SerializeField, Space]
    List<UnattachedAnimationCombo> animationCombos;

    [SerializeField, Space]
    private float jumpTime = 5;

    [Header("whyt he fuck aren't these in the animator")]
    [SerializeField, Range(0, 0.999f)]
    protected float aimPitch = 0.5f;
    [SerializeField, Range(0, 0.999f)]
    protected float aimYaw = 0.5f;

    protected float _combatTim;
    protected float _jumpTim;
    private bool wasInCombat;

    private void Moob()
    {
        //man it's been so long since I've written a moob function

        float hori = Input.GetAxis("Horizontal");
        float veri = Input.GetAxis("Vertical");
        float horiRaw = Input.GetAxisRaw("Horizontal");
        float veriRaw = Input.GetAxisRaw("Vertical");
        for (int i = 0; i < animators.Length; i++)
        {

            animators[i].SetBool("isMoving", Mathf.Abs(horiRaw) + Mathf.Abs(veriRaw) > 0.01f);
            animators[i].SetFloat("forwardSpeed", veri);
            animators[i].SetFloat("rightSpeed", hori);

            animators[i].SetBool("isSprinting", Input.GetKey(KeyCode.LeftControl));
            animators[i].SetFloat("walkSpeed", Input.GetKey(KeyCode.LeftControl) ? 12.8f : 7);
        }
    }

    private void Jumb()
    {

        for (int i = 0; i < animators.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animators[i].Play("Jump");
                animators[i].SetBool("isGrounded", false);
                _jumpTim = jumpTime;
            }

            _jumpTim -= Time.deltaTime;

            animators[i].SetFloat("upSpeed", Mathf.Lerp(-48, 16, _jumpTim / 2f));

            if (_jumpTim <= 0)
            {
                if (!animators[i].GetBool("isGrounded"))
                {
                    animators[i].Play("LightImpact", 1);
                }
                animators[i].SetBool("isGrounded", true);
            }
        }
    }

    private void Timers()
    {
        _combatTim -= Time.deltaTime;
        bool inCombat = _combatTim > 0;

        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetBool("inCombat", inCombat);

            //if (inCombat) animators[i].SetLayerWeight(animators[i].GetLayerIndex("Body, Combat"), 1f);
            //else animators[i].SetLayerWeight(animators[i].GetLayerIndex("Body, Combat"), 0f);

            //if (inCombat != this.wasInCombat) {
            //    if (animators[i].GetBool("isGrounded") && !animators[i].GetBool("isMoving")) {
            //        if (!inCombat) animators[i].Play("ToRestIdle", animators[i].GetLayerIndex("Body"));
            //    } else if (animators[i].GetBool("isGrounded") && animators[i].GetBool("isSprinting")) {
            //        //if (!inCombat) animators[i].Play("SprintToRest2", animators[i].GetLayerIndex("Body"));
            //    } else {
            //        if (inCombat) animators[i].Play("ToCombat", animators[i].GetLayerIndex("Transition"));
            //        else animators[i].Play("ToRest", animators[i].GetLayerIndex("Transition"));
            //    }
            //}
        }

        this.wasInCombat = inCombat;
    }

    protected virtual void Update()
    {
        //if (!animator)
        //    return;

        Moob();
        Jumb();
        Shooting();
        Aiming();
        Timers();
    }
    private void Aiming()
    {

        if (Input.GetKeyDown(KeyCode.Q))
            aimYaw += 0.2f;

        if (Input.GetKeyDown(KeyCode.E))
            aimYaw -= 0.2f;

        aimYaw = Mathf.Clamp(aimYaw, 0, 0.999f);

        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].SetFloat("aimYawCycle", aimYaw);
            animators[i].SetFloat("aimPitchCycle", aimPitch);
        }
    }

    protected virtual void Shooting()
    {
        for (int i = 0; i < animationCombos.Count; i++)
        {
            RunCombo(animationCombos[i]);
        }
    }

    protected virtual void RunCombo(UnattachedAnimationCombo combo)
    {
        if (Input.GetKeyDown(combo.keyCode))
        {

            List<UnattachedAnimation> animations = combo.comboAnimations[combo.comboStep].animations;
            for (int i = 0; i < animations.Count; i++)
            {

                for (int j = 0; j < animators.Length; j++)
                {
                    animators[j].Play(animations[i].animationState, animations[i].layer);
                }
            }

            combo.comboTimer = 2;

            combo.comboStep++;
            if (combo.comboStep >= combo.comboAnimations.Count)
            {
                combo.comboStep = 0;
            }

            _combatTim = 6;
        }

        combo.comboTimer -= Time.deltaTime;

        if (combo.comboTimer <= 0)
        {
            combo.comboStep = 0;
        }
    }
}
