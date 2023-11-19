#version 330 core

in vec2 coord;
in vec3 vertexColor;
out vec3 fragColor;
void main() 
{
    gl_Position = vec4(coord, 0.0, 1.0);
    fragColor = vertexColor;
}