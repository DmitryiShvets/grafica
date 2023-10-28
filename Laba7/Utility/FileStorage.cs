using blank.Primitives;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace blank.Utility
{
    internal class FileStorage
    {

        public void ExportModel(string file_name, Object3D obj)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(file_name))
                {
                    writer.WriteLine($"1;2");


                    writer.WriteLine($"{obj.transform.position.x} {obj.transform.position.y} {obj.transform.position.z};" +
                                     $"{obj.transform.rotation.x} {obj.transform.rotation.y} {obj.transform.rotation.z};" +
                                     $"{obj.transform.scale.x} {obj.transform.scale.y} {obj.transform.scale.z};" +
                                     $"{obj.transform.reflection.x} {obj.transform.reflection.y} {obj.transform.reflection.z}");


                    foreach (var face in obj.mech.faces)
                    {
                        writer.WriteLine($"{face[0].x} {face[0].y} {face[0].z};" +
                                         $"{face[1].x} {face[1].y} {face[1].z};" +
                                         $"{face[2].x} {face[2].y} {face[2].z};" +
                                         $"{face.color.R} {face.color.G} {face.color.B}");
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка записи в файл: {e.Message}");
            }
        }



        public Object3D ImportModel(string file_name)
        {
            Object3D new_obj = new Object3D();
            int cur_line = 0;
            int start_transform = 0;
            int start_faces = 0;
            try
            {
                foreach (string line in File.ReadLines(file_name))
                {
                    if (line == "") continue;
                    if (cur_line == 0)
                    {
                        string[] parts = line.Split(';');
                        start_faces = ParseInt(parts[1]);
                        start_transform = ParseInt(parts[0]);
                    }
                    else if (cur_line >= start_transform && cur_line < start_faces)
                    {
                        new_obj.transform = ParseTransform(line);
                    }
                    else
                    {
                        new_obj.mech.AddFace(ParseFace(line));
                    }
                    cur_line++;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine($"Ошибка чтения файла: {e.Message}");
            }
            return new_obj;
        }

        // Функция для парсинга грани
        private Transform ParseTransform(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length == 4)
            {
                Vector4[] transorm = new Vector4[4];
                for (int i = 0; i < 4; ++i)
                {
                    string[] vec3 = parts[0].Split(' ');
                    float x, y, z;
                    CultureInfo cultureInfo = new CultureInfo("en-US");
                    try
                    {
                        x = ParseFloat(vec3[0], cultureInfo);
                        y = ParseFloat(vec3[1], cultureInfo);
                        z = ParseFloat(vec3[2], cultureInfo);
                        transorm[i] = new Vector4(x, y, z);
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Ошибка парсинга координаты {e.Message} в строке: {line}");
                    }
                }
                return new Transform(transorm[0], transorm[1], transorm[2], transorm[3]);
            }
            else
            {
                throw new Exception($"Ошибка формата строки: {line} в файле");
            }
        }

        // Функция для парсинга грани
        private Triangle3D ParseFace(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length == 4)
            {
                Vector4[] faces = new Vector4[4];
                for (int i = 0; i < 4; ++i)
                {
                    string[] vec3 = parts[0].Split(' ');
                    float x, y, z;
                    CultureInfo cultureInfo = new CultureInfo("en-US");
                    try
                    {
                        x = ParseFloat(vec3[0], cultureInfo);
                        y = ParseFloat(vec3[1], cultureInfo);
                        z = ParseFloat(vec3[2], cultureInfo);
                        faces[i] = new Vector4(x, y, z);
                    }
                    catch (Exception e)
                    {
                        throw new Exception($"Ошибка парсинга координаты {e.Message} в строке: {line}");
                    }
                }
                var color = Color.FromArgb((int)faces[3].x, (int)faces[3].y, (int)faces[3].z);
                return new Triangle3D(faces[0], faces[1], faces[2], color);
            }
            else
            {
                throw new Exception($"Ошибка формата строки: {line} в файле");
            }
        }


        private int ParseInt(string line)
        {
            if (int.TryParse(line, out int result))
            {
                return result;
            }
            throw new Exception(line);
        }

        // Функция для парсинга float
        private float ParseFloat(string input, CultureInfo cultureInfo)
        {
            if (float.TryParse(input, NumberStyles.AllowDecimalPoint, cultureInfo, out float result))
            {
                return result;
            }
            throw new Exception(input);
        }
    }
}
