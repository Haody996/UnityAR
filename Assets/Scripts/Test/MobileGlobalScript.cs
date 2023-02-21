using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MyFirstARGame
{
    public class MobileGlobalScript : MonoBehaviourPunCallbacks
    {

        private GameObject nm;
        private NetworkCommunication nc;
        private GameObject objToDelete;
        public Button resultButton;
        public Button restartButton;
        private bool waitForRes = false;
        void Start()
        {
            objToDelete = GameObject.Find("ObjectsToDelete");
            resultButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(false);
        }
        void Update()
        {

            if (nm == null)
            {
                nm = GameObject.Find("NetworkManager(Clone)");
                if(nm != null)
                {
                    nc = nm.GetComponent<NetworkCommunication>();
                }
            }
            else
            {

                if (waitForRes)
                {
                    if (!nc.waitForRes)
                    {
                        resultButton.GetComponentInChildren<Text>().text = "";
                        restartButton.GetComponentInChildren<Text>().text = "";
                        resultButton.gameObject.SetActive(false);
                        restartButton.gameObject.SetActive(false);
                        cleanScene();
                        waitForRes = false;
                        nc.waitForRes = true;
                    }
                }
                else
                {
                    if (nc.shooterWins || nc.shooterLose)
                    {
                        if (nc.shooterWins)
                        {
                            resultButton.GetComponentInChildren<Text>().text = "Shooter Wins!\nDefender Lose!";
                            restartButton.GetComponentInChildren<Text>().text = "Restart";
                            resultButton.gameObject.SetActive(true);
                            restartButton.gameObject.SetActive(true);
                        }
                        else
                        {
                            resultButton.GetComponentInChildren<Text>().text = "Defender Wins!\nShooter Lose!";
                            restartButton.GetComponentInChildren<Text>().text = "Restart";
                            resultButton.gameObject.SetActive(true);
                            restartButton.gameObject.SetActive(true);
                        }
                        waitForRes = true;
                    }
                    else if (nc.gameStart)
                    {
                        nc.minusTime(Time.deltaTime);
                        if (nc.score >= 30)
                        {
                            nc.shooterWinsTrue();
                        }
                        else if (nc.timeLeft <= 0f)
                        {
                            nc.shooterLoseTrue();
                        }
                    }
                }
            }

            
        }

        public void startTheGame()
        {
            if(nm != null)
            {
                nm.GetComponent<NetworkCommunication>().startTheGame();
            }
            else
            {
                Debug.Log("Fail to start the game!");
            }
        }

        void cleanScene()
        {
            if (nm != null)
            {
                foreach (Transform child in objToDelete.transform)
                {
                    PhotonNetwork.Destroy(child.gameObject);
                }
            }
        }

        public void ResumeGame()
        {
            nc.waitForRespondEnd();
            nc.restartTheGame();
            nc.cleanSceneTrue();
            nc.noWinNoLose();
        }
    }
}
