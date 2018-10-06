using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFlash : MonoBehaviour
{
    public GameObject selectedObject;
    public int red;
    public int green;
    public int blue;
    public bool lookingAtObject = false;
    public bool flashingIn = true;
    public bool startedFlashing = false;
 
	
	// Update is called once per frame
	void Update ()
    {
		if(lookingAtObject == true)
        {
            selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)red, (byte)green, (byte)blue, 255);
        }
	}

    void OnMouseOver()
    {
        selectedObject = GameObject.Find(CastingToObject.selectedObject);
        lookingAtObject = true;
        if(startedFlashing == false)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }

        if(selectedObject.name == "HealthPack" && Input.GetKey(KeyCode.Mouse0))
        {
            GameManager.manage.health += 50;
            startedFlashing = false;
            lookingAtObject = false;
            Destroy(selectedObject);
            
        }
    }

    void OnMouseExit()
    {
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        selectedObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
    }

    IEnumerator FlashObject()
    {
        while (lookingAtObject)
        {
            yield return new WaitForSeconds(0.05f);
            if (flashingIn == true)
            {
                if (blue <= 30)
                {
                    flashingIn = false;
                }
                else
                {
                    red -= 1;
                    green -= 25;
                }
            }
            if (flashingIn == false)
            {
                if (blue >= 250)
                {
                    flashingIn = true;
                }
                else
                {
                    red += 1;
                    green += 25;
                }
            }
        }
    }
}
