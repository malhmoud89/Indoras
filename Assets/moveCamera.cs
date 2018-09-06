using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveCamera : MonoBehaviour {

    float timerX;
    float timerY;
    bool isSticky;
    Vector3 cameraOffSet;
    public GameObject player;
	// Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = -1;
        cameraOffSet = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            isSticky = !isSticky;
        }
        if (!isSticky)
        {
            if (Input.mousePosition.x > Screen.width * .9f)
            {
                timerX += Time.deltaTime;
                if (timerX > 0.25f)
                    transform.position = transform.position + (new Vector3(5f, 0) * Time.smoothDeltaTime);
            }
            else
            {
                if (Input.mousePosition.x < Screen.width * .1f)
                {
                    timerX += Time.deltaTime;
                    if (timerX > 0.25f)
                        transform.position = transform.position - (new Vector3(5f, 0) * Time.smoothDeltaTime);
                }
                else
                {
                    timerX = 0;
                }
            }


            if (Input.mousePosition.y > Screen.height * .9f)
            {
                transform.position = transform.position + (new Vector3(0, 0, 5f) * Time.smoothDeltaTime);
            }
            else
            {
                if (Input.mousePosition.y < Screen.height * .1f)
                {
                    transform.position = transform.position - (new Vector3(0, 0, 5f) * Time.smoothDeltaTime);
                }
            }

        }
        else
        {
            transform.position = player.transform.position + cameraOffSet;

        }
    }
}
