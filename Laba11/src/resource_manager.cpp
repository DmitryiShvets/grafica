
#include "resource_manager.h"

#include <iostream>
#include <fstream>
#include <cmath>
#include <random>
#include <chrono>

struct Color {
    GLfloat r;
    GLfloat g;
    GLfloat b;
};

Color customColor = { 1.0f, 1.0f, 1.0f };

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

// Функция для генерации случайного цвета
void generateRandomColor(Color& c) {
    c.r = randomFloat(0.2f, 1.0f);
    c.g = randomFloat(0.2f, 1.0f);
    c.b = randomFloat(0.2f, 1.0f);
}

ResourceManager::ResourceManager() {
    std::cout << "Constructor ResourceManager (" << this << ") called " << std::endl;
}

ResourceManager::~ResourceManager() {
    std::cout << "Destructor ResourceManager (" << this << ") called " << std::endl;
}

void ResourceManager::init() {

    shaderPrograms.emplace("default", ShaderProgram(readFile("res/shaders/v_default.glsl"), readFile("res/shaders/f_default.glsl")));
    //shaderPrograms.emplace("gradient", ShaderProgram(readFile("res/shaders/v_gradient.glsl"), readFile("res/shaders/f_gradient.glsl")));
    //shaderPrograms.emplace("fixed", ShaderProgram(readFile("res/shaders/v_default.glsl"), readFile("res/shaders/f_default.glsl")));
    shaderPrograms.emplace("custom", ShaderProgram(readFile("res/shaders/v_default.glsl"), readFile("res/shaders/f_custom_color.glsl")));

    // Получение id атрибута из шейдерной программы
    ShaderProgram* mProgram = &ResourceManager::getInstance().getProgram("gradient");
    GLuint glProgram = mProgram->getUintProgram();
    GLint posAttribGradient = glGetAttribLocation(glProgram, "coord");
    if (posAttribGradient == -1) {
        exit;
    }

    // Новый id атрибута для цвета
    GLint colorAttribGradient = glGetAttribLocation(glProgram, "vertexColor");
    if (colorAttribGradient == -1) {
        exit;
    }

    mProgram = &ResourceManager::getInstance().getProgram("fixed");
    glProgram = mProgram->getUintProgram();
    // Получение id атрибута из шейдерной программы
    GLint posAttribFixedColor = glGetAttribLocation(glProgram, "coord");
    if (posAttribFixedColor == -1) {
        exit;
    }

    mProgram = &ResourceManager::getInstance().getProgram("custom");
    glProgram = mProgram->getUintProgram();
    // Получение id атрибута из шейдерной программы
    GLint posAttribCustomColor = glGetAttribLocation(glProgram, "coord");
    if (posAttribCustomColor == -1) {
        exit;
    }

    // Новый id атрибута для цвета
    GLint customColorUniformLocation = glGetUniformLocation(glProgram, "customColor");
    if (customColorUniformLocation == -1) {
        exit;
    }

    glUniform4f(customColorUniformLocation, customColor.r, customColor.g, customColor.b, 1.0f);

    const GLfloat vertex[] = {
        //x(s)  y(t)
        0.0f, 1.0f,
        1.0f, -1.0f,
        -1.0f, -1.0f
    };

    const GLfloat vertexQuad[] = {
        //x(s)  y(t)
        0.0f, 0.0f,
        0.0f, 1.0f,
        1.0f, 1.0f,

        1.0f, 1.0f,
        1.0f, 0.0f,
        0.0f, 0.0f,
    };

    const GLfloat vertexVeer[] = {
        // TODO
        0.0f
    };

    const GLfloat vertexFigure[] = {
        // TODO
        0.0f
    };

    baseVAO.bind();
    quadVAO.bind();
    veerVAO.bind();
    figureVAO.bind();

    VBO mVBO;
    VBO quadVBO;
    VBO veerVBO;
    VBO figureVBO;

    mVBO.init(vertex, 2 * 6 * sizeof(GLfloat));
    quadVBO.init(vertexQuad, 2 * 6 * sizeof(GLfloat));
    veerVBO.init(vertexVeer, 2 * 6 * sizeof(GLfloat));
    figureVBO.init(vertexFigure, 2 * 6 * sizeof(GLfloat));

    // Установка указателя на атрибут и активация атрибута для координат
    glVertexAttribPointer(posAttribGradient, 2, GL_FLOAT, GL_FALSE, 2 * sizeof(GLfloat), (void*)0);
    glEnableVertexAttribArray(posAttribGradient);

    // Установка указателя на атрибут и активация атрибута для цвета
    glVertexAttribPointer(colorAttribGradient, 3, GL_FLOAT, GL_FALSE, 2 * sizeof(GLfloat), (void*)(2 * sizeof(GLfloat)));
    glEnableVertexAttribArray(colorAttribGradient);

    // Fixed Color Shader
    glVertexAttribPointer(posAttribFixedColor, 2, GL_FLOAT, GL_FALSE, 2 * sizeof(GLfloat), (void*)0);
    glEnableVertexAttribArray(posAttribFixedColor);

    // Custom Color Shader
    glVertexAttribPointer(posAttribCustomColor, 2, GL_FLOAT, GL_FALSE, 2 * sizeof(GLfloat), (void*)0);
    glEnableVertexAttribArray(posAttribCustomColor);

    VBOLayout menuVBOLayout;
    menuVBOLayout.addLayoutElement(2, GL_FLOAT, GL_FALSE);

    baseVAO.addBuffer(mVBO, menuVBOLayout, 3);
    quadVAO.addBuffer(quadVBO, menuVBOLayout, 6);
    veerVAO.addBuffer(veerVBO, menuVBOLayout, 24);
    figureVAO.addBuffer(figureVBO, menuVBOLayout, 15);

    mVBO.unbind();
    baseVAO.unbind();

    quadVBO.unbind();
    quadVAO.unbind();

    veerVBO.unbind();
    veerVAO.unbind();

    figureVBO.unbind();
    figureVAO.unbind();
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
