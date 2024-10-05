using UnityEngine;
using UnityEngine.EventSystems;

namespace DevDog
{
    public class JoystickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        // Public Variables //

        public delegate void PressedDown();
        public event PressedDown pressedDown;

        public void OnPointerUp(PointerEventData data)
        {
            if (pressedDown != null)
            {
                pressedDown();
            }
        }

        public void OnPointerDown(PointerEventData data)
        {
        }
    }
}