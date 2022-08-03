using System.Collections.Generic;
using UnityEngine;

namespace Shooter
{
    public class PlayerMovement : MonoBehaviour
    {


        [SerializeField]
        private Rigidbody rb;
        [SerializeField]
        private Transform groundCheck, cealingCheck;

        private float h;
        private float v;
        private Vector3 move;


        private List<PlayerGeneric> Behaviours;
        private List<PlayerGeneric> OverridingBehaviours;

        private int DefaultBehaviours;
        private int ActiveBehaviour;
        private int BehaviourLocked;

        private void Awake()
        {
            Behaviours = new List<PlayerGeneric>();
            OverridingBehaviours = new List<PlayerGeneric>()
        }

        public void SubscribeBehaviour(PlayerGeneric behaviour)
        {
            Behaviours.Add(behaviour);
        }

        public void InitialiseDefaultBehaviours(int behaviourCode)
        {
            DefaultBehaviours = behaviourCode;
            ActiveBehaviour = behaviourCode;
        }


    }

    public abstract class PlayerGeneric : MonoBehaviour
    {
        protected PlayerMovement Manager;
        protected int HashCode;

        private void Awake()
        {
            Manager = this.GetComponent<PlayerMovement>();

            HashCode = GetType().GetHashCode();
        }

        public virtual void LocalFixedUpdate() { }
        
        public virtual void LocalLateUpdate() { }
       
        public virtual void OnOverride() { }

        public int GetBehaviourCode()
        {
            return HashCode;
        }
    }
}
/*private Rigidbody body;
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
            FindSlopeAngle();
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
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out ray, this.GetComponent<CapsuleCollider>().height / 2f + 0.1f))
            {
                angle = (Mathf.Atan2(transform.position.x, ray.transform.position.x) * Mathf.Rad2Deg)-90f;

                
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

        }*/