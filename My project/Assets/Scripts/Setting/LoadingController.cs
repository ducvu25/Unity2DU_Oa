using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float delta = 0.4f;
    [SerializeField] ShowMessage showMessage;
    float _delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0;
        showMessage.ShowLoop("...");
    }

    // Update is called once per frame
    void Update()
    {
        if(_delta > 0)
        {
            _delta -= Time.deltaTime;
        }
        else
        {
            _delta = delta;
            if((int)Random.Range(0, 2) == 1)
            {
                slider.value += Random.Range(0, 0.1f);
                if(slider.value >= slider.maxValue)
                {
                    SceneManager.LoadScene(SettingController.nameMap[(int)IndexMap.manHinhChinh]);
                }
            }
        }
    }
}
