#pragma once
#include <string>

#include <glad/gl.h>
#define GLFW_INCLUDE_NONE
#include <GLFW/glfw3.h>
#include "resource_manager.h"

class Application {
public:
    static Application& get_instance();

    void init();

    void start();

    void close();

    ~Application();

    Application() = delete;

    Application(const Application&) = delete;

    Application& operator=(const Application&) = delete;

private:
    Application(std::string name, int width, int height);

    std::string name;
    int width;
    int height;
    GLFWwindow* window = nullptr;
    ResourceManager* resourceManager = nullptr;
};