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
}

void DrawQuad();
void RenderObj(Renderable* obj);
void DrawPentagon();
void DrawSkull();


void Application::start()
{
	Renderer::setClearColor(175.0f / 255.0f, 218.0f / 255.0f, 252.0f / 255.0f, 1.0f);
	ShaderProgram& p = resourceManager->getProgram("texture");
	p.use();
	p.setUniform("texture1", 0);
	p.setUniform("texture2", 1);
	p.unbind();


	// Game loop
	while (!glfwWindowShouldClose(window)) {
		glfwPollEvents();

		Renderer::clear();

		switch (m_current_task)
		{
		case 1:
			RenderObj(primitives["tetra"]);
			break;
		case 2:
			RenderObj(primitives["cube"]);
			break;
		case 3:
			DrawSkull();
			break;
		case 4:
			RenderObj(primitives["circle"]);
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
	for (auto x : primitives)delete(x.second);
}

void Application::select_task(int value)
{
	if (value < 1 || value > 4)return;
	m_current_task = value;
}

Application::Application(std::string name, int width, int height) : name(std::move(name)), width(width), height(height) {}

void DrawSkull()
{
	ResourceManager* resources = &ResourceManager::getInstance();
	ShaderProgram* program = &resources->getProgram("model");
	Texture2D* texture = &resources->getTexture("skull");


	// Create transformations
	// Установка матриц преобразования
	glm::mat4 model = glm::rotate(glm::mat4(1.0f), 0.0f, glm::vec3(0.0f, 0.0f, 1.0f));

	glm::mat4 view = glm::lookAt(glm::vec3(40, -40.0f, 15.0f),   // eye (позиция камеры)
		glm::vec3(0.0f, 0.0f, 10.0f),   // target (точка, на которую смотрит камера)
		glm::vec3(0.0f, 0.0f, 1.0f));  // up (вектор "вверх")

	glm::mat4 projection = glm::perspective(glm::radians(45.0f), 800.0f / 600.0f, 0.1f, 100.0f);

	program->use();
	program->setUniform("view", view);
	program->setUniform("projection", projection);
	program->setUniform("model", model);

	glActiveTexture(GL_TEXTURE0);
	texture->bind();

	glBindVertexArray(resources->getMesh("skull").VAO);
	glDrawArrays(GL_TRIANGLES, 0, resources->getMesh("skull").vertices.size());
	glBindVertexArray(0);

	texture->unbind();
	program->unbind();
}
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
	ShaderProgram* mProgram = &resources->getProgram("texture");
	Texture2D* mTexture1 = &resources->getTexture("default");
	Texture2D* mTexture2 = &resources->getTexture("container");
	VAO* vao = &resources->getVAO("veer");
	EBO* ebo = &resources->getEBO("veer");

	mProgram->use();
	glActiveTexture(GL_TEXTURE0);
	mTexture1->bind();
	glActiveTexture(GL_TEXTURE1);
	mTexture2->bind();
	Renderer::draw(vao, ebo);
	mTexture2->unbind();
	mTexture1->unbind();
	mProgram->unbind();
}

void RenderObj(Renderable* obj) {
	obj->render();
}

void DrawPentagon() {
	ResourceManager* resources = &ResourceManager::getInstance();
	ShaderProgram* mProgram = &resources->getProgram("default");
	VAO* vao = &resources->getVAO("pentagon");
	EBO* ebo = &resources->getEBO("pentagon");
	mProgram->use();
	Renderer::draw(vao, ebo);
	mProgram->unbind();
}