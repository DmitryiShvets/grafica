#include "application.h"
#include "logger.hpp"
#include "callback_manager.h"
#include "renderer.h"

Application& Application::get_instance()
{
	static Application instance("Window", 900, 900);
	return instance;
}

static void key_callback(GLFWwindow* window, int key, int scancode, int action, int mods)
{
	if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
		glfwSetWindowShouldClose(window, GLFW_TRUE);
}

void Application::init()
{
	if (!glfwInit()) {
		Logger::error_log("Неудалось иницализировать GLFW!");
		exit(EXIT_FAILURE);
	}
	glfwWindowHint(GLFW_CONTEXT_VERSION_MAJOR, 4);
	glfwWindowHint(GLFW_CONTEXT_VERSION_MINOR, 6);
	glfwWindowHint(GLFW_OPENGL_PROFILE, GLFW_OPENGL_CORE_PROFILE);

	window = glfwCreateWindow(width, height, name.c_str(), NULL, NULL);
	if (!window)
	{
		Logger::error_log("Неудалось создать окно!");
		glfwTerminate();
		exit(EXIT_FAILURE);
	}
	//glfwSetWindowAttrib(window, GLFW_RESIZABLE, GLFW_FALSE);

	glfwMakeContextCurrent(window);
	int version = gladLoadGL(glfwGetProcAddress);
	if (version == 0) {
		Logger::error_log("Неудалось инициализровать OpenGL контекст!");
		exit(EXIT_FAILURE);
	}

	int w, h;
	glfwGetFramebufferSize(window, &w, &h);

	Renderer::setViewPort(0, 0, w, h);

	glfwSwapInterval(1);

	glfwSetErrorCallback(CallbackManager::error_callback);
	glfwSetWindowUserPointer(window, this);
	glfwSetKeyCallback(window, CallbackManager::key_callback);
	glfwSetMouseButtonCallback(window, CallbackManager::mouse_button_callback);
	glfwSetCursorPosCallback(window, CallbackManager::cursor_position_callback);
	glfwSetFramebufferSizeCallback(window, CallbackManager::framebuffer_size_callback);

	resourceManager = &ResourceManager::getInstance();
	resourceManager->init();
}

void Application::start()
{
	Renderer::setClearColor(0.0f, 0.0f, 0.0f, 1.0f);
	VAO* mVAO = &ResourceManager::getInstance().quadVAO;
	//ShaderProgram* mProgram = &ResourceManager::getInstance().getProgram("default");
	ShaderProgram* mProgram = &ResourceManager::getInstance().getProgram("custom");

	// Game loop
	while (!glfwWindowShouldClose(window)) {
		glfwPollEvents();

		Renderer::clear();

		mProgram->use();
		mProgram->setUniform("customColor", glm::vec4(ResourceManager::getInstance().colors["randomColor"], 1.0));
		Renderer::draw(mVAO);
		mProgram->unbind();

		// Swap the screen buffers
		glfwSwapBuffers(window);
	}
	resourceManager->destroy();
	glfwTerminate();
}

void Application::close()
{
	glfwSetWindowShouldClose(window, GL_TRUE);
}

Application::~Application()
{

}

Application::Application(std::string name, int width, int height) : name(std::move(name)), width(width), height(height) {}

