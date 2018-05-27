using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIListener : MonoBehaviour
{
    public void updateHealth(float percent)
    {
        RectTransform healthBack = this.transform.Find("HP_Background").transform.Find("HP_Red").GetComponent<RectTransform>();
        RectTransform healthBar = this.transform.Find("HP_Background").transform.Find("HP_Red").transform.Find("HP_Green").GetComponent<RectTransform>();
        healthBar.sizeDelta = new Vector2(healthBack.rect.width * percent, healthBar.sizeDelta.y);

    }

    public void updateAmmunition(float percent)
    {
        RectTransform ammoBar = this.transform.Find("Ammunition").GetComponent<RectTransform>();
        RectTransform greyout = this.transform.Find("Ammunition").transform.Find("Greyout").GetComponent<RectTransform>();
        greyout.sizeDelta = new Vector2(2*ammoBar.rect.width * (1f - percent) , greyout.sizeDelta.y);

        if (percent == 0 || percent == 1)
        {
            RectTransform reloadText = this.transform.Find("Reloading").GetComponent<RectTransform>();
            reloadText.gameObject.SetActive(percent == 0);
        }
    }
}