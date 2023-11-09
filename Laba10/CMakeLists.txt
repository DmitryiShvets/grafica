set(PROJ_NAME Laba10)
set(PROJ_SRC 
				src/Laba10.cpp 
				src/Laba10.hpp
)
add_executable (${PROJ_NAME} ${PROJ_SRC})

find_package(OpenGL REQUIRED)
target_link_libraries(${PROJ_NAME} PRIVATE ${OPENGL_LIBRARIES} glfw glad)
