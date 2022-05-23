using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinOrLose : MonoBehaviour
{
    bool start;
    bool win;
    float timer;
    void Start()
    {
        start = false;
        win = false;
    }

    private void Update()
    {
        if (start)
        {
            if (!win)
            {
                SceneManager.LoadScene("LooseScene");
                Cursor.lockState = CursorLockMode.None;

            }
            else
            {
                timer += Time.deltaTime;
                if (timer > 3)
                {
                    SceneManager.LoadScene("WinScene");
                    Cursor.lockState = CursorLockMode.None;

                }
            }

        }
    }

    public void startWinOrLose(bool win_)
    {
        win = win_;
        start = true;
    }
}
