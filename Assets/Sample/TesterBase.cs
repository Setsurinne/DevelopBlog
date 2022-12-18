using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

namespace Sample
{
    public class TesterBase : MonoBehaviour
    {
        [Header("Key to trigger the test")]
        public KeyCode testKey = KeyCode.A;

        [Header("If need to pause the application after trigger testing?")]
        public bool doPauseAfterTest = true;
        
        [Header("Time before pause the application")]
        public float pauseWait = 0;
        //public string sampleId = "tester";

        private void Update()
        {
            if (Input.GetKeyUp(testKey))
            {
                RunTest();
            }
        }

        [ContextMenu("RunTest")]
        public void RunTest()
        {
            //Profiler.BeginSample(sampleId);
            
            DoTest();

            if (doPauseAfterTest)
            {
                StartCoroutine(StopApplication());
            }
            
            //Profiler.EndSample();
        }

        public virtual void DoTest()
        {
            
        }

        protected virtual IEnumerator StopApplication()
        {
            yield return new WaitForSeconds(pauseWait);
            EditorApplication.isPaused = true;
        }
    }
}