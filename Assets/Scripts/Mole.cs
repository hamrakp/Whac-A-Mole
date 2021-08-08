using UnityEngine;

public class Mole : MonoBehaviour
{
    public float visible = 3f;
    public float hidden = -10f;
    public float speed = 60f;
    public float disappearDuration = 5f;
    public bool visibleMole;
    public bool visibleMidMole;
    public bool visibleHighMole;

    private float disappearTimer = 1f;
    private Vector3 wantedPosition;

    void Awake()
    {

        visibleMole = false;
        visibleMidMole = false;
        visibleHighMole = false;

        wantedPosition = new Vector3(
            transform.localPosition.x,
            visible,
            transform.localPosition.z);

    }

    // Update is called once per frame
    void Update()
    {
        
        disappearTimer -= Time.deltaTime;

        if (disappearTimer <= 0f)
        {
            Hide();
           
        }
        // Linear interpolation for smooth movement
        transform.localPosition = Vector3.Lerp(transform.localPosition, wantedPosition, Time.deltaTime*2);
        isVisible();
        isMidVisible();
        isHighVisible();
        notVisible();

    }

    public void Rise()// Method for moving an object to a visible position
    {
        wantedPosition = new Vector3(
            transform.localPosition.x,
            visible,
            transform.localPosition.z);

        disappearTimer = disappearDuration;
    }

    public void Hide()// Method for moving an object to a position where the player cannot see it
    {

        wantedPosition = new Vector3(
            transform.localPosition.x,
            hidden,
            transform.localPosition.z);
    }

    public void isVisible()
    {
        if (transform.localPosition.y >= 1.3f)
        {
            visibleMole = true;
            visibleHighMole = false;
            visibleMidMole = false;
        }
    }

    public void isMidVisible()
    {

        if (transform.localPosition.y >= 0.1f && transform.localPosition.y <= 1.29f)
        {
            visibleMole = false;
            visibleMidMole = true;
            visibleHighMole = false;
        }
    }

    public void isHighVisible()
    {
        if (transform.localPosition.y >= -1.01f && transform.localPosition.y <= -0.09f)
        {

            visibleMole = false;
            visibleMidMole = false;
            visibleHighMole = true;
        }
    }

    public void notVisible()
    {
        if (transform.localPosition.y <= -1f)
        {

            visibleMole = false;
            visibleHighMole = false;
            visibleMidMole = false;
        }
    }

    public void particlesEnableHit()// Method for triggering the effect of the particles system component
    {

        GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = true;
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(new Color(255, 100, 100));// Creating a new red color

    }

    public void particlesMidEnableHit()// Method for triggering the effect of the particles system component
    {

        GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        // Play the default color value and Particles System component values
    }

    public void particlesHighEnableHit()// Method for triggering the effect of the particles system component
    {        

        GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = true;
        ParticleSystem.MainModule settings = GetComponent<ParticleSystem>().main;
        settings.startColor = new ParticleSystem.MinMaxGradient(new Color(100, 255, 100));// Creating a new green color

    }
}
