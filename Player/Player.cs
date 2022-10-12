using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Player : MonoBehaviour
{
    [Serializable]
    public struct Settings
    {
        public GlobalVariables globalVariables;
        public bool startPaused;
        public bool usingPhysics;
        public bool usingAnimator;
    }

    [Serializable]
    public struct Movement
    {
        public int moveSpeed;
        public int sprintSpeed;
        public int rotationSpeed;
        public Vector3 jumpHight;
        public Vector3 rotationAngle;
        public ForceMode forceMode;
        public float horizontal;
        public float vertical;
        public bool jumping;
    }

    [Serializable]
    public struct PlayerAnimations
    {
        public string standardBlends;
        public float standardBlendSpeed;
        public string jump;
        public string danceAnims;
        public int currentDance;
        public string dieAnim;
    }

    [Serializable]
    public struct GroundCheckSettings
    {
        public LayerMask layerMask;
        public float distanceToGround;
        public bool grounded;
    }

    [SerializeField]
    protected Settings settings;

    [SerializeField]
    protected Movement movement;

    [SerializeField]
    private PlayerAnimations playerAnimations;

    [SerializeField]
    protected GroundCheckSettings groundCheck;

    [SerializeField] 
    protected PlayerInput playerInput;

    protected Rigidbody rigid;
    protected Animator anim;

    private int moveChar;

    protected GameObject mainMenu { get; private set; }

    public virtual void Init()
    {
        EnableGameMenu(settings.globalVariables.mainMenu, settings.startPaused);
        Sprint(false);
        if (settings.usingPhysics) rigid = GetComponent<Rigidbody>();
        if (settings.usingAnimator) anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (settings.usingAnimator) SetAnimations();
    }

    private void EnableGameMenu(GameObject menu, bool active)
    {
        settings.globalVariables.PauseGame = active;
        mainMenu = Instantiate(menu);
        mainMenu.SetActive(active);
    }

    //Animtion controller 
    public void SetAnimations()
    {
        float blendStndard = Mathf.Lerp(anim.GetFloat(playerAnimations.standardBlends), RoundNumber(movement.vertical), playerAnimations.standardBlendSpeed * Time.deltaTime);
        anim.SetFloat(playerAnimations.standardBlends, blendStndard);
        anim.SetInteger(playerAnimations.danceAnims, playerAnimations.currentDance);
    }

    //Inputs and calculations for rotating the player

    public void PhysicsMove()
    {
        rigid.AddForce(transform.forward * RoundNumber(movement.vertical) * moveChar, movement.forceMode);
        float t = movement.rotationAngle.y += movement.horizontal;

        rigid.MoveRotation(SlerpRotation(transform.rotation, GetQuaterionWithEuler(CreateVector3(0, t, 0)), movement.rotationSpeed));


    }

    private float RoundNumber(float value)
    {
        float t = Mathf.RoundToInt(value);
        return t;
    }

    private Vector3 CreateVector3(float x, float y, float z)
    {
        return new Vector3(x, y, z);
    }

    private Quaternion GetQuaterionWithEuler(Vector3 rot)
    {
        Quaternion t = Quaternion.Euler(new Vector3(0, rot.y * movement.rotationSpeed, 0));
        return t;
    }

    private Quaternion SlerpRotation(Quaternion from, Quaternion to, float slerp)
    {
        Quaternion t = Quaternion.Slerp(from, to, slerp * Time.deltaTime);
        return t;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            groundCheck.grounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            groundCheck.grounded = false;
        }
    }

    public void Sprint(bool isSprint)
    {
        if (isSprint) moveChar += movement.sprintSpeed;
        else moveChar = movement.moveSpeed;
    }

    public void Jump()
    {
        rigid.AddForce(transform.up * movement.jumpHight.y, ForceMode.Impulse);
    }

    public virtual void Die()
    {
        settings.globalVariables.dead = true;
        anim.SetBool(playerAnimations.dieAnim, true);
    }
}
