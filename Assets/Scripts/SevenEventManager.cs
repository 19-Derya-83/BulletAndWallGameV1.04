using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


    public class SevenEventManager : MonoBehaviour
    {

        public static event UnityAction OnGameFinish;

        public static event UnityAction OnGameFail;

        public static void InvokeOnGameFinish()

        {

            OnGameFinish?.Invoke();

        }


        public static event UnityAction OnCollisionBullet;

        public static void InvokeOnCollisionBullet()

        {

        OnCollisionBullet?.Invoke();

        }


        public static event UnityAction<Transform> OnCollisionBulletParam; // Parametreli event e örnek 01

        public static void InvokeOnCollisionBulletParam(Transform wall)

        {

        OnCollisionBulletParam?.Invoke(wall);

        }

        public static void InvokeGameFail()

        {

        OnGameFail?.Invoke();

        }


    //public static event UnityAction<int, string> OnCollisionBulletParam2; // Parametreli event e örnek 02

    //public static void InvokeOnCollisionBulletParam(int wall, string name)

    //{

    //OnCollisionBulletParam2?.Invoke(wall, name);

    //}


}


