using UnityEngine;
using UnityEngine.UI;

public class KeyScript : MonoBehaviour
{
    public GameObject inticon_k, key, Icon;
    public AudioSource pickup, warning;
    public GameObject LurkingMonster;
    public GameObject PresenceText;
    public float fadeDuration;

    private void Start()
    {
     
        SetTextAlpha(0f);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inticon_k.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                key.SetActive(false);
                Door.keyfound = true;
                inticon_k.SetActive(false);
                Icon.SetActive(true);
                pickup.Play();
                warning.Play();
                LurkingMonster.SetActive(true);

                
                ShowText("You feel a presence following you...", fadeDuration);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            inticon_k.SetActive(false);
        }
    }

    
    private void ShowText(string text, float duration)
    {
        PresenceText.SetActive(true);
        PresenceText.GetComponent<Text>().text = text;
        PresenceText.GetComponent<Text>().CrossFadeAlpha(1f, fadeDuration, false);
        Invoke("HideText", duration);
    }

    
    private void HideText()
    {
        PresenceText.GetComponent<Text>().CrossFadeAlpha(0f, fadeDuration, false);
        Invoke("DeactivateText", fadeDuration);
    }

    
    private void DeactivateText()
    {
        PresenceText.SetActive(false);
    }

    
    private void SetTextAlpha(float alpha)
    {
        PresenceText.GetComponent<Text>().canvasRenderer.SetAlpha(alpha);
    }
}
