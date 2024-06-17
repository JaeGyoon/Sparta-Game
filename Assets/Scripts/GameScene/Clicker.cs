using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public int point = 0;
    public TextMeshProUGUI pointTxt;

    IEnumerator coroutine;

    public float autoTick = 1f;

    public int oneClickPoint = 1;

    public int upgradePoint = 25;

    public TextMeshProUGUI upgradeTxt;

    // Start is called before the first frame update
    void Start()
    {
        upgradeTxt.text = upgradePoint.ToString();

        coroutine = AutoClick();
        StartCoroutine(coroutine);
    }
       

    public void Click()
    {
        point += oneClickPoint;

        pointTxt.text = point.ToString();

        Debug.Log("클릭 되어짐");
    }

    public IEnumerator AutoClick()
    {
        while (true)
        {
            Click();

            yield return new WaitForSeconds(autoTick);
        }
    }

    public void OnClickUpgrade()
    {
        if (point < upgradePoint)
        {
            Debug.Log("비용이 부족합니다.");
        }
        else
        {
            point -= upgradePoint;

            oneClickPoint *= 2;
            upgradePoint *= 2;

            pointTxt.text = point.ToString();
            upgradeTxt.text = upgradePoint.ToString();
        }
    }

}
