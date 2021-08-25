using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject creationPoint;
    public GameObject finishLineTrigger;
    public GameObject finishLine;

    private int onetime = 1;


    private void Start()
    {
        finishLine.SetActive(false);
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
        Vector3 position = creationPoint.transform.position;//scriptin ekli olduğu gameobjectin konumu

        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 30f, 1 << LayerMask.NameToLayer("ground"));//sahnenin aşağısına 30f uzunluğunda ışın gönderiyoruz ve çarptığı nesneye RaycastHit2D türünde ve hit değişken adını veriyoruz. 
        //daha sonra layerMask.NameToLayer ("ground") ile diğer tüm katmanları görmesini engelliyoruz.
        Vector3 spawn_point = new Vector3(position.x, hit.point.y + 0.1f, position.z);//çarpışma noktasının 1f yukarısını spawn point olarak seçiyoruz
        finishLine.transform.position = spawn_point;//spawn pointi ekli gameobjectin konumu olarak belirliyoruz
        finishLine.SetActive(true);       
    }
}
