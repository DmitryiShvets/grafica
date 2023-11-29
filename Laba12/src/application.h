#pragma once
#include <string>

#include <glad/gl.h>
#define GLFW_INCLUDE_NONE
#include <GLFW/glfw3.h>
#include "resource_manager.h"
#include "tetra.h"

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

	void select_task(int value);
	Tetra* tetra = nullptr;
private:
	Application(std::string name, int width, int height);
	int m_current_task = 1;
	std::string name;
	int width;
	int height;
	GLFWwindow* window = nullptr;
	ResourceManager* resourceManager = nullptr;
};