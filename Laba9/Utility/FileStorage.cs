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
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Diagnostics;

namespace blank.Utility
{

    internal class FileStorage
    {
        public static void ExportModel(string file_name, Object3D obj)
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

        //Чтение .obj файла
        public static Object3D ImportModelObj(string filename)
        {
            Object3D newObj = new Object3D();

            var vertices = new List<Vector4>();
            var normals = new List<Vector4>();
            var texCoords = new List<Point2D>();
            var faces = new List<Face>();

            CultureInfo cultureInfo = new CultureInfo("en-US");

            foreach (var line in File.ReadLines(filename))
            {
                var parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Count() == 0)
                {
                    continue;
                }

                switch (parts[0])
                {
                    case "v": { vertices.Add(ParseVector3(parts, cultureInfo)); break; }
                    case "vn": { normals.Add(ParseVector3(parts, cultureInfo)); break; }
                    case "vt": { texCoords.Add(ParseVector2(parts, cultureInfo)); break; }
                    case "f": { faces.Add(ParseFace(parts.Skip(1), cultureInfo)); break; }
                }
            }
            Random random = new Random();
            int trCount = 0;
            foreach (var face in faces)
            {
                var trVert = new List<Vector4>();
                foreach (var vertexData in face.VertexData)
                {
                    int vertexIndex = vertexData[0] - 1;
                    int uvIndex = vertexData[1] - 1;

                    Vector4 vertex = vertices[vertexIndex];
                    // UV-развертка
                    vertex.u = 1-texCoords[uvIndex].x;
                    vertex.v = 1-texCoords[uvIndex].y;


                    trVert.Add(vertex);
                    //Debug.WriteLine($"u {trVert[trVert.Count-1].u} v {trVert[trVert.Count - 1].v}");
                }

                int red = random.Next(256);
                int green = random.Next(256);
                int blue = random.Next(256);

                var tr = new Triangle3D(new Vector4(trVert[0].x, trVert[0].y, trVert[0].z, trVert[0].u, trVert[0].v),
                                        new Vector4(trVert[1].x, trVert[1].y, trVert[1].z, trVert[1].u, trVert[1].v),
                                        new Vector4(trVert[2].x, trVert[2].y, trVert[2].z, trVert[2].u, trVert[2].v), Color.FromArgb(red, green, blue));
                tr.index = trCount++;
                //Debug.WriteLine(tr);
                newObj.mech.AddFace(tr);
                if (trVert.Count == 4)
                {
                    tr = new Triangle3D(new Vector4(trVert[0].x, trVert[0].y, trVert[0].z, trVert[0].u, trVert[0].v),
                                            new Vector4(trVert[2].x, trVert[2].y, trVert[2].z, trVert[2].u, trVert[2].v),
                                            new Vector4(trVert[3].x, trVert[3].y, trVert[3].z, trVert[3].u, trVert[3].v), Color.FromArgb(red, green, blue));
                    tr.index = trCount++;
                    //Debug.WriteLine(tr);
                    newObj.mech.AddFace(tr);
                }
            }
            //Debug.WriteLine("Модель считана");
            return newObj;
        }

        private static Point2D ParseVector2(string[] parts, CultureInfo info) =>
                new Point2D(float.Parse(parts[1], info), float.Parse(parts[2], info));

        private static Vector4 ParseVector3(string[] parts, CultureInfo info)
        {
            return new Vector4(float.Parse(parts[1], info), float.Parse(parts[2], info), float.Parse(parts[3], info));
        }

        private static Face ParseFace(IEnumerable<string> vertexData, CultureInfo info) =>
                new Face(vertexData.Select(v => v.Split('/').Select(int.Parse).ToArray()));

        public static Object3D ImportModel(string file_name)
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
        private static Transform ParseTransform(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length == 4)
            {
                Vector4[] transorm = new Vector4[4];
                for (int i = 0; i < 4; ++i)
                {
                    string[] vec3 = parts[i].Split(' ');
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
        private static Triangle3D ParseFace(string line)
        {
            string[] parts = line.Split(';');
            if (parts.Length == 4)
            {
                Vector4[] faces = new Vector4[4];
                for (int i = 0; i < 4; ++i)
                {
                    string[] vec3 = parts[i].Split(' ');
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


        private static int ParseInt(string line)
        {
            if (int.TryParse(line, out int result))
            {
                return result;
            }
            throw new Exception(line);
        }

        // Функция для парсинга float
        private static float ParseFloat(string input, CultureInfo cultureInfo)
        {
            if (float.TryParse(input, out float result))
            {
                return result;
            }
            throw new Exception(input);
        }
    }
}
