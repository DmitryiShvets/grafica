#pragma once
#include <string>
#include <map>
#include "shader_program.h"
#include "buffer_objects.h"

class ResourceManager {
public:
    static ResourceManager& getInstance();

    ~ResourceManager();

    void init();

    void destroy();

    ShaderProgram& getProgram(const std::string& progName);

    VAO baseVAO;
    VAO quadVAO;
    VAO veerVAO;
    VAO figureVAO;

    std::map<std::string, glm::vec3> colors;

private:
    ResourceManager();

    ResourceManager(const ResourceManager&) = delete;

    ResourceManager& operator=(const ResourceManager&) = delete;

    ResourceManager& operator=(ResourceManager&& program) = delete;

    ResourceManager(ResourceManager&& program) = delete;

    std::map<std::string, ShaderProgram> shaderPrograms;
};