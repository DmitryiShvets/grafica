#include "tetra.h"
#include "resource_manager.h"
#include "renderer.h"

Tetra::Tetra()
{
	VBOLayout gradient_layout;
	gradient_layout.addLayoutElement(2, GL_FLOAT, GL_FALSE);
	gradient_layout.addLayoutElement(3, GL_FLOAT, GL_FALSE);

	const GLfloat vertexTetra[] = {
		//x(s)  y(t)  r    g     b
		0.0f, 0.5f, 1.0f, 0.0f, 0.0f,
		0.1f, -0.5f, 0.0f, 1.0f, 0.0f,
		-0.5f, -0.1f, 0.0f, 0.0f, 1.0f,

		0.0f, 0.5f, 0.8f, 0.0f, 0.0f,
		0.1f, -0.5f, 0.0f, 0.8f, 0.0f,
		0.3f, 0.1f, 0.0f, 0.0f, 0.8f,
	};
	VAO tetraVAO;
	VBO tetraVBO;

	tetraVAO.bind();
	tetraVBO.init(vertexTetra, 5 * 6 * sizeof(GLfloat));
	tetraVAO.addBuffer(tetraVBO, gradient_layout, 6);
	tetraVBO.unbind();
	tetraVAO.unbind();

	m_vao = std::move(tetraVAO);
}

void Tetra::render()
{
	ResourceManager* resources = &ResourceManager::getInstance();
	ShaderProgram* mProgram = &resources->getProgram("move");

	mProgram->use();
	mProgram->setUniform("delta", getVecMove());
	Renderer::draw(&m_vao);
	mProgram->unbind();
}

glm::vec3 Tetra::getVecMove()
{
	return glm::vec3(deltaX, deltaY, 0.0f);
}

void Tetra::changeX(float x)
{
	deltaX += x;
}

void Tetra::changeY(float y)
{
	deltaY += y;
}
