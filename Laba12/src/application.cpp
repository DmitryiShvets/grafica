#include "application.h"
#include "logger.hpp"
#include "callback_manager.h"
#include "renderer.h"

Application& Application::get_instance()
{
	static Application instance("Window", 900, 900);
	return instance;
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

void DrawQuad();
void DrawVeer();
void DrawPentagon();

void Application::start()
{
	Renderer::setClearColor(0.0f, 0.0f, 0.0f, 1.0f);

	// Game loop
	while (!glfwWindowShouldClose(window)) {
		glfwPollEvents();

		Renderer::clear();

		switch (m_current_task)
		{
		case 1:
			DrawQuad();
			break;
		case 2:
			DrawVeer();
			break;
		case 3:
			DrawPentagon();
			break;
		default:
			DrawQuad();
			break;
		}

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

void Application::select_task(int value)
{
	if (value < 1 || value > 3)return;
	m_current_task = value;
}

Application::Application(std::string name, int width, int height) : name(std::move(name)), width(width), height(height) {}

void DrawQuad() {
	ResourceManager* resources = &ResourceManager::getInstance();
	ShaderProgram* mProgram = &resources->getProgram("custom");
	VAO* vao = &resources->getVAO("quad");
	glm::vec3 color = resources->getColor("randomColor");

	mProgram->use();
	mProgram->setUniform("customColor", glm::vec4(color, 1.0));
	Renderer::draw(vao);
	mProgram->unbind();
}

void DrawVeer() {
	ResourceManager* resources = &ResourceManager::getInstance();
	ShaderProgram* mProgram = &resources->getProgram("gradient");
	VAO* vao = &resources->getVAO("veer");
	EBO* ebo = &resources->getEBO("veer");
	mProgram->use();
	Renderer::draw(vao,ebo);
	mProgram->unbind();
}

void DrawPentagon() {
	ResourceManager* resources = &ResourceManager::getInstance();
	ShaderProgram* mProgram = &resources->getProgram("default");
	VAO* vao = &resources->getVAO("pentagon");
	EBO* ebo = &resources->getEBO("pentagon");
	mProgram->use();
	Renderer::draw(vao,ebo);
	mProgram->unbind();
}