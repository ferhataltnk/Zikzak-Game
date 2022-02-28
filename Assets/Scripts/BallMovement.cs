using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    AudioSource audioSource;
   public AudioClip diamondSound;

    Vector3 yon;
    public float topHizi;
    public FloorSpawner floorSpawnScripti; /*zemin oluşturma kodunu kullanacaım için FloorSpawner classından nesne oluşturur gibi scripti tanıştırıyoruz aslında.Inspector panelinden scripti içeren bir objeyi sürükle bırakla ekleyeceğim*/
    public static bool dustuMu; /*Static tanımladım çünkü her yerden erişmem gerekiyor ve tek veri olmalı sadece*/
    public Transform floorTransform;
    public ParticleSystem coinParticle;
    public float eklenecekHiz;
    public GameObject gameOverPanel;

    public MenuScript menuScript;
    void Start()
    {
        menuScript = FindObjectOfType<MenuScript>().GetComponent<MenuScript>();
        audioSource = GetComponent<AudioSource>();
        yon = Vector3.forward;
        dustuMu = false;
        
        
    }

    void Update()
    {
     


        if(transform.position.y < floorTransform.position.y-1f)
        {
            dustuMu = true;
        }

        if(dustuMu == true)
        {
            Debug.Log("Düşüş gerçekleşti");
            gameOverPanel.SetActive(true);
            return;
        }
        else
        {
            if (Input.GetMouseButtonDown(0)) /*Tıkladıktan sonra elimi kaldırmazsam da bir kez yapar.GetMouseButton deseydim basılı tuttukça komut yenilenecekti*/
            {
                if (yon.x == 0) /*yönümün x değeri sıfır ve z değeri atıyorsa*/
                {
                    yon = Vector3.left;

                }
                else
                {
                    yon = Vector3.forward;


                }
                topHizi += eklenecekHiz * Time.deltaTime;  /*Her tıklandığında hız artacak*/

            }
        }
          
        topHizi += 0.001f * Time.deltaTime;    /*zaman geçtitkçe de artacak*/
    }

    private void FixedUpdate()
    {
        Vector3 hareket = yon * Time.deltaTime * topHizi;
        transform.position += hareket;
    }


   
    private void OnCollisionExit(Collision collision)
    {
      


        if (collision.gameObject.tag == "Floor")
        {
            collision.gameObject.AddComponent<Rigidbody>();  /*Zeminle temas sağlanıp ayrılır ayrılmaz o zemine rigidbody ekleyecek böylece zemin yere düşecek ağırlıkla.*/
            floorSpawnScripti.createFloor();
            StartCoroutine(FloorDestruct(collision.gameObject));  /*Yani burada start coroutine ile FloorSpawner classındaki IEnumeratoru çağırıyorum.Parametre olarak da collisiondan çıtıktan sonra objeyi yolluyorum.IE numeratore gidecek ve o obje 3f sonra yok edilecek. */
            
        }
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            audioSource.clip = diamondSound;
            audioSource.Play();
            Instantiate(coinParticle,transform.position,Quaternion.identity);
            Score.skor += 10;
            other.gameObject.SetActive(false);

        }
    }



    IEnumerator FloorDestruct(GameObject destructFloor)
    {
        yield return new WaitForSeconds(3f);
        Destroy(destructFloor);    /*IEnumeratorlar içerisinde zaman kullanılacaksa kullanılan fonksiyonlardır.yield return ile 3f kadar beklediktetn sonra sonrasında yazılan fonksiyonu çağırır.*/
    }




}
