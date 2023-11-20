
#include "resource_manager.h"

#include <iostream>
#include <fstream>
#include <cmath>
#include <random>
#include <chrono>

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
    colors["randomColor"] = glm::vec3(randomFloat(0.0f, 1.0f), randomFloat(0.0f, 1.0f), randomFloat(0.0f, 1.0f));
    std::cout << colors["randomColor"].x << " " << colors["randomColor"].y << " " << colors["randomColor"].z << std::endl;
}

ResourceManager::~ResourceManager() {
    std::cout << "Destructor ResourceManager (" << this << ") called " << std::endl;
}

void ResourceManager::init() {

    shaderPrograms.emplace("default", ShaderProgram(readFile("res/shaders/v_default.glsl"), readFile("res/shaders/f_default.glsl")));
    shaderPrograms.emplace("custom", ShaderProgram(readFile("res/shaders/v_default.glsl"), readFile("res/shaders/f_custom_color.glsl")));

    VBOLayout menuVBOLayout;
    menuVBOLayout.addLayoutElement(2, GL_FLOAT, GL_FALSE);

    const GLfloat vertex[] = {
        //x(s)  y(t)
        0.0f, 1.0f,
        1.0f, -1.0f,
        -1.0f, -1.0f
    };

    baseVAO.bind();
    VBO mVBO;
    mVBO.init(vertex, 2 * 3 * sizeof(GLfloat));
    baseVAO.addBuffer(mVBO, menuVBOLayout, 3);
    mVBO.unbind();
    baseVAO.unbind();

    const GLfloat vertexQuad[] = {
        //x(s)  y(t)
        -0.5f, -0.5f,
        -0.5f, 0.5f,
        0.5f, 0.5f,

        0.5f, 0.5f,
        0.5f, -0.5f,
        -0.5f, -0.5f,
    };

    quadVAO.bind();
    VBO quadVBO;
    quadVBO.init(vertexQuad, 2 * 6 * sizeof(GLfloat));
    quadVAO.addBuffer(quadVBO, menuVBOLayout, 6);
    quadVBO.unbind();
    quadVAO.unbind();
}

void ResourceManager::destroy() {
    //std::cout << "Destructor ResourceManager (" << this << ") called " << std::endl;
    shaderPrograms.clear();
    colors.clear();
}


ShaderProgram& ResourceManager::getProgram(const std::string& progName) {
    //return shaderPrograms[progName];
    auto it = shaderPrograms.find(progName);
    if (it != shaderPrograms.end()) {
        return it->second;
    }
    return shaderPrograms.find("default")->second;
}

ResourceManager& ResourceManager::getInstance() {
    static ResourceManager instance;

    return instance;
}
