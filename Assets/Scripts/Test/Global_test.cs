using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class Global_test : MonoBehaviour
    {
        private float timeInterval = 0f;
        public GameObject ballPrefab;
        private float count = 0f;
        private bool startOut = true;
        // Start is called before the first frame update
        void Start()
        {
            NetworkLauncher.Singleton.JoinedRoom += this.createStadium;
        }

        public void createStadium(NetworkLauncher sender)
        {
            //PhotonNetwork.Instantiate("Stadion_02", new Vector3(0f, 0f, 0f), Quaternion.identity);
            PhotonNetwork.Instantiate("goal Variant 1", new Vector3(2.58f, 0f, 0f), Quaternion.Euler(-90f, 0f, -90f));
            //PhotonNetwork.Instantiate("goal Variant 1", new Vector3(1.58f, 0f, 0f), Quaternion.Euler(-90f, 0f, -90f));
        }

        // Update is called once per frame
        void Update()
        {
            timeInterval += Time.deltaTime;
            if (timeInterval > 1.0f)
            {
                //PhotonNetwork.Instantiate("Soccer Ball Variant", new Vector3(0f, 0f + count, 0f), Quaternion.identity);
                timeInterval = 0.0f;
                count += 0.5f;
                if (startOut)
                {
                    //PhotonNetwork.Instantiate("goal 1 Variant", new Vector3(0f, 0f, 0f), Quaternion.identity);
                    startOut = false;
                }
            }
        }
    }
}
