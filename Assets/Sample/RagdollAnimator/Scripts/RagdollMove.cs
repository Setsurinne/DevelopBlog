using UnityEngine;

namespace JxSample.RagdollAnimator
{
    public class RagdollMove : MonoBehaviour
    {
        #region Attributes
        public float Speed = 10f;
        public Rigidbody Hip;
        public Animator Animator;
        #endregion

        #region Update
        
        void FixedUpdate()
        {
            Vector3 direction = GetTransformInput();
            if (direction.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
                ChangeRotation(targetAngle);
                Move(direction * Speed);
            }
            else
            {
                StopMove();
            }
        }
        #endregion

        #region Input
        
        private Vector3 GetTransformInput()
        {
            return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
        }
        
        #endregion

        #region Moving
        
        /// <summary>
        /// To move the character, add force in the hip, and play animation
        /// </summary>
        /// <param name="force"></param>
        private void Move(Vector3 force)
        {
            Hip.AddForce(force);
            Animator.SetBool("IsMove", true);
        }

        private void StopMove()
        {
            Animator.SetBool("IsMove", false);
        }
        
        /// <summary>
        /// To change the rotation of the character, we modify targetRotation of the Hip
        /// </summary>
        /// <param name="targetAngle"></param>
        private void ChangeRotation(float targetAngle)
        {
            Hip.angularVelocity = Vector3.zero;
            Hip.GetComponent<ConfigurableJoint>().targetRotation = Quaternion.Euler(0f, targetAngle, 0f);
        }
        
        #endregion
    }
}
