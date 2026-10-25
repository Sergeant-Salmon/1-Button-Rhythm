using UnityEngine;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public KeyCode keyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);

                //GameManager.instance.NoteHit();

                if(Mathf.Abs(transform.position.y) > 0.25)
                {
                    Debug.Log("hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y) > 0.05f)
                {
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                    Debug.Log("good hit");
                    GameManager.instance.GoodHit();
                }
                else
                {
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                    Debug.Log("perfect hit");
                    GameManager.instance.PerfectHit();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator" && gameObject.activeSelf)
        {
            canBePressed = false;

            GameManager.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
