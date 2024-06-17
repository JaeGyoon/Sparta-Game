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
        public string key;              // � ���������� Ȯ���ϱ� ���� Ű ��
        public GameObject prefab;       // ������ ������Ʈ
        public int initCount;           // �ʱ� ������ ������Ʈ ����

    }

    public List<Pool> poolList = new List<Pool>();

    public Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    public Transform parentTest;

    // �ʱ� ������Ʈ ����
    private void Awake()
    {
        foreach (Pool pool in poolList)
        {
            Queue<GameObject> queue = new Queue<GameObject> ();

            // initCount ��ŭ prefab ����
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
            Debug.Log("����");
            return null;
        }

        Debug.Log("����2");
        // ť���� ����
        GameObject obj = poolDictionary[key].Dequeue();

        // �ٽ� ���� �ļ����� ť�� ����
        poolDictionary[key].Enqueue(obj);


        Vector3 mousePoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);

        Vector3 clickPoint = Camera.main.ScreenToWorldPoint(mousePoint);


        obj.transform.position = mousePoint;

        obj.SetActive(true);

        return obj;



    }
}
