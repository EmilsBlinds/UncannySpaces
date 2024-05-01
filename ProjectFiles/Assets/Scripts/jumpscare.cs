using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpscare : MonoBehaviour
{
	public string scenename;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("MainCamera"))
		{
			SceneManager.LoadScene(scenename);
		}
	}
}
