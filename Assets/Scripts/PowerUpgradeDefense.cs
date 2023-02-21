using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace MyFirstARGame
{
    public class PowerUpgradeDefense : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

				void OnCollisionEnter(Collision collision){
					Collider collider = collision.collider;
					if (collider.CompareTag("Projectile")){
						PhotonNetwork.Destroy(gameObject);
					}
					if (collider.CompareTag("Ball")){
						//defense get the attack resouce
						MyFirstARGame.global.isLargeSoccer = true;
						Debug.Log(MyFirstARGame.global.isLargeSoccer);
						PhotonNetwork.Destroy(gameObject);
					}
				}
			
    }
}
