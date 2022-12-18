using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Profiling;

namespace Sample
{
    public class TesterBase : MonoBehaviour
    {
        public string sampleId = "tester";
        public KeyCode testKey = KeyCode.A;
        public float pauseWait = 0;
        
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
            StartCoroutine(StopApplication());
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