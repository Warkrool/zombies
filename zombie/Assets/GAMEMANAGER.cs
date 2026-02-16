using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class GAMEMANAGER : MonoBehaviour
{
    public GameObject selectedZombie;

    public GameObject[] zombies;

    public Vector3 selectedSize;

    InputAction left, right, up;
    
    public Vector3 pushForce;
    
    private int selectedIndex = 0;

    public TMP_Text timerText;

    private float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        selectZombie( 0);
        left = InputSystem.actions.FindAction("PrevZombie");
        right = InputSystem.actions.FindAction("NextZombie");
        up = InputSystem.actions.FindAction("Jump");
    }
    void selectZombie(int index)
    {
        if (selectedZombie != null) ;
        selectedZombie.transform.localScale = Vector3.one;
        selectedZombie = zombies[index];
        selectedZombie.transform.localScale = selectedSize;
    }
    // Update is called once per frame
    void Update()
    {
        if (left.triggered)
        {
            selectedIndex--;
            if (selectedIndex <0)
                selectedIndex = zombies.Length - 1;
            selectZombie(selectedIndex);
        }
        
        if (right.triggered)
        {
            selectedIndex++;
            if(selectedIndex >= zombies.Length)
                selectedIndex = 0;
            selectZombie(selectedIndex);
        }

        if (up.triggered)
        {
            Rigidbody rb = selectedZombie.GetComponent<Rigidbody>();
            rb.AddForce(pushForce);
            Debug.Log("jump");
        }
        time += Time.deltaTime;
        timerText.text = "Time: " + time.ToString("F1") + "s";

    }
}
