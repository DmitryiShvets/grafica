
#include "resource_manager.h"

#include <iostream>
#include <fstream>
#include <cmath>
#include <random>
#include <chrono>
#include "logger.hpp"
static std::string readFile(const std::string& path) {
	std::ifstream input_file(path);
	if (!input_file.is_open()) {
		std::cerr << "Could not open the file - '"
			<< path << "'" << std::endl;
		exit(EXIT_FAILURE);
	}
	return std::string{ (std::istreambuf_iterator<char>(input_file)), std::istreambuf_iterator<char>() };
}

// Функция для генерации случайного числа в диапазоне [min, max)
float randomFloat(float min, float max) {
	static auto seed = std::chrono::high_resolution_clock::now().time_since_epoch().count();
	static std::mt19937 rng(static_cast<unsigned>(seed));
	std::uniform_real_distribution<float> distribution(min, max);
	return distribution(rng);
}

ResourceManager::ResourceManager() {
	std::cout << "Constructor ResourceManager (" << this << ") called " << std::endl;
	m_colors["randomColor"] = glm::vec3(randomFloat(0.0f, 1.0f), randomFloat(0.0f, 1.0f), randomFloat(0.0f, 1.0f));
	m_colors["default"] = glm::vec3(0.0f, 1.0f, 0.0f);
}

ResourceManager::~ResourceManager() {
	std::cout << "Destructor ResourceManager (" << this << ") called " << std::endl;
}

void ResourceManager::init() {

	shaderPrograms.emplace("default", ShaderProgram(readFile("res/shaders/v_default.glsl"), readFile("res/shaders/f_default.glsl")));
	shaderPrograms.emplace("custom", ShaderProgram(readFile("res/shaders/v_default.glsl"), readFile("res/shaders/f_custom_color.glsl")));
	shaderPrograms.emplace("gradient", ShaderProgram(readFile("res/shaders/v_veer.glsl"), readFile("res/shaders/f_veer.glsl")));
	shaderPrograms.emplace("texture", ShaderProgram(readFile("res/shaders/v_texture.glsl"), readFile("res/shaders/f_texture.glsl")));
	try
	{
		m_textures.emplace("default", Texture2D("res/textures/awesomeface.png"));
		m_textures.emplace("container", Texture2D("res/textures/container.jpg"));
	}
	catch (const std::exception& e)
	{
		Logger::error_log(e.what());
	}
	

	VBOLayout menuVBOLayout;
	menuVBOLayout.addLayoutElement(2, GL_FLOAT, GL_FALSE);

	const GLfloat vertex[] = {
		//x(s)  y(t)
		0.0f, 1.0f,
		1.0f, -1.0f,
		-1.0f, -1.0f
	};
	VAO baseVAO;
	VBO baseVBO;

	baseVAO.bind();
	baseVBO.init(vertex, 2 * 3 * sizeof(GLfloat));
	baseVAO.addBuffer(baseVBO, menuVBOLayout, 3);
	baseVBO.unbind();
	baseVAO.unbind();

	m_vao.emplace("default", std::move(baseVAO));

	const GLfloat vertexQuad[] = {
		//x(s)  y(t)
		-0.5f, -0.5f,
		-0.5f, 0.5f,
		0.5f, 0.5f,

		0.5f, 0.5f,
		0.5f, -0.5f,
		-0.5f, -0.5f,
	};
	VAO quadVAO;
	VBO quadVBO;

	quadVAO.bind();
	quadVBO.init(vertexQuad, 2 * 6 * sizeof(GLfloat));
	quadVAO.addBuffer(quadVBO, menuVBOLayout, 6);
	quadVBO.unbind();
	quadVAO.unbind();

	m_vao.emplace("quad", std::move(quadVAO));

	const GLfloat vertexVeer[] = {

	 0.5f,  0.5f, 0.0f,   1.0f, 0.0f, 0.0f,   1.0f, 1.0f,   // top right
	 0.5f, -0.5f, 0.0f,   0.0f, 1.0f, 0.0f,   1.0f, 0.0f,   // bottom right
	-0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   0.0f, 0.0f,   // bottom left
	-0.5f,  0.5f, 0.0f,   1.0f, 1.0f, 0.0f,   0.0f, 1.0f    // top left 
	};

	VBOLayout veer_layout;
	veer_layout.addLayoutElement(3, GL_FLOAT, GL_FALSE);
	veer_layout.addLayoutElement(3, GL_FLOAT, GL_FALSE);
	veer_layout.addLayoutElement(2, GL_FLOAT, GL_FALSE);

	VAO veerVAO;
	VBO veerVBO;

	veerVAO.bind();
	veerVBO.init(vertexVeer, 8 * 4 * sizeof(GLfloat));
	veerVAO.addBuffer(veerVBO, veer_layout, 4);
	veerVBO.unbind();
	veerVAO.unbind();

	m_vao.emplace("veer", std::move(veerVAO));

	EBO veerEBO;
	const GLuint indexVeer[] = {
		3,0,1,
		1,2,3,
	};
	veerEBO.init(indexVeer, 12);
	m_ebo.emplace("veer", std::move(veerEBO));

	const GLfloat vertexPentagon[] = {
		//x(s)  y(t)
		0.0f, 0.5f,
		-0.4f, 0.3f,
		0.4f, 0.3f,
		-0.25f, -0.1f,
		0.25f, -0.1f,
		0.0f, 0.0f,
	};

	VAO pentaVAO;
	VBO pentaVBO;

	pentaVAO.bind();
	pentaVBO.init(vertexPentagon, 2 * 6 * sizeof(GLfloat));
	pentaVAO.addBuffer(pentaVBO, menuVBOLayout, 6);
	pentaVBO.unbind();
	pentaVAO.unbind();

	m_vao.emplace("pentagon", std::move(pentaVAO));

	EBO pentaEBO;
	const GLuint indexPentagon[] = {
		0,1,5,
		0,2,5,
		2,4,5,
		3,4,5,
		1,3,5
	};
	pentaEBO.init(indexPentagon, 15);
	m_ebo.emplace("pentagon", std::move(pentaEBO));
}

void ResourceManager::destroy() {
	//std::cout << "Destructor ResourceManager (" << this << ") called " << std::endl;
	shaderPrograms.clear();
	m_colors.clear();
	m_vao.clear();
	m_ebo.clear();
	m_textures.clear();
}


ShaderProgram& ResourceManager::getProgram(const std::string& progName) {
	//return shaderPrograms[progName];
	auto it = shaderPrograms.find(progName);
	if (it != shaderPrograms.end()) {
		return it->second;
	}
	return shaderPrograms.find("default")->second;
}

VAO& ResourceManager::getVAO(const std::string& vaoName)
{
	auto it = m_vao.find(vaoName);
	if (it != m_vao.end()) {
		return it->second;
	}
	return m_vao.find("default")->second;
}

EBO& ResourceManager::getEBO(const std::string& vaoName)
{
	auto it = m_ebo.find(vaoName);
	if (it != m_ebo.end()) {
		return it->second;
	}
	return m_ebo.find("veer")->second;
}

glm::vec3& ResourceManager::getColor(const std::string& colorName)
{
	auto it = m_colors.find(colorName);
	if (it != m_colors.end()) {
		return it->second;
	}
	return m_colors.find("default")->second;
}

Texture2D& ResourceManager::getTexture(const std::string& textureName)
{
	auto it = m_textures.find(textureName);
	if (it != m_textures.end()) {
		return it->second;
	}
	return m_textures.find("default")->second;

}

ResourceManager& ResourceManager::getInstance() {
	static ResourceManager instance;

	return instance;
}
