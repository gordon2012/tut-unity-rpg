using UnityEngine;

public class CharacterStats : MonoBehaviour {

  public int maxHealth = 100;
  public int currentHealth { get; private set; }

	public Stat damage;
  public Stat armor;

  void Awake() {
    currentHealth = maxHealth;
  }

  void Update() {
    if(Input.GetKeyDown(KeyCode.T)) {
      TakeDamage(10);
    }
  }

  public void TakeDamage(int damage) {
    damage = Mathf.Clamp(damage - armor.GetValue(), 0, int.MaxValue);
    currentHealth-= damage;

    Debug.Log(transform.name + " takes " + damage + " damage.");

    if(currentHealth <= 0) {
      Die();
    }
  }

  public virtual void Die() {
    // Die in some way, this method is meant to be overriten
    Debug.Log(transform.name + " has been slain.");
  }

}
