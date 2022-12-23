using UnityEngine;


namespace JxSample.RagdollAnimator
{
    
    public class RagdollAnimationSync : MonoBehaviour
    {
        [SerializeField] private Transform targetLimb;
        [SerializeField] private bool enableCopy = true;
        private ConfigurableJoint ConfigurableJoint;


        Quaternion targetInitialRotation;
        // Start is called before the first frame update
        void Awake()
        {
            this.ConfigurableJoint = this.GetComponent<ConfigurableJoint>();
            this.targetInitialRotation = this.targetLimb.transform.localRotation;
        }

        private void FixedUpdate() {
            if (!enableCopy)
            {
                return;
            }
            
            // Copy the rotation
            ConfigurableJoint.targetRotation = copyRotation();
        }
        
        private Quaternion copyRotation() {
            return Quaternion.Inverse(this.targetLimb.localRotation) * this.targetInitialRotation;
        }
    }
}
