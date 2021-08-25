using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFuel : MonoBehaviour
{
    public GameObject creationPoint;
    public Transform gasStationPoint;
    public GameObject gasStation;

    private int onetime=1;


    private void Start()
    {
        gasStation.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Yerlestirici();
        }
    }

    public void Yerlestirici()//coinlerin yerleştirilieceği konumları belirler
    {
        Vector3 position =creationPoint.transform.position;//scriptin ekli olduğu gameobjectin konumu
        Debug.Log("position: " + position);
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 30f, 1 << LayerMask.NameToLayer("ground"));//sahnenin aşağısına 30f uzunluğunda ışın gönderiyoruz ve çarptığı nesneye RaycastHit2D türünde ve hit değişken adını veriyoruz. 
                                                                            //daha sonra layerMask.NameToLayer ("ground") ile diğer tüm katmanları görmesini engelliyoruz.
        Debug.Log("hit point position: " + hit.point);
        Vector3 spawn_point = new Vector3(position.x, hit.point.y + 3f, position.z);//çarpışma noktasının 1f yukarısını spawn point olarak seçiyoruz
        Debug.Log("spawn_point: " + spawn_point);
        gasStation.transform.position = spawn_point;//spawn pointi ekli gameobjectin konumu olarak belirliyoruz
        gasStation.SetActive(true);
        
    }

}
