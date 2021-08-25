using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
   
    public Transform triggerPoint;// MainCAmera üzerindeki enpoint noktası
    public GameObject diamond;

    private int onetime=1;
    private int randomNumber;


    private void Start()
    {
        diamond.SetActive(false);
        randomNumber = Random.Range(1, 8);
    }

    private void Update()
    {
        if (transform.position.x < triggerPoint.transform.position.x /*&& transform.position.x > maxPoint.position.x*/)
        {
            if (onetime == 1)//update içinde yalnızca bir kez çalışmasını sağlıyor
            {
                if (randomNumber==1)
                {
                    Yerlestirici();
                }
                onetime = 2;
            }

        }
    }

    public void Yerlestirici()//almasların yerleştirilieceği konumları belirler
    {
            Vector3 position = transform.position;//scriptin ekli olduğu gameobjectin konumu

            RaycastHit2D hit = Physics2D.Raycast(position, Vector2.down, 30f);//sahnenin aşağısına 30f uzunluğunda ışın gönderiyoruz ve çarptığı nesneye RaycastHit2D türünde ve hit değişken adını veriyoruz. 

                if (hit.collider.gameObject.tag == "ground")//ground taglı nesneye çarptığı zaman işlem olmasını istiyoruz
                {
                    Vector3 spawn_point = new Vector3(position.x, hit.point.y + 1.5f, position.z);//çarpışma noktasının 1f yukarısını spawn point olarak seçiyoruz
                
                    diamond.transform.position = spawn_point;//spawn pointi ekli gameobjectin konumu olarak belirliyoruz
                    diamond.SetActive(true);
                }            
    }
}
