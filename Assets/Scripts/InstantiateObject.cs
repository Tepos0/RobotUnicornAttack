using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class InstantiateObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectToInstantiate;

    private Stack<GameObject> _objectPool = new Stack<GameObject>();

    public void InstantiateObjectAtPosition(Transform asset)
    {
        if (_objectPool.Count > 0)
        {
            GameObject obj = _objectPool.Pop();
            obj.transform.position = asset.position;
            obj.SetActive(true);
        }
        else
        {
        GameObject obj = Instantiate(_objectToInstantiate, asset.position, Quaternion.identity);
        obj.GetComponent<ObjectFromPool>().onDesactivate.AddListener(OnObjectDeactivated);
        }
    }

    public GameObject CreateInstance()
    {
        GameObject obj;
        if(_objectPool.Count > 0)
        {
            obj = _objectPool.Pop();
            obj.SetActive(true);
        }
        else
        {
            obj = Instantiate(_objectToInstantiate, transform.position, Quaternion.identity);
            obj.GetComponent<ObjectFromPool> ().onDesactivate.AddListener(OnObjectDeactivated);
        }
        return obj;
    }
    public void OnObjectDeactivated(GameObject obj)
    {
        _objectPool.Push(obj);
    }
   
}
