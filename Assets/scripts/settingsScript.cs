using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class settingsScript : MonoBehaviour
{
    public GameObject pad1 , pad2;
    public Text padSize;
    public static int pad_size = 1;
    private void Start()
    {
        pad_size = PlayerPrefs.GetInt("padSize" , 1);

    }
    public void increasePadSize(){
        pad_size = PlayerPrefs.GetInt("padSize" , 1);
        Debug.Log(pad_size);

        if(pad_size <= 4 && pad_size >= 1){
            pad_size ++;
            PlayerPrefs.SetInt("padSize" , pad_size);
            padSize.text = pad_size.ToString();
            pad1.transform.localScale = new Vector3(pad1.transform.localScale.x + 0.1f , pad1.transform.localScale.y + 0.1f , pad1.transform.localScale.z + 0.1f);
            pad2.transform.localScale = new Vector3(pad2.transform.localScale.x + 0.1f , pad2.transform.localScale.y + 0.1f , pad2.transform.localScale.z + 0.1f);
        }
    }

    public void decreasePadSize(){
                pad_size = PlayerPrefs.GetInt("padSize" , 1);
        Debug.Log(pad_size);

        if(pad_size <= 5 && pad_size >= 2){
            pad_size--;
            PlayerPrefs.SetInt("padSize" , pad_size);
            padSize.text = pad_size.ToString();
            pad1.transform.localScale = new Vector3(pad1.transform.localScale.x - 0.1f , pad1.transform.localScale.y - 0.1f , pad1.transform.localScale.z - 0.1f);
            pad2.transform.localScale = new Vector3(pad2.transform.localScale.x - 0.1f , pad2.transform.localScale.y - 0.1f , pad2.transform.localScale.z - 0.1f);
        }
    }
}
