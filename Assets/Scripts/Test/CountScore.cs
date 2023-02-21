using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
namespace MyFirstARGame
{
    public class countScoreScript : MonoBehaviourPunCallbacks
    {

        public int score = 0;
        private GameObject nm;
        private NetworkCommunication nc;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if(nm == null)
            {
                nm = GameObject.Find("NetworkManager(Clone)");
                if(nm != null)
                {
                    nc = nm.GetComponent<NetworkCommunication>();
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Ball") || other.CompareTag("Projectile"))
            {
                if (nm != null)
                {
                    if (nc.gameStart)
                    {
                        nc.addScore();
                        PhotonNetwork.Destroy(other.gameObject);
                    }
                }
            }
        }
    }
}
