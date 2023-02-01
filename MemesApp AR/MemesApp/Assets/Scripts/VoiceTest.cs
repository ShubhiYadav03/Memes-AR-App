using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(VoiceController))]
public class VoiceTest : MonoBehaviour {

    public TextMeshProUGUI uiText;

    VoiceController voiceController;

    public void GetSpeech() {
        voiceController.GetSpeech();
    }

    void Start() {
        voiceController = GetComponent<VoiceController>();
    }

    void OnEnable() {
        VoiceController.resultRecieved += OnVoiceResult;
    }

    void OnDisable() {
        VoiceController.resultRecieved -= OnVoiceResult;
    }

    void OnVoiceResult(string text) {
        uiText.text = text;
    }
}
