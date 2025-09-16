# Program Demo

![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/demo.gif)

# Steps
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/1.PNG)
```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
        private Rigidbody rb;
        // Start is called on the frame when a script is enabled just before any of the Update methods is called the first time.
        protected void Start()
        {
                rb = GetComponent<Rigidbody>();
        }
        // This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
        protected void FixedUpdate()
        {
                rb.velocity =
                new Vector3(Input.GetAxisRaw("Horizontal"),rb.velocity.y,0)* 6 ;
        }
}
```

---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/2.PNG)
```csharp
// Camera
private float currentRotation = 0;
void Update()
        {
                currentRotation =
                (Input.GetAxisRaw("Mouse Y") * (400f * Time.deltaTime) * -1)
                        + currentRotation;

                transform.rotation = Quaternion.Euler(new Vector3(currentRotation,0,0));
    }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/3.PNG)

```csharp
// Camera
currentRotation = Mathf.Clamp(currentRotation, -50, 50);
```
---

![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/4.PNG)
```csharp
// Bow
protected void Update()
        {
                if (Input.GetMouseButtonDown(0)){ Debug.Log("fire"); }
                // Input.GetButtonDown("Fire1")
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/5.PNG)
```csharp
// Bow
public GameObject Arrow;
public GameObject mainCamera;
protected void Update()
        {
                if ( Input.GetButtonDown("Fire1") )
                {
                Instantiate(Arrow,
                transform.position,
                mainCamera.transform.rotation);
                }
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/6.PNG)
```csharp
// Arrow
Rigidbody rb ;

void Start()
{
        rb = GetComponent<Rigidbody>();
        // rb.AddForce(new Vector3(0, 0, 100)); for World axis
        rb.AddRelativeForce(new Vector3(0, 0, 1500)); // for Self axis
}
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/7.PNG)
```csharp
protected void Start()
        {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Confined;
                                        ...
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/8.PNG)
```csharp
// Arrow
protected void OnCollisionEnter(Collision collisionInfo)
        {
                Destroy(this.gameObject);
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/9.PNG)
```csharp
// Bow
public GameObject Arrow;
public GameObject mainCamera;
private GameObject ArrowInstance;

protected void Update()
        {
        if ( Input.GetButtonDown("Fire1") && ArrowInstance == null )
                {
                        ArrowInstance = Instantiate(Arrow,
                        transform.position, mainCamera.transform.rotation);
                }
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/10.PNG)
```csharp
// Arrow
public GameObject effectBurst;
    protected void OnCollisionEnter(Collision collisionInfo)
        {
        Instantiate(effectBurst,transform.position,Quaternion.identity);
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/11.PNG)
```csharp
// GameManager
public class GameManager : MonoBehaviour
{
        public static int CurrentScore;
}
```

```csharp
// Rings
public GameObject effectBurst;
        public int point;
    protected void OnCollisionEnter(Collision collisionInfo)
        {
                Instantiate(effectBurst,transform.position,Quaternion.identity);
                GameManager.CurrentScore = point + GameManager.CurrentScore;
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/12.PNG)
```csharp
// PointDisplay
using TMPro;

public class PointDisplay : MonoBehaviour
{
        private TextMeshProUGUI ScoreText;

        void Start()
        {
                ScoreText = GetComponent<TextMeshProUGUI>();
        }
    void Update()
        {
                ScoreText.text = GameManager.CurrentScore.ToString();
    }
}
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/13.PNG)
```csharp
public class GameManager : MonoBehaviour
{
        public static int CurrentScore;
        public static float power;
}
```

```csharp
// Bow
private float fireRate = 0.2f;
private float nextFireTime = 0f;

protected void Update()
{
        if ( Input.GetButton("Fire1") && Time.time >= nextFireTime)        {
        nextFireTime = Time.time + fireRate;
        GameManager.power = GameManager.power + Time.deltaTime + 0.2f;
        }

        if ( Input.GetButtonUp("Fire1") && ArrowInstance == null )
        {
                ...
        }
}
```

![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/14.PNG)
```csharp
// Arrow
void Start()
    {
        rb = GetComponent<Rigidbody>();
            // rb.AddForce(new Vector3(0, 0, 100)); for World axis
        rb.AddRelativeForce(new Vector3(0, 0, 1500)*GameManager.power); // for Self axis
    }

protected void OnCollisionEnter(Collision collisionInfo)
        {
        Destroy(this.gameObject);
        GameManager.power = 0;
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/15.PNG)
```csharp
// Bow
if ( Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
        nextFireTime = Time.time + fireRate;
        GameManager.power =
        Mathf.Clamp(GameManager.power + Time.deltaTime + 0.2f,
        0, 1);
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/16.PNG)
```csharp
// Slider
private UnityEngine.UI.Slider slider;

void Start()
    {
            slider = GetComponent<UnityEngine.UI.Slider>();
    }

void Update()
    {
            slider.value = GameManager.power;
    }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/17.PNG)
```csharp
// Arrow
protected void FixedUpdate()
        {
                transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/18.PNG)
```csharp
// Bow
private bool IsDecreasing = false;

protected void Update()
        {
        if ( Input.GetButton("Fire1") && Time.time >= nextFireTime && IsDecreasing == false )
                {
                nextFireTime = Time.time + fireRate;
                GameManager.power =
                        Mathf.Clamp(GameManager.power + Time.deltaTime + 0.15f,
                                0, 1);
                        if ( GameManager.power == 1 )
                        {
                                IsDecreasing = true;
                        }
                }
                else if ( Input.GetButton("Fire1") && Time.time >= nextFireTime && IsDecreasing )
                {
                nextFireTime = Time.time + fireRate;
                GameManager.power =
                        Mathf.Clamp(GameManager.power - Time.deltaTime - 0.15f,
                                0, 1);
                        if ( GameManager.power == 0 )
                        {
                                IsDecreasing = false;
                        }
                }

                if ( Input.GetButtonUp("Fire1") && ArrowInstance == null )
                {
                ArrowInstance = Instantiate(Arrow, transform.position,
                mainCamera.transform.rotation);
                }
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/19.PNG)
```csharp
// Timer
private TMPro.TextMeshProUGUI text;
void Start()
    {
            text = GetComponent<TextMeshProUGUI>();
    }

private int limitTime = 60;
void Update()
    {
            text.text = (limitTime - Time.time).ToString();
    }
```
---

Warrnig: `Look rotation viewing vector is zero`
`UnityEngine.Quaternion:LookRotation (UnityEngine.Vector3)`
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/20.PNG)
```csharp
protected void FixedUpdate()
        {
                if ( rb.velocity == new Vector3(0, 0, 0))
                {
                        return;
                }
                else
                {
                        transform.rotation = Quaternion.LookRotation(rb.velocity);
                }
        }
```
---
![](https://github.com/Poyamohamadi/Arrows_Away/blob/main/image/21.PNG)
```csharp
private TMPro.TextMeshProUGUI text;

void Start()
{
        text = GetComponent<TextMeshProUGUI>();
        GameManager.isShoot = true;
}

private float limitTime = 30;
private float nowTime;
private float waitTime;
public GameObject panelGameOver;

void Update()
{  
        nowTime =
        Mathf.Round(Mathf.Clamp(( limitTime - Time.time),0,60));
        text.text = nowTime.ToString();
        if( nowTime == 0 )
        {  
                if (waitTime >= Time.time)
                {
                panelGameOver.SetActive(true);
                GameManager.isShoot = false;
                GameManager.CurrentScore = 0;
                }
                else
                {
                panelGameOver.SetActive(false);
                GameManager.isShoot = true;
                limitTime = 30 + Time.time;
         }
        }
        else
        {
        waitTime = Time.time + 4;
         }
}
```

