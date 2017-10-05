using System;
using System.ComponentModel;

#if ENABLE_UNET

namespace UnityEngine.Networking
{
    public class AutomaticServer : MonoBehaviour
    {
        public NetworkManager manager;
    

        // Runtime variable
         void Awake()
        {
            manager = GetComponent<NetworkManager>();
            manager.StartServer();
        }

    }
}
#endif //ENABLE_UNET