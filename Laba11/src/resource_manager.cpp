
#include "resource_manager.h"

#include <iostream>
#include <fstream>


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
}

ResourceManager::~ResourceManager() {
    std::cout << "Destructor ResourceManager (" << this << ") called " << std::endl;
}

void ResourceManager::init() {

    shaderPrograms.emplace("default", ShaderProgram(readFile("res/shaders/v_default.glsl"), readFile("res/shaders/f_default.glsl")));
  

    const GLfloat vertex[] = {
        //x(s)  y(t)
        0.0f, 1.0f,
        1.0f, -1.0f,
        -1.0f, -1.0f
    };

    baseVAO.bind();

    VBO mVBO;
    mVBO.init(vertex, 2 * 6 * sizeof(GLfloat));

    VBOLayout menuVBOLayout;
    menuVBOLayout.addLayoutElement(2, GL_FLOAT, GL_FALSE);

    baseVAO.addBuffer(mVBO, menuVBOLayout, 3);

    mVBO.unbind();
    baseVAO.unbind();

}

void ResourceManager::destroy() {
    //std::cout << "Destructor ResourceManager (" << this << ") called " << std::endl;
    shaderPrograms.clear();
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
