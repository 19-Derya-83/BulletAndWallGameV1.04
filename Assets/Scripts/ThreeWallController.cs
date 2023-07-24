using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



    public class ThreeWallController : MonoBehaviour
    {

        public int health;

        public Transform startPosition;

        public Transform endPosition;

        public float duration = 2f;

        private float timer;


        public float minX = -8f; // Minimum X koordinatý
        public float maxX = 8f; // Maksimum X koordinatý
        public float speed = 5f; // Hýz deðeri

        private float targetX;
        private bool isMovingRight = true;

        private Slider _slider;

        public int bulletCount2;

        private void Awake()
        {

            _slider = GetComponentInChildren<Slider>();

        }

        private void Start()
        {

            targetX = maxX;

            //transform.position = startPosition.position;

            _slider.maxValue = health;

        }

        private void Update()
        {

            //MoveLerp();

            MoveTowards();
            
        }

    

        //private void OnTriggerEnter(Collider other)
        //{

        //    TwoBulletController bulletController =  other.GetComponent<TwoBulletController>();

        //    if (bulletController != null)
        //    {

        //        Debug.Log("Bullet algýlandý");

        //        //Destroy(bulletController.gameObject);

        //        bulletController.SelfDestroy();

        //        DecreaseHealth(bulletController.damage);

        //        FiveUIManager.Instance.IncreaseDamage();

        //        UpdateSlider(bulletController.damage);

        //        if (health <= 0)
        //        {

        //            SevenEventManager.InvokeOnGameFinish();

        //            Destroy(gameObject);

        //        }

        //    }

        //}

        private void OnCollisionEnter(Collision collision)
        {

            TwoBulletController bulletController = collision.gameObject.GetComponent<TwoBulletController>();

            if (bulletController != null)
            {

                Debug.Log("Bullet algýlandý");

                //Destroy(bulletController.gameObject);
             
                SevenEventManager.InvokeOnCollisionBullet();

               //SevenEventManager.InvokeOnCollisionBulletParam(transform);

               bulletController.SelfDestroy();

               bulletController.ChangeLayer();

               //bulletController.bulletParticle.SetActive(true);

                bulletController.BulletParticleActive(transform);

                //bulletController.bulletParticle.transform.SetParent(transform);

                DecreaseHealth(bulletController.damage);

                //FiveUIManager.Instance.IncreaseDamage();

                DecreaseBulletCount(bulletController.bulletCount);

                FiveUIManager.Instance.IncreaseBulletCount();

                UpdateSlider(bulletController.damage);

                if (health <= 0)
                {

                    SevenEventManager.InvokeOnGameFinish();

                    Destroy(gameObject);

                }

            }

        }

        private void DecreaseHealth( int decreaseAmount)

        {

            health -= decreaseAmount;

        }

        private void DecreaseBulletCount(int decreaseBulletCount)

       {

        bulletCount2 -= decreaseBulletCount;

        }

    private void MoveLerp()

        {

            timer += Time.deltaTime;

            float t = timer / duration; // Normalize the time between 0 aand 1

            // Smoothly interpolate between the start and end positions

            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, t);

            if (t >= 1f)
            {

                //The movement is complete, swap start and positions for the return journey

                Transform temp = startPosition;

                startPosition = endPosition;
                endPosition = temp;

                timer = 0f;

            }

        }

        private void MoveTowards()

        {

            // Hedef X koordinatýna doðru ilerleme
            transform.position = Vector3.MoveTowards(transform.position,
                new Vector3(targetX, transform.position.y, transform.position.z),
                speed * Time.deltaTime);

            // Hedef X koordinatýna ulaþýldýðýnda yön deðiþtirme
            if (Mathf.Approximately(transform.position.x, targetX))
            {
                if (isMovingRight)
                {
                    targetX = minX;
                }
                else
                {
                    targetX = maxX;
                }

                isMovingRight = !isMovingRight;
            }

        }

        private void UpdateSlider(int damage)

        {

            _slider.value += damage;

        }

    }


