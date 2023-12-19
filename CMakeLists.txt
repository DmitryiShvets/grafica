cmake_minimum_required (VERSION 3.12)
set(PROJECT_NAME CG)
project(${PROJECT_NAME})

set(CMAKE_CXX_STANDARD 20)

set(GLFW_BUILD_DOCS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_TESTS OFF CACHE BOOL "" FORCE)
set(GLFW_BUILD_EXAMPLES OFF CACHE BOOL "" FORCE)
set(GLFW_INSTALL OFF CACHE BOOL "" FORCE)

add_subdirectory(glfw)
add_subdirectory(glad)
add_subdirectory(glm)
add_subdirectory(Laba10)
add_subdirectory(Laba11)
add_subdirectory(Laba12)
add_subdirectory(Laba13)
add_subdirectory(Laba14)
