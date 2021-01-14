﻿///Louie Williamson
///This scripts shows the mobile ui if necessary

using UnityEngine;

public class UIManager_LouieWilliamson : MonoBehaviour
{
    public GameObject mobileWpnUI;
    public GameObject mobileBtnUI;
    public GameObject normalUI;
    public GameObject mobileJoystickUI;
    public GameObject vendingMachine;

    void Start()
    {
        vendingMachine.SetActive(false);
        SetMobileUI(false);

        if (Application.isMobilePlatform)
        {
            SetMobileUI(true);
        }
    }
    void SetMobileUI(bool ShownIfTrue)
    {
        mobileWpnUI.SetActive(ShownIfTrue);
        mobileBtnUI.SetActive(ShownIfTrue);
        mobileJoystickUI.SetActive(ShownIfTrue);
        normalUI.SetActive(!ShownIfTrue);
    }
}
