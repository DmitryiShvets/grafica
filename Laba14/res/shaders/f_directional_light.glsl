#version 330 core

in vec3 FragPos;
in vec3 Normal;
in vec2 TexCoord;

out vec4 FragColor;

uniform sampler2D texture1;

uniform struct Material {
    vec3 diffuseColor;    // Диффузный цвет материала
    vec3 specularColor;   // Цвет бликов материала
    float shininess;      // Степень блеска материала
} material;

uniform struct Light {
    vec3 direction;       // Направление света
    vec3 color;           // Цвет света
    float intensity;      // Интенсивность света
} light;

uniform vec3 ViewPos;

void main() {
    //Расчет фоновой освещенности (амбиентного света)
    vec3 ambient = 0.1 * material.diffuseColor;

    //Расчет диффузной освещенности
    vec3 norm = normalize(Normal);
    vec3 lightDir = normalize(-light.direction);
    float diff = max(dot(norm, lightDir), 0.0);

    //Расчет бликов (блеска) на поверхности
    vec3 specular = vec3(0.0);

    //if (diff > 0.0) //Отключение бликов на теневой стороне
    {
        vec3 viewDir = normalize(ViewPos-FragPos);
        vec3 reflectDir = reflect(-lightDir, norm);
        float spec = pow(max(dot(viewDir, reflectDir), 0.0), material.shininess);
        specular = spec * light.color * material.specularColor;
    }

    //Итоговый расчет цвета фрагмента с учетом освещенности и бликов
    vec3 result = (ambient + light.intensity * (diff * material.diffuseColor + specular));

    //Добавление текстуры
    vec4 textureColor = texture(texture1, TexCoord);
    result *= textureColor.rgb;

    FragColor = vec4(result, 1.0);
}
