using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class randomGame : MonoBehaviour
{
    public int numberOfGift = 6;
    public float timeRotate;
    public float numberCircleRotate;

    private const float Circle = 360;
    private float angleOfGift;

    public Transform parrent;
    private float currentTime;
    public AnimationCurve curve;

    private void Start()
    {
        angleOfGift = Circle / numberOfGift;
    }

    IEnumerator rotateSpin()
    {
        float startArrow = transform.eulerAngles.z;
        currentTime = 0;

        int indexGiftRandom = Random.Range(1, numberOfGift);
        Debug.Log(indexGiftRandom);

        float spinWant = (numberCircleRotate * Circle) + angleOfGift * indexGiftRandom - startArrow;

        while (currentTime < timeRotate)
        {
            yield return new WaitForEndOfFrame();
            currentTime += Time.deltaTime;

            float angleCurrent = spinWant * curve.Evaluate(currentTime / timeRotate);
            this.transform.eulerAngles = new Vector3(0, 0, angleCurrent + startArrow);
        }
    }

    [ContextMenu("Rotate")]
    void rotateNow()
    {
        StartCoroutine(rotateSpin());
    }


}
