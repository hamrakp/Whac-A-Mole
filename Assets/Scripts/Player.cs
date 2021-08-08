using UnityEngine;

[RequireComponent(typeof(AudioSource))]
// Pridanie komponentu audio
public class Player : MonoBehaviour
{
    public int score = 0;
    public bool Switch = false;
    public Mole mole;
    public GameObject Mole1;
    public GameObject Mole2;
    public GameObject Mole3;
    public GameObject Mole4;
    public GameObject Mole5;
    public GameObject Mole6;
    public GameObject Mole7;
    public GameObject Mole8;
    public GameObject Mole9;
    public GameObject Mole;
    public AudioClip hit;
    public float stress = 0.1f;

    StressReceiver stressReceiver;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        // Assign tags to Mole objects
        Mole1 = GameObject.FindWithTag("Mole1"); 
        Mole2 = GameObject.FindWithTag("Mole2");
        Mole3 = GameObject.FindWithTag("Mole3");
        Mole4 = GameObject.FindWithTag("Mole4");
        Mole5 = GameObject.FindWithTag("Mole5");
        Mole6 = GameObject.FindWithTag("Mole6");
        Mole7 = GameObject.FindWithTag("Mole7");
        Mole8 = GameObject.FindWithTag("Mole8");
        Mole9 = GameObject.FindWithTag("Mole9");
        Mole = GameObject.FindWithTag("Mole");

        // Assign the audio component to the audioSource variable
        audioSource = GetComponent<AudioSource>();
        stressReceiver = GetComponent<StressReceiver>();
        // Condition if the audio component is not created, it will create it

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    // OnGUI is a method called multiple times per frame, allowing immediate response when a key is pressed
    public void OnGUI()
    {
        // LEFT SIDE
        if (Event.current.Equals(Event.KeyboardEvent("Q")))// Condition if the event is currently executed by pressing the Q key
        {
                if (Mole9.GetComponent<Mole>().visibleMole == true && Mole9.GetComponent<Mole>().visibleMidMole == false && Mole9.GetComponent<Mole>().visibleHighMole == false)
                // Condition if the Mole object is fully visible and not in another position
                {

                    Mole9.GetComponent<Mole>().particlesEnableHit();// Call the particlesEnableHit method for the given Mole object
                    stressReceiver.InduceStress(stress);// Call the method, for the shake effect
                    Mole9.GetComponent<Mole>().Hide();// Call a method to return the Mole object to its initial position
                    audioSource.PlayOneShot(hit);// Call a method for the sound effect of an intervention
                    score++;// Increment score

                }

                if (Mole9.GetComponent<Mole>().visibleMidMole == true && Mole9.GetComponent<Mole>().visibleMole == false && Mole9.GetComponent<Mole>().visibleHighMole == false)
                {

                    Mole9.GetComponent<Mole>().particlesMidEnableHit();
                    stressReceiver.InduceStress(stress);
                    Mole9.GetComponent<Mole>().Hide();
                    audioSource.PlayOneShot(hit);
                    score = score + 2;
                }

                if (Mole9.GetComponent<Mole>().visibleHighMole == true && Mole9.GetComponent<Mole>().visibleMidMole == false && Mole9.GetComponent<Mole>().visibleMole == false)
                {

                    Mole9.GetComponent<Mole>().particlesHighEnableHit();
                    stressReceiver.InduceStress(stress);
                    Mole9.GetComponent<Mole>().Hide();
                    audioSource.PlayOneShot(hit);
                    score = score + 3;
                }
        }

        if (Event.current.Equals(Event.KeyboardEvent("W")))
        {
            if (Mole8.GetComponent<Mole>().visibleMole == true && Mole8.GetComponent<Mole>().visibleMidMole == false && Mole8.GetComponent<Mole>().visibleHighMole == false)
            {
                Mole8.GetComponent<Mole>().particlesEnableHit();
                stressReceiver.InduceStress(stress);
                Mole8.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score++;

            }

            if (Mole8.GetComponent<Mole>().visibleMidMole == true && Mole8.GetComponent<Mole>().visibleMole == false && Mole8.GetComponent<Mole>().visibleHighMole == false)
            {

                Mole8.GetComponent<Mole>().particlesMidEnableHit();
                stressReceiver.InduceStress(stress);
                Mole8.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 2;
            }

            if (Mole8.GetComponent<Mole>().visibleHighMole == true && Mole8.GetComponent<Mole>().visibleMidMole == false && Mole8.GetComponent<Mole>().visibleMole == false)
            {

                Mole8.GetComponent<Mole>().particlesHighEnableHit();
                stressReceiver.InduceStress(stress);
                Mole8.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 3;
            }
        }

        if (Event.current.Equals(Event.KeyboardEvent("E")))
        {
            if (Mole7.GetComponent<Mole>().visibleMole == true && Mole7.GetComponent<Mole>().visibleMidMole == false && Mole7.GetComponent<Mole>().visibleHighMole == false)
            {
                Mole7.GetComponent<Mole>().particlesEnableHit();
                stressReceiver.InduceStress(stress);
                Mole7.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score++;

            }

            if (Mole7.GetComponent<Mole>().visibleMidMole == true && Mole7.GetComponent<Mole>().visibleMole == false && Mole7.GetComponent<Mole>().visibleHighMole == false)
            {

                Mole7.GetComponent<Mole>().particlesMidEnableHit();
                stressReceiver.InduceStress(stress);
                Mole7.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 2;
            }

            if (Mole7.GetComponent<Mole>().visibleHighMole == true && Mole7.GetComponent<Mole>().visibleMidMole == false && Mole7.GetComponent<Mole>().visibleMole == false)
            {

                Mole7.GetComponent<Mole>().particlesHighEnableHit();
                stressReceiver.InduceStress(stress);
                Mole7.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 3;
            }
        }

        if (Event.current.Equals(Event.KeyboardEvent("R")))
        {
            if (Mole6.GetComponent<Mole>().visibleMole == true && Mole6.GetComponent<Mole>().visibleMidMole == false && Mole6.GetComponent<Mole>().visibleHighMole == false)
            {
                Mole6.GetComponent<Mole>().particlesEnableHit();
                stressReceiver.InduceStress(stress);
                Mole6.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score++;

            }

            if (Mole6.GetComponent<Mole>().visibleMidMole == true && Mole6.GetComponent<Mole>().visibleMole == false && Mole6.GetComponent<Mole>().visibleHighMole == false)
            {

                Mole6.GetComponent<Mole>().particlesMidEnableHit();
                stressReceiver.InduceStress(stress);
                Mole6.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 2;
            }

            if (Mole6.GetComponent<Mole>().visibleHighMole == true && Mole6.GetComponent<Mole>().visibleMidMole == false && Mole6.GetComponent<Mole>().visibleMole == false)
            {

                Mole6.GetComponent<Mole>().particlesHighEnableHit();
                stressReceiver.InduceStress(stress);
                Mole6.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 3;
            }
        }

        if (Event.current.Equals(Event.KeyboardEvent("V")))
        {
            if (Mole5.GetComponent<Mole>().visibleMole == true && Mole5.GetComponent<Mole>().visibleMidMole == false && Mole5.GetComponent<Mole>().visibleHighMole == false)
            {
                Mole5.GetComponent<Mole>().particlesEnableHit();
                stressReceiver.InduceStress(stress);
                Mole5.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score++;

            }

            if (Mole5.GetComponent<Mole>().visibleMidMole == true && Mole5.GetComponent<Mole>().visibleMole == false && Mole5.GetComponent<Mole>().visibleHighMole == false)
            {

                Mole5.GetComponent<Mole>().particlesMidEnableHit();
                stressReceiver.InduceStress(stress);
                Mole5.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 2;
            }

            if (Mole5.GetComponent<Mole>().visibleHighMole == true && Mole5.GetComponent<Mole>().visibleMidMole == false && Mole5.GetComponent<Mole>().visibleMole == false)
            {

                Mole5.GetComponent<Mole>().particlesHighEnableHit();
                stressReceiver.InduceStress(stress);
                Mole5.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 3;
            }
        }

        //RIGHT SIDE

        if (Event.current.Equals(Event.KeyboardEvent("U")))
        {
            if (Mole3.GetComponent<Mole>().visibleMole == true && Mole3.GetComponent<Mole>().visibleMidMole == false && Mole3.GetComponent<Mole>().visibleHighMole == false)
            {
                Mole3.GetComponent<Mole>().particlesEnableHit();
                stressReceiver.InduceStress(stress);
                Mole3.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score++;

            }

            if (Mole3.GetComponent<Mole>().visibleMidMole == true && Mole3.GetComponent<Mole>().visibleMole == false && Mole3.GetComponent<Mole>().visibleHighMole == false)
            {

                Mole3.GetComponent<Mole>().particlesMidEnableHit();
                stressReceiver.InduceStress(stress);
                Mole3.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 2;
            }

            if (Mole3.GetComponent<Mole>().visibleHighMole == true && Mole3.GetComponent<Mole>().visibleMidMole == false && Mole3.GetComponent<Mole>().visibleMole == false)
            {

                Mole3.GetComponent<Mole>().particlesHighEnableHit();
                stressReceiver.InduceStress(stress);
                Mole3.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 3;
            }
        }

        if (Event.current.Equals(Event.KeyboardEvent("I")))
        {
            if (Mole.GetComponent<Mole>().visibleMole == true && Mole.GetComponent<Mole>().visibleMidMole == false && Mole.GetComponent<Mole>().visibleHighMole == false)
            {
                Mole.GetComponent<Mole>().particlesEnableHit();
                stressReceiver.InduceStress(stress);
                Mole.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score++;

            }

            if (Mole.GetComponent<Mole>().visibleMidMole == true && Mole.GetComponent<Mole>().visibleMole == false && Mole.GetComponent<Mole>().visibleHighMole == false)
            {

                Mole.GetComponent<Mole>().particlesMidEnableHit();
                stressReceiver.InduceStress(stress);
                Mole.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 2;
            }

            if (Mole.GetComponent<Mole>().visibleHighMole == true && Mole.GetComponent<Mole>().visibleMidMole == false && Mole.GetComponent<Mole>().visibleMole == false)
            {

                Mole.GetComponent<Mole>().particlesHighEnableHit();
                stressReceiver.InduceStress(stress);
                Mole.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 3;
            }
        }

        if (Event.current.Equals(Event.KeyboardEvent("O")))
        {
            if (Mole1.GetComponent<Mole>().visibleMole == true && Mole1.GetComponent<Mole>().visibleMidMole == false && Mole1.GetComponent<Mole>().visibleHighMole == false)
            {
                Mole1.GetComponent<Mole>().particlesEnableHit();
                stressReceiver.InduceStress(stress);
                Mole1.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score++;

            }

            if (Mole1.GetComponent<Mole>().visibleMidMole == true && Mole1.GetComponent<Mole>().visibleMole == false && Mole1.GetComponent<Mole>().visibleHighMole == false)
            {

                Mole1.GetComponent<Mole>().particlesMidEnableHit();
                stressReceiver.InduceStress(stress);
                Mole1.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 2;
            }

            if (Mole1.GetComponent<Mole>().visibleHighMole == true && Mole1.GetComponent<Mole>().visibleMidMole == false && Mole1.GetComponent<Mole>().visibleMole == false)
            {

                Mole1.GetComponent<Mole>().particlesHighEnableHit();
                stressReceiver.InduceStress(stress);
                Mole1.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 3;
            }
        }

        if (Event.current.Equals(Event.KeyboardEvent("P")))
        {
            if (Mole2.GetComponent<Mole>().visibleMole == true && Mole2.GetComponent<Mole>().visibleMidMole == false && Mole2.GetComponent<Mole>().visibleHighMole == false)
            {
                Mole2.GetComponent<Mole>().particlesEnableHit();
                stressReceiver.InduceStress(stress);
                Mole2.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score++;

            }

            if (Mole2.GetComponent<Mole>().visibleMidMole == true && Mole2.GetComponent<Mole>().visibleMole == false && Mole2.GetComponent<Mole>().visibleHighMole == false)
            {

                Mole2.GetComponent<Mole>().particlesMidEnableHit();
                stressReceiver.InduceStress(stress);
                Mole2.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 2;
            }

            if (Mole2.GetComponent<Mole>().visibleHighMole == true && Mole2.GetComponent<Mole>().visibleMidMole == false && Mole2.GetComponent<Mole>().visibleMole == false)
            {

                Mole2.GetComponent<Mole>().particlesHighEnableHit();
                stressReceiver.InduceStress(stress);
                Mole2.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 3;
            }
        }

        if (Event.current.Equals(Event.KeyboardEvent("N")))
        {
            if (Mole4.GetComponent<Mole>().visibleMole == true && Mole4.GetComponent<Mole>().visibleMidMole == false && Mole4.GetComponent<Mole>().visibleHighMole == false)
            {
                Mole4.GetComponent<Mole>().particlesEnableHit();
                stressReceiver.InduceStress(stress);
                Mole4.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score++;

            }

            if (Mole4.GetComponent<Mole>().visibleMidMole == true && Mole4.GetComponent<Mole>().visibleMole == false && Mole4.GetComponent<Mole>().visibleHighMole == false)
            {

                Mole4.GetComponent<Mole>().particlesMidEnableHit();
                stressReceiver.InduceStress(stress);
                Mole4.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 2;
            }

            if (Mole4.GetComponent<Mole>().visibleHighMole == true && Mole4.GetComponent<Mole>().visibleMidMole == false && Mole4.GetComponent<Mole>().visibleMole == false)
            {

                Mole4.GetComponent<Mole>().particlesHighEnableHit();
                stressReceiver.InduceStress(stress);
                Mole4.GetComponent<Mole>().Hide();
                audioSource.PlayOneShot(hit);
                score = score + 3;
            }
        }
    }
}
