using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
public class menu_handler : MonoBehaviour
{
    AudioSource adi;
    [SerializeField] Canvas loading_lvel;
    [SerializeField] Canvas menu_canvas;
    [SerializeField] AudioClip click;
    [SerializeField] GameObject menu_ui;
    [SerializeField] GameObject player;
    [SerializeField] Canvas ammo;
    [SerializeField] Canvas aim_canva;
    setting_handler setting;
    how_to_play tut;
    credit_ui cred;
    private void Start()
    {
        adi = GetComponent<AudioSource>();
        setting = FindObjectOfType<setting_handler>();
        tut = FindObjectOfType<how_to_play>();
        cred = FindObjectOfType<credit_ui>();
    }

    public void resume()
    {
        player.SetActive(true);
        menu_ui.SetActive(false);
        aim_canva.enabled = true;
        ammo.enabled = true;
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void menu()
    {
        gameObject.SetActive(true);
    }
    public void play()
    {
        adi.PlayOneShot(click);
        SceneManager.LoadScene(4);
    }

    public void settings()
    {
        adi.PlayOneShot(click);
      //  menu_canvas.enabled = false;
        setting.sett();
    }
     public void howto_play()
    {
        adi.PlayOneShot(click);
        tut.hoto();
        menu_canvas.enabled = false;
    }
    public void credits()
    {
        adi.PlayOneShot(click);
        menu_canvas.enabled = false;
        cred.credit();
    }
    public void quuiti()
    {
        adi.PlayOneShot(click);
        Application.Quit();
    }
    public void loadlevel()
    {
        adi.PlayOneShot(click);
        menu_canvas.enabled = false;
        loading_lvel.enabled = true;
    }
    public void restart_level()
    {
        adi.PlayOneShot(click);
        Time.timeScale = 1;
        int currentsceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentsceneindex);
    }
    public void tomenu()
    {
        adi.PlayOneShot(click);
        SceneManager.LoadScene(3);
    }
}

