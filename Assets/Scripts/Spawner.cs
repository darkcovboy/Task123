using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    [SerializeField] private Transform _path;
    [SerializeField] private bool isWorking;
    private Transform[] _spawners;
    private int _spawnPoint = 0;

    private void Start()
    {
        _spawners = new Transform[_path.childCount];

        for(int i =0; i < _path.childCount; i++)
        {
            _spawners[i] = _path.GetChild(i);
        }

        var fareJob = StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        while(isWorking)
        {
            Transform spawner = _spawners[_spawnPoint];

            GameObject gameObject = Instantiate(Enemy);

            Transform newObjectTransform = gameObject.GetComponent<Transform>();

            newObjectTransform.position = spawner.position;
            _spawnPoint++;

            if (_spawnPoint > _spawners.Length - 1)
            {
                _spawnPoint = 0;
            }

            yield return new WaitForSecondsRealtime(2f);
        }
    }
}
