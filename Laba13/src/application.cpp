#include "application.h"
#include "logger.hpp"
#include "callback_manager.h"
#include "renderer.h"
#include "cub_mixed_textures.h"
#include "tetra.h"
#include "circle.h"
#include <glm/gtc/matrix_transform.hpp>

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
	glEnable(GL_DEPTH_TEST);

	primitives["tetra"] = new Tetra();
	primitives["cube"] = new CubMixedTextures();
	primitives["circle"] = new Circle();

	glfwSetCursorPos(window, 450, 450);

}

void RenderObj(glm::vec3 position, Mesh* obj, ShaderProgram* program,
	Texture2D* texture, float scale, glm::mat4 view, glm::vec3 rotation, float angle);


void Application::start()
{
	Renderer::setClearColor(175.0f / 255.0f, 218.0f / 255.0f, 252.0f / 255.0f, 1.0f);

	ResourceManager* resources = &ResourceManager::getInstance();
	ShaderProgram* program = &resources->getProgram("model");
	Texture2D* texture_skull = &resources->getTexture("skull");
	Texture2D* texture_barrel = &resources->getTexture("barrel");
	Mesh* skull_obj = &resources->getMesh("skull");
	Mesh* barrel_obj = &resources->getMesh("barrel");

	//Матрица проекции - не меняется между кадрами, поэтому устанавливается вне цикла
	glm::mat4 projection = glm::perspective(glm::radians(45.0f), 800.0f / 600.0f, 0.1f, 100.0f);

	program->use();
	program->setUniform("projection", projection);
	program->unbind();

	//glm::mat4 view = glm::lookAt(glm::vec3(0), glm::vec3(0.0f, 0.0f, 1.0f), glm::vec3(0.0f, 1.0f, 0.0f));
	// Game loop
	while (!glfwWindowShouldClose(window)) {
		glfwPollEvents();

		Renderer::clear();

		glm::mat4 view = camera.GetViewMatrix();

		for (int i = 0; i < 5; i++)
		{
			RenderObj(glm::vec3(i,0,0), skull_obj, program, texture_skull, 0.2f, view, glm::vec3(0.0f, 0.0f, 1.0f), 0);
		}
		RenderObj(glm::vec3(1, 0, 0), barrel_obj, program, texture_barrel, 1.0f, view, glm::vec3(0.0f, 0.0f, 1.0f), 0);

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
	for (auto& x : primitives)delete(x.second);
}

void Application::select_task(int value)
{
	if (value < 1 || value > 4)return;
	m_current_task = value;
}

Application::Application(std::string name, int width, int height) : name(std::move(name)), width(width), height(height) {}

void RenderObj(glm::vec3 position, Mesh* obj, ShaderProgram* program,
	Texture2D* texture, float scale, glm::mat4 view, glm::vec3 rotation, float angle)
{
	//Матрица модели - меняется между кадрами, поэтому устанавливается в цикле
	glm::mat4 model = glm::translate(glm::mat4(1.0f), position);
	model = glm::rotate(model, angle, rotation);
	model = glm::scale(model, glm::vec3(scale));

	program->use();
	program->setUniform("view", view);
	program->setUniform("model", model);

	glActiveTexture(GL_TEXTURE0);
	texture->bind();

	glBindVertexArray(obj->VAO);
	glDrawArrays(GL_TRIANGLES, 0, obj->vertices.size());
	glBindVertexArray(0);

	texture->unbind();
	program->unbind();
}
