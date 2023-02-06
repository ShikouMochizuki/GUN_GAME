using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
	public Transform bulletSpawnPoint;
	public GameObject bulletPrefab;
	public float bulletSpeed = 10;
	public GameObject Player;
	public AudioClip se;

	private AudioSource sound;
	//private Rigidbody rb;

	private void Start() {
		//rb = Player.GetComponent<Rigidbody>();
		sound = GetComponent<AudioSource>();
	}

	void Update()
	{
		if (GameState.State == GameState.PLAY) {
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E)) {
				var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
				bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;// + rb.velocity;
				sound.PlayOneShot(se);
			}
		}
	}
}
