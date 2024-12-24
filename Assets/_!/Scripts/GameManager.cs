using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //static public event Action onLevelGeneration;

    public Vector3 spawnPosition = new Vector3(0, 0, 0);
    public bool isGenerating = true;


    Coroutine newLevelCoroutine;

    private void OnEnable()
    {
        DamageWallController.isPlayerDead += PlayerDead;
    }
    private void Update()
    {
        NewLevel();
    }
    private void NewLevel()
    {
        
        if (isGenerating && newLevelCoroutine == null)
        {
            newLevelCoroutine = StartCoroutine(GenerateNewLevel());

        }
        else if (!isGenerating && newLevelCoroutine != null)
        {
            StopCoroutine(newLevelCoroutine);
            newLevelCoroutine = null;
        }
    }
    private void PlayerDead()
    {
        SceneManager.LoadScene(0);
    }

    private IEnumerator GenerateNewLevel()
    {
        while (true)
        {

            GameObject instance = ObjectPool.SharedInstance.GetPooledLevelObject(); //Instantiate(selection[selectionNum], new Vector3(0, 0, zPosition), Quaternion.identity);
            if (instance != null)
            {
                instance.transform.position = spawnPosition;
                instance.transform.rotation = transform.rotation;
                for (int i = 0; i < instance.transform.GetChild(1).childCount; i++)
                {
                    instance.transform.GetChild(1).GetChild(i).gameObject.SetActive(true);
                }
                instance.SetActive(true);
                //onLevelGeneration?.Invoke();
                spawnPosition.z += 100;
                StartCoroutine(DeactivateLevel(instance));
            }

            yield return new WaitForSeconds(12);
        }
    }

    private IEnumerator DeactivateLevel(GameObject gameObject)
    {
        yield return new WaitForSeconds(60);
        gameObject.SetActive(false);
        //Destroy(gameObject);
    }

    private void OnDisable()
    {
        DamageWallController.isPlayerDead -= PlayerDead;

    }
}
