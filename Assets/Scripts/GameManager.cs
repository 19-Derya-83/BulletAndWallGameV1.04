using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class GameManager : MonoBehaviour
    {

        public GameObject finishParticle;

        public GameObject failParticle;

        private void OnEnable()
        {

            SevenEventManager.OnGameFinish += OpenFinishParticle;

            SevenEventManager.OnGameFail += OpenFailParticle;

    }

        private void OnDisable()
        {

            SevenEventManager.OnGameFinish -= OpenFinishParticle;

            SevenEventManager.OnGameFail -= OpenFailParticle;

        }

        public void RestartGame()

        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        private void OpenFinishParticle()

        {

            finishParticle.SetActive(true);

        }

        private void OpenFailParticle()

        {

        failParticle.SetActive(true);

        }

}


