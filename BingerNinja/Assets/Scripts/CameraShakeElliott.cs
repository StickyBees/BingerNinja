﻿//Elliott Desouza
/// this script makes the main camara shake

//Elliott 07/10/2020 - implented the shake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShakeElliott : MonoBehaviour
{
   public IEnumerator Shake (float duration, float magnitude)
   {
        Vector3 orgignalPos = transform.localPosition;

        float elapsed = 0.0f;

        while(elapsed <duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = new Vector3(x, y, orgignalPos.z);

            elapsed += Time.deltaTime;
            
            yield return null;
        }
        transform.localPosition = orgignalPos;
   }
}
