﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This component spawns the given object whenever the player clicks a given key.
 */
public class KeyboardSpawner: MonoBehaviour {
    [SerializeField] protected KeyCode keyToPress;
    [SerializeField] protected GameObject prefabToSpawn;
    [SerializeField] protected Vector3 velocityOfSpawnedObject;

    protected virtual GameObject spawnObject() {
        // Step 1: spawn the new object.
        Vector3 positionOfSpawnedObject = transform.position - new Vector3(0.3f,0,0); // get the position for first rocket
        Vector3 positionOfSpawnedObject2 = transform.position - new Vector3(-0.3f, 0, 0); // get the position for second rocket
        Quaternion rotationOfSpawnedObject = Quaternion.identity;  // no rotation.
     // Quaternion t = Quaternion.
        GameObject newObject = Instantiate(prefabToSpawn, positionOfSpawnedObject, rotationOfSpawnedObject); // create first rocket object
        newObject.transform.Rotate(new Vector3(0, 0, -90)); // rotate it -90 degrees so it will go up

        GameObject newObject2 = Instantiate(prefabToSpawn, positionOfSpawnedObject2, rotationOfSpawnedObject);
        newObject2.transform.Rotate(new Vector3(0, 0, -90));// rotate it -90 degrees so it will go up

        // Step 2: modify the velocity of the new object.
        Mover newObjectMover = newObject.GetComponent<Mover>();
        Mover newObjectMover2 = newObject2.GetComponent<Mover>();
        if (newObjectMover && newObjectMover2) {
            newObjectMover.SetVelocity(velocityOfSpawnedObject);
            newObjectMover2.SetVelocity(velocityOfSpawnedObject);
            //  newObjectMover2.SetVelocity(velocityOfSpawnedObject);
        }

        return newObject;
    }

    private void Update() {
        if (Input.GetKeyDown(keyToPress)) {
            spawnObject();
        }
    }
}
