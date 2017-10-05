using System;
using System.ComponentModel;

#if ENABLE_UNET

namespace UnityEngine.Networking
{
    [AddComponentMenu("Network/NetworkManagerHUD")]
    [RequireComponent(typeof(NetworkManager))]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NetworkManagerHUD2 : MonoBehaviour
    {
        public NetworkManager manager;
        [SerializeField]
        public bool showGUI = true;
        [SerializeField]
        public int offsetX;
        [SerializeField]
        public int offsetY;

        // Runtime variable
        bool m_ShowServer;

        void Awake()
        {
            manager = GetComponent<NetworkManager>();
        }

        void Update()
        {
            if (!showGUI)
                return;

            if (!manager.IsClientConnected() && !NetworkServer.active && manager.matchMaker == null)
            {
                if (UnityEngine.Application.platform != RuntimePlatform.WebGLPlayer)
                {
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        manager.StartServer();
                    }
                    if (Input.GetKeyDown(KeyCode.H))
                    {
                        manager.StartHost();
                    }
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    manager.StartClient();
                }
            }
            if (NetworkServer.active && manager.IsClientConnected())
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    manager.StopHost();
                }
            }
        }

        void OnGUI()
        {
            if (!showGUI)
                return;

            int xpos = 50 + offsetX;
            int ypos = 40 + offsetY;
            const int spacing = 50;

            bool noConnection = (manager.client == null || manager.client.connection == null ||
                                 manager.client.connection.connectionId == -1);

            if (!manager.IsClientConnected() && !NetworkServer.active && manager.matchMaker == null)
            {
                if (noConnection)
                {
                 
                    if (GUI.Button(new Rect(xpos, ypos, 800, 200), "LAN Client(C)"))
                    {
                        manager.StartClient();
                        
                    }
                    ypos = ypos + 250;
                    manager.networkAddress = GUI.TextField(new Rect(xpos + 440, ypos, 505, 100), manager.networkAddress);
                    ypos += spacing;

                    
                }
                else
                {
                    GUI.Label(new Rect(xpos, ypos, 400, 40), "Connecting to " + manager.networkAddress + ":" + manager.networkPort + "..");
                    ypos += spacing;


                    if (GUI.Button(new Rect(xpos, ypos, 400, 40), "Cancel Connection Attempt"))
                    {
                        manager.StopClient();
                    }
                }
            }
            else
            {
                if (NetworkServer.active)
                {
                    string serverMsg = "Server: port=" + manager.networkPort;
                    if (manager.useWebSockets)
                    {
                        serverMsg += " (Using WebSockets)";
                    }
                    GUI.Label(new Rect(xpos, ypos, 400, 40), serverMsg);
                    ypos += spacing;
                }
                if (manager.IsClientConnected())
                {
                    GUI.Label(new Rect(xpos, ypos, 400, 40), "Client: address=" + manager.networkAddress + " port=" + manager.networkPort);
                    ypos += spacing;
                }
            }

            if (manager.IsClientConnected() && !ClientScene.ready)
            {
                if (GUI.Button(new Rect(xpos, ypos, 400, 40), "Client Ready"))
                {
                    ClientScene.Ready(manager.client.connection);

                    if (ClientScene.localPlayers.Count == 0)
                    {
                        ClientScene.AddPlayer(0);
                    }
                }
                ypos += spacing;
            }


        }
    }
}
#endif //ENABLE_UNET