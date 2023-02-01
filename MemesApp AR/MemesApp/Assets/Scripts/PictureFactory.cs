using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureFactory : MonoBehaviour
{
    public GameObject pickPrefab;
    public GoogleService googleService;
    // Start is called before the first frame update
    public void DeleteOldPictures(){
        if(transform.childCount > 0){
            foreach(Transform child in this.transform){
                Destroy(child.gameObject);
            }
        }
    }

    public void CreateImages(List<string> urlList, int resultnum, Vector3 cameraForward){
        int pickNum = 1;
        Vector3 center = Camera.main.transform.position;
        foreach(string url in urlList){
            Vector3 pos = GetPosition(pickNum, resultnum, cameraForward);
            GameObject pic = Instantiate(pickPrefab, pos, Quaternion.identity, this.transform);
            pic.GetComponent<PictureBehaviour>().LoadImage(url);
            pickNum++;

        }
        
    }
     Vector3 GetPosition(int pickNum, int rowNum, Vector3 cameraForward){
        Vector3 pos = Vector3.zero;
        if(pickNum <= 5){
            pos = cameraForward + new Vector3(pickNum * -3, 0, rowNum * 3.5f);
        }
        else
        {
            pos = cameraForward + new Vector3((pickNum % 5) * 3, 0, rowNum * 3.5f);
        }
        return pos;
     }

}
