using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk {

	Tile[,] tiles = new Tile[5, 5];
	int width = 5;
	int height = 5;

	public Chunk() {
		for (int x = 0; x < this.width; x++) {
			for (int y = 0; y < this.height; y++) {
				if (x % 2 == 0) {
					tiles[x,y] = new Tile(TerrainType.Sand);
				} else {
					tiles[x,y] = new Tile(TerrainType.Dirt);
				}
			}
		}
	}
}

public enum TerrainType {
	Dirt,
	Sand
}

public class Tile {

//	public Tile(TerrainType type) {
//		typeID(type);
//	}

//	public int typeID(TerrainType type) {
//		switch(type) {
//		case TerrainType.Dirt:
//			return 1;
//		default:
//			return 0;
//		}
//	}

	public int typeID;

	public Tile(TerrainType type) {
		switch (type) {
		case TerrainType.Dirt:
			typeID = 1;
			break;
		default:
			typeID = 0;
			break;
		}
	}
}