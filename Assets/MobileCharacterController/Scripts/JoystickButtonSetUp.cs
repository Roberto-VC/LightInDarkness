using UnityEngine;

namespace DevDog
{
    public class JoystickButtonSetUp : MonoBehaviour
    {
        // Public Variables //
        public PlayerController playerController;
        public JoystickButton attackButton, evadeButton;


        void Start()
        {
            if (playerController == null)
            {
                Debug.LogError("No Player Controller assigned to Joystick Button Set Up");
                return;
            }

            attackButton.pressedDown += playerController.Attack;
            evadeButton.pressedDown += playerController.Evade;
        }
    }
}