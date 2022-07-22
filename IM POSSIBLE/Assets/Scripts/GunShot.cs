using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShot : MonoBehaviour
{
    private AudioSource gunShotSound;
    public GameObject rightShot;
    public GameObject leftShot;


    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;
    public int whichSide = 0;

    // Start is called before the first frame update
    void Start()
    {
        gunShotSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            StartCoroutine(Shaking());
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot() {
        if (whichSide == 0)
        {
            rightShot.SetActive(true);
            whichSide = 1;
        }
        else
        {
            leftShot.SetActive(true);
            whichSide = 0;
        }
        gunShotSound.Play();
        yield return new WaitForSeconds(0.1f);
        rightShot.SetActive(false);
        leftShot.SetActive(false);
    }

    IEnumerator Shaking() { 
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }
}
