using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics.Contracts;


[Serializable]
public class ObjectPool : MonoBehaviour
{
    [Serializable]
    public class Pool
    {
        public string key;              // 어떤 프리팹인지 확인하기 위한 키 값
        public GameObject prefab;       // 프리팹 오브젝트
        public int initCount;           // 초기 생성할 오브젝트 갯수

    }

    public List<Pool> poolList = new List<Pool>();

    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public Transform parentTest;

    // 초기 오브젝트 생성
    private void Awake()
    {
        foreach (Pool pool in poolList)
        {
            Queue<GameObject> queue = new Queue<GameObject> ();

            // initCount 만큼 prefab 생성
            for ( int i = 0;  i < pool.initCount; i++ )
            {
                GameObject obj = Instantiate(pool.prefab);

                //obj.transform.parent = parentTest;

                obj.transform.SetParent(parentTest);

                obj.SetActive(false);
                queue.Enqueue (obj);
            }

            poolDictionary.Add (pool.key, queue);
        }
    }


    
    public GameObject SpawnObject(string key)
    {
        if (poolDictionary.ContainsKey(key) == false )
        {
            Debug.Log("잉잉");
            return null;
        }

        Debug.Log("잉잉2");
        // 큐에서 꺼냄
        GameObject obj = poolDictionary[key].Dequeue();

        // 다시 가장 후순위로 큐에 넣음
        poolDictionary[key].Enqueue(obj);


        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        Vector3 clickPoint = Camera.main.ScreenToWorldPoint(mousePoint);


        obj.transform.position = mousePoint;

        obj.SetActive(true);

        return obj;



    }
}
