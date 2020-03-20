using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//FearGauge
//Increase Fear Value From GameManager method -> increaseFearValue(float)
public class FearGauge : MonoBehaviour {

	public Slider fearGauge;
    public GameManager GameManager;

	void Start() {
        GameManager = FindObjectOfType<GameManager>();
        if(GameManager != null){
            initFearGauge();
        }
	}

    void Update() {
       setFearValue(GameManager.getFearValue());
    }

    private void initFearGauge() {
		if(fearGauge != null){
			fearGauge.value = 0;
		}
	}
	private void setFearValue(float value) {
		fearGauge.value = value;
	}
}
