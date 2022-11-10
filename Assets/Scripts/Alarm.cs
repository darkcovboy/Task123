using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isAlarmWorking = false;
    private readonly float recoveryRate = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            isAlarmWorking = true;
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            audioSource.volume = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        audioSource.Play();
        isAlarmWorking =false;
    }

    private void Update()
    {
        if (isAlarmWorking == true)
        {
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, audioSource.maxDistance, recoveryRate * Time.deltaTime);
        }
        else
        {
            audioSource.volume = Mathf.MoveTowards(audioSource.volume, audioSource.maxDistance, recoveryRate * Time.deltaTime * (-1));
        }
    }
}
