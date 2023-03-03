using System;
using System.Reflection;
using UnityEngine;

namespace DefaultNamespace
{
    public class Bootstrap : MonoBehaviour
    {
        public NetworkBehaviourTest NetworkBehaviour;

        public void Awake()
        {
            Type type = NetworkBehaviour.GetType();
            foreach (MethodInfo methodInfo in type.GetRuntimeMethods())
            {
                Debug.Log("Start without inherit: " + methodInfo.Name);
                // If the inherit = false, it works
                if (methodInfo.IsDefined(typeof(CustomAttribute), false))
                {
                    Debug.Log("Do without inherit: " + methodInfo.Name);
                }
                Debug.Log("End without inherit: " + methodInfo.Name);

                Debug.Log("Start with inherit: " + methodInfo.Name);
                // If the inherit = true and there is a "NetworkInitialize___Early" method, the game crashes in IL2CPP build on Adroid
                if (methodInfo.IsDefined(typeof(CustomAttribute), true))
                {
                    Debug.Log("Do with inherit: " + methodInfo.Name);
                }
                Debug.Log("End with inherit: " + methodInfo.Name);

            }
        }
    }
}