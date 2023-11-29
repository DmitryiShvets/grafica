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
		//std::cout << "click - UP" << std::endl;
		Application::get_instance().changeY(0.05f);
	}
	if (key == GLFW_KEY_RIGHT) {
		//std::cout << "click - RIGHT" << std::endl;
		Application::get_instance().changeX(0.05f);
	}
	if (key == GLFW_KEY_DOWN) {
		//std::cout << "click - DOWN" << std::endl;
		Application::get_instance().changeY(-0.05f);
	}
	if (key == GLFW_KEY_LEFT) {
		//std::cout << "click - LEFT" << std::endl;
		Application::get_instance().changeX(-0.05f);
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