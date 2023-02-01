using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoogleService : MonoBehaviour
{
    public PictureFactory pictureFactory;

    public TextMeshProUGUI ResultedText; 

    private const string APIkey = "AIzaSyDVxREDiELW1ELJ6mpavmbuCL6JEJyX_Gs";
    // Start is called before the first frame update
    public void GetPicture(){
        StartCoroutine(PictureRoutine());
    }

    IEnumerator PictureRoutine(){
        //ResultedText.transform.parent.gameObject
        string query = ResultedText.text;
        query = WWW.EscapeURL(query + "memes");
        pictureFactory.DeleteOldPictures();
        Vector3 cameraForward = Camera.main.transform.forward;

        int rowNum = 1;
        for(int i = 1; i <= 60; i+= 10){
            string url ="https://customsearch.googleapis.com/customsearch/v1?cx=354fa66beafcf4c9c&filter=1&num=10&q=" + query + "&searchType=image&start=" + i + "&fields=items%2Flink&key=" + APIkey;
            WWW www = new WWW(url);
            yield return www;
            pictureFactory.CreateImages(ParseResponse(www.text), rowNum, cameraForward);
            rowNum++;
        }

        yield return new WaitForSeconds(5f);
    }

    List<string> ParseResponse(string text){
        List<string> urlList = new List<string>();
        string[] urls = text.Split('\n');
        foreach (string line in urls){
            if(line.Contains("link")){
                
                string url = line.Substring(15, line.Length - 16);
                // Debug.Log(url);
                if(url.Contains(".jpg") || url.Contains(".png")){
                    urlList.Add(url);
                    
                }
            }
        }
        
        return urlList;
    }
}
