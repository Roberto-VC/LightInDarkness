using UnityEngine;

namespace DevDog
{
    public class PlayerCamera : MonoBehaviour
    {
        // Public Variables //
        public GameObject thePlayer;
        public float damping = 7f;

        // Private Variables //
        Vector3 offset;

        void Start()
        {
            offset = transform.position - thePlayer.transform.position;
        }

        void LateUpdate()
        {
            if (thePlayer == null) return;

            Vector3 initPosition = thePlayer.transform.position + offset;
            Vector3 finalPosition = Vector3.Lerp(transform.position, initPosition, Time.deltaTime * damping);
            transform.position = finalPosition;

            transform.LookAt(thePlayer.transform);
        }

        public void AssignPlayer(GameObject player)
        {
            thePlayer = player;
        }

        public void UpdateOffseet()
        {
            offset = transform.position - thePlayer.transform.position;
        }
    }
}