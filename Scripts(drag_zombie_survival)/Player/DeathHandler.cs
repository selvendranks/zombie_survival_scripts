using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Canvas DeathCanvas;
    [SerializeField] GameObject wepon;
    [SerializeField] GameObject aim;

    private void Start()
    {
        DeathCanvas.enabled = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void death()
    {
        DeathCanvas.enabled = true;
        Time.timeScale = 0;
     //   FindObjectOfType<WeponSwitch>().enabled = false;
       // FindObjectOfType<wepon_single>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        aim.SetActive(false);
        wepon.SetActive(false);
    }
}
