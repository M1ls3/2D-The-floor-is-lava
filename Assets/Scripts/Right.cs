using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Right : MonoBehaviour
{
    public PlayerMoving playerMoving;
    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        //playerMoving = GetComponent<PlayerMoving>();
        button.onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    void OnClick()
    {
        playerMoving.toRight = true;
    }
}
