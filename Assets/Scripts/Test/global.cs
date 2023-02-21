using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Random = System.Random;

namespace MyFirstARGame
{
    public class global : MonoBehaviourPunCallbacks
    {
        private float UpgradeTimer = 0f;
				public static bool isLargeSoccer = false;
        private float count = 0f;
        private bool startOut = true;
        private ExitGames.Client.Photon.Hashtable customProperty = new ExitGames.Client.Photon.Hashtable();
        
        private GameObject objToDelete;
        private GameObject nm;
        private NetworkCommunication nc;

        private float largeSoccerBallTime = -16f;
        
        void Start()
        {
            customProperty["score"] = 0;
            customProperty["gameStart"] = false;
            customProperty["timeValue"] = 90f;
            isLargeSoccer = false;
            UpgradeTimer = 0.0f;
            count = 0f;
            startOut = true;
            objToDelete = GameObject.Find("ObjectsToDelete");
            NetworkLauncher.Singleton.JoinedRoom += this.createStadium;
        }

        public void createStadium(NetworkLauncher sender)
        {
            PhotonNetwork.Instantiate("Stadion_02", new Vector3(0f, 0f, 0f), Quaternion.identity);
            PhotonNetwork.Instantiate("goal Variant 1", new Vector3(2.58f, 0f, 0f), Quaternion.Euler(-90f, 0f, -90f));
            PhotonNetwork.Instantiate("PersistentManager", new Vector3(0f, 0f, 0f), Quaternion.identity);
            PhotonNetwork.CurrentRoom.SetCustomProperties(customProperty);
        }

        // Update is called once per frame
        void Update()
        {
            

            if (nm == null)
            {
                nm = GameObject.Find("NetworkManager(Clone)");
                if (nm != null)
                {
                    nc = nm.GetComponent<NetworkCommunication>();
                }
            }
            else
            {
                if (nc.gameStart)
                {
                    UpgradeTimer += Time.deltaTime;
                    largeSoccerBallTime += Time.deltaTime;
                    if (UpgradeTimer > 15.0f)
                    {
                        nc.shootLargeSoccer();
                        UpgradeTimer = 0f;
                        largeSoccerBallTime = 0f;
                        var rand = new Random();
                        PhotonNetwork.Instantiate("PowerUpgradeAttack", new Vector3(rand.Next(-2, 2), 0.25f, rand.Next(-2, 2)), Quaternion.identity).transform.parent = objToDelete.transform;
                        PhotonNetwork.Instantiate("PowerUpgradeDefense", new Vector3(rand.Next(-2, 2), 0.25f, rand.Next(-2, 2)), Quaternion.identity).transform.parent = objToDelete.transform;
                    }
                    if(largeSoccerBallTime > 3f)
                    {
                        largeSoccerBallTime = -16f;
                        nc.shootLargeSoccerEnd();
                    }
                }
                if (nc.cleanScene)
                {
                    nc.cleanSceneFalse();
                    CleanScene();
                }
            }
        }

        void CleanScene()
        {
            if(nm != null)
            {
                foreach (Transform child in objToDelete.transform)
                {
                    PhotonNetwork.Destroy(child.gameObject);
                }
                nc.setTime(90f);
                nc.resetScore();
            }
        }
    }
}
