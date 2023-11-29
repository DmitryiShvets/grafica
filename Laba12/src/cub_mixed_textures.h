#pragma once
#include "cube.h"
#include "object.h"

class CubMixedTextures : private Cube, public Renderable {
public:
	CubMixedTextures();
	// Унаследовано через Renderable
	void render() override;
};