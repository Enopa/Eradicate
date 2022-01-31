using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboSystem : MonoBehaviour
{
    public GameObject ultCounter;
    private TMPro.TextMeshProUGUI ults;

    private float newAmount;
    private float comboTimer;

    // Start is called before the first frame update
    void OnEnable()
    {
        ults = ultCounter.GetComponent<TMPro.TextMeshProUGUI>();
        newAmount = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Image>().fillAmount >= 1)
        {
            GetComponent<Image>().fillAmount = 0;
            int numUlts = int.Parse(ults.text) + 1;
            ults.text = string.Format("{0}", numUlts);
            newAmount = 0;
            comboTimer = 0;
        }


        if (newAmount != GetComponent<Image>().fillAmount)
        {
            comboTimer = 3;
            newAmount = GetComponent<Image>().fillAmount;
        }
        if (GetComponent<Image>().fillAmount > 0)
        {
            comboTimer -= Time.deltaTime;
            
        }
        if (comboTimer <= 0)
        {
            GetComponent<Image>().fillAmount = 0;
            newAmount = 0;
        }

        


    }
}
