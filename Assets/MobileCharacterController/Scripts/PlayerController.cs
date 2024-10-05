using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevDog
{
    public class PlayerController : MonoBehaviour
    {
        // Public Variables //
        public CharacterController characterController;
        public Joystick joystick;
        public float movementSpeed = 1f;
        public Animator animator;

        // Private Variables //
        Vector3 moveDirection;

        void Update()
        {
            UpdateMovement();
        }

        void UpdateMovement()
        {
            moveDirection = new Vector3(joystick.currentJoystickPos.x * 0.25f * Time.deltaTime, 0f, joystick.currentJoystickPos.y * 0.25f * Time.deltaTime);

            characterController.Move(moveDirection);
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, moveDirection, 360, 0.0f));
            animator.SetFloat("inputH", joystick.currentJoystickPos.x);
            animator.SetFloat("inputV", joystick.currentJoystickPos.y);
        }
        

        public void Attack()
        {
            CancelInvoke("ResetAttack");
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Attack");
            animator.SetBool("Attacking", true);
            Invoke("ResetAttack", 0.15f);
        }

        void ResetAttack()
        {
            animator.SetBool("Attacking", false);
        }

        public void Evade()
        {
            CancelInvoke("ResetRoll");
            animator.SetBool("Attacking", false);
            animator.SetBool("roll", true);
            Invoke("ResetRoll", 0.84f);
        }

        void ResetRoll()
        {
            animator.SetBool("roll", false);
        }
    }
}