#pragma once
#include "buffer_objects.h"
#include "object.h"
#include <glm/vec3.hpp>

class Tetra: public Renderable {
public:
	Tetra();
	VAO m_vao;
	EBO m_ebo;

	// Унаследовано через Renderable
	virtual void render() override;
	glm::vec3 getVecMove();
	void changeX(float x);
	void changeY(float y);
private:
	float deltaX = 0.0f;
	float deltaY = 0.0f;
};



