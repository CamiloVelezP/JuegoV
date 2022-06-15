using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTriggerController : MonoBehaviour
{
    [Header("Time")]
    [SerializeField] private float activeTime;
    [SerializeField] private float cooldownTime;
    private bool isCooldown;

    [Header("Text")]
    [TextArea]
    [SerializeField] private string textString;

    [Header("Controller")]
    [SerializeField] private textController textController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isCooldown)
            {
                textController.ShowText(textString, activeTime);
                StartCoroutine("Cooldown");
            }
        }
    }

    IEnumerator Cooldown()
    {
        isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isCooldown = false;
        yield return null;
    }
}
