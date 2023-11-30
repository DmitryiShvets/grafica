#include "callback_manager.h"
#include <iostream>
#include <application.h>
void CallbackManager::mouse_button_callback(GLFWwindow* window, int button, int action, int mods)
{
	if (button == GLFW_MOUSE_BUTTON_LEFT && action == GLFW_PRESS) {
		double xpos, ypos;
		//getting cursor position
		glfwGetCursorPos(window, &xpos, &ypos);
		int width, nowHeight;
		glfwGetWindowSize(window, &width, &nowHeight);

		std::cout << "click - x: " << xpos << " y: " << nowHeight - ypos << std::endl;
	}
}

void CallbackManager::key_callback(GLFWwindow* window, int key, int scancode, int action, int mode)
{
	if (key == GLFW_KEY_ESCAPE && action == GLFW_PRESS)
		glfwSetWindowShouldClose(window, GL_TRUE);
	if (key == GLFW_KEY_ENTER && action == GLFW_PRESS) {
	}
	if ((key == GLFW_KEY_1 || key == GLFW_KEY_2 || key == GLFW_KEY_3 || key == GLFW_KEY_4)&& action == GLFW_PRESS) {
		std::cout << "click - "<< key - 48 <<std::endl;
		Application::get_instance().select_task(key - 48);
	}
	if (key == GLFW_KEY_UP) {
		Application::get_instance().primitives["tetra"]->update(
			Event(EVENT_TYPE::TRANSFORM, std::make_tuple(0.f, 0.05f, 0.f)));
		std::cout << "click -  " << key << std::endl;
	}
	if (key == GLFW_KEY_RIGHT) {
		Application::get_instance().primitives["tetra"]->update(
			Event(EVENT_TYPE::TRANSFORM, std::make_tuple(0.05f, 0.f, 0.f)));
	}
	if (key == GLFW_KEY_DOWN) {
		Application::get_instance().primitives["tetra"]->update(
			Event(EVENT_TYPE::TRANSFORM, std::make_tuple(0.f, -0.05f, 0.f)));
	}
	if (key == GLFW_KEY_LEFT) {
		Application::get_instance().primitives["tetra"]->update(
			Event(EVENT_TYPE::TRANSFORM, std::make_tuple(-0.05f, 0.f, 0.f)));
	}
	if (key == GLFW_KEY_MINUS && action == GLFW_PRESS) {
		Application::get_instance().primitives["cube"]->update(
			Event(EVENT_TYPE::RATIO, std::make_tuple(-0.1f, 0.f, 0.f)));
	}
	if (key == GLFW_KEY_EQUAL && action == GLFW_PRESS) {
		Application::get_instance().primitives["cube"]->update(
			Event(EVENT_TYPE::RATIO, std::make_tuple(0.1f, 0.f, 0.f)));
	}
}

void CallbackManager::cursor_position_callback(GLFWwindow* window, double xpos, double ypos)
{
	int width, nowHeight;
	glfwGetWindowSize(window, &width, &nowHeight);

}
void CallbackManager::error_callback(int error, const char* description)
{
	std::cerr << "Error: " << description << std::endl;
}

void CallbackManager::framebuffer_size_callback(GLFWwindow* window, int width, int height)
{
	glViewport(0, 0, width, height);
}