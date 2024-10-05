using UnityEngine;
using UnityEngine.EventSystems;

namespace DevDog
{
    public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
    {
        // Public Variables //
        public int movementRange = 100;

        [HideInInspector]
        public Vector3 currentJoystickPos = Vector3.zero;

        // Private Variables //
        Vector3 joystickStartPos;

        void Start()
        {
            joystickStartPos = transform.position;
        }

        public void OnDrag(PointerEventData data)
        {
            int delta = (int)(data.position.x - joystickStartPos.x);
            delta = Mathf.Clamp(delta, -movementRange, movementRange);
            currentJoystickPos.x = delta;

            delta = (int)(data.position.y - joystickStartPos.y);
            delta = Mathf.Clamp(delta, -movementRange, movementRange);
            currentJoystickPos.y = delta;

            transform.position = joystickStartPos +  currentJoystickPos;
        }

        public void OnPointerUp(PointerEventData data)
        {
            transform.position = joystickStartPos;
            currentJoystickPos = Vector3.zero;
        }

        public void OnPointerDown(PointerEventData data)
        {

        }
    }
}