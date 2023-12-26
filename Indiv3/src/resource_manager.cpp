
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


ResourceManager::ResourceManager() {
	std::cout << "Constructor ResourceManager (" << this << ") called " << std::endl;
	m_colors["default"] = glm::vec3(0.0f, 1.0f, 0.0f);
}

ResourceManager::~ResourceManager() {
	std::cout << "Destructor ResourceManager (" << this << ") called " << std::endl;
}

void ResourceManager::init() {

	shaderPrograms.emplace("default", ShaderProgram(readFile("res/shaders/v_default.glsl"), readFile("res/shaders/f_default.glsl")));
	shaderPrograms.emplace("directionalLight", ShaderProgram(readFile("res/shaders/v_light.glsl"), readFile("res/shaders/f_directional_light.glsl")));

	try
	{
		m_textures.emplace("grass", Texture2D("res/textures/2.jpg"));
		m_textures.emplace("tree", Texture2D("res/textures/t11.png"));
		m_textures.emplace("copter", Texture2D("res/textures/AW101.png"));

		m_meshes.emplace("terrain", Mesh("res/meshes/grass.obj"));
		m_meshes.emplace("tree", Mesh("res/meshes/t1.obj"));
		m_meshes.emplace("copter", Mesh("res/meshes/AW101.obj"));
	}
	catch (const std::exception& e)
	{
		Logger::error_log(e.what());
	}


	VBOLayout menuVBOLayout;
	menuVBOLayout.addLayoutElement(2, GL_FLOAT, GL_FALSE);

	const GLfloat vertex[] = {
		//x(s)  y(t)
		-1.0f, 1.0f,0.0f, 0.0f, 1.0f,0.0f, 1.0f,
		1.0f, 1.0f,
		-1.0f, -1.0f,
		1.0f, 1.0f,
		-1.0f, -1.0f,
		1.0f, -1.0f,
	};
	VAO baseVAO;
	VBO baseVBO;

	baseVAO.bind();
	baseVBO.init(vertex, 2 * 6 * sizeof(GLfloat));
	baseVAO.addBuffer(baseVBO, menuVBOLayout, 6);
	baseVBO.unbind();
	baseVAO.unbind();

	m_vao.emplace("default", std::move(baseVAO));
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

Mesh& ResourceManager::getMesh(const std::string& meshName)
{
	auto it = m_meshes.find(meshName);
	if (it != m_meshes.end()) {
		return it->second;
	}
	return m_meshes.find("default")->second;
}

ResourceManager& ResourceManager::getInstance() {
	static ResourceManager instance;

	return instance;
}
