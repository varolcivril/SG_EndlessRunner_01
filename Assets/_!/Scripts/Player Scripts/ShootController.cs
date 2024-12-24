using System.Collections;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    //[SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifetime = 5f;
    [SerializeField] float baseFireRate = 0.5f; //0.2f;

    //[SerializeField] bool useAI;
    //[SerializeField] float firingRateVariance = 0f;
    //[SerializeField] float minimumFiringRate = 0.1f;

    public bool isFiring = true;

    Coroutine fireCoroutine;

    private void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if (isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = ObjectPool.SharedInstance.GetPooledBulletObject(); //Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            if (instance != null)
            {
                instance.transform.position = transform.position;
                instance.transform.rotation = transform.rotation;
                instance.SetActive(true);
                Rigidbody rb = instance.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.velocity = transform.forward * projectileSpeed;
                }
                StartCoroutine(DeactivateProjectile(instance)); //Destroy(instance, projectileLifetime);
            }


            //float timeToNextProjectile = Random.Range(baseFireRate - firingRateVariance, baseFireRate + firingRateVariance);
            //timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);

            yield return new WaitForSeconds(baseFireRate);
        }
    }

    private IEnumerator DeactivateProjectile(GameObject gameObject)
    {
        yield return new WaitForSeconds(projectileLifetime);
        gameObject.SetActive(false);
    }
}
