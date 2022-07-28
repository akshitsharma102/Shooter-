using UnityEngine;

namespace Shooter
{
    public class PlayerMovement : MonoBehaviour, IInteractables
    {
        private Rigidbody body;
        public MovementRelatedVariables mb;

        [HideInInspector]
        public bool isDead = false;
        [SerializeField]
        private Vector3 move;

        [System.Serializable]
        public struct MovementRelatedVariables
        {

            public float speed;
            public bool can_sprint;
            public float sprint_speed;
            public bool can_jump;
            public float jump_force;
            public bool can_crouch;
            public float crouch_speed;
        }

        

        void Start()
        {
            body = this.GetComponent<Rigidbody>();
            Debug.Log("rb initialised");
            mb = new MovementRelatedVariables();
        }


        void Update()
        {
            if (isDead)
            {
                Motion();
            }
        }

        public void Motion()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("vertical");

            move = h * transform.right + v * transform.forward;

            


        }
        
        private void FixedUpdate()
        {

        }
         public void Interact()
        {

        }



    }
}

