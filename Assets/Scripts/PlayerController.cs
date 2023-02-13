using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float forwardInput;
    private Rigidbody _rigidbody;
    private GameObject focalPoint;
    private bool hasPowerup;
    private bool hasPowerup2;
    private float powerUpForce = 15f;
    public GameObject[] powerupIndicators;
    private float originalScale = 1.5f;
    private float powerupScale = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());

        }

        if (other.gameObject.CompareTag("Powerup_2"))
        {
            hasPowerup2 = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDown());

        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position).normalized;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }
    private IEnumerator PowerupCountDown()
    {
        for(int i = 0; i < powerupIndicators.Length; i++)
        {
            if (hasPowerup2)
            {
                transform.localScale = powerupScale * Vector3.one;
            }
            powerupIndicators[i].SetActive(true);
            yield return new WaitForSeconds(2);
            powerupIndicators[i].SetActive(false);
        }

        if (hasPowerup2)
        {
            transform.localScale = originalScale * Vector3.one;
        }
        hasPowerup = false;
        hasPowerup = false;

    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }
    private void Update()
    {
        forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * speed * forwardInput);
        
    }

}
