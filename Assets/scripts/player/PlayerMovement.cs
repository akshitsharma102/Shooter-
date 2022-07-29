using UnityEngine;

namespace Shooter
{
    public class PlayerMovement : MonoBehaviour, IInteractables
    {
        private Rigidbody body;
        public MovementRelatedVariables mb = new MovementRelatedVariables();

        [HideInInspector]
        public bool isDead = false;
        [SerializeField]
        private Vector3 move;
        [SerializeField]
        float angle;
        float h, v;
        GameObject spawn;
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
          
        }


        void Update()
        {
           
            if (isDead != true)
            {
                Motion();
            }
        }
        public void Motion()
        {
            h = Input.GetAxisRaw("Horizontal");
            v = Input.GetAxisRaw("Vertical");

            move = h * transform.right + v * transform.forward;
        }
        private void FixedUpdate()
        {
            
            body.AddForce(move * mb.speed * Time.deltaTime * 30f, ForceMode.Acceleration);
        }
       
        #region public variables
        public void FindSlopeAngle()
        {
            RaycastHit ray;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out ray ,this.GetComponent<CapsuleCollider>().height / 2f + 0.1f))
            {
                angle = Mathf.Atan2(transform.position.x, ray.transform.position.x) * Mathf.Rad2Deg;

                Debug.Log(angle);
            }
            
        }
        public bool isMoveing()
        {
            if (h != 1 || h != -1 && v != 1 || v != -1) return true;
            else return false;
        }

        public bool isHorizontallyMoveing()
        {
            if (h != 1 || h != -1) return true;
            else return false;
        }
        #endregion


        public void Interact()
        {

        }
    }

    public abstract class PlayerGeneric : MonoBehaviour
    {
        protected PlayerMovement playerManager;
        protected int HashCode;
        private void Awake()
        {
            playerManager = GetComponent<PlayerMovement>();
            HashCode = this.GetType().GetHashCode();
        }

        public virtual void LocalFixedUpdare
        {

        }
    }
}

