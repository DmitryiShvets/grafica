#include "application.h"
#include "logger.hpp"
#include "callback_manager.h"
#include "renderer.h"
#include "cub_mixed_textures.h"
#include "tetra.h"
#include "circle.h"
#include <glm/gtc/matrix_transform.hpp>
#include <chrono>

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
	glfwSetInputMode(window, GLFW_CURSOR, GLFW_CURSOR_DISABLED);

	resourceManager = &ResourceManager::getInstance();
	resourceManager->init();
	glEnable(GL_DEPTH_TEST);

	primitives["tetra"] = new Tetra();
	primitives["cube"] = new CubMixedTextures();
	primitives["circle"] = new Circle();

	glfwSetCursorPos(window, 450, 450);

}

void RenderObj(glm::vec3 position, Mesh* obj, ShaderProgram* program,
	Texture2D* texture, float scale, glm::mat4 view, glm::vec3 rotation, float angle,
	int shading, glm::vec3 viewPos, int light_type);

//TODO вынести в отдельный файл
struct Material {
	glm::vec3 diffuseColor;
	glm::vec3 specularColor;
	glm::vec3 emissionColor;
	glm::vec3 ambientColor;
	float shininess;
};

void Application::start()
{
	Renderer::setClearColor(65.0f / 255.0f, 74.0f / 255.0f, 76.0f / 255.0f, 1.0f);

	ResourceManager* resources = &ResourceManager::getInstance();
	ShaderProgram* program = &resources->getProgram("model");
	Texture2D* texture_skull = &resources->getTexture("skull");
	Texture2D* texture_barrel = &resources->getTexture("barrel");
	Texture2D* texture_t_rex = &resources->getTexture("t-rex");
	Texture2D* texture_elas = &resources->getTexture("elas");
	Texture2D* texture_cear = &resources->getTexture("cear");
	Texture2D* texture_tric = &resources->getTexture("tric");
	Texture2D* texture_diplo = &resources->getTexture("diplo");
	Texture2D* texture_tree = &resources->getTexture("tree");
	Texture2D* texture_patrik = &resources->getTexture("patrik");
	Mesh* skull_obj = &resources->getMesh("skull");
	Mesh* barrel_obj = &resources->getMesh("barrel");
	Mesh* t_rex_obj = &resources->getMesh("t-rex");
	Mesh* elas_obj = &resources->getMesh("elas");
	Mesh* cear_obj = &resources->getMesh("cear");
	Mesh* tric_obj = &resources->getMesh("tric");
	Mesh* diplo_obj = &resources->getMesh("diplo");
	Mesh* tree_obj = &resources->getMesh("tree");
	Mesh* patrik_obj = &resources->getMesh("patrik");

	//Матрица проекции - не меняется между кадрами, поэтому устанавливается вне цикла
	glm::mat4 projection = glm::perspective(glm::radians(45.0f), 800.0f / 600.0f, 0.1f, 100.0f);

	program->use();
	program->setUniform("projection", projection);
	program->unbind();

	//Направленный источник света (Фонг)
	ShaderProgram* directionalLight = &resources->getProgram("directionalLight");
	directionalLight->use();
	directionalLight->setUniform("projection", projection);

	glm::vec3 lightPosition(1, 2, 8);
	glm::vec3 lightDirection(0.0f, 0, -1.0f);
	glm::vec3 lightColor(1.0f, 1.0f, 1.0f);
	float lightIntensity = 1.0f;

	directionalLight->setUniform("light.position", lightPosition);
	directionalLight->setUniform("light.direction", lightDirection);
	directionalLight->setUniform("light.color", lightColor);
	directionalLight->setUniform("light.intensity", lightIntensity);
	directionalLight->setUniform("light.constant", 1.0f);
	directionalLight->setUniform("light.linear", 0.09f);
	directionalLight->setUniform("light.quadratic", 0.032f);
	directionalLight->setUniform("light.cutOff", glm::cos(glm::radians(12.5f)));

	Material material = { glm::vec3(1.0f, 1.0f, 1.0f), // diffuseColor
						 glm::vec3(1.0f, 1.0f, 1.0f),  // specularColor
						 glm::vec3(0.0f, 0.0f, 0.0f),  // emissionColor
						 glm::vec3(0.1f, 0.1f, 0.1f),  // ambientColor
						 32.0f };                      // shininess

	directionalLight->setUniform("material.diffuseColor", material.diffuseColor);
	directionalLight->setUniform("material.specularColor", material.specularColor);
	directionalLight->setUniform("material.emissionColor", material.emissionColor);
	directionalLight->setUniform("material.ambientColor", material.ambientColor);
	directionalLight->setUniform("material.shininess", material.shininess);

	directionalLight->unbind();

	// Game loop
	auto start = std::chrono::steady_clock::now();
	float r = 0; //Вращение черепа
	while (!glfwWindowShouldClose(window)) {
		glfwPollEvents();

		Renderer::clear();
		glm::mat4 view = camera.GetViewMatrix();

		glm::vec3 viewPos = camera.GetPosition();
		//RenderObj(glm::vec3(1, 0, 0), barrel_obj, directionalLight, texture_barrel,
		//	1.0f, view, glm::vec3(0.0f, 0.0f, 1.0f), 0, 0, viewPos, m_current_task - 1);

		// T-Rex
		RenderObj(glm::vec3(-20, -8, 0), t_rex_obj, directionalLight, texture_t_rex,
			1.0f, view, glm::vec3(0.0f, 0.0f, 1.0f), 0, 0, viewPos, m_current_task - 1);
		// Elasmosaurus
		RenderObj(glm::vec3(-50, -8, -50), elas_obj, directionalLight, texture_elas,
			0.1f, view, glm::vec3(1.0f, 0.0f, 0.0f), 30, 1, viewPos, m_current_task - 1);
		//Cearadactylus
		RenderObj(glm::vec3(20, 20, 0), cear_obj, directionalLight, texture_cear,
			0.1f, view, glm::vec3(0.0f, 1.0f, 1.0f), 30, 2, viewPos, m_current_task - 1);
		//Triceratops
		RenderObj(glm::vec3(0, -4, 0), tric_obj, directionalLight, texture_tric,
			1.6f, view, glm::vec3(1.0f, 0.0f, 0.0f), 0, 0, viewPos, m_current_task - 1);
		// Diplodocus
		//RenderObj(glm::vec3(10, 0, 5), diplo_obj, directionalLight, texture_diplo,
		//	3.0f, view, glm::vec3(1.0f, 0.0f, 0.0f), 0, 0, viewPos, m_current_task - 1);
		// Tree
		//RenderObj(glm::vec3(10, 0, 5), tree_obj, directionalLight, texture_tree,
		//	0.03f, view, glm::vec3(1.0f, 0.0f, 0.0f), 0, 0, viewPos, m_current_task - 1);
		//patrik
		RenderObj(glm::vec3(5, 0, -10), patrik_obj, directionalLight, texture_patrik,
			50.0f, view, glm::vec3(1.0f, 0.0f, 0.0f), 0, 1, viewPos, m_current_task - 1);

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
	Texture2D* texture, float scale, glm::mat4 view, glm::vec3 rotation,
	float angle, int shading, glm::vec3 viewPos, int light_type)
{
	//Матрица модели - меняется между кадрами, поэтому устанавливается в цикле
	glm::mat4 model = glm::translate(glm::mat4(1.0f), position);
	model = glm::rotate(model, angle, rotation);
	model = glm::scale(model, glm::vec3(scale));

	program->use();
	program->setUniform("view", view);
	program->setUniform("model", model);
	program->setUniform("ViewPos", viewPos);
	program->setUniform("lightingMethod", shading);
	program->setUniform("lighting_type", light_type);
	glActiveTexture(GL_TEXTURE0);
	texture->bind();

	glBindVertexArray(obj->VAO);
	glDrawArrays(GL_TRIANGLES, 0, obj->vertices.size());
	glBindVertexArray(0);

	texture->unbind();
	program->unbind();
}
