namespace MyFirstARGame
{
    using Photon.Pun;
    using UnityEngine;
    
    /// <summary>
    /// You can use this class to make RPC calls between the clients. It is already spawned on each client with networking capabilities.
    /// </summary>
    public class NetworkCommunication : MonoBehaviourPun
    {
        public int score = 0;
        public bool gameStart = false;
        public float timeLeft = 90f;
        public bool cleanScene = false;
        public bool waitForRes = true;
        public bool shooterWins = false;
        public bool shooterLose = false;
        public bool largeSoccer = false;
        private PhotonView PV;

        void Start()
        {
            PV = GetComponent<PhotonView>();
            waitForRes = true;
        }

        public void addScore()
        {
            PV.RPC("RPC_addScore", RpcTarget.All);
        }

        [PunRPC]
        void RPC_addScore()
        {
            score++;
        }

        public void resetScore()
        {
            PV.RPC("RPC_resetScore", RpcTarget.All);
        }

        [PunRPC]
        void RPC_resetScore()
        {
            score = 0;
        }

        public void startTheGame()
        {
            PV.RPC("RPC_startTheGame", RpcTarget.All);
        }

        [PunRPC]
        void RPC_startTheGame()
        {
            gameStart = true;
        }

        public void restartTheGame()
        {
            PV.RPC("RPC_restartTheGame", RpcTarget.All);
        }

        [PunRPC]
        void RPC_restartTheGame()
        {
            gameStart = false;
        }

        public void minusTime(float val)
        {
            PV.RPC("RPC_minusTime", RpcTarget.All, val);
        }

        [PunRPC]
        void RPC_minusTime(float val)
        {
            timeLeft -= val;
        }

        public void setTime(float val)
        {
            PV.RPC("RPC_setTime", RpcTarget.All, val);
        }

        [PunRPC]
        void RPC_setTime(float val)
        {
            timeLeft = val;
        }

        public void cleanSceneTrue()
        {
            PV.RPC("RPC_cleanSceneTrue", RpcTarget.All);
        }

        [PunRPC]
        void RPC_cleanSceneTrue()
        {
            cleanScene = true;
        }

        public void cleanSceneFalse()
        {
            PV.RPC("RPC_cleanSceneFalse", RpcTarget.All);
        }

        [PunRPC]
        void RPC_cleanSceneFalse()
        {
            cleanScene = false;
        }

        public void waitForRespond()
        {
            PV.RPC("RPC_waitForRespond", RpcTarget.All);
        }

        [PunRPC]
        void RPC_waitForRespond()
        {
            waitForRes = true;
        }

        public void waitForRespondEnd()
        {
            PV.RPC("RPC_waitForRespondEnd", RpcTarget.All);
        }

        [PunRPC]
        void RPC_waitForRespondEnd()
        {
            waitForRes = false;
        }

        public void shooterWinsTrue()
        {
            PV.RPC("RPC_shooterWinsTrue", RpcTarget.All);
        }

        [PunRPC]
        void RPC_shooterWinsTrue()
        {
            shooterWins = true;
        }

        public void shooterLoseTrue()
        {
            PV.RPC("RPC_shooterLoseTrue", RpcTarget.All);
        }

        [PunRPC]
        void RPC_shooterLoseTrue()
        {
            shooterLose = true;
        }

        public void noWinNoLose()
        {
            PV.RPC("RPC_noWinNoLose", RpcTarget.All);
        }

        [PunRPC]
        void RPC_noWinNoLose()
        {
            shooterWins = false;
            shooterLose = false;
        }

        public void shootLargeSoccer()
        {
            PV.RPC("RPC_shootLargeSoccer", RpcTarget.All);
        }

        [PunRPC]
        void RPC_shootLargeSoccer()
        {
            largeSoccer = true;
        }

        public void shootLargeSoccerEnd()
        {
            PV.RPC("RPC_shootLargeSoccerEnd", RpcTarget.All);
        }

        [PunRPC]
        void RPC_shootLargeSoccerEnd()
        {
            largeSoccer = false;
        }
    }

}