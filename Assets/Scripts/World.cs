using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World {

	Chunk[,] chunks = new Chunk[10,10];
	public int width = 10;
	public int height = 10;

	public int Width {
		get {
			return width;
		}
	}

	public int Height {
		get {
			return height;
		}
	}

	public World() {
		for (int x = 0; x < this.width; x++) {
			for (int y = 0; y < this.height; y++) {
				chunks[x,y] = new Chunk();
			}
		}
	}

	public World(int width, int height) {
		for (int x = 0; x < width; x++) {
			for (int y = 0; y < height; y++) {
				chunks[x,y] = new Chunk();
			}
		}
	}
}
