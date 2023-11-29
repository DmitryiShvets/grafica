#include "cub_mixed_textures.h"
#include "resource_manager.h"
#include "renderer.h"
#include <glm/gtc/matrix_transform.hpp>

CubMixedTextures::CubMixedTextures() :Cube()
{
}
void CubMixedTextures::render()
{
	ResourceManager* resources = &ResourceManager::getInstance();
	ShaderProgram* program = &resources->getProgram("texture");
	Texture2D* texture1 = &resources->getTexture("default");
	Texture2D* texture2 = &resources->getTexture("container");


	// Create transformations
	glm::mat4 view(1.0f);
	glm::mat4 projection(1.0f);
	glm::mat4 model(1.0f);
	glm::vec3 cube_pos(0.0f, 0.0f, 0.0f);
	model = glm::translate(model, cube_pos);
	GLfloat angle = 45;
	model = glm::rotate(model, glm::radians(angle), glm::vec3(1.0f, 1.0f, 1.0f));
	view = glm::translate(view, glm::vec3(0.0f, 0.0f, -3.0f));
	projection = glm::perspective(45.0f, (GLfloat)800 / (GLfloat)600, 0.1f, 100.0f);

	program->use();
	program->setUniform("view", view);
	program->setUniform("projection", projection);
	program->setUniform("model", model);

	glActiveTexture(GL_TEXTURE0);
	texture1->bind();
	glActiveTexture(GL_TEXTURE1);
	texture2->bind();
	//Renderer::draw(&m_vao, &m_ebo);
	Renderer::draw(&m_vao);
	texture2->unbind();
	texture1->unbind();
	program->unbind();
}
